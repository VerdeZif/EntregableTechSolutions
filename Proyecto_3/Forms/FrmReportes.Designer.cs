namespace Presentacion.Forms
{
    partial class FrmReportes
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Label lblDesde;
        private Label lblHasta;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Button btnBuscar;
        private Button btnVerDetalle;
        private DataGridView dgvReportes;

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
            lblDesde = new Label();
            lblHasta = new Label();
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            btnBuscar = new Button();
            btnVerDetalle = new Button();
            dgvReportes = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvReportes).BeginInit();
            SuspendLayout();

            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(230, 20);
            lblTitulo.Text = "Reportes de Ventas";

            // lblDesde
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(40, 80);
            lblDesde.Text = "Desde:";

            // dtpDesde
            dtpDesde.Location = new Point(100, 75);
            dtpDesde.Width = 200;

            // lblHasta
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(320, 80);
            lblHasta.Text = "Hasta:";

            // dtpHasta
            dtpHasta.Location = new Point(380, 75);
            dtpHasta.Width = 200;

            // btnBuscar
            btnBuscar.Text = "Buscar";
            btnBuscar.Location = new Point(600, 75);
            btnBuscar.Click += btnBuscar_Click;

            // dgvReportes
            dgvReportes.Location = new Point(40, 130);
            dgvReportes.Size = new Size(700, 250);
            dgvReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReportes.ReadOnly = true;

            // btnVerDetalle
            btnVerDetalle.Text = "Ver Detalle";
            btnVerDetalle.Location = new Point(40, 400);
            btnVerDetalle.Click += btnVerDetalle_Click;

            // FrmReportes
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 460);
            Controls.Add(lblTitulo);
            Controls.Add(lblDesde);
            Controls.Add(dtpDesde);
            Controls.Add(lblHasta);
            Controls.Add(dtpHasta);
            Controls.Add(btnBuscar);
            Controls.Add(dgvReportes);
            Controls.Add(btnVerDetalle);
            Name = "FrmReportes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reportes de Ventas";
            Load += FrmReportes_Load;

            ((System.ComponentModel.ISupportInitialize)dgvReportes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
