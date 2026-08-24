using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using NITGEN.SDK.NBioBSP;
using RestSharp;
using Newtonsoft.Json;

namespace ProjetoFinal
{
    public partial class CadCartao : Form
    {
        private NBioAPI m_NBioAPI;
        private readonly string apiKey = ConfigHelper.GetRequiredSetting("AsaasAccessToken");
        private readonly string baseUrl = ConfigHelper.GetSetting("AsaasBaseUrl", "https://api-sandbox.asaas.com/v3");
        private string customerId;

        public CadCartao(string customerId)
        {
            InitializeComponent();
            InitializeNBioBSP();
            this.customerId = customerId;
            PreencherDadosCliente(customerId);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
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

        private void PreencherDadosCliente(string customerId)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(ConfigHelper.GetOracleConnectionString()))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("SELECT NAME, EMAIL, CPF_CNPJ, PHONE, POSTALCODE FROM CLIENTES WHERE CUSTOMER_ID = :CustomerId", conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("CustomerId", customerId));
                        OracleDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            textBoxNomeTitular.Text = reader.GetString(0);
                            textBoxEmailTitular.Text = reader.GetString(1);
                            textBoxCpfCnpj.Text = reader.GetString(2);
                            textBoxPhone.Text = reader.GetString(3);
                            textBoxPostalCode.Text = reader.GetString(4);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Não foi possível carregar os dados do cliente.");
            }
        }

        private void btnTokenizarCartao_Click(object sender, EventArgs e)
        {
            try
            {
                string numeroCartao = textBoxNumeroCartao.Text;
                string validade = textBoxValidade.Text;
                string cvv = textBoxCVV.Text;
                string nomeTitular = textBoxNomeTitular.Text;
                string emailTitular = textBoxEmailTitular.Text;
                string cpfCnpj = textBoxCpfCnpj.Text;
                string phone = textBoxPhone.Text;
                string postalCode = textBoxPostalCode.Text;
                string addressNumber = textBoxAddressNumber.Text;

                TokenizarEArmazenarCartao(customerId, numeroCartao, validade, cvv, nomeTitular, emailTitular, cpfCnpj, phone, postalCode, addressNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }
        }

        private async void TokenizarEArmazenarCartao(string customerId, string numeroCartao, string validade, string cvv, string nomeTitular, string emailTitular, string cpfCnpj, string phone, string postalCode, string addressNumber)
        {
            try
            {
                string cardToken = await TokenizarCartaoAsync(customerId, numeroCartao, validade, cvv, nomeTitular, emailTitular, cpfCnpj, phone, postalCode, addressNumber);
                SalvarTokenNoBancoDeDados(customerId, cardToken);
                MessageBox.Show("Cartão tokenizado e salvo com sucesso!");

                Inicio inicioForm = new Inicio();
                inicioForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tokenizar o cartão: " + ex.Message);
            }
        }

        private void SalvarTokenNoBancoDeDados(string customerId, string cardToken)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(ConfigHelper.GetOracleConnectionString()))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("UPDATE CLIENTES SET CARD_TOKEN = :CardToken WHERE CUSTOMER_ID = :CustomerId", conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("CardToken", cardToken));
                        cmd.Parameters.Add(new OracleParameter("CustomerId", customerId));
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Token do cartão salvo no banco de dados com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o token do cartão no banco de dados: " + ex.Message);
            }
        }

        private async Task<string> TokenizarCartaoAsync(string customerId, string numeroCartao, string validade, string cvv, string nomeTitular, string emailTitular, string cpfCnpj, string phone, string postalCode, string addressNumber)
        {
            var options = new RestClientOptions(baseUrl + "/creditCard/tokenizeCreditCard");
            var client = new RestClient(options);
            var request = new RestRequest("", Method.Post);
            request.AddHeader("accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("User-Agent", "BiometricPaymentSystem");
            request.AddHeader("access_token", apiKey);

            string[] validadeParts = validade.Split('/');
            if (validadeParts.Length != 2)
            {
                throw new ArgumentException("Formato de validade inválido. Use MM/AA.");
            }

            string expiryMonth = validadeParts[0];
            string expiryYear = "20" + validadeParts[1];

            var jsonBody = new
            {
                customer = customerId,
                creditCard = new
                {
                    holderName = nomeTitular,
                    number = numeroCartao,
                    expiryMonth = expiryMonth,
                    expiryYear = expiryYear,
                    ccv = cvv
                },
                creditCardHolderInfo = new
                {
                    name = nomeTitular,
                    email = emailTitular,
                    cpfCnpj = cpfCnpj,
                    phone = phone,
                    postalCode = postalCode,
                    addressNumber = addressNumber
                }
            };

            request.AddJsonBody(jsonBody);

            var apiResponse = await client.ExecuteAsync(request);
            var apiResponseData = apiResponse.Content;

            Console.WriteLine("Response Status Code: " + apiResponse.StatusCode);

            dynamic result = JsonConvert.DeserializeObject(apiResponseData);

            if (apiResponse.IsSuccessful)
            {
                return result.creditCardToken;
            }
            else
            {
                throw new Exception("Erro ao tokenizar o cartão: " + apiResponse.StatusDescription);
            }
        }

        private void CadCartao_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxValidade_TextChanged(object sender, EventArgs e)
        {
            textBoxValidade.TextChanged -= textBoxValidade_TextChanged;

            string entrada = textBoxValidade.Text.Replace("/", "");

            if (entrada.Length > 2)
            {
                entrada = entrada.Insert(2, "/");
            }

            if (entrada.Length > 7)
            {
                entrada = entrada.Substring(0, 7);
            }

            textBoxValidade.Text = entrada;
            textBoxValidade.SelectionStart = entrada.Length;
            textBoxValidade.TextChanged += textBoxValidade_TextChanged;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
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
