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

        // Nuevos campos para editar Usuario
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
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.btnSeleccionarFoto = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblFoto = new System.Windows.Forms.Label();

            // Nuevos
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();

            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            this.SuspendLayout();

            // 
            // pbFoto
            // 
            this.pbFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFoto.Location = new System.Drawing.Point(20, 30);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(120, 120);
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // btnSeleccionarFoto
            // 
            this.btnSeleccionarFoto.Location = new System.Drawing.Point(20, 160);
            this.btnSeleccionarFoto.Name = "btnSeleccionarFoto";
            this.btnSeleccionarFoto.Size = new System.Drawing.Size(120, 30);
            this.btnSeleccionarFoto.Text = "Seleccionar Foto";
            this.btnSeleccionarFoto.Click += new System.EventHandler(this.btnSeleccionarFoto_Click);

            // 
            // lblNombre
            // 
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Location = new System.Drawing.Point(160, 30);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(250, 30);

            // 
            // lblCorreo
            // 
            this.lblCorreo.Text = "Correo:";
            this.lblCorreo.Location = new System.Drawing.Point(160, 70);
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(250, 70);

            // 
            // lblTelefono
            // 
            this.lblTelefono.Text = "Teléfono:";
            this.lblTelefono.Location = new System.Drawing.Point(160, 110);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(250, 110);

            // 
            // lblDireccion
            // 
            this.lblDireccion.Text = "Dirección:";
            this.lblDireccion.Location = new System.Drawing.Point(160, 150);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(250, 150);

            // 
            // lblUsername
            // 
            this.lblUsername.Text = "Usuario:";
            this.lblUsername.Location = new System.Drawing.Point(160, 190);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(250, 190);
            this.txtUsername.Size = new System.Drawing.Size(200, 23);

            // 
            // lblPassword
            // 
            this.lblPassword.Text = "Contraseña:";
            this.lblPassword.Location = new System.Drawing.Point(160, 230);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(250, 230);
            this.txtPassword.Size = new System.Drawing.Size(200, 23);
            this.txtPassword.PasswordChar = '*';

            // 
            // btnGuardar
            // 
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(250, 280);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // 
            // btnCancelar
            // 
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(350, 280);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // 
            // FrmEditarPerfilCliente
            // 
            this.ClientSize = new System.Drawing.Size(500, 330);
            this.Controls.Add(this.pbFoto);
            this.Controls.Add(this.btnSeleccionarFoto);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblPassword);
            this.Name = "FrmEditarPerfilCliente";
            this.Text = "Editar Perfil";
            this.Load += new System.EventHandler(this.FrmEditarPerfilCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
