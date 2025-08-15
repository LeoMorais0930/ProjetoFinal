namespace ProjetoFinal
{
    partial class formteste : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnPedirDigital;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.Label lblCardToken;

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
            btnPedirDigital = new Button();
            lblCustomerId = new Label();
            lblCardToken = new Label();
            SuspendLayout();
            // 
            // btnPedirDigital
            // 
            btnPedirDigital.Location = new Point(12, 12);
            btnPedirDigital.Name = "btnPedirDigital";
            btnPedirDigital.Size = new Size(260, 23);
            btnPedirDigital.TabIndex = 0;
            btnPedirDigital.Text = "Pedir Digital";
            btnPedirDigital.UseVisualStyleBackColor = true;
            btnPedirDigital.Click += btnPedirDigital_Click;
            // 
            // lblCustomerId
            // 
            lblCustomerId.AutoSize = true;
            lblCustomerId.Location = new Point(12, 50);
            lblCustomerId.Name = "lblCustomerId";
            lblCustomerId.Size = new Size(76, 15);
            lblCustomerId.TabIndex = 1;
            lblCustomerId.Text = "Customer ID:";
            // 
            // lblCardToken
            // 
            lblCardToken.AutoSize = true;
            lblCardToken.Location = new Point(12, 80);
            lblCardToken.Name = "lblCardToken";
            lblCardToken.Size = new Size(69, 15);
            lblCardToken.TabIndex = 2;
            lblCardToken.Text = "Card Token:";
            // 
            // formteste
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 111);
            Controls.Add(lblCardToken);
            Controls.Add(lblCustomerId);
            Controls.Add(btnPedirDigital);
            Name = "formteste";
            Text = "formteste";
            Load += formteste_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
