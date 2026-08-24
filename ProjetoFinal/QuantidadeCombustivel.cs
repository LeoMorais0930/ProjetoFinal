using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using NITGEN.SDK.NBioBSP;
using RestSharp;

namespace ProjetoFinal
{
    public partial class QuantidadeCombustivel : Form
    {
        private NBioAPI m_NBioAPI;
        private string customerId;
        private string combustivel;
        private decimal valorDecimal;

        public QuantidadeCombustivel(string customerId, string combustivel)
        {
            InitializeComponent();
            this.customerId = customerId;
            this.combustivel = combustivel;
            InitializeNBioBSP();

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

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
            }
            else
            {
                MessageBox.Show("Erro ao enumerar dispositivos: " + ret.ToString());
            }
        }

        private void ConfigureLayout()
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 3
            };

            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            this.Controls.Add(tableLayoutPanel);

            Label lblQuantidade = new Label
            {
                Text = "Quantidade de Combustível",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold)
            };

            TextBox textBoxValor = new TextBox
            {
                Dock = DockStyle.Fill,
                Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Regular)
            };
            textBoxValor.TextChanged += textBoxValor_TextChanged;

            Button btnProcessarPagamento = new Button
            {
                Text = "Processar Pagamento",
                AutoSize = false,
                Size = new System.Drawing.Size(200, 50),
                Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold)
            };
            btnProcessarPagamento.Click += btnProcessarPagamento_Click;

            tableLayoutPanel.Controls.Add(lblQuantidade, 1, 0);
            tableLayoutPanel.Controls.Add(textBoxValor, 1, 1);
            tableLayoutPanel.Controls.Add(btnProcessarPagamento, 1, 2);
        }

        private void textBoxValor_TextChanged(object sender, EventArgs e)
        {
            textBoxValor.TextChanged -= textBoxValor_TextChanged;

            string entrada = textBoxValor.Text;
            if (Regex.IsMatch(entrada, @"^\d+$"))
            {
                textBoxValor.Text = entrada;
            }
            else
            {
                textBoxValor.Text = Regex.Replace(entrada, @"[^0-9]", "");
            }

            textBoxValor.SelectionStart = textBoxValor.Text.Length;

            textBoxValor.TextChanged += textBoxValor_TextChanged;
        }

        private void btnProcessarPagamento_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBoxValor.Text, out valorDecimal))
            {
                CapturarDigitalParaVerificacao();
            }
            else
            {
                MessageBox.Show("Valor inválido. Por favor, insira um valor numérico.");
            }
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

                NBioAPI.Type.HFIR hCapturedFIR;
                ret = m_NBioAPI.Capture(NBioAPI.Type.FIR_PURPOSE.VERIFY, out hCapturedFIR, NBioAPI.Type.TIMEOUT.DEFAULT, null, null);
                if (ret != NBioAPI.Error.NONE)
                {
                    MessageBox.Show("Falha ao capturar digital. Tente novamente.");
                    FecharDispositivo();
                    return;
                }

                ConfirmarPagamentoForm confirmarPagamentoForm = new ConfirmarPagamentoForm(customerId, valorDecimal, combustivel, hCapturedFIR);
                confirmarPagamentoForm.Show();
                this.Hide();
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
                if (m_NBioAPI == null)
                {
                    m_NBioAPI = new NBioAPI();
                }
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
                if (m_NBioAPI != null)
                {
                    m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao fechar o dispositivo: " + ex.Message);
            }
        }

        private bool TestarConexao()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(ConfigHelper.GetOracleConnectionString()))
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
                return false;
            }
        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
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
