namespace ProjetoFinal
{
    partial class Inicio
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            tableLayoutPanel = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            btnCadastro = new Button();
            label1 = new Label();
            btnEntrar = new Button();
            button1 = new Button();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.BackColor = Color.Yellow;
            tableLayoutPanel.ColumnCount = 4;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.4932556F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 73.5067444F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 421F));
            tableLayoutPanel.Controls.Add(pictureBox1, 1, 0);
            tableLayoutPanel.Controls.Add(btnCadastro, 2, 1);
            tableLayoutPanel.Controls.Add(label1, 2, 0);
            tableLayoutPanel.Controls.Add(btnEntrar, 2, 2);
            tableLayoutPanel.Controls.Add(button1, 3, 2);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 28.5280819F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 34.88372F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 36.5891457F));
            tableLayoutPanel.Size = new Size(1460, 645);
            tableLayoutPanel.TabIndex = 0;
            tableLayoutPanel.Paint += tableLayoutPanel_Paint_1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Captura_de_tela_2025_01_28_200235;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(189, 178);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // btnCadastro
            // 
            btnCadastro.Anchor = AnchorStyles.None;
            btnCadastro.BackColor = Color.White;
            btnCadastro.Font = new Font("Arial", 16F, FontStyle.Bold);
            btnCadastro.Location = new Point(424, 246);
            btnCadastro.Name = "btnCadastro";
            btnCadastro.Size = new Size(465, 100);
            btnCadastro.TabIndex = 0;
            btnCadastro.Text = "Cadastro";
            btnCadastro.UseVisualStyleBackColor = false;
            btnCadastro.Click += btnCadastro_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Yellow;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Arial Rounded MT Bold", 50.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ImageAlign = ContentAlignment.MiddleRight;
            label1.Location = new Point(278, 0);
            label1.Name = "label1";
            label1.Size = new Size(757, 184);
            label1.TabIndex = 5;
            label1.Text = "FNGPAY";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.UseMnemonic = false;
            label1.Click += label1_Click_1;
            // 
            // btnEntrar
            // 
            btnEntrar.Anchor = AnchorStyles.None;
            btnEntrar.BackColor = Color.White;
            btnEntrar.Font = new Font("Arial", 16F, FontStyle.Bold);
            btnEntrar.Location = new Point(417, 476);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(479, 100);
            btnEntrar.TabIndex = 1;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = false;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.White;
            button1.Location = new Point(1357, 611);
            button1.Name = "button1";
            button1.Size = new Size(100, 31);
            button1.TabIndex = 6;
            button1.Text = "Desligar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Inicio
            // 
            ClientSize = new Size(1460, 645);
            Controls.Add(tableLayoutPanel);
            Name = "Inicio";
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        private TableLayoutPanel tableLayoutPanel;
        private Button btnEntrar;
        private Button btnCadastro;
        private PictureBox pictureBox1;
        private Label label1;
        private Button button1;
    }
}
