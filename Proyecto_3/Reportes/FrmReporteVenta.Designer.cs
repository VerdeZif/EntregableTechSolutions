namespace Presentacion.Forms
{
    partial class FrmReporteVenta
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlEncabezado;
        private Panel pnlDetalle;
        private Panel pnlTotales;
        private Label lblVentaId;
        private Label lblFecha;
        private Label lblCliente;
        private Label lblTotal;
        private Button btnExportarPDF;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblVentaId = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.pnlTotales = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnExportarPDF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEncabezado.Controls.Add(this.lblVentaId);
            this.pnlEncabezado.Controls.Add(this.lblFecha);
            this.pnlEncabezado.Controls.Add(this.lblCliente);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Height = 100;
            // 
            // lblVentaId
            // 
            this.lblVentaId.AutoSize = true;
            this.lblVentaId.Location = new System.Drawing.Point(10, 10);
            this.lblVentaId.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(10, 40);
            this.lblFecha.Font = new System.Drawing.Font("Consolas", 10F);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(10, 65);
            this.lblCliente.Font = new System.Drawing.Font("Consolas", 10F);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetalle.Height = 300;
            this.pnlDetalle.AutoScroll = true;
            // 
            // pnlTotales
            // 
            this.pnlTotales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTotales.Controls.Add(this.lblTotal);
            this.pnlTotales.Controls.Add(this.btnExportarPDF);
            this.pnlTotales.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotales.Height = 80;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(10, 10);
            this.lblTotal.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.Location = new System.Drawing.Point(350, 20);
            this.btnExportarPDF.Size = new System.Drawing.Size(120, 40);
            this.btnExportarPDF.Text = "Exportar PDF";
            this.btnExportarPDF.Click += new System.EventHandler(this.btnExportarPDF_Click);
            // 
            // FrmReporteVenta
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.pnlDetalle);
            this.Controls.Add(this.pnlEncabezado);
            this.Controls.Add(this.pnlTotales);
            this.Text = "Reporte de Venta";
            this.Load += new System.EventHandler(this.FrmReporteVenta_Load);
            this.ResumeLayout(false);
        }
    }
}
