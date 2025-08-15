using System;
using System.Windows.Forms;
using NITGEN.SDK.NBioBSP;
using Oracle.ManagedDataAccess.Client;

namespace ProjetoFinal
{
    public partial class EscolherComb : Form
    {
        private NBioAPI m_NBioAPI;

        public EscolherComb()
        {
            InitializeComponent();
            InitializeNBioBSP();

            // Configurar tela cheia
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            // Configurar layout
            ConfigureLayout();
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

        private void ConfigureLayout()
        {
            // Layout configuration logic here...
        }

        private void AbrirQuantidadeCombustivelForm(string customerId, string combustivel)
        {
            QuantidadeCombustivel quantidadeCombustivelForm = new QuantidadeCombustivel(customerId, combustivel);
            quantidadeCombustivelForm.Show();
            this.Hide();
        }

        private void VerificarDigital(string combustivel)
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

                // Verificar usuário no banco de dados pela digital capturada
                string uniqueId = VerificarUsuario(hCapturedFIR);
                if (!string.IsNullOrEmpty(uniqueId))
                {
                    // Abrir o próximo formulário com o uniqueId e o combustível selecionado
                    AbrirQuantidadeCombustivelForm(uniqueId, combustivel);
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado. Tente novamente.");
                }
                FecharDispositivo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }
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

        private void button1_Click(object sender, EventArgs e) => VerificarDigital("Gasolina Comum");
        private void button2_Click(object sender, EventArgs e) => VerificarDigital("Etanol");
        private void button3_Click(object sender, EventArgs e) => VerificarDigital("Gasolina Aditivada");
        private void button4_Click(object sender, EventArgs e) => VerificarDigital("Diesel Comum");
        private void button5_Click(object sender, EventArgs e) => VerificarDigital("Diesel S-10");
        private void button6_Click(object sender, EventArgs e) => VerificarDigital("GNV");

        private void EscolherComb_Load(object sender, EventArgs e)
        {

        }

        private void Txtescolhacomb_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Inicio inicioForm = new Inicio();
            inicioForm.Show();
            this.Close();
        }
    }
}

