namespace ProjetoFinal
{
    partial class CadastroDig
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox comboBoxDispositivo;
        private Button btnEscolherDispositivo;
        private Button btnCadastrarDigital;

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
            comboBoxDispositivo = new ComboBox();
            btnEscolherDispositivo = new Button();
            btnCadastrarDigital = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // comboBoxDispositivo
            // 
            comboBoxDispositivo.FormattingEnabled = true;
            comboBoxDispositivo.Location = new Point(4, 206);
            comboBoxDispositivo.Margin = new Padding(4, 3, 4, 3);
            comboBoxDispositivo.Name = "comboBoxDispositivo";
            comboBoxDispositivo.Size = new Size(16, 23);
            comboBoxDispositivo.TabIndex = 0;
            // 
            // btnEscolherDispositivo
            // 
            btnEscolherDispositivo.BackColor = Color.White;
            btnEscolherDispositivo.Location = new Point(621, 206);
            btnEscolherDispositivo.Margin = new Padding(4, 3, 4, 3);
            btnEscolherDispositivo.Name = "btnEscolherDispositivo";
            btnEscolherDispositivo.Size = new Size(700, 103);
            btnEscolherDispositivo.TabIndex = 1;
            btnEscolherDispositivo.Text = "Escolher Dispositivo";
            btnEscolherDispositivo.UseVisualStyleBackColor = false;
            btnEscolherDispositivo.Click += btnEscolherDispositivo_Click;
            // 
            // btnCadastrarDigital
            // 
            btnCadastrarDigital.BackColor = Color.White;
            btnCadastrarDigital.Location = new Point(621, 532);
            btnCadastrarDigital.Margin = new Padding(4, 3, 4, 3);
            btnCadastrarDigital.Name = "btnCadastrarDigital";
            btnCadastrarDigital.Size = new Size(700, 119);
            btnCadastrarDigital.TabIndex = 2;
            btnCadastrarDigital.Text = "Cadastrar Digital";
            btnCadastrarDigital.UseVisualStyleBackColor = false;
            btnCadastrarDigital.Click += btnCadastrarDigital_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.55667F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 53.44333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 583F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(btnCadastrarDigital, 1, 2);
            tableLayoutPanel1.Controls.Add(btnEscolherDispositivo, 1, 1);
            tableLayoutPanel1.Controls.Add(comboBoxDispositivo, 0, 1);
            tableLayoutPanel1.Controls.Add(button1, 0, 3);
            tableLayoutPanel1.Location = new Point(-4, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 38.37429F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 61.62571F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 406F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 109F));
            tableLayoutPanel1.Size = new Size(1909, 1045);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Captura_de_tela_2025_01_28_200235;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(186, 178);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.White;
            button1.Location = new Point(366, 994);
            button1.Name = "button1";
            button1.Size = new Size(248, 48);
            button1.TabIndex = 17;
            button1.Text = "Desistir";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // CadastroDig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Yellow;
            ClientSize = new Size(1904, 1041);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CadastroDig";
            Text = "Cadastro de Digital";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private Button button1;
    }
}
