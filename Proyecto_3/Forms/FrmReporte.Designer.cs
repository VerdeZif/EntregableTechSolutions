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
            dgvVentas = new DataGridView();
            btnReporteVendedorMensual = new Button();
            btnReporteClienteMensual = new Button();
            btnReporteProductoMensual = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = SystemColors.Control;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(203, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REPORTE DE VENTAS";
            // 
            // chkRangoFechas
            // 
            chkRangoFechas.AutoSize = true;
            chkRangoFechas.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkRangoFechas.Location = new Point(11, 53);
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
            dtpInicio.Location = new Point(126, 53);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(200, 23);
            dtpInicio.TabIndex = 2;
            // 
            // dtpFin
            // 
            dtpFin.Enabled = false;
            dtpFin.Format = DateTimePickerFormat.Short;
            dtpFin.Location = new Point(445, 55);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(200, 23);
            dtpFin.TabIndex = 3;
            // 
            // cbCliente
            // 
            cbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCliente.Location = new Point(126, 94);
            cbCliente.Name = "cbCliente";
            cbCliente.Size = new Size(200, 23);
            cbCliente.TabIndex = 4;
            // 
            // cbVendedor
            // 
            cbVendedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVendedor.Location = new Point(445, 93);
            cbVendedor.Name = "cbVendedor";
            cbVendedor.Size = new Size(200, 23);
            cbVendedor.TabIndex = 5;
            // 
            // txtTotalMin
            // 
            txtTotalMin.Location = new Point(126, 130);
            txtTotalMin.Name = "txtTotalMin";
            txtTotalMin.Size = new Size(200, 23);
            txtTotalMin.TabIndex = 6;
            // 
            // txtTotalMax
            // 
            txtTotalMax.Location = new Point(445, 130);
            txtTotalMax.Name = "txtTotalMax";
            txtTotalMax.Size = new Size(200, 23);
            txtTotalMax.TabIndex = 7;
            // 
            // lblCliente
            // 
            lblCliente.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblCliente.Location = new Point(29, 93);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(73, 23);
            lblCliente.TabIndex = 8;
            lblCliente.Text = "CLIENTE:";
            // 
            // lblVendedor
            // 
            lblVendedor.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVendedor.Location = new Point(347, 93);
            lblVendedor.Name = "lblVendedor";
            lblVendedor.Size = new Size(100, 23);
            lblVendedor.TabIndex = 9;
            lblVendedor.Text = "VENDEDOR:";
            // 
            // lblTotalMin
            // 
            lblTotalMin.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalMin.Location = new Point(29, 133);
            lblTotalMin.Name = "lblTotalMin";
            lblTotalMin.Size = new Size(100, 23);
            lblTotalMin.TabIndex = 10;
            lblTotalMin.Text = "TOTAL MIN:";
            // 
            // lblTotalMax
            // 
            lblTotalMax.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalMax.Location = new Point(347, 130);
            lblTotalMax.Name = "lblTotalMax";
            lblTotalMax.Size = new Size(92, 23);
            lblTotalMax.TabIndex = 11;
            lblTotalMax.Text = "TOTAL MAX:";
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.Lavender;
            btnBuscar.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnBuscar.Location = new Point(664, 55);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 33);
            btnBuscar.TabIndex = 12;
            btnBuscar.Text = "BUSCAR";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.PaleTurquoise;
            btnLimpiar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.Location = new Point(664, 94);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 34);
            btnLimpiar.TabIndex = 13;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.BackColor = Color.GreenYellow;
            btnVerDetalle.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnVerDetalle.Location = new Point(29, 489);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(115, 35);
            btnVerDetalle.TabIndex = 14;
            btnVerDetalle.Text = "VER TICKET";
            btnVerDetalle.UseVisualStyleBackColor = false;
            btnVerDetalle.Click += btnVerDetalle_Click;
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
            btnReporteVendedorMensual.BackColor = Color.LemonChiffon;
            btnReporteVendedorMensual.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnReporteVendedorMensual.Location = new Point(195, 489);
            btnReporteVendedorMensual.Name = "btnReporteVendedorMensual";
            btnReporteVendedorMensual.Size = new Size(191, 35);
            btnReporteVendedorMensual.TabIndex = 17;
            btnReporteVendedorMensual.Text = "REPORTE VENDEDOR";
            btnReporteVendedorMensual.UseVisualStyleBackColor = false;
            btnReporteVendedorMensual.Click += btnReporteVendedorMensual_Click_1;
            // 
            // btnReporteClienteMensual
            // 
            btnReporteClienteMensual.BackColor = Color.LemonChiffon;
            btnReporteClienteMensual.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnReporteClienteMensual.Location = new Point(392, 489);
            btnReporteClienteMensual.Name = "btnReporteClienteMensual";
            btnReporteClienteMensual.Size = new Size(164, 35);
            btnReporteClienteMensual.TabIndex = 18;
            btnReporteClienteMensual.Text = "REPORTE CLIENTE";
            btnReporteClienteMensual.UseVisualStyleBackColor = false;
            btnReporteClienteMensual.Click += btnReporteClienteMensual_Click;
            // 
            // btnReporteProductoMensual
            // 
            btnReporteProductoMensual.BackColor = Color.LemonChiffon;
            btnReporteProductoMensual.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnReporteProductoMensual.Location = new Point(562, 489);
            btnReporteProductoMensual.Name = "btnReporteProductoMensual";
            btnReporteProductoMensual.Size = new Size(167, 35);
            btnReporteProductoMensual.TabIndex = 19;
            btnReporteProductoMensual.Text = "REPORTE PRODUCTO";
            btnReporteProductoMensual.UseVisualStyleBackColor = false;
            btnReporteProductoMensual.Click += btnReporteProductoMensual_Click;
            // 
            // FrmReporte
            // 
            BackColor = SystemColors.GradientInactiveCaption;
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
            Controls.Add(dgvVentas);
            Name = "FrmReporte";
            Text = "REPORTE DE VENTAS";
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
