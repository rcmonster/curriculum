namespace WindowsFormsApp2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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
            this.btnCarregarPDF = new System.Windows.Forms.Button();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.txtVagasRecomendadas = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCarregarPDF
            // 
            this.btnCarregarPDF.Location = new System.Drawing.Point(12, 12);
            this.btnCarregarPDF.Name = "btnCarregarPDF";
            this.btnCarregarPDF.Size = new System.Drawing.Size(75, 23);
            this.btnCarregarPDF.TabIndex = 0;
            this.btnCarregarPDF.Text = "Carregar PDF";
            this.btnCarregarPDF.UseVisualStyleBackColor = true;
            this.btnCarregarPDF.Click += new System.EventHandler(this.btnCarregarPDF_Click);
            // 
            // txtResultado
            // 
            this.txtResultado.Location = new System.Drawing.Point(12, 41);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultado.Size = new System.Drawing.Size(776, 150);
            this.txtResultado.TabIndex = 1;
            this.txtResultado.Text = "Habilidades e Formação aparecerão aqui...";
            // 
            // txtVagasRecomendadas
            // 
            this.txtVagasRecomendadas.Location = new System.Drawing.Point(12, 197);
            this.txtVagasRecomendadas.Multiline = true;
            this.txtVagasRecomendadas.Name = "txtVagasRecomendadas";
            this.txtVagasRecomendadas.ReadOnly = true;
            this.txtVagasRecomendadas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtVagasRecomendadas.Size = new System.Drawing.Size(776, 241);
            this.txtVagasRecomendadas.TabIndex = 2;
            this.txtVagasRecomendadas.Text = "Vagas recomendadas aparecerão aqui...";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtVagasRecomendadas);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.btnCarregarPDF);
            this.Name = "Form1";
            this.Text = "Analisador de Currículo";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnCarregarPDF;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.TextBox txtVagasRecomendadas;
    }
}
