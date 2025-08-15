using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using NITGEN.SDK.NBioBSP;
using Newtonsoft.Json;
using RestSharp;

namespace ProjetoFinal
{
    public partial class CadCus : Form
    {
        private NBioAPI m_NBioAPI;
        private string uniqueId;
        private string apiKey = "$aact_MzkwODA2MWY2OGM3MWRlMDU2NWM3MzJlNzZmNGZhZGY6Ojg2OGExNDI4LTllZGYtNDZiZS05Mzc0LWYyYTFhOTNhNTgxMTo6JGFhY2hfYjk3YzA3ZDUtZWFkNi00NmQxLWIwOGEtOTZiNWNjODYwMTUy"; // Insira sua chave de API do Sandbox aqui
        private string baseUrl = "https://api-sandbox.asaas.com/v3/"; // URL correta para o ambiente de produção

        public CadCus(string uniqueId)
        {
            InitializeComponent();
            this.uniqueId = uniqueId;
            InitializeNBioBSP();
            // Adicionar essas linhas para tela cheia
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void InitializeNBioBSP()
        {
            m_NBioAPI = new NBioAPI();
            EnumerateDevices();
        }

        private void EnumerateDevices()
        {
            int i;
            uint nNumDevice;
            short[] nDeviceID;
            NBioAPI.Type.DEVICE_INFO_EX[] deviceInfoEx;
            uint ret = m_NBioAPI.EnumerateDevice(out nNumDevice, out nDeviceID, out deviceInfoEx);
            if (ret == NBioAPI.Error.NONE)
            {
                comboBoxDispositivo.Items.Add("Auto_Detect");
                for (i = 0; i < nNumDevice; i++)
                {
                    comboBoxDispositivo.Items.Add(deviceInfoEx[i].Name);
                }
            }
            else
            {
                MessageBox.Show("Erro ao enumerar dispositivos: " + ret.ToString());
            }
        }

        private void btnEscolherDispositivo_Click(object sender, EventArgs e)
        {
            uint ret;
            if (comboBoxDispositivo.SelectedItem != null && comboBoxDispositivo.SelectedItem.ToString() != "Auto_Detect")
            {
                short deviceID = (short)(comboBoxDispositivo.SelectedIndex - 1); // Ajustar índice para Auto_Detect
                ret = m_NBioAPI.OpenDevice(deviceID);
                if (ret == NBioAPI.Error.NONE)
                {
                    MessageBox.Show("Dispositivo aberto com sucesso!");
                }
                else
                {
                    MessageBox.Show("Falha ao abrir o dispositivo: " + ret.ToString());
                }
            }
            else
            {
                ret = m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO);
                if (ret == NBioAPI.Error.NONE)
                {
                    MessageBox.Show("Dispositivo aberto com sucesso!");
                }
                else
                {
                    MessageBox.Show("Falha ao abrir o dispositivo: " + ret.ToString());
                }
            }
        }

        private async void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Capturar digital para verificação
                NBioAPI.Type.HFIR hCapturedFIR;
                uint ret = m_NBioAPI.Capture(NBioAPI.Type.FIR_PURPOSE.VERIFY, out hCapturedFIR, NBioAPI.Type.TIMEOUT.DEFAULT, null, null);
                if (ret != NBioAPI.Error.NONE)
                {
                    MessageBox.Show("Falha ao capturar digital. Tente novamente.");
                    return;
                }

