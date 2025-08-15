namespace ProjetoFinal
{
    partial class ConfirmarPagamentoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnConfirmar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnConfirmar = new Button();
            lblCombustivel = new Label();
            lblValor = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            button1 = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.White;
            btnConfirmar.Location = new Point(631, 675);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(622, 103);
            btnConfirmar.TabIndex = 1;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // lblCombustivel
            // 
            lblCombustivel.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCombustivel.Location = new Point(631, 204);
            lblCombustivel.Name = "lblCombustivel";
            lblCombustivel.Size = new Size(622, 158);
            lblCombustivel.TabIndex = 2;
            lblCombustivel.Text = "label1";
            lblCombustivel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblValor
            // 
            lblValor.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblValor.Location = new Point(631, 408);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(622, 144);
            lblValor.TabIndex = 3;
            lblValor.Text = "label2";
            lblValor.TextAlign = ContentAlignment.MiddleCenter;
            lblValor.Click += lblValor_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Yellow;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 636F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(btnConfirmar, 1, 3);
            tableLayoutPanel1.Controls.Add(lblValor, 1, 2);
            tableLayoutPanel1.Controls.Add(lblCombustivel, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Controls.Add(button1, 0, 3);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 264F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 377F));
            tableLayoutPanel1.Size = new Size(1892, 1050);
            tableLayoutPanel1.TabIndex = 4;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Captura_de_tela_2025_01_28_200235;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(188, 178);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Font = new Font("Arial Rounded MT Bold", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(631, 0);
            label1.Name = "label1";
            label1.Size = new Size(622, 128);
            label1.TabIndex = 4;
            label1.Text = "Confirma o abastecimento de:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.White;
            button1.Location = new Point(377, 999);
            button1.Name = "button1";
            button1.Size = new Size(248, 48);
            button1.TabIndex = 17;
            button1.Text = "Desistir";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // ConfirmarPagamentoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Yellow;
            ClientSize = new Size(1904, 1041);
            Controls.Add(tableLayoutPanel1);
            Name = "ConfirmarPagamentoForm";
            Text = "Confirmar Pagamento";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        private Label lblCombustivel;
        private Label lblValor;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Button button1;
    }
}
