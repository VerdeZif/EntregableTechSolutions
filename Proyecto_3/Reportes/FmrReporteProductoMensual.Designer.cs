namespace Presentacion.Forms
{
    partial class FrmReporteProductoMensual
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Panel panelVistaPrevia;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.ComboBox cbAnio;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnExportarPDF;
        private System.Windows.Forms.Button btnImprimir;

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
            dgvReporte = new DataGridView();
            panelVistaPrevia = new Panel();
            cbMes = new ComboBox();
            cbAnio = new ComboBox();
            lblMes = new Label();
            lblAnio = new Label();
            btnGenerar = new Button();
            btnExportarPDF = new Button();
            btnImprimir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            SuspendLayout();
            // 
            // dgvReporte
            // 
            dgvReporte.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Location = new Point(12, 50);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.Size = new Size(400, 500);
            dgvReporte.TabIndex = 0;
            // 
            // panelVistaPrevia
            // 
            panelVistaPrevia.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panelVistaPrevia.AutoScroll = true;
            panelVistaPrevia.BorderStyle = BorderStyle.FixedSingle;
            panelVistaPrevia.Location = new Point(420, 50);
            panelVistaPrevia.Name = "panelVistaPrevia";
            panelVistaPrevia.Size = new Size(550, 500);
            panelVistaPrevia.TabIndex = 1;
            // 
            // cbMes
            // 
            cbMes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMes.FormattingEnabled = true;
            cbMes.Location = new Point(50, 12);
            cbMes.Name = "cbMes";
            cbMes.Size = new Size(121, 23);
            cbMes.TabIndex = 2;
            // 
            // cbAnio
            // 
            cbAnio.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAnio.FormattingEnabled = true;
            cbAnio.Location = new Point(220, 12);
            cbAnio.Name = "cbAnio";
            cbAnio.Size = new Size(100, 23);
            cbAnio.TabIndex = 3;
            // 
            // lblMes
            // 
            lblMes.AutoSize = true;
            lblMes.Location = new Point(12, 15);
            lblMes.Name = "lblMes";
            lblMes.Size = new Size(32, 15);
            lblMes.TabIndex = 4;
            lblMes.Text = "Mes:";
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Location = new Point(180, 15);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(32, 15);
            lblAnio.TabIndex = 5;
            lblAnio.Text = "Año:";
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(330, 12);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(80, 23);
            btnGenerar.TabIndex = 6;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // btnExportarPDF
            // 
            btnExportarPDF.Location = new Point(784, 15);
            btnExportarPDF.Name = "btnExportarPDF";
            btnExportarPDF.Size = new Size(90, 23);
            btnExportarPDF.TabIndex = 7;
            btnExportarPDF.Text = "Exportar PDF";
            btnExportarPDF.UseVisualStyleBackColor = true;
            btnExportarPDF.Click += btnExportarPDF_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(890, 15);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(80, 23);
            btnImprimir.TabIndex = 8;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // FrmReporteProductoMensual
            // 
            ClientSize = new Size(984, 561);
            Controls.Add(btnImprimir);
            Controls.Add(btnExportarPDF);
            Controls.Add(btnGenerar);
            Controls.Add(lblAnio);
            Controls.Add(lblMes);
            Controls.Add(cbAnio);
            Controls.Add(cbMes);
            Controls.Add(panelVistaPrevia);
            Controls.Add(dgvReporte);
            Name = "FrmReporteProductoMensual";
            Text = "Reporte Mensual por Producto";
            Load += FrmReporteProductoMensual_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
