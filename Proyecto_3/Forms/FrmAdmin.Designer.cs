namespace Presentacion.Forms
{
    partial class FrmAdmin
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblAdminNombre;
        private System.Windows.Forms.TextBox txtAdminNombre;
        private System.Windows.Forms.PictureBox pbAdminFoto;
        private System.Windows.Forms.Button btnGestionClientes;
        private System.Windows.Forms.Button btnGestionVendedores;
        private System.Windows.Forms.Button btnGestionProductos;
        private System.Windows.Forms.Button btnVerReportes;
        private System.Windows.Forms.GroupBox groupBoxAdmin;
        private System.Windows.Forms.GroupBox groupBoxGestion;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Label lblVentas;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBoxAdmin = new System.Windows.Forms.GroupBox();
            this.pbAdminFoto = new System.Windows.Forms.PictureBox();
            this.txtAdminNombre = new System.Windows.Forms.TextBox();
            this.lblAdminNombre = new System.Windows.Forms.Label();

            this.groupBoxGestion = new System.Windows.Forms.GroupBox();
            this.btnGestionClientes = new System.Windows.Forms.Button();
            this.btnGestionVendedores = new System.Windows.Forms.Button();
            this.btnGestionProductos = new System.Windows.Forms.Button();
            this.btnVerReportes = new System.Windows.Forms.Button();

            this.lblVentas = new System.Windows.Forms.Label();
            this.dgvVentas = new System.Windows.Forms.DataGridView();

            // 
            // groupBoxAdmin
            // 
            this.groupBoxAdmin.Controls.Add(this.pbAdminFoto);
            this.groupBoxAdmin.Controls.Add(this.txtAdminNombre);
            this.groupBoxAdmin.Controls.Add(this.lblAdminNombre);
            this.groupBoxAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxAdmin.Height = 150;
            this.groupBoxAdmin.Text = "Datos del Administrador";

            // 
            // lblAdminNombre
            // 
            this.lblAdminNombre.Location = new System.Drawing.Point(20, 40);
            this.lblAdminNombre.Size = new System.Drawing.Size(100, 20);
            this.lblAdminNombre.Text = "Nombre:";

            // 
            // txtAdminNombre
            // 
            this.txtAdminNombre.Location = new System.Drawing.Point(130, 37);
            this.txtAdminNombre.Size = new System.Drawing.Size(200, 22);
            this.txtAdminNombre.ReadOnly = true;

            // 
            // pbAdminFoto
            // 
            this.pbAdminFoto.Location = new System.Drawing.Point(360, 20);
            this.pbAdminFoto.Size = new System.Drawing.Size(100, 100);
            this.pbAdminFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAdminFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            // 
            // groupBoxGestion
            // 
            this.groupBoxGestion.Controls.Add(this.btnGestionClientes);
            this.groupBoxGestion.Controls.Add(this.btnGestionVendedores);
            this.groupBoxGestion.Controls.Add(this.btnGestionProductos);
            this.groupBoxGestion.Controls.Add(this.btnVerReportes);
            this.groupBoxGestion.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxGestion.Height = 100;
            this.groupBoxGestion.Text = "Gestión";

            // 
            // btnGestionClientes
            // 
            this.btnGestionClientes.Location = new System.Drawing.Point(20, 30);
            this.btnGestionClientes.Size = new System.Drawing.Size(150, 40);
            this.btnGestionClientes.Text = "Gestionar Clientes";
            this.btnGestionClientes.Click += new System.EventHandler(this.btnGestionClientes_Click);

            // 
            // btnGestionVendedores
            // 
            this.btnGestionVendedores.Location = new System.Drawing.Point(200, 30);
            this.btnGestionVendedores.Size = new System.Drawing.Size(150, 40);
            this.btnGestionVendedores.Text = "Gestionar Vendedores";
            this.btnGestionVendedores.Click += new System.EventHandler(this.btnGestionVendedores_Click);

            // 
            // btnGestionProductos
            // 
            this.btnGestionProductos.Location = new System.Drawing.Point(380, 30);
            this.btnGestionProductos.Size = new System.Drawing.Size(150, 40);
            this.btnGestionProductos.Text = "Gestionar Productos";
            this.btnGestionProductos.Click += new System.EventHandler(this.btnGestionProductos_Click);

            // 
            // btnVerReportes
            // 
            this.btnVerReportes.Location = new System.Drawing.Point(560, 30);
            this.btnVerReportes.Size = new System.Drawing.Size(150, 40);
            this.btnVerReportes.Text = "Ver Reporte Seleccionado";
            this.btnVerReportes.Click += new System.EventHandler(this.btnVerReportes_Click);

            // 
            // lblVentas
            // 
            this.lblVentas.Location = new System.Drawing.Point(20, 260);
            this.lblVentas.Size = new System.Drawing.Size(150, 20);
            this.lblVentas.Text = "Ventas registradas:";

            // 
            // dgvVentas
            // 
            this.dgvVentas.Location = new System.Drawing.Point(20, 285);
            this.dgvVentas.Size = new System.Drawing.Size(740, 200);
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentas.MultiSelect = false;
            this.dgvVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // 
            // FrmAdmin
            // 
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.dgvVentas);
            this.Controls.Add(this.lblVentas);
            this.Controls.Add(this.groupBoxGestion);
            this.Controls.Add(this.groupBoxAdmin);
            this.Text = "Panel de Administración";
            this.Load += new System.EventHandler(this.FrmAdmin_Load);
        }
    }
}
