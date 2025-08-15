namespace ProjetoFinal
{
    partial class CadCus
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBoxNome;
        private TextBox textBoxSobrenome;
        private TextBox textBoxEmail;
        private TextBox textBoxCpfCnpj;
        private ComboBox comboBoxDispositivo;
        private Button btnEscolherDispositivo;
        private Button btnCadastrar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            textBoxNome = new TextBox();
            textBoxSobrenome = new TextBox();
            textBoxEmail = new TextBox();
            textBoxCpfCnpj = new TextBox();
            comboBoxDispositivo = new ComboBox();
            btnEscolherDispositivo = new Button();
            btnCadastrar = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            button1 = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBoxNome
            // 
            textBoxNome.Location = new Point(633, 309);
            textBoxNome.Margin = new Padding(4, 3, 4, 3);
            textBoxNome.Name = "textBoxNome";
            textBoxNome.PlaceholderText = "Nome";
            textBoxNome.Size = new Size(603, 23);
            textBoxNome.TabIndex = 0;
            // 
            // textBoxSobrenome
            // 
            textBoxSobrenome.Location = new Point(633, 393);
            textBoxSobrenome.Margin = new Padding(4, 3, 4, 3);
            textBoxSobrenome.Name = "textBoxSobrenome";
            textBoxSobrenome.PlaceholderText = "Sobrenome";
            textBoxSobrenome.Size = new Size(603, 23);
            textBoxSobrenome.TabIndex = 1;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(633, 491);
            textBoxEmail.Margin = new Padding(4, 3, 4, 3);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.PlaceholderText = "Email";
            textBoxEmail.Size = new Size(603, 23);
            textBoxEmail.TabIndex = 2;
            // 
            // textBoxCpfCnpj
            // 
            textBoxCpfCnpj.Location = new Point(633, 592);
            textBoxCpfCnpj.Margin = new Padding(4, 3, 4, 3);
            textBoxCpfCnpj.Name = "textBoxCpfCnpj";
            textBoxCpfCnpj.PlaceholderText = "CPF/CNPJ";
            textBoxCpfCnpj.Size = new Size(603, 23);
            textBoxCpfCnpj.TabIndex = 3;
            // 
            // comboBoxDispositivo
            // 
            comboBoxDispositivo.Anchor = AnchorStyles.Bottom;
            comboBoxDispositivo.FormattingEnabled = true;
            comboBoxDispositivo.Location = new Point(1594, 1075);
            comboBoxDispositivo.Margin = new Padding(4, 3, 4, 3);
            comboBoxDispositivo.Name = "comboBoxDispositivo";
            comboBoxDispositivo.Size = new Size(10, 23);
            comboBoxDispositivo.TabIndex = 4;
            // 
            // btnEscolherDispositivo
            // 
            btnEscolherDispositivo.BackColor = Color.White;
            btnEscolherDispositivo.Location = new Point(633, 694);
            btnEscolherDispositivo.Margin = new Padding(4, 3, 4, 3);
            btnEscolherDispositivo.Name = "btnEscolherDispositivo";
            btnEscolherDispositivo.Size = new Size(603, 61);
            btnEscolherDispositivo.TabIndex = 5;
            btnEscolherDispositivo.Text = "Escolher Dispositivo";
            btnEscolherDispositivo.UseVisualStyleBackColor = false;
            btnEscolherDispositivo.Click += btnEscolherDispositivo_Click;
            // 
            // btnCadastrar
            // 
            btnCadastrar.BackColor = Color.White;
            btnCadastrar.Location = new Point(633, 800);
            btnCadastrar.Margin = new Padding(4, 3, 4, 3);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(603, 57);
            btnCadastrar.TabIndex = 6;
            btnCadastrar.Text = "Cadastrar Cliente";
            btnCadastrar.UseVisualStyleBackColor = false;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tableLayoutPanel1.BackColor = Color.Yellow;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 682F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(btnCadastrar, 1, 6);
            tableLayoutPanel1.Controls.Add(textBoxEmail, 1, 3);
            tableLayoutPanel1.Controls.Add(btnEscolherDispositivo, 1, 5);
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Controls.Add(textBoxSobrenome, 1, 2);
            tableLayoutPanel1.Controls.Add(textBoxNome, 1, 1);
            tableLayoutPanel1.Controls.Add(textBoxCpfCnpj, 1, 4);
            tableLayoutPanel1.Controls.Add(comboBoxDispositivo, 2, 6);
            tableLayoutPanel1.Controls.Add(button1, 0, 6);
            tableLayoutPanel1.Location = new Point(-37, -60);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RightToLeft = RightToLeft.No;
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 78.29457F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 21.7054272F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 98F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 101F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 102F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 106F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 303F));
            tableLayoutPanel1.Size = new Size(1941, 1101);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Captura_de_tela_2025_01_28_200235;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(250, 178);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.Font = new Font("Arial Rounded MT Bold", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ImageAlign = ContentAlignment.TopCenter;
            label1.Location = new Point(650, 94);
            label1.Name = "label1";
            label1.Size = new Size(605, 212);
            label1.TabIndex = 7;
            label1.Text = "Etapa 1: Cadastrar dados do cliente no banco de dados.";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.White;
            button1.Location = new Point(378, 1050);
            button1.Name = "button1";
            button1.Size = new Size(248, 48);
            button1.TabIndex = 17;
            button1.Text = "Desistir";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // CadCus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CadCus";
            Text = "Cadastro de Cliente";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private Button button1;
    }
}
