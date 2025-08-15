namespace ProjetoFinal
{
    partial class QuantidadeCombustivel
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBoxValor;
        private Button btnProcessarPagamento;
        private TableLayoutPanel tableLayoutPanel;
        private Label lblQuantidade;

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
            tableLayoutPanel = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            lblQuantidade = new Label();
            textBoxValor = new TextBox();
            btnProcessarPagamento = new Button();
            button1 = new Button();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.6912766F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.020134F));
            tableLayoutPanel.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel.Controls.Add(lblQuantidade, 1, 0);
            tableLayoutPanel.Controls.Add(textBoxValor, 1, 1);
            tableLayoutPanel.Controls.Add(btnProcessarPagamento, 1, 2);
            tableLayoutPanel.Controls.Add(button1, 0, 2);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 42.6666679F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 30.666666F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 26.5F));
            tableLayoutPanel.Size = new Size(1490, 600);
            tableLayoutPanel.TabIndex = 0;
            tableLayoutPanel.Paint += tableLayoutPanel_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Captura_de_tela_2025_01_28_200235;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(178, 174);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // lblQuantidade
            // 
            lblQuantidade.Dock = DockStyle.Fill;
            lblQuantidade.Font = new Font("Arial Rounded MT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuantidade.Location = new Point(499, 0);
            lblQuantidade.Name = "lblQuantidade";
            lblQuantidade.Size = new Size(495, 256);
            lblQuantidade.TabIndex = 0;
            lblQuantidade.Text = "Quantidade de Combustível";
            lblQuantidade.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxValor
            // 
            textBoxValor.Dock = DockStyle.Fill;
            textBoxValor.Font = new Font("Arial", 14F);
            textBoxValor.Location = new Point(499, 259);
            textBoxValor.Name = "textBoxValor";
            textBoxValor.Size = new Size(495, 29);
            textBoxValor.TabIndex = 1;
            textBoxValor.TextChanged += textBoxValor_TextChanged;
            // 
            // btnProcessarPagamento
            // 
            btnProcessarPagamento.BackColor = Color.White;
            btnProcessarPagamento.Font = new Font("Arial", 14F, FontStyle.Bold);
            btnProcessarPagamento.ImageAlign = ContentAlignment.MiddleRight;
            btnProcessarPagamento.Location = new Point(499, 443);
            btnProcessarPagamento.Name = "btnProcessarPagamento";
            btnProcessarPagamento.Size = new Size(495, 50);
            btnProcessarPagamento.TabIndex = 2;
            btnProcessarPagamento.Text = "Processar Pagamento";
            btnProcessarPagamento.UseVisualStyleBackColor = false;
            btnProcessarPagamento.Click += btnProcessarPagamento_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.White;
            button1.Location = new Point(245, 549);
            button1.Name = "button1";
            button1.Size = new Size(248, 48);
            button1.TabIndex = 17;
            button1.Text = "Desistir";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // QuantidadeCombustivel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Yellow;
            ClientSize = new Size(1490, 600);
            Controls.Add(tableLayoutPanel);
            Name = "QuantidadeCombustivel";
            Text = "Processar Pagamento";
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
    }
}
