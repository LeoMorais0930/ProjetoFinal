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
        private readonly string apiKey = ConfigHelper.GetRequiredSetting("AsaasAccessToken");
        private readonly string baseUrl = ConfigHelper.GetSetting("AsaasBaseUrl", "https://api-sandbox.asaas.com/v3");

        public CadCus(string uniqueId)
        {
            InitializeComponent();
            this.uniqueId = uniqueId;
            InitializeNBioBSP();

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
                short deviceID = (short)(comboBoxDispositivo.SelectedIndex - 1);
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
                NBioAPI.Type.HFIR hCapturedFIR;
                uint ret = m_NBioAPI.Capture(NBioAPI.Type.FIR_PURPOSE.VERIFY, out hCapturedFIR, NBioAPI.Type.TIMEOUT.DEFAULT, null, null);
                if (ret != NBioAPI.Error.NONE)
                {
                    MessageBox.Show("Falha ao capturar digital. Tente novamente.");
                    return;
                }

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
                        MessageBox.Show("Cliente cadastrado com sucesso!");
                        this.Close();

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
                using (OracleConnection conn = new OracleConnection(ConfigHelper.GetOracleConnectionString()))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("SELECT UNIQUE_ID, TEXTDATA FROM CLIENTES", conn))
                    {
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string uniqueId = reader.GetString(0);
                            string storedFIRText = reader.GetString(1);
                            NBioAPI.Type.FIR_TEXTENCODE textFIR = new NBioAPI.Type.FIR_TEXTENCODE { TextFIR = storedFIRText };
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
            var request = new RestRequest("", Method.Post);
            request.AddHeader("accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("User-Agent", "BiometricPaymentSystem");
            request.AddHeader("access_token", apiKey);

            var jsonBody = new
            {
                name = nome,
                email = email,
                cpfCnpj = cpfCnpj
            };

            request.AddJsonBody(jsonBody);

            var response = await client.ExecuteAsync(request);
            var responseData = response.Content;

            if (response.IsSuccessful)
            {
                dynamic result = JsonConvert.DeserializeObject(responseData);
                return result.id;
            }
            else
            {
                Console.WriteLine("Status Code: " + response.StatusCode);
                throw new Exception("Erro ao criar cliente: " + response.StatusDescription);
            }
        }

        private void SalvarClienteNoBancoDeDados(string uniqueId, string customerId, string nome, string sobrenome, string email, string cpfCnpj)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(ConfigHelper.GetOracleConnectionString()))
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
            catch
            {
                MessageBox.Show("Erro ao atualizar os dados do cliente no banco de dados.");
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
