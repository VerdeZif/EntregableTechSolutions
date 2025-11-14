namespace Presentacion.Forms
{
    partial class FrmReporteVentaIndividual
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Button btnExportarPDF;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCerrar;

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
            pictureBoxPreview = new PictureBox();
            btnExportarPDF = new Button();
            btnImprimir = new Button();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxPreview
            // 
            pictureBoxPreview.BackColor = Color.White;
            pictureBoxPreview.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxPreview.Location = new Point(31, 12);
            pictureBoxPreview.Name = "pictureBoxPreview";
            pictureBoxPreview.Size = new Size(445, 595);
            pictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPreview.TabIndex = 0;
            pictureBoxPreview.TabStop = false;
            // 
            // btnExportarPDF
            // 
            btnExportarPDF.BackColor = Color.FromArgb(52, 152, 219);
            btnExportarPDF.FlatStyle = FlatStyle.Flat;
            btnExportarPDF.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExportarPDF.ForeColor = Color.White;
            btnExportarPDF.Location = new Point(12, 613);
            btnExportarPDF.Name = "btnExportarPDF";
            btnExportarPDF.Size = new Size(150, 35);
            btnExportarPDF.TabIndex = 1;
            btnExportarPDF.Text = "Exportar PDF";
            btnExportarPDF.UseVisualStyleBackColor = false;
            btnExportarPDF.Click += btnExportarPDF_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.FromArgb(46, 204, 113);
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnImprimir.ForeColor = Color.White;
            btnImprimir.Location = new Point(168, 613);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(167, 35);
            btnImprimir.TabIndex = 2;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.FromArgb(231, 76, 60);
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(341, 613);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(150, 35);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FrmReporteVentaIndividual
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(503, 751);
            Controls.Add(btnCerrar);
            Controls.Add(btnImprimir);
            Controls.Add(btnExportarPDF);
            Controls.Add(pictureBoxPreview);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmReporteVentaIndividual";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ticket de Venta (Vista Previa)";
            Load += FrmReporteVentaIndividual_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).EndInit();
            ResumeLayout(false);
        }
    }
}
