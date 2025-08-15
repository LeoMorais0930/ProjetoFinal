using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using NITGEN.SDK.NBioBSP;
using Oracle.ManagedDataAccess.Client;
using RestSharp;
using Newtonsoft.Json;

namespace ProjetoFinal
{
    public partial class ConfirmarPagamentoForm : Form
    {
        private NBioAPI m_NBioAPI;
        private string customerId;
        private decimal valor;
        private string combustivel;
        private NBioAPI.Type.HFIR hCapturedFIR;
        private string cardToken;
        private string apiKey = "$aact_MzkwODA2MWY2OGM3MWRlMDU2NWM3MzJlNzZmNGZhZGY6Ojg2OGExNDI4LTllZGYtNDZiZS05Mzc0LWYyYTFhOTNhNTgxMTo6JGFhY2hfYjk3YzA3ZDUtZWFkNi00NmQxLWIwOGEtOTZiNWNjODYwMTUy";
        private string baseUrl = "https://api-sandbox.asaas.com/v3/";
        // private string remoteIp = "187.122.39.204";


        public ConfirmarPagamentoForm(string customerId, decimal valor, string combustivel, NBioAPI.Type.HFIR hCapturedFIR)
        {
            InitializeComponent();
            this.customerId = customerId;
            this.valor = valor;
            this.combustivel = combustivel;
            this.hCapturedFIR = hCapturedFIR;

            // Configurar tela cheia
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            InitializeNBioBSP();
            lblValor.Text = $"Valor: R$ {valor}";
            lblCombustivel.Text = $"Combustível: {combustivel}";
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
                // Adicione seu código de configuração aqui
            }
            else
            {
                MessageBox.Show("Erro ao enumerar dispositivos: " + ret.ToString());
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            CapturarDigitalParaVerificacao();
        }

        private void CapturarDigitalParaVerificacao()
        {
            try
            {
                uint ret = AbrirDispositivo();
                if (ret != NBioAPI.Error.NONE)
                {
                    MessageBox.Show("Falha ao inicializar o dispositivo. Tente novamente.");
                    return;
                }

                // Capturar digital para verificação
                NBioAPI.Type.HFIR hCapturedFIR;
                ret = m_NBioAPI.Capture(NBioAPI.Type.FIR_PURPOSE.VERIFY, out hCapturedFIR, NBioAPI.Type.TIMEOUT.DEFAULT, null, null);
                if (ret != NBioAPI.Error.NONE)
                {
                    MessageBox.Show("Falha ao capturar digital. Tente novamente.");
                    FecharDispositivo();
                    return;
                }

                // Verificar e prosseguir com o pagamento
                VerificarUsuarioEProcessarPagamento(hCapturedFIR);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }
        }

        private void VerificarUsuarioEProcessarPagamento(NBioAPI.Type.HFIR hCapturedFIR)
        {
            string customerId = null;
            string cardToken = null;
            bool result = false;
            NBioAPI.Type.FIR_TEXTENCODE textFIR;
            m_NBioAPI.GetTextFIRFromHandle(hCapturedFIR, out textFIR, true);

            using (var conn = new OracleConnection("User Id=system;Password=093003;Data Source=DESKTOP-KHKU2NH:1521/FREE;Pooling=true;Min Pool Size=1;Max Pool Size=10;Connection Lifetime=120;"))
            {
                conn.Open();
                string query = "SELECT CUSTOMER_ID, TEXTDATA, CARD_TOKEN FROM CLIENTES";
                using (var cmd = new OracleCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string storedFIRText = reader.GetString(1);
                            string storedCardToken = reader.GetString(2);
                            string storedCustomerId = reader.GetString(0);

                            NBioAPI.Type.FIR_TEXTENCODE storedFIR = new NBioAPI.Type.FIR_TEXTENCODE { TextFIR = storedFIRText };
                            NBioAPI.Type.FIR_PAYLOAD payload = new NBioAPI.Type.FIR_PAYLOAD();

                            uint ret = m_NBioAPI.VerifyMatch(hCapturedFIR, storedFIR, out result, payload);
                            if (ret == NBioAPI.Error.NONE && result)
                            {
                                customerId = storedCustomerId;
                                cardToken = storedCardToken;
                                break;
                            }
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(customerId) && !string.IsNullOrEmpty(cardToken))
            {
                ProcessarPagamento(customerId, cardToken);
            }
            else
            {
                MessageBox.Show("Usuário não encontrado ou token do cartão não encontrado. Tente novamente.");
            }

            FecharDispositivo();
        }

        private uint AbrirDispositivo()
        {
            try
            {
                uint ret = m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO);
                return ret;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inicializar o dispositivo: " + ex.Message);
                return NBioAPI.Error.INVALID_HANDLE;
            }
        }

        private void FecharDispositivo()
        {
            try
            {
                m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao fechar o dispositivo: " + ex.Message);
            }
        }

        private async void ProcessarPagamento(string customerId, string cardToken)
        {
            try
            {
                var result = await ProcessarPagamentoAsync(customerId, cardToken, valor);
                if (!string.IsNullOrEmpty(result))
                {
                    MessageBox.Show($"Pagamento realizado com sucesso! Valor: R$ {valor}, Combustível: {combustivel}.");
                    // Voltar para o formulário Inicio após sucesso no pagamento
                    Inicio inicioForm = new Inicio();
                    inicioForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Erro ao processar pagamento.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao processar pagamento: " + ex.Message);
            }
        }

        public async Task<string> ProcessarPagamentoAsync(string customerId, string cardToken, decimal valor)
        {
            var options = new RestClientOptions(baseUrl + "/payments");
            var client = new RestClient(options);
            var request = new RestRequest("", Method.Post);
            request.AddHeader("accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("User-Agent", "MeuProjetoFinal"); // Substitua pelo nome da sua aplicação
            request.AddHeader("access_token", apiKey);
            //request.AddHeader("X-Forwarded-For", "187.122.39.204"); // Adicionar o IP público diretamente no cabeçalho

            var body = new
            {
                customer = customerId,
                billingType = "CREDIT_CARD",
                value = valor,
                dueDate = DateTime.Now.ToString("yyyy-MM-dd"), // Data de vencimento definida automaticamente para o dia atual
                creditCardToken = cardToken,
                // remoteIp = remoteIp,
                authorizeOnly = false
            };

            request.AddJsonBody(body);

            var response = await client.ExecuteAsync(request);
            var responseData = response.Content;
            dynamic result = JsonConvert.DeserializeObject(responseData);

            if (response.IsSuccessful)
            {
                return result.id;
            }
            else
            {
                throw new Exception("Erro ao processar pagamento: " + response.StatusDescription + "\nDetalhes: " + responseData);
            }
        }

        private void lblValor_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inicio inicioForm = new Inicio();
            inicioForm.Show();
            this.Close();
        }
    }
}
