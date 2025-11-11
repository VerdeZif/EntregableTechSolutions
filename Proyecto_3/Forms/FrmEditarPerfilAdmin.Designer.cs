namespace Presentacion.Forms
{
    partial class FrmEditarPerfilAdmin
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNombreTitulo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Button btnSeleccionarFoto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblNombreTitulo = new System.Windows.Forms.Label();
            txtNombre = new System.Windows.Forms.TextBox();
            lblUsername = new System.Windows.Forms.Label();
            lblPassword = new System.Windows.Forms.Label();
            txtUsername = new System.Windows.Forms.TextBox();
            txtPassword = new System.Windows.Forms.TextBox();
            pbFoto = new System.Windows.Forms.PictureBox();
            btnSeleccionarFoto = new System.Windows.Forms.Button();
            btnGuardar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pbFoto).BeginInit();
            SuspendLayout();

            // lblNombreTitulo
            lblNombreTitulo.AutoSize = true;
            lblNombreTitulo.Location = new System.Drawing.Point(12, 15);
            lblNombreTitulo.Name = "lblNombreTitulo";
            lblNombreTitulo.Size = new System.Drawing.Size(108, 15);
            lblNombreTitulo.TabIndex = 0;
            lblNombreTitulo.Text = "Nombre completo:";

            // txtNombre
            txtNombre.Location = new System.Drawing.Point(130, 12);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new System.Drawing.Size(250, 23);
            txtNombre.TabIndex = 1;

            // lblUsername
            lblUsername.AutoSize = true;
            lblUsername.Location = new System.Drawing.Point(12, 50);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new System.Drawing.Size(63, 15);
            lblUsername.TabIndex = 6;
            lblUsername.Text = "Username:";

            // txtUsername
            txtUsername.Location = new System.Drawing.Point(130, 47);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new System.Drawing.Size(250, 23);
            txtUsername.TabIndex = 7;

            // lblPassword
            lblPassword.AutoSize = true;
            lblPassword.Location = new System.Drawing.Point(12, 85);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(60, 15);
            lblPassword.TabIndex = 8;
            lblPassword.Text = "Password:";

            // txtPassword
            txtPassword.Location = new System.Drawing.Point(130, 82);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new System.Drawing.Size(250, 23);
            txtPassword.TabIndex = 9;

            // pbFoto
            pbFoto.Location = new System.Drawing.Point(24, 120);
            pbFoto.Name = "pbFoto";
            pbFoto.Size = new System.Drawing.Size(120, 120);
            pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbFoto.TabIndex = 2;
            pbFoto.TabStop = false;

            // btnSeleccionarFoto
            btnSeleccionarFoto.Location = new System.Drawing.Point(24, 250);
            btnSeleccionarFoto.Name = "btnSeleccionarFoto";
            btnSeleccionarFoto.Size = new System.Drawing.Size(120, 30);
            btnSeleccionarFoto.TabIndex = 3;
            btnSeleccionarFoto.Text = "Seleccionar Foto";
            btnSeleccionarFoto.Click += btnSeleccionarFoto_Click;

            // btnGuardar
            btnGuardar.Location = new System.Drawing.Point(220, 160);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(120, 30);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;

            // btnCancelar
            btnCancelar.Location = new System.Drawing.Point(220, 210);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(120, 30);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;

            // FrmEditarPerfilAdmin
            ClientSize = new System.Drawing.Size(410, 300);
            Controls.Add(lblNombreTitulo);
            Controls.Add(txtNombre);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(pbFoto);
            Controls.Add(btnSeleccionarFoto);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Name = "FrmEditarPerfilAdmin";
            Text = "Editar Perfil Administrador";
            Load += FrmEditarPerfilAdmin_Load;
            ((System.ComponentModel.ISupportInitialize)pbFoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
