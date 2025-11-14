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
            groupBoxDatos.BackColor = SystemColors.GradientActiveCaption;
            groupBoxDatos.Controls.Add(label2);
            groupBoxDatos.Controls.Add(label1);
            groupBoxDatos.Controls.Add(pbFoto);
            groupBoxDatos.Controls.Add(lblNombre);
            groupBoxDatos.Controls.Add(lblRole);
            groupBoxDatos.Dock = DockStyle.Top;
            groupBoxDatos.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxDatos.Location = new Point(0, 0);
            groupBoxDatos.Name = "groupBoxDatos";
            groupBoxDatos.Size = new Size(800, 120);
            groupBoxDatos.TabIndex = 2;
            groupBoxDatos.TabStop = false;
            groupBoxDatos.Text = "DATOS DEL VENDEDOR";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 63);
            label2.Name = "label2";
            label2.Size = new Size(40, 20);
            label2.TabIndex = 4;
            label2.Text = "ROL:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 30);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 3;
            label1.Text = "NOMBRE:";
            // 
            // pbFoto
            // 
            pbFoto.BackColor = SystemColors.Control;
            pbFoto.BorderStyle = BorderStyle.FixedSingle;
            pbFoto.Location = new Point(627, 12);
            pbFoto.Name = "pbFoto";
            pbFoto.Size = new Size(167, 102);
            pbFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pbFoto.TabIndex = 0;
            pbFoto.TabStop = false;
            // 
            // lblNombre
            // 
            lblNombre.BackColor = SystemColors.AppWorkspace;
            lblNombre.Location = new Point(102, 30);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(200, 20);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre: ";
            lblNombre.Click += lblNombre_Click;
            // 
            // lblRole
            // 
            lblRole.BackColor = SystemColors.AppWorkspace;
            lblRole.Location = new Point(102, 63);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(200, 20);
            lblRole.TabIndex = 2;
            lblRole.Text = "Rol: ";
            // 
            // groupBoxAcciones
            // 
            groupBoxAcciones.BackColor = SystemColors.InactiveBorder;
            groupBoxAcciones.Controls.Add(btnEditarPerfil);
            groupBoxAcciones.Controls.Add(btnGestionarClientes);
            groupBoxAcciones.Controls.Add(btnGestionarProductos);
            groupBoxAcciones.Controls.Add(btnGestionarVenta);
            groupBoxAcciones.Controls.Add(btnCerrarSesion);
            groupBoxAcciones.Dock = DockStyle.Top;
            groupBoxAcciones.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxAcciones.Location = new Point(0, 120);
            groupBoxAcciones.Name = "groupBoxAcciones";
            groupBoxAcciones.Size = new Size(800, 85);
            groupBoxAcciones.TabIndex = 1;
            groupBoxAcciones.TabStop = false;
            groupBoxAcciones.Text = "ACCIONES";
            groupBoxAcciones.Enter += groupBoxAcciones_Enter;
            // 
            // btnEditarPerfil
            // 
            btnEditarPerfil.BackColor = SystemColors.Control;
            btnEditarPerfil.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditarPerfil.Location = new Point(47, 22);
            btnEditarPerfil.Name = "btnEditarPerfil";
            btnEditarPerfil.Size = new Size(111, 52);
            btnEditarPerfil.TabIndex = 0;
            btnEditarPerfil.Text = "GESTIONAR PERFIL";
            btnEditarPerfil.UseVisualStyleBackColor = false;
            btnEditarPerfil.Click += btnEditarPerfil_Click;
            // 
            // btnGestionarClientes
            // 
            btnGestionarClientes.BackColor = SystemColors.Control;
            btnGestionarClientes.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGestionarClientes.Location = new Point(191, 22);
            btnGestionarClientes.Name = "btnGestionarClientes";
            btnGestionarClientes.Size = new Size(111, 52);
            btnGestionarClientes.TabIndex = 1;
            btnGestionarClientes.Text = "GESTIONAR CLIENTES";
            btnGestionarClientes.UseVisualStyleBackColor = false;
            btnGestionarClientes.Click += btnGestionarClientes_Click;
            // 
            // btnGestionarProductos
            // 
            btnGestionarProductos.BackColor = SystemColors.Control;
            btnGestionarProductos.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGestionarProductos.Location = new Point(350, 22);
            btnGestionarProductos.Name = "btnGestionarProductos";
            btnGestionarProductos.Size = new Size(111, 52);
            btnGestionarProductos.TabIndex = 2;
            btnGestionarProductos.Text = "GESTIONAR PRODUCTOS";
            btnGestionarProductos.UseVisualStyleBackColor = false;
            btnGestionarProductos.Click += btnGestionarProductos_Click;
            // 
            // btnGestionarVenta
            // 
            btnGestionarVenta.BackColor = SystemColors.Control;
            btnGestionarVenta.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGestionarVenta.Location = new Point(498, 22);
            btnGestionarVenta.Name = "btnGestionarVenta";
            btnGestionarVenta.Size = new Size(111, 52);
            btnGestionarVenta.TabIndex = 3;
            btnGestionarVenta.Text = "REGISTRAR VENTA";
            btnGestionarVenta.UseVisualStyleBackColor = false;
            btnGestionarVenta.Click += btnGestionarVenta_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.MistyRose;
            btnCerrarSesion.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrarSesion.Location = new Point(644, 22);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(111, 52);
            btnCerrarSesion.TabIndex = 4;
            btnCerrarSesion.Text = "CERRAR SESION";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // groupBoxHistorial
            // 
            groupBoxHistorial.BackColor = SystemColors.GradientInactiveCaption;
            groupBoxHistorial.Controls.Add(dgvVentas);
            groupBoxHistorial.Dock = DockStyle.Fill;
            groupBoxHistorial.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxHistorial.Location = new Point(0, 205);
            groupBoxHistorial.Name = "groupBoxHistorial";
            groupBoxHistorial.Size = new Size(800, 295);
            groupBoxHistorial.TabIndex = 0;
            groupBoxHistorial.TabStop = false;
            groupBoxHistorial.Text = "HISTORIAL DE VENTAS";
            // 
            // dgvVentas
            // 
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.ColumnHeadersHeight = 25;
            dgvVentas.Dock = DockStyle.Fill;
            dgvVentas.Location = new Point(3, 23);
            dgvVentas.MultiSelect = false;
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.Size = new Size(794, 269);
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
            Text = "PANEL DEL VENDEDOR";
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
