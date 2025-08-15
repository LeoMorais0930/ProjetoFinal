namespace ProjetoFinal
{
    partial class CadCartao
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBoxNumeroCartao;
        private TextBox textBoxCVV;
        private TextBox textBoxNomeTitular;
        private TextBox textBoxEmailTitular;
        private TextBox textBoxCpfCnpj;
        private TextBox textBoxPhone;
        private TextBox textBoxPostalCode;
        private TextBox textBoxAddressNumber;
        private ComboBox comboBoxDispositivo;
        private Button btnEscolherDispositivo;
        private Button btnTokenizarCartao;

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
            textBoxNumeroCartao = new TextBox();
            textBoxCVV = new TextBox();
            textBoxNomeTitular = new TextBox();
            textBoxEmailTitular = new TextBox();
            textBoxCpfCnpj = new TextBox();
            textBoxPhone = new TextBox();
            textBoxPostalCode = new TextBox();
            textBoxAddressNumber = new TextBox();
            comboBoxDispositivo = new ComboBox();
            btnEscolherDispositivo = new Button();
            btnTokenizarCartao = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            textBoxValidade = new TextBox();
            button1 = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBoxNumeroCartao
            // 
            textBoxNumeroCartao.Location = new Point(625, 249);
            textBoxNumeroCartao.Margin = new Padding(4, 3, 4, 3);
            textBoxNumeroCartao.Name = "textBoxNumeroCartao";
            textBoxNumeroCartao.PlaceholderText = "Número do Cartão";
            textBoxNumeroCartao.Size = new Size(566, 23);
            textBoxNumeroCartao.TabIndex = 0;
            // 
            // textBoxCVV
            // 
            textBoxCVV.Location = new Point(625, 312);
            textBoxCVV.Margin = new Padding(4, 3, 4, 3);
            textBoxCVV.Name = "textBoxCVV";
            textBoxCVV.PlaceholderText = "CVV";
            textBoxCVV.Size = new Size(59, 23);
            textBoxCVV.TabIndex = 2;
            // 
            // textBoxNomeTitular
            // 
            textBoxNomeTitular.Location = new Point(625, 218);
            textBoxNomeTitular.Margin = new Padding(4, 3, 4, 3);
            textBoxNomeTitular.Name = "textBoxNomeTitular";
            textBoxNomeTitular.PlaceholderText = "Nome do Titular";
            textBoxNomeTitular.Size = new Size(566, 23);
            textBoxNomeTitular.TabIndex = 3;
            // 
            // textBoxEmailTitular
            // 
            textBoxEmailTitular.Location = new Point(625, 344);
            textBoxEmailTitular.Margin = new Padding(4, 3, 4, 3);
            textBoxEmailTitular.Name = "textBoxEmailTitular";
            textBoxEmailTitular.PlaceholderText = "Email do Titular";
            textBoxEmailTitular.Size = new Size(566, 23);
            textBoxEmailTitular.TabIndex = 4;
            // 
            // textBoxCpfCnpj
            // 
            textBoxCpfCnpj.Location = new Point(625, 380);
            textBoxCpfCnpj.Margin = new Padding(4, 3, 4, 3);
            textBoxCpfCnpj.Name = "textBoxCpfCnpj";
            textBoxCpfCnpj.PlaceholderText = "CPF/CNPJ";
            textBoxCpfCnpj.Size = new Size(566, 23);
            textBoxCpfCnpj.TabIndex = 5;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(625, 416);
            textBoxPhone.Margin = new Padding(4, 3, 4, 3);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.PlaceholderText = "Telefone (com DDD)";
            textBoxPhone.Size = new Size(566, 23);
            textBoxPhone.TabIndex = 6;
            // 
            // textBoxPostalCode
            // 
            textBoxPostalCode.Location = new Point(625, 451);
            textBoxPostalCode.Margin = new Padding(4, 3, 4, 3);
            textBoxPostalCode.Name = "textBoxPostalCode";
            textBoxPostalCode.PlaceholderText = "CEP";
            textBoxPostalCode.Size = new Size(566, 23);
            textBoxPostalCode.TabIndex = 7;
            // 
            // textBoxAddressNumber
            // 
            textBoxAddressNumber.Location = new Point(625, 492);
            textBoxAddressNumber.Margin = new Padding(4, 3, 4, 3);
            textBoxAddressNumber.Name = "textBoxAddressNumber";
            textBoxAddressNumber.PlaceholderText = "Número do Endereço";
            textBoxAddressNumber.Size = new Size(566, 23);
            textBoxAddressNumber.TabIndex = 8;
            // 
            // comboBoxDispositivo
            // 
            comboBoxDispositivo.FormattingEnabled = true;
            comboBoxDispositivo.Location = new Point(4, 535);
            comboBoxDispositivo.Margin = new Padding(4, 3, 4, 3);
            comboBoxDispositivo.Name = "comboBoxDispositivo";
            comboBoxDispositivo.Size = new Size(10, 23);
            comboBoxDispositivo.TabIndex = 9;
            // 
            // btnEscolherDispositivo
            // 
            btnEscolherDispositivo.BackColor = Color.White;
            btnEscolherDispositivo.Location = new Point(625, 535);
            btnEscolherDispositivo.Margin = new Padding(4, 3, 4, 3);
            btnEscolherDispositivo.Name = "btnEscolherDispositivo";
            btnEscolherDispositivo.Size = new Size(566, 37);
            btnEscolherDispositivo.TabIndex = 10;
            btnEscolherDispositivo.Text = "Escolher Dispositivo";
            btnEscolherDispositivo.UseVisualStyleBackColor = false;
            btnEscolherDispositivo.Click += btnEscolherDispositivo_Click;
            // 
            // btnTokenizarCartao
            // 
            btnTokenizarCartao.BackColor = Color.White;
            btnTokenizarCartao.Location = new Point(625, 587);
            btnTokenizarCartao.Margin = new Padding(4, 3, 4, 3);
            btnTokenizarCartao.Name = "btnTokenizarCartao";
            btnTokenizarCartao.Size = new Size(566, 87);
            btnTokenizarCartao.TabIndex = 11;
            btnTokenizarCartao.Text = "Tokenizar Cartão";
            btnTokenizarCartao.UseVisualStyleBackColor = false;
            btnTokenizarCartao.Click += btnTokenizarCartao_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Yellow;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 51.5664673F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48.4335327F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 597F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 99F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 151F));
            tableLayoutPanel1.Controls.Add(btnEscolherDispositivo, 1, 10);
            tableLayoutPanel1.Controls.Add(comboBoxDispositivo, 0, 10);
            tableLayoutPanel1.Controls.Add(textBoxAddressNumber, 1, 9);
            tableLayoutPanel1.Controls.Add(textBoxEmailTitular, 1, 5);
            tableLayoutPanel1.Controls.Add(textBoxPostalCode, 1, 8);
            tableLayoutPanel1.Controls.Add(textBoxCpfCnpj, 1, 6);
            tableLayoutPanel1.Controls.Add(textBoxPhone, 1, 7);
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(textBoxNomeTitular, 1, 1);
            tableLayoutPanel1.Controls.Add(textBoxNumeroCartao, 1, 2);
            tableLayoutPanel1.Controls.Add(textBoxCVV, 1, 4);
            tableLayoutPanel1.Controls.Add(textBoxValidade, 1, 3);
            tableLayoutPanel1.Controls.Add(button1, 0, 11);
            tableLayoutPanel1.Controls.Add(btnTokenizarCartao, 1, 11);
            tableLayoutPanel1.Location = new Point(-4, -3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 15;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 215F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 49.25373F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.74627F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 348F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 174F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(2052, 1147);
            tableLayoutPanel1.TabIndex = 12;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // label1
            // 
            label1.Font = new Font("Arial Rounded MT Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(624, 0);
            label1.Name = "label1";
            label1.Size = new Size(568, 151);
            label1.TabIndex = 13;
            label1.Text = "Vamos cadastrar um cartão para sua digital!";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Captura_de_tela_2025_01_28_200235;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(182, 158);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // textBoxValidade
            // 
            textBoxValidade.Location = new Point(624, 281);
            textBoxValidade.Name = "textBoxValidade";
            textBoxValidade.PlaceholderText = "Validade";
            textBoxValidade.Size = new Size(568, 23);
            textBoxValidade.TabIndex = 15;
            textBoxValidade.TextChanged += textBoxValidade_TextChanged;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.White;
            button1.Location = new Point(370, 881);
            button1.Name = "button1";
            button1.Size = new Size(248, 48);
            button1.TabIndex = 16;
            button1.Text = "Desistir";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // CadCartao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Yellow;
            ClientSize = new Size(1924, 1061);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CadCartao";
            Text = "Cadastro de Cartão";
            Load += CadCartao_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private PictureBox pictureBox1;
        private TextBox textBoxValidade;
        private Button button1;
    }
}
