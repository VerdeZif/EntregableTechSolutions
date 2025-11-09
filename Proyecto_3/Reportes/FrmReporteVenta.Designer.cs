namespace Presentacion.Forms
{
    partial class FrmReporteVenta
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Label lblVentaId;
        private Label lblFecha;
        private Label lblCliente;
        private Label lblTotal;
        private DataGridView dgvDetalle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblVentaId = new Label();
            lblFecha = new Label();
            lblCliente = new Label();
            lblTotal = new Label();
            dgvDetalle = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            SuspendLayout();

            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(220, 20);
            lblTitulo.Text = "Detalle de Venta";

            // lblVentaId
            lblVentaId.AutoSize = true;
            lblVentaId.Location = new Point(40, 80);
            lblVentaId.Text = "Venta N°:";

            // lblFecha
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(40, 110);
            lblFecha.Text = "Fecha:";

            // lblCliente
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(40, 140);
            lblCliente.Text = "Cliente:";

            // lblTotal
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotal.Location = new Point(40, 170);
            lblTotal.Text = "Total:";

            // dgvDetalle
            dgvDetalle.Location = new Point(40, 210);
            dgvDetalle.Size = new Size(700, 220);
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.ReadOnly = true;

            // FrmReporteVenta
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 460);
            Controls.Add(lblTitulo);
            Controls.Add(lblVentaId);
            Controls.Add(lblFecha);
            Controls.Add(lblCliente);
            Controls.Add(lblTotal);
            Controls.Add(dgvDetalle);
            Name = "FrmReporteVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle de Venta";
            Load += FrmReporteVenta_Load;

            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
