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
            groupBoxDatos = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            pbFoto = new PictureBox();
            lblNombre = new Label();
            lblRole = new Label();
            groupBoxAcciones = new GroupBox();
            btnEditarPerfil = new Button();
            btnGestionarClientes = new Button();
            btnGestionarProductos = new Button();
            btnGestionarVenta = new Button();
            btnCerrarSesion = new Button();
            groupBoxHistorial = new GroupBox();
            dgvVentas = new DataGridView();
            groupBoxDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbFoto).BeginInit();
            groupBoxAcciones.SuspendLayout();
            groupBoxHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // groupBoxDatos
            // 
            groupBoxDatos.Controls.Add(label2);
            groupBoxDatos.Controls.Add(label1);
            groupBoxDatos.Controls.Add(pbFoto);
            groupBoxDatos.Controls.Add(lblNombre);
            groupBoxDatos.Controls.Add(lblRole);
            groupBoxDatos.Dock = DockStyle.Top;
            groupBoxDatos.Location = new Point(0, 0);
            groupBoxDatos.Name = "groupBoxDatos";
            groupBoxDatos.Size = new Size(800, 120);
            groupBoxDatos.TabIndex = 2;
            groupBoxDatos.TabStop = false;
            groupBoxDatos.Text = "Datos del Vendedor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 63);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 4;
            label2.Text = "Rol:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 30);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 3;
            label1.Text = "Nombre:";
            // 
            // pbFoto
            // 
            pbFoto.BorderStyle = BorderStyle.FixedSingle;
            pbFoto.Location = new Point(678, 12);
            pbFoto.Name = "pbFoto";
            pbFoto.Size = new Size(114, 102);
            pbFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pbFoto.TabIndex = 0;
            pbFoto.TabStop = false;
            // 
            // lblNombre
            // 
            lblNombre.BackColor = SystemColors.AppWorkspace;
            lblNombre.Location = new Point(91, 30);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(200, 20);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre: ";
            lblNombre.Click += lblNombre_Click;
            // 
            // lblRole
            // 
            lblRole.BackColor = SystemColors.AppWorkspace;
            lblRole.Location = new Point(91, 63);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(200, 20);
            lblRole.TabIndex = 2;
            lblRole.Text = "Rol: ";
            // 
            // groupBoxAcciones
            // 
            groupBoxAcciones.Controls.Add(btnEditarPerfil);
            groupBoxAcciones.Controls.Add(btnGestionarClientes);
            groupBoxAcciones.Controls.Add(btnGestionarProductos);
            groupBoxAcciones.Controls.Add(btnGestionarVenta);
            groupBoxAcciones.Controls.Add(btnCerrarSesion);
            groupBoxAcciones.Dock = DockStyle.Top;
            groupBoxAcciones.Location = new Point(0, 120);
            groupBoxAcciones.Name = "groupBoxAcciones";
            groupBoxAcciones.Size = new Size(800, 70);
            groupBoxAcciones.TabIndex = 1;
            groupBoxAcciones.TabStop = false;
            groupBoxAcciones.Text = "Acciones";
            groupBoxAcciones.Enter += groupBoxAcciones_Enter;
            // 
            // btnEditarPerfil
            // 
            btnEditarPerfil.Location = new Point(20, 25);
            btnEditarPerfil.Name = "btnEditarPerfil";
            btnEditarPerfil.Size = new Size(120, 30);
            btnEditarPerfil.TabIndex = 0;
            btnEditarPerfil.Text = "Gestionar Perfil";
            btnEditarPerfil.Click += btnEditarPerfil_Click;
            // 
            // btnGestionarClientes
            // 
            btnGestionarClientes.Location = new Point(188, 25);
            btnGestionarClientes.Name = "btnGestionarClientes";
            btnGestionarClientes.Size = new Size(120, 30);
            btnGestionarClientes.TabIndex = 1;
            btnGestionarClientes.Text = "Gestionar Clientes";
            btnGestionarClientes.Click += btnGestionarClientes_Click;
            // 
            // btnGestionarProductos
            // 
            btnGestionarProductos.Location = new Point(350, 25);
            btnGestionarProductos.Name = "btnGestionarProductos";
            btnGestionarProductos.Size = new Size(145, 30);
            btnGestionarProductos.TabIndex = 2;
            btnGestionarProductos.Text = "Gestionar Productos";
            btnGestionarProductos.Click += btnGestionarProductos_Click;
            // 
            // btnGestionarVenta
            // 
            btnGestionarVenta.Location = new Point(526, 25);
            btnGestionarVenta.Name = "btnGestionarVenta";
            btnGestionarVenta.Size = new Size(120, 30);
            btnGestionarVenta.TabIndex = 3;
            btnGestionarVenta.Text = "Registrar Venta";
            btnGestionarVenta.Click += btnGestionarVenta_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(674, 25);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(120, 30);
            btnCerrarSesion.TabIndex = 4;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // groupBoxHistorial
            // 
            groupBoxHistorial.Controls.Add(dgvVentas);
            groupBoxHistorial.Dock = DockStyle.Fill;
            groupBoxHistorial.Location = new Point(0, 190);
            groupBoxHistorial.Name = "groupBoxHistorial";
            groupBoxHistorial.Size = new Size(800, 310);
            groupBoxHistorial.TabIndex = 0;
            groupBoxHistorial.TabStop = false;
            groupBoxHistorial.Text = "Historial de Ventas";
            // 
            // dgvVentas
            // 
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.Dock = DockStyle.Fill;
            dgvVentas.Location = new Point(3, 19);
            dgvVentas.MultiSelect = false;
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.Size = new Size(794, 288);
            dgvVentas.TabIndex = 0;
            dgvVentas.CellDoubleClick += dgvVentas_CellDoubleClick;
            // 
            // FrmVendedor
            // 
            ClientSize = new Size(800, 500);
            Controls.Add(groupBoxHistorial);
            Controls.Add(groupBoxAcciones);
            Controls.Add(groupBoxDatos);
            Name = "FrmVendedor";
            Text = "Panel Vendedor";
            Load += FrmVendedor_Load;
            groupBoxDatos.ResumeLayout(false);
            groupBoxDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbFoto).EndInit();
            groupBoxAcciones.ResumeLayout(false);
            groupBoxHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
        }
        private Label label2;
        private Label label1;
    }
}
