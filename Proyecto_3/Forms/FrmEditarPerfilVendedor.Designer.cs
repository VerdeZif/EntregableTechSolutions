namespace Presentacion.Forms
{
    partial class FrmEditarPerfilVendedor
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblNombreTitulo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Button btnSeleccionarFoto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

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
            lblNombreTitulo = new Label();
            txtNombre = new TextBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            pbFoto = new PictureBox();
            btnSeleccionarFoto = new Button();
            btnGuardar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)pbFoto).BeginInit();
            SuspendLayout();
            // 
            // lblNombreTitulo
            // 
            lblNombreTitulo.AutoSize = true;
            lblNombreTitulo.Location = new Point(12, 15);
            lblNombreTitulo.Name = "lblNombreTitulo";
            lblNombreTitulo.Size = new Size(108, 15);
            lblNombreTitulo.TabIndex = 0;
            lblNombreTitulo.Text = "Nombre completo:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(130, 12);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(250, 23);
            txtNombre.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(12, 50);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(65, 15);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(130, 47);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(250, 23);
            txtUsername.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(12, 85);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(63, 15);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(130, 82);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(250, 23);
            txtPassword.TabIndex = 5;
            // 
            // pbFoto
            // 
            pbFoto.BorderStyle = BorderStyle.FixedSingle;
            pbFoto.Location = new Point(24, 120);
            pbFoto.Name = "pbFoto";
            pbFoto.Size = new Size(120, 120);
            pbFoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbFoto.TabIndex = 6;
            pbFoto.TabStop = false;
            // 
            // btnSeleccionarFoto
            // 
            btnSeleccionarFoto.Location = new Point(24, 250);
            btnSeleccionarFoto.Name = "btnSeleccionarFoto";
            btnSeleccionarFoto.Size = new Size(120, 30);
            btnSeleccionarFoto.TabIndex = 7;
            btnSeleccionarFoto.Text = "Seleccionar Foto";
            btnSeleccionarFoto.Click += btnSeleccionarFoto_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(220, 150);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 30);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(220, 195);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 30);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmEditarPerfilVendedor
            // 
            ClientSize = new Size(410, 310);
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
            Name = "FrmEditarPerfilVendedor";
            Text = "Editar Perfil del Vendedor";
            Load += FrmEditarPerfilVendedor_Load;
            ((System.ComponentModel.ISupportInitialize)pbFoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
