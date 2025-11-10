namespace Presentacion.Forms
{
    partial class FrmVendedor
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnEditarPerfil;
        private System.Windows.Forms.Button btnGestionarClientes;
        private System.Windows.Forms.Button btnGestionarProductos;
        private System.Windows.Forms.Button btnGestionarVenta;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.GroupBox groupBoxDatos;
        private System.Windows.Forms.GroupBox groupBoxAcciones;
        private System.Windows.Forms.GroupBox groupBoxHistorial;

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
            this.groupBoxDatos = new System.Windows.Forms.GroupBox();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();

            this.groupBoxAcciones = new System.Windows.Forms.GroupBox();
            this.btnEditarPerfil = new System.Windows.Forms.Button();
            this.btnGestionarClientes = new System.Windows.Forms.Button();
            this.btnGestionarProductos = new System.Windows.Forms.Button();
            this.btnGestionarVenta = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();

            this.groupBoxHistorial = new System.Windows.Forms.GroupBox();
            this.dgvVentas = new System.Windows.Forms.DataGridView();

            // 
            // groupBoxDatos
            // 
            this.groupBoxDatos.Controls.Add(this.pbFoto);
            this.groupBoxDatos.Controls.Add(this.lblNombre);
            this.groupBoxDatos.Controls.Add(this.lblRole);
            this.groupBoxDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxDatos.Height = 120;
            this.groupBoxDatos.Text = "Datos del Vendedor";

            // 
            // pbFoto
            // 
            this.pbFoto.Location = new System.Drawing.Point(350, 20);
            this.pbFoto.Size = new System.Drawing.Size(80, 80);
            this.pbFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(20, 30);
            this.lblNombre.Size = new System.Drawing.Size(200, 20);
            this.lblNombre.Text = "Nombre: ";

            // 
            // lblRole
            // 
            this.lblRole.Location = new System.Drawing.Point(20, 60);
            this.lblRole.Size = new System.Drawing.Size(200, 20);
            this.lblRole.Text = "Rol: ";

            // 
            // groupBoxAcciones
            // 
            this.groupBoxAcciones.Controls.Add(this.btnEditarPerfil);
            this.groupBoxAcciones.Controls.Add(this.btnGestionarClientes);
            this.groupBoxAcciones.Controls.Add(this.btnGestionarProductos);
            this.groupBoxAcciones.Controls.Add(this.btnGestionarVenta);
            this.groupBoxAcciones.Controls.Add(this.btnCerrarSesion);
            this.groupBoxAcciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxAcciones.Height = 70;
            this.groupBoxAcciones.Text = "Acciones";

            // 
            // btnEditarPerfil
            // 
            this.btnEditarPerfil.Location = new System.Drawing.Point(20, 25);
            this.btnEditarPerfil.Size = new System.Drawing.Size(120, 30);
            this.btnEditarPerfil.Text = "Editar Perfil";
            this.btnEditarPerfil.Click += new System.EventHandler(this.btnEditarPerfil_Click);

            // 
            // btnGestionarClientes
            // 
            this.btnGestionarClientes.Location = new System.Drawing.Point(160, 25);
            this.btnGestionarClientes.Size = new System.Drawing.Size(120, 30);
            this.btnGestionarClientes.Text = "Gestionar Clientes";
            this.btnGestionarClientes.Click += new System.EventHandler(this.btnGestionarClientes_Click);

            // 
            // btnGestionarProductos
            // 
            this.btnGestionarProductos.Location = new System.Drawing.Point(300, 25);
            this.btnGestionarProductos.Size = new System.Drawing.Size(120, 30);
            this.btnGestionarProductos.Text = "Gestionar Productos";
            this.btnGestionarProductos.Click += new System.EventHandler(this.btnGestionarProductos_Click);

            // 
            // btnGestionarVenta
            // 
            this.btnGestionarVenta.Location = new System.Drawing.Point(440, 25);
            this.btnGestionarVenta.Size = new System.Drawing.Size(120, 30);
            this.btnGestionarVenta.Text = "Registrar Venta";
            this.btnGestionarVenta.Click += new System.EventHandler(this.btnGestionarVenta_Click);

            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(580, 25);
            this.btnCerrarSesion.Size = new System.Drawing.Size(120, 30);
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);

            // 
            // groupBoxHistorial
            // 
            this.groupBoxHistorial.Controls.Add(this.dgvVentas);
            this.groupBoxHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxHistorial.Text = "Historial de Ventas";

            // 
            // dgvVentas
            // 
            this.dgvVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentas.MultiSelect = false;
            this.dgvVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // 
            // FrmVendedor
            // 
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.groupBoxHistorial);
            this.Controls.Add(this.groupBoxAcciones);
            this.Controls.Add(this.groupBoxDatos);
            this.Text = "Panel Vendedor";
            this.Load += new System.EventHandler(this.FrmVendedor_Load);
        }
    }
}
