namespace Presentacion.Forms
{
    partial class FrmEditarPerfilCliente
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Button btnSeleccionarFoto;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblFoto;

        // Campos de usuario
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPasswordActual;
        private System.Windows.Forms.Label lblPasswordActual;
        private System.Windows.Forms.CheckBox chkMostrarPassword;

        // Label informativo
        private System.Windows.Forms.Label lblInfoPassword;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pbFoto = new PictureBox();
            btnSeleccionarFoto = new Button();
            txtNombre = new TextBox();
            txtCorreo = new TextBox();
            txtTelefono = new TextBox();
            txtDireccion = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            lblNombre = new Label();
            lblCorreo = new Label();
            lblTelefono = new Label();
            lblDireccion = new Label();
            lblFoto = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtPasswordActual = new TextBox();
            lblPasswordActual = new Label();
            chkMostrarPassword = new CheckBox();
            lblInfoPassword = new Label();
            ((System.ComponentModel.ISupportInitialize)pbFoto).BeginInit();
            SuspendLayout();
            // 
            // pbFoto
            // 
            pbFoto.BackColor = SystemColors.Control;
            pbFoto.BorderStyle = BorderStyle.FixedSingle;
            pbFoto.Location = new Point(20, 30);
            pbFoto.Name = "pbFoto";
            pbFoto.Size = new Size(120, 120);
            pbFoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbFoto.TabIndex = 0;
            pbFoto.TabStop = false;
            // 
            // btnSeleccionarFoto
            // 
            btnSeleccionarFoto.BackColor = Color.LemonChiffon;
            btnSeleccionarFoto.Location = new Point(20, 160);
            btnSeleccionarFoto.Name = "btnSeleccionarFoto";
            btnSeleccionarFoto.Size = new Size(120, 30);
            btnSeleccionarFoto.TabIndex = 1;
            btnSeleccionarFoto.Text = "SELECCIONAR";
            btnSeleccionarFoto.UseVisualStyleBackColor = false;
            btnSeleccionarFoto.Click += btnSeleccionarFoto_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(334, 30);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 27);
            txtNombre.TabIndex = 2;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(334, 66);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(200, 27);
            txtCorreo.TabIndex = 3;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(334, 107);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(200, 27);
            txtTelefono.TabIndex = 4;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(334, 150);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(200, 27);
            txtDireccion.TabIndex = 5;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Aquamarine;
            btnGuardar.Location = new Point(434, 342);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 33);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.MistyRose;
            btnCancelar.Location = new Point(20, 342);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(110, 33);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(160, 30);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(165, 23);
            lblNombre.TabIndex = 12;
            lblNombre.Text = "NOMBRE COMPLETO:";
            // 
            // lblCorreo
            // 
            lblCorreo.Location = new Point(160, 70);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(100, 23);
            lblCorreo.TabIndex = 13;
            lblCorreo.Text = "CORREO:";
            // 
            // lblTelefono
            // 
            lblTelefono.Location = new Point(160, 110);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(100, 23);
            lblTelefono.TabIndex = 14;
            lblTelefono.Text = "TELEFONO:";
            // 
            // lblDireccion
            // 
            lblDireccion.Location = new Point(160, 150);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(100, 23);
            lblDireccion.TabIndex = 15;
            lblDireccion.Text = "DIRECCION:";
            // 
            // lblFoto
            // 
            lblFoto.Location = new Point(0, 0);
            lblFoto.Name = "lblFoto";
            lblFoto.Size = new Size(100, 23);
            lblFoto.TabIndex = 0;
            // 
            // lblUsername
            // 
            lblUsername.Location = new Point(160, 190);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(100, 23);
            lblUsername.TabIndex = 16;
            lblUsername.Text = "USUARIO:";
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(160, 292);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(165, 31);
            lblPassword.TabIndex = 18;
            lblPassword.Text = "NUEVA CONTRASEÑA:";
            lblPassword.Click += lblPassword_Click;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(334, 190);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(200, 27);
            txtUsername.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(334, 292);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 27);
            txtPassword.TabIndex = 7;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtPasswordActual
            // 
            txtPasswordActual.BackColor = SystemColors.Control;
            txtPasswordActual.Location = new Point(334, 227);
            txtPasswordActual.Name = "txtPasswordActual";
            txtPasswordActual.ReadOnly = true;
            txtPasswordActual.Size = new Size(200, 27);
            txtPasswordActual.TabIndex = 8;
            txtPasswordActual.TabStop = false;
            // 
            // lblPasswordActual
            // 
            lblPasswordActual.Location = new Point(160, 230);
            lblPasswordActual.Name = "lblPasswordActual";
            lblPasswordActual.Size = new Size(194, 23);
            lblPasswordActual.TabIndex = 17;
            lblPasswordActual.Text = "CONTRASEÑA ACTUAL:";
            // 
            // chkMostrarPassword
            // 
            chkMostrarPassword.Location = new Point(334, 318);
            chkMostrarPassword.Name = "chkMostrarPassword";
            chkMostrarPassword.Size = new Size(104, 24);
            chkMostrarPassword.TabIndex = 9;
            chkMostrarPassword.Text = "Mostrar contraseña";
            // 
            // lblInfoPassword
            // 
            lblInfoPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfoPassword.ForeColor = Color.Gray;
            lblInfoPassword.Location = new Point(334, 257);
            lblInfoPassword.Name = "lblInfoPassword";
            lblInfoPassword.Size = new Size(200, 30);
            lblInfoPassword.TabIndex = 19;
            lblInfoPassword.Text = "La contraseña actual no se puede mostrar por seguridad.";
            // 
            // FrmEditarPerfilCliente
            // 
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(600, 423);
            Controls.Add(pbFoto);
            Controls.Add(btnSeleccionarFoto);
            Controls.Add(txtNombre);
            Controls.Add(txtCorreo);
            Controls.Add(txtTelefono);
            Controls.Add(txtDireccion);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(txtPasswordActual);
            Controls.Add(chkMostrarPassword);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Controls.Add(lblNombre);
            Controls.Add(lblCorreo);
            Controls.Add(lblTelefono);
            Controls.Add(lblDireccion);
            Controls.Add(lblUsername);
            Controls.Add(lblPasswordActual);
            Controls.Add(lblPassword);
            Controls.Add(lblInfoPassword);
            Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "FrmEditarPerfilCliente";
            Text = "EDITAR PERFIL CLIENTE";
            Load += FrmEditarPerfilCliente_Load;
            ((System.ComponentModel.ISupportInitialize)pbFoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
