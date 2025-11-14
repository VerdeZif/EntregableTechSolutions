namespace Presentacion.Forms
{
    partial class FrmEditarPerfilAdmin
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblNombreTitulo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPasswordActual;
        private System.Windows.Forms.TextBox txtPasswordActual;
        private System.Windows.Forms.Label lblInfoPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkMostrarPassword;
        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Button btnSeleccionarFoto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblNombreTitulo = new Label();
            txtNombre = new TextBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPasswordActual = new Label();
            txtPasswordActual = new TextBox();
            lblInfoPassword = new Label();
            lblPassword = new Label();
            txtPassword = new TextBox();
            chkMostrarPassword = new CheckBox();
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
            txtNombre.Location = new Point(150, 12);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(250, 23);
            txtNombre.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(12, 50);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(50, 15);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Usuario:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(150, 47);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(250, 23);
            txtUsername.TabIndex = 3;
            // 
            // lblPasswordActual
            // 
            lblPasswordActual.AutoSize = true;
            lblPasswordActual.Location = new Point(12, 85);
            lblPasswordActual.Name = "lblPasswordActual";
            lblPasswordActual.Size = new Size(105, 15);
            lblPasswordActual.TabIndex = 4;
            lblPasswordActual.Text = "Contraseña actual:";
            // 
            // txtPasswordActual
            // 
            txtPasswordActual.BackColor = SystemColors.Control;
            txtPasswordActual.Location = new Point(150, 82);
            txtPasswordActual.Name = "txtPasswordActual";
            txtPasswordActual.ReadOnly = true;
            txtPasswordActual.Size = new Size(250, 23);
            txtPasswordActual.TabIndex = 5;
            txtPasswordActual.TabStop = false;
            txtPasswordActual.Text = "********";
            // 
            // lblInfoPassword
            // 
            lblInfoPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfoPassword.ForeColor = Color.DimGray;
            lblInfoPassword.Location = new Point(150, 105);
            lblInfoPassword.Name = "lblInfoPassword";
            lblInfoPassword.Size = new Size(250, 38);
            lblInfoPassword.TabIndex = 6;
            lblInfoPassword.Text = "La contraseña actual no se puede mostrar por seguridad.";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(12, 146);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(105, 15);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Nueva contraseña:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(150, 146);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(250, 23);
            txtPassword.TabIndex = 8;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // chkMostrarPassword
            // 
            chkMostrarPassword.Location = new Point(150, 174);
            chkMostrarPassword.Name = "chkMostrarPassword";
            chkMostrarPassword.Size = new Size(104, 24);
            chkMostrarPassword.TabIndex = 9;
            chkMostrarPassword.Text = "Mostrar contraseña";
            // 
            // pbFoto
            // 
            pbFoto.BorderStyle = BorderStyle.FixedSingle;
            pbFoto.Location = new Point(22, 208);
            pbFoto.Name = "pbFoto";
            pbFoto.Size = new Size(120, 120);
            pbFoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbFoto.TabIndex = 10;
            pbFoto.TabStop = false;
            // 
            // btnSeleccionarFoto
            // 
            btnSeleccionarFoto.Location = new Point(22, 338);
            btnSeleccionarFoto.Name = "btnSeleccionarFoto";
            btnSeleccionarFoto.Size = new Size(120, 30);
            btnSeleccionarFoto.TabIndex = 11;
            btnSeleccionarFoto.Text = "Seleccionar Foto";
            btnSeleccionarFoto.Click += btnSeleccionarFoto_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(200, 320);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 30);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(330, 320);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 30);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmEditarPerfilAdmin
            // 
            ClientSize = new Size(470, 370);
            Controls.Add(lblNombreTitulo);
            Controls.Add(txtNombre);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblPasswordActual);
            Controls.Add(txtPasswordActual);
            Controls.Add(lblInfoPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(chkMostrarPassword);
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
