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
            pnlEncabezado = new Panel();
            lblVentaId = new Label();
            lblFecha = new Label();
            lblCliente = new Label();
            pnlDetalle = new Panel();
            pnlTotales = new Panel();
            lblTotal = new Label();
            btnExportarPDF = new Button();
            pnlEncabezado.SuspendLayout();
            pnlTotales.SuspendLayout();
            SuspendLayout();
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.BorderStyle = BorderStyle.FixedSingle;
            pnlEncabezado.Controls.Add(lblVentaId);
            pnlEncabezado.Controls.Add(lblFecha);
            pnlEncabezado.Controls.Add(lblCliente);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(500, 100);
            pnlEncabezado.TabIndex = 1;
            pnlEncabezado.Paint += pnlEncabezado_Paint;
            // 
            // lblVentaId
            // 
            lblVentaId.AutoSize = true;
            lblVentaId.Font = new Font("Consolas", 12F, FontStyle.Bold);
            lblVentaId.Location = new Point(10, 10);
            lblVentaId.Name = "lblVentaId";
            lblVentaId.Size = new Size(0, 19);
            lblVentaId.TabIndex = 0;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Consolas", 10F);
            lblFecha.Location = new Point(10, 40);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(0, 17);
            lblFecha.TabIndex = 1;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Consolas", 10F);
            lblCliente.Location = new Point(10, 65);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(0, 17);
            lblCliente.TabIndex = 2;
            // 
            // pnlDetalle
            // 
            pnlDetalle.AutoScroll = true;
            pnlDetalle.BorderStyle = BorderStyle.FixedSingle;
            pnlDetalle.Dock = DockStyle.Top;
            pnlDetalle.Location = new Point(0, 100);
            pnlDetalle.Name = "pnlDetalle";
            pnlDetalle.Size = new Size(500, 300);
            pnlDetalle.TabIndex = 0;
            // 
            // pnlTotales
            // 
            pnlTotales.BorderStyle = BorderStyle.FixedSingle;
            pnlTotales.Controls.Add(lblTotal);
            pnlTotales.Controls.Add(btnExportarPDF);
            pnlTotales.Dock = DockStyle.Bottom;
            pnlTotales.Location = new Point(0, 420);
            pnlTotales.Name = "pnlTotales";
            pnlTotales.Size = new Size(500, 80);
            pnlTotales.TabIndex = 2;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Consolas", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(10, 10);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(0, 19);
            lblTotal.TabIndex = 0;
            // 
            // btnExportarPDF
            // 
            btnExportarPDF.Location = new Point(350, 20);
            btnExportarPDF.Name = "btnExportarPDF";
            btnExportarPDF.Size = new Size(120, 40);
            btnExportarPDF.TabIndex = 1;
            btnExportarPDF.Text = "Exportar PDF";
            btnExportarPDF.Click += btnExportarPDF_Click;
            // 
            // FrmReporteVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 500);
            Controls.Add(pnlDetalle);
            Controls.Add(pnlEncabezado);
            Controls.Add(pnlTotales);
            Name = "FrmReporteVenta";
            Text = "Reporte de Venta";
            Load += FrmReporteVenta_Load;
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            pnlTotales.ResumeLayout(false);
            pnlTotales.PerformLayout();
            ResumeLayout(false);
        }
    }
}
