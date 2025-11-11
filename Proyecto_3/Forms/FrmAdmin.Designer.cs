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
        private System.Windows.Forms.Button btnEditarPerfil;
        private System.Windows.Forms.Button btnCerrarSesion;
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
            groupBoxAdmin = new GroupBox();
            pbAdminFoto = new PictureBox();
            txtAdminNombre = new TextBox();
            lblAdminNombre = new Label();
            btnEditarPerfil = new Button();
            btnCerrarSesion = new Button();
            groupBoxGestion = new GroupBox();
            btnGestionClientes = new Button();
            btnGestionVendedores = new Button();
            btnGestionProductos = new Button();
            btnVerReportes = new Button();
            lblVentas = new Label();
            dgvVentas = new DataGridView();
            groupBoxAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbAdminFoto).BeginInit();
            groupBoxGestion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // groupBoxAdmin
            // 
            groupBoxAdmin.Controls.Add(pbAdminFoto);
            groupBoxAdmin.Controls.Add(txtAdminNombre);
            groupBoxAdmin.Controls.Add(lblAdminNombre);
            groupBoxAdmin.Controls.Add(btnEditarPerfil);
            groupBoxAdmin.Controls.Add(btnCerrarSesion);
            groupBoxAdmin.Dock = DockStyle.Top;
            groupBoxAdmin.Location = new Point(0, 0);
            groupBoxAdmin.Name = "groupBoxAdmin";
            groupBoxAdmin.Size = new Size(800, 150);
            groupBoxAdmin.TabIndex = 3;
            groupBoxAdmin.TabStop = false;
            groupBoxAdmin.Text = "Datos del Administrador";
            // 
            // pbAdminFoto
            // 
            pbAdminFoto.BorderStyle = BorderStyle.FixedSingle;
            pbAdminFoto.Location = new Point(360, 20);
            pbAdminFoto.Name = "pbAdminFoto";
            pbAdminFoto.Size = new Size(100, 100);
            pbAdminFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pbAdminFoto.TabIndex = 0;
            pbAdminFoto.TabStop = false;
            // 
            // txtAdminNombre
            // 
            txtAdminNombre.Location = new Point(130, 37);
            txtAdminNombre.Name = "txtAdminNombre";
            txtAdminNombre.ReadOnly = true;
            txtAdminNombre.Size = new Size(200, 23);
            txtAdminNombre.TabIndex = 1;
            // 
            // lblAdminNombre
            // 
            lblAdminNombre.Location = new Point(20, 40);
            lblAdminNombre.Name = "lblAdminNombre";
            lblAdminNombre.Size = new Size(100, 20);
            lblAdminNombre.TabIndex = 2;
            lblAdminNombre.Text = "Nombre:";
            // 
            // btnEditarPerfil
            // 
            btnEditarPerfil.Location = new Point(130, 70);
            btnEditarPerfil.Name = "btnEditarPerfil";
            btnEditarPerfil.Size = new Size(150, 30);
            btnEditarPerfil.TabIndex = 3;
            btnEditarPerfil.Text = "Gestionar Perfil";
            btnEditarPerfil.Click += btnEditarPerfil_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(644, 20);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(150, 30);
            btnCerrarSesion.TabIndex = 4;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // groupBoxGestion
            // 
            groupBoxGestion.Controls.Add(btnGestionClientes);
            groupBoxGestion.Controls.Add(btnGestionVendedores);
            groupBoxGestion.Controls.Add(btnGestionProductos);
            groupBoxGestion.Controls.Add(btnVerReportes);
            groupBoxGestion.Dock = DockStyle.Top;
            groupBoxGestion.Location = new Point(0, 150);
            groupBoxGestion.Name = "groupBoxGestion";
            groupBoxGestion.Size = new Size(800, 100);
            groupBoxGestion.TabIndex = 2;
            groupBoxGestion.TabStop = false;
            groupBoxGestion.Text = "Gestión";
            // 
            // btnGestionClientes
            // 
            btnGestionClientes.Location = new Point(20, 30);
            btnGestionClientes.Name = "btnGestionClientes";
            btnGestionClientes.Size = new Size(150, 40);
            btnGestionClientes.TabIndex = 0;
            btnGestionClientes.Text = "Gestionar Clientes";
            btnGestionClientes.Click += btnGestionClientes_Click;
            // 
            // btnGestionVendedores
            // 
            btnGestionVendedores.Location = new Point(200, 30);
            btnGestionVendedores.Name = "btnGestionVendedores";
            btnGestionVendedores.Size = new Size(150, 40);
            btnGestionVendedores.TabIndex = 1;
            btnGestionVendedores.Text = "Gestionar Vendedores";
            btnGestionVendedores.Click += btnGestionVendedores_Click;
            // 
            // btnGestionProductos
            // 
            btnGestionProductos.Location = new Point(380, 30);
            btnGestionProductos.Name = "btnGestionProductos";
            btnGestionProductos.Size = new Size(150, 40);
            btnGestionProductos.TabIndex = 2;
            btnGestionProductos.Text = "Gestionar Productos";
            btnGestionProductos.Click += btnGestionProductos_Click;
            // 
            // btnVerReportes
            // 
            btnVerReportes.Location = new Point(560, 30);
            btnVerReportes.Name = "btnVerReportes";
            btnVerReportes.Size = new Size(150, 40);
            btnVerReportes.TabIndex = 3;
            btnVerReportes.Text = "Ver Reporte Seleccionado";
            btnVerReportes.Click += btnVerReportes_Click;
            // 
            // lblVentas
            // 
            lblVentas.Location = new Point(20, 260);
            lblVentas.Name = "lblVentas";
            lblVentas.Size = new Size(150, 20);
            lblVentas.TabIndex = 1;
            lblVentas.Text = "Ventas registradas:";
            // 
            // dgvVentas
            // 
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.Location = new Point(20, 285);
            dgvVentas.MultiSelect = false;
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.Size = new Size(740, 200);
            dgvVentas.TabIndex = 0;
            // 
            // FrmAdmin
            // 
            ClientSize = new Size(800, 500);
            Controls.Add(dgvVentas);
            Controls.Add(lblVentas);
            Controls.Add(groupBoxGestion);
            Controls.Add(groupBoxAdmin);
            Name = "FrmAdmin";
            Text = "Panel de Administración";
            Load += FrmAdmin_Load;
            groupBoxAdmin.ResumeLayout(false);
            groupBoxAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbAdminFoto).EndInit();
            groupBoxGestion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
        }
    }
}
