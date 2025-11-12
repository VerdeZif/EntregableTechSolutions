namespace Presentacion.Forms
{
    partial class FrmReporte
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.CheckBox chkRangoFechas;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.ComboBox cbVendedor;
        private System.Windows.Forms.TextBox txtTotalMin;
        private System.Windows.Forms.TextBox txtTotalMax;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Label lblTotalMin;
        private System.Windows.Forms.Label lblTotalMax;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.Button btnExportarPDF;
        private System.Windows.Forms.DataGridView dgvVentas;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            chkRangoFechas = new CheckBox();
            dtpInicio = new DateTimePicker();
            dtpFin = new DateTimePicker();
            cbCliente = new ComboBox();
            cbVendedor = new ComboBox();
            txtTotalMin = new TextBox();
            txtTotalMax = new TextBox();
            lblCliente = new Label();
            lblVendedor = new Label();
            lblTotalMin = new Label();
            lblTotalMax = new Label();
            btnBuscar = new Button();
            btnLimpiar = new Button();
            btnVerDetalle = new Button();
            btnExportarPDF = new Button();
            dgvVentas = new DataGridView();
            btnReporteVendedorMensual = new Button();
            btnReporteClienteMensual = new Button();
            btnReporteProductoMensual = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(300, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Reporte de Ventas";
            // 
            // chkRangoFechas
            // 
            chkRangoFechas.AutoSize = true;
            chkRangoFechas.Location = new Point(20, 55);
            chkRangoFechas.Name = "chkRangoFechas";
            chkRangoFechas.Size = new Size(109, 19);
            chkRangoFechas.TabIndex = 1;
            chkRangoFechas.Text = "Filtrar por fecha";
            chkRangoFechas.CheckedChanged += chkRangoFechas_CheckedChanged;
            // 
            // dtpInicio
            // 
            dtpInicio.Enabled = false;
            dtpInicio.Format = DateTimePickerFormat.Short;
            dtpInicio.Location = new Point(150, 53);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(200, 23);
            dtpInicio.TabIndex = 2;
            // 
            // dtpFin
            // 
            dtpFin.Enabled = false;
            dtpFin.Format = DateTimePickerFormat.Short;
            dtpFin.Location = new Point(389, 53);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(200, 23);
            dtpFin.TabIndex = 3;
            // 
            // cbCliente
            // 
            cbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCliente.Location = new Point(80, 90);
            cbCliente.Name = "cbCliente";
            cbCliente.Size = new Size(200, 23);
            cbCliente.TabIndex = 4;
            // 
            // cbVendedor
            // 
            cbVendedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVendedor.Location = new Point(370, 90);
            cbVendedor.Name = "cbVendedor";
            cbVendedor.Size = new Size(200, 23);
            cbVendedor.TabIndex = 5;
            // 
            // txtTotalMin
            // 
            txtTotalMin.Location = new Point(100, 130);
            txtTotalMin.Name = "txtTotalMin";
            txtTotalMin.Size = new Size(100, 23);
            txtTotalMin.TabIndex = 6;
            // 
            // txtTotalMax
            // 
            txtTotalMax.Location = new Point(270, 130);
            txtTotalMax.Name = "txtTotalMax";
            txtTotalMax.Size = new Size(100, 23);
            txtTotalMax.TabIndex = 7;
            // 
            // lblCliente
            // 
            lblCliente.Location = new Point(20, 93);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(100, 23);
            lblCliente.TabIndex = 8;
            lblCliente.Text = "Cliente:";
            // 
            // lblVendedor
            // 
            lblVendedor.Location = new Point(300, 93);
            lblVendedor.Name = "lblVendedor";
            lblVendedor.Size = new Size(100, 23);
            lblVendedor.TabIndex = 9;
            lblVendedor.Text = "Vendedor:";
            // 
            // lblTotalMin
            // 
            lblTotalMin.Location = new Point(20, 133);
            lblTotalMin.Name = "lblTotalMin";
            lblTotalMin.Size = new Size(100, 23);
            lblTotalMin.TabIndex = 10;
            lblTotalMin.Text = "Total Min:";
            // 
            // lblTotalMax
            // 
            lblTotalMax.Location = new Point(210, 133);
            lblTotalMax.Name = "lblTotalMax";
            lblTotalMax.Size = new Size(100, 23);
            lblTotalMax.TabIndex = 11;
            lblTotalMax.Text = "Total Max:";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(640, 55);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 12;
            btnBuscar.Text = "Buscar";
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(640, 93);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 13;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.Location = new Point(29, 489);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(100, 23);
            btnVerDetalle.TabIndex = 14;
            btnVerDetalle.Text = "Ver Ticket";
            btnVerDetalle.Click += btnVerDetalle_Click;
            // 
            // btnExportarPDF
            // 
            btnExportarPDF.Location = new Point(135, 489);
            btnExportarPDF.Name = "btnExportarPDF";
            btnExportarPDF.Size = new Size(108, 23);
            btnExportarPDF.TabIndex = 15;
            btnExportarPDF.Text = "Exportar PDF";
            btnExportarPDF.Click += btnExportarPDF_Click;
            // 
            // dgvVentas
            // 
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.Location = new Point(29, 172);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.Size = new Size(700, 300);
            dgvVentas.TabIndex = 16;
            dgvVentas.CellDoubleClick += dgvVentas_CellDoubleClick;
            // 
            // btnReporteVendedorMensual
            // 
            btnReporteVendedorMensual.Location = new Point(387, 489);
            btnReporteVendedorMensual.Name = "btnReporteVendedorMensual";
            btnReporteVendedorMensual.Size = new Size(110, 23);
            btnReporteVendedorMensual.TabIndex = 17;
            btnReporteVendedorMensual.Text = "Reporte Vendedor";
            btnReporteVendedorMensual.Click += btnReporteVendedorMensual_Click_1;
            // 
            // btnReporteClienteMensual
            // 
            btnReporteClienteMensual.Location = new Point(503, 489);
            btnReporteClienteMensual.Name = "btnReporteClienteMensual";
            btnReporteClienteMensual.Size = new Size(110, 23);
            btnReporteClienteMensual.TabIndex = 18;
            btnReporteClienteMensual.Text = "Reporte Cliente";
            btnReporteClienteMensual.Click += btnReporteClienteMensual_Click;
            // 
            // btnReporteProductoMensual
            // 
            btnReporteProductoMensual.Location = new Point(619, 489);
            btnReporteProductoMensual.Name = "btnReporteProductoMensual";
            btnReporteProductoMensual.Size = new Size(110, 23);
            btnReporteProductoMensual.TabIndex = 19;
            btnReporteProductoMensual.Text = "Reporte Producto";
            btnReporteProductoMensual.Click += btnReporteProductoMensual_Click;
            // 
            // FrmReporte
            // 
            ClientSize = new Size(760, 550);
            Controls.Add(btnReporteProductoMensual);
            Controls.Add(btnReporteClienteMensual);
            Controls.Add(btnReporteVendedorMensual);
            Controls.Add(lblTitulo);
            Controls.Add(chkRangoFechas);
            Controls.Add(dtpInicio);
            Controls.Add(dtpFin);
            Controls.Add(cbCliente);
            Controls.Add(cbVendedor);
            Controls.Add(txtTotalMin);
            Controls.Add(txtTotalMax);
            Controls.Add(lblCliente);
            Controls.Add(lblVendedor);
            Controls.Add(lblTotalMin);
            Controls.Add(lblTotalMax);
            Controls.Add(btnBuscar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnVerDetalle);
            Controls.Add(btnExportarPDF);
            Controls.Add(dgvVentas);
            Name = "FrmReporte";
            Text = "Reporte de Ventas";
            Load += FrmReporte_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Button btnReporteVendedorMensual;
        private Button btnReporteClienteMensual;
        private Button btnReporteProductoMensual;
    }
}
