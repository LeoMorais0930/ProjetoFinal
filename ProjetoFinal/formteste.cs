using System;
using System.Windows.Forms;
using NITGEN.SDK.NBioBSP;
using Oracle.ManagedDataAccess.Client;

namespace ProjetoFinal
{
    public partial class formteste : Form
    {
        private NBioAPI m_NBioAPI;

        public formteste()
        {
            InitializeComponent();
            InitializeNBioBSP();
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

        private void btnPedirDigital_Click(object sender, EventArgs e)
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

                // Verificar usuário e exibir informações
                VerificarUsuarioEExibirInformacoes(hCapturedFIR);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }
        }

        private void VerificarUsuarioEExibirInformacoes(NBioAPI.Type.HFIR hCapturedFIR)
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
                lblCustomerId.Text = "Customer ID: " + customerId;
                lblCardToken.Text = "Card Token: " + cardToken;
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

        private void formteste_Load(object sender, EventArgs e)
        {

        }
    }
}
