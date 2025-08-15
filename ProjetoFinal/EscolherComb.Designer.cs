namespace ProjetoFinal
{
    partial class EscolherComb
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label Txtescolhacomb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;

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
            tableLayoutPanel = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            Txtescolhacomb = new Label();
            flowLayoutPanel = new FlowLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.BackColor = Color.Yellow;
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.5020027F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63.6849136F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.75F));
            tableLayoutPanel.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel.Controls.Add(Txtescolhacomb, 1, 0);
            tableLayoutPanel.Controls.Add(flowLayoutPanel, 1, 1);
            tableLayoutPanel.Controls.Add(button7, 0, 2);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 57F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 9.833333F));
            tableLayoutPanel.Size = new Size(1498, 600);
            tableLayoutPanel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Captura_de_tela_2025_01_28_200235;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(185, 178);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // Txtescolhacomb
            // 
            Txtescolhacomb.AutoSize = true;
            Txtescolhacomb.Dock = DockStyle.Fill;
            Txtescolhacomb.Font = new Font("Segoe UI", 25F);
            Txtescolhacomb.Location = new Point(400, 0);
            Txtescolhacomb.Name = "Txtescolhacomb";
            Txtescolhacomb.Size = new Size(948, 199);
            Txtescolhacomb.TabIndex = 0;
            Txtescolhacomb.Text = "Escolha qual tipo de combustível você deseja abastecer!";
            Txtescolhacomb.TextAlign = ContentAlignment.MiddleLeft;
            Txtescolhacomb.Click += Txtescolhacomb_Click;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.Controls.Add(button1);
            flowLayoutPanel.Controls.Add(button2);
            flowLayoutPanel.Controls.Add(button3);
            flowLayoutPanel.Controls.Add(button4);
            flowLayoutPanel.Controls.Add(button5);
            flowLayoutPanel.Controls.Add(button6);
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.Location = new Point(400, 202);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(948, 335);
            flowLayoutPanel.TabIndex = 1;
            flowLayoutPanel.WrapContents = false;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Font = new Font("Arial", 14F, FontStyle.Bold);
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(844, 50);
            button1.TabIndex = 0;
            button1.Text = "Gasolina Comum";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Font = new Font("Arial", 14F, FontStyle.Bold);
            button2.Location = new Point(3, 59);
            button2.Name = "button2";
            button2.Size = new Size(844, 50);
            button2.TabIndex = 1;
            button2.Text = "Etanol";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.Font = new Font("Arial", 14F, FontStyle.Bold);
            button3.Location = new Point(3, 115);
            button3.Name = "button3";
            button3.Size = new Size(844, 50);
            button3.TabIndex = 2;
            button3.Text = "Gasolina Aditivada";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.White;
            button4.Font = new Font("Arial", 14F, FontStyle.Bold);
            button4.Location = new Point(3, 171);
            button4.Name = "button4";
            button4.Size = new Size(844, 50);
            button4.TabIndex = 3;
            button4.Text = "Diesel Comum";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.White;
            button5.Font = new Font("Arial", 14F, FontStyle.Bold);
            button5.Location = new Point(3, 227);
            button5.Name = "button5";
            button5.Size = new Size(844, 50);
            button5.TabIndex = 4;
            button5.Text = "Diesel S-10";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.White;
            button6.Font = new Font("Arial", 14F, FontStyle.Bold);
            button6.Location = new Point(3, 283);
            button6.Name = "button6";
            button6.Size = new Size(844, 50);
            button6.TabIndex = 5;
            button6.Text = "GNV";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button7.BackColor = Color.White;
            button7.Location = new Point(146, 549);
            button7.Name = "button7";
            button7.Size = new Size(248, 48);
            button7.TabIndex = 17;
            button7.Text = "Desistir";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click_1;
            // 
            // EscolherComb
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1498, 600);
            Controls.Add(tableLayoutPanel);
            Name = "EscolherComb";
            Text = "EscolherComb";
            Load += EscolherComb_Load;
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private PictureBox pictureBox1;
        private Button button7;
    }
}
