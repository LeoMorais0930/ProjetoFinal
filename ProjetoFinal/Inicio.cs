using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using NITGEN.SDK.NBioBSP;

namespace ProjetoFinal
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            ConfigureLayout();
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

            Button btnCadastro = new Button
            {
                Text = "Cadastro",
                Anchor = AnchorStyles.None,
                AutoSize = false,
                Size = new System.Drawing.Size(200, 100),
                Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold)
            };
            btnCadastro.Click += btnCadastro_Click;

            Button btnEntrar = new Button
            {
                Text = "Entrar",
                Anchor = AnchorStyles.None,
                AutoSize = false,
                Size = new System.Drawing.Size(200, 100),
                Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold)
            };
            btnEntrar.Click += btnEntrar_Click;

            tableLayoutPanel.Controls.Add(btnCadastro, 1, 1);
            tableLayoutPanel.Controls.Add(btnEntrar, 1, 2);
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            CadastroDig cadastroDigForm = new CadastroDig();
            cadastroDigForm.Show();
            this.Hide();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            EscolherComb escolherComb = new EscolherComb();
            escolherComb.Show();
            this.Hide();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Anchor = AnchorStyles.None;
            label1.Location = new Point((this.ClientSize.Width - label1.Width) / 2, (this.ClientSize.Height - label1.Height) / 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
