namespace Presentacion.Forms
{
    partial class FrmRegistroClientes
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Button btnSeleccionarFoto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtNombre = new TextBox();
            txtCorreo = new TextBox();
            txtTelefono = new TextBox();
            txtDireccion = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            pbFoto = new PictureBox();
            btnSeleccionarFoto = new Button();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            dgvClientes = new DataGridView();
            lblNombre = new Label();
            lblCorreo = new Label();
            lblTelefono = new Label();
            lblDireccion = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            ((System.ComponentModel.ISupportInitialize)pbFoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(120, 20);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(120, 60);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(200, 23);
            txtCorreo.TabIndex = 3;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(120, 100);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(200, 23);
            txtTelefono.TabIndex = 5;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(120, 140);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(200, 23);
            txtDireccion.TabIndex = 7;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(120, 180);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(200, 23);
            txtUsername.TabIndex = 9;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(120, 220);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 11;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // pbFoto
            // 
            pbFoto.BorderStyle = BorderStyle.FixedSingle;
            pbFoto.Location = new Point(497, 35);
            pbFoto.Name = "pbFoto";
            pbFoto.Size = new Size(141, 148);
            pbFoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbFoto.TabIndex = 12;
            pbFoto.TabStop = false;
            pbFoto.Click += pbFoto_Click;
            // 
            // btnSeleccionarFoto
            // 
            btnSeleccionarFoto.Location = new Point(528, 206);
            btnSeleccionarFoto.Name = "btnSeleccionarFoto";
            btnSeleccionarFoto.Size = new Size(75, 23);
            btnSeleccionarFoto.TabIndex = 13;
            btnSeleccionarFoto.Text = "Seleccionar Foto";
            btnSeleccionarFoto.Click += btnSeleccionarFoto_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(373, 29);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 14;
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(373, 87);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 15;
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(373, 136);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 16;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.Location = new Point(12, 266);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(626, 272);
            dgvClientes.TabIndex = 17;
            dgvClientes.CellClick += dgvClientes_CellClick;
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(20, 20);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(100, 23);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // lblCorreo
            // 
            lblCorreo.Location = new Point(20, 60);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(100, 23);
            lblCorreo.TabIndex = 2;
            lblCorreo.Text = "Correo:";
            // 
            // lblTelefono
            // 
            lblTelefono.Location = new Point(20, 100);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(100, 23);
            lblTelefono.TabIndex = 4;
            lblTelefono.Text = "Teléfono:";
            // 
            // lblDireccion
            // 
            lblDireccion.Location = new Point(20, 140);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(100, 23);
            lblDireccion.TabIndex = 6;
            lblDireccion.Text = "Dirección:";
            // 
            // lblUsername
            // 
            lblUsername.Location = new Point(20, 180);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(100, 23);
            lblUsername.TabIndex = 8;
            lblUsername.Text = "Usuario:";
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(20, 220);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(100, 23);
            lblPassword.TabIndex = 10;
            lblPassword.Text = "Contraseña:";
            // 
            // FrmRegistroClientes
            // 
            ClientSize = new Size(650, 550);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblCorreo);
            Controls.Add(txtCorreo);
            Controls.Add(lblTelefono);
            Controls.Add(txtTelefono);
            Controls.Add(lblDireccion);
            Controls.Add(txtDireccion);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(pbFoto);
            Controls.Add(btnSeleccionarFoto);
            Controls.Add(btnAgregar);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(dgvClientes);
            Name = "FrmRegistroClientes";
            Text = "Registro de Clientes";
            Load += FrmRegistroClientes_Load;
            ((System.ComponentModel.ISupportInitialize)pbFoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