                // Verificar usuário no banco de dados pela digital capturada
                string uniqueId = VerificarUsuario(hCapturedFIR);
                if (!string.IsNullOrEmpty(uniqueId))
                {
                    string nome = textBoxNome.Text;
                    string sobrenome = textBoxSobrenome.Text;
                    string email = textBoxEmail.Text;
                    string cpfCnpj = textBoxCpfCnpj.Text;

                    try
                    {
                        string customerId = await CriarClienteAsync(nome, email, cpfCnpj);
                        SalvarClienteNoBancoDeDados(uniqueId, customerId, nome, sobrenome, email, cpfCnpj);
                        MessageBox.Show("Cliente cadastrado com sucesso! ID do Cliente: " + customerId);
                        // Fecha o formulário após salvar o cliente
                        this.Close();
                        // Abre o próximo formulário (CadCartao)
                        CadCartao cadCartaoForm = new CadCartao(customerId);
                        cadCartaoForm.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao cadastrar o cliente: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado. Tente novamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }
        }
        private string VerificarUsuario(NBioAPI.Type.HFIR hCapturedFIR)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection("User Id=system;Password=093003;Data Source=DESKTOP-KHKU2NH:1521/FREE;Pooling=true;Min Pool Size=1;Max Pool Size=10;Connection Lifetime=120;"))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("SELECT UNIQUE_ID, TEXTDATA FROM CLIENTES", conn))
                    {
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string uniqueId = reader.GetString(0);
                            string storedFIRText = reader.GetString(1);
                            // Criar FIR_TEXTENCODE a partir da string armazenada
                            NBioAPI.Type.FIR_TEXTENCODE textFIR = new NBioAPI.Type.FIR_TEXTENCODE { TextFIR = storedFIRText };
                            // Verificar digital capturada com digital armazenada no servidor
                            bool result;
                            NBioAPI.Type.FIR_PAYLOAD myPayload = new NBioAPI.Type.FIR_PAYLOAD();
                            uint ret = m_NBioAPI.VerifyMatch(hCapturedFIR, textFIR, out result, myPayload);
                            if (ret == NBioAPI.Error.NONE && result)
                            {
                                return uniqueId;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar a digital no banco de dados: " + ex.Message);
            }
            return null;
        }

        private async Task<string> CriarClienteAsync(string nome, string email, string cpfCnpj)
        {
            var options = new RestClientOptions(baseUrl + "/customers");
            var client = new RestClient(options);
            var request = new RestRequest("", Method.Post); // Especificar o método POST corretamente
            request.AddHeader("accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("User-Agent", "MeuProjetoFinal"); // Substitua pelo nome da sua aplicação
            request.AddHeader("access_token", apiKey);
            // request.AddHeader("X-Forwarded-For", "187.122.39.204"); // Adicionar o IP público diretamente no cabeçalho

            var jsonBody = new
            {
                name = nome,
                email = email,
                cpfCnpj = cpfCnpj
            };

            request.AddJsonBody(jsonBody);

            // Adicionar log para o corpo da requisição
            Console.WriteLine("Request Body: " + JsonConvert.SerializeObject(jsonBody));

            var response = await client.ExecuteAsync(request);
            var responseData = response.Content;

            if (response.IsSuccessful)
            {
                dynamic result = JsonConvert.DeserializeObject(responseData);
                return result.id;
            }
            else
            {
                // Adicionar logs de depuração
                MessageBox.Show("Erro ao criar cliente: " + response.StatusDescription + "\nDetalhes: " + responseData);
                Console.WriteLine("Status Code: " + response.StatusCode);
                Console.WriteLine("Response Content: " + responseData);
                throw new Exception("Erro ao criar cliente: " + response.StatusDescription + "\nDetalhes: " + responseData);
            }
        }

        private void SalvarClienteNoBancoDeDados(string uniqueId, string customerId, string nome, string sobrenome, string email, string cpfCnpj)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection("User Id=system;Password=093003;Data Source=DESKTOP-KHKU2NH:1521/FREE;Pooling=true;Min Pool Size=1;Max Pool Size=10;Connection Lifetime=120;"))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand("UPDATE CLIENTES SET CUSTOMER_ID = :CustomerId, NAME = :Name, SOBRENOME = :Sobrenome, EMAIL = :Email, CPF_CNPJ = :CpfCnpj WHERE UNIQUE_ID = :UniqueId", connection))
                    {
                        command.Parameters.Add(new OracleParameter("CustomerId", customerId));
                        command.Parameters.Add(new OracleParameter("Name", nome));
                        command.Parameters.Add(new OracleParameter("Sobrenome", sobrenome));
                        command.Parameters.Add(new OracleParameter("Email", email));
                        command.Parameters.Add(new OracleParameter("CpfCnpj", cpfCnpj));
                        command.Parameters.Add(new OracleParameter("UniqueId", uniqueId));
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Dados do cliente atualizados no banco de dados com sucesso!");
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inicio inicioForm = new Inicio();
            inicioForm.Show();
            this.Close();
        }
    }
}
