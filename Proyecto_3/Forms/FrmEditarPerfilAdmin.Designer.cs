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
            lblNombreTitulo.Size = new Size(156, 20);
            lblNombreTitulo.TabIndex = 0;
            lblNombreTitulo.Text = "NOMBRE COMPLETO:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(190, 15);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(250, 27);
            txtNombre.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(12, 50);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(77, 20);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "USUARIO:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(190, 50);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(250, 27);
            txtUsername.TabIndex = 3;
            // 
            // lblPasswordActual
            // 
            lblPasswordActual.AutoSize = true;
            lblPasswordActual.Location = new Point(12, 85);
            lblPasswordActual.Name = "lblPasswordActual";
            lblPasswordActual.Size = new Size(169, 20);
            lblPasswordActual.TabIndex = 4;
            lblPasswordActual.Text = "CONTRASEÑA ACTUAL:";
            // 
            // txtPasswordActual
            // 
            txtPasswordActual.BackColor = SystemColors.Control;
            txtPasswordActual.Location = new Point(190, 85);
            txtPasswordActual.Name = "txtPasswordActual";
            txtPasswordActual.ReadOnly = true;
            txtPasswordActual.Size = new Size(250, 27);
            txtPasswordActual.TabIndex = 5;
            txtPasswordActual.TabStop = false;
            txtPasswordActual.Text = "********";
            // 
            // lblInfoPassword
            // 
            lblInfoPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfoPassword.ForeColor = Color.DimGray;
            lblInfoPassword.Location = new Point(190, 108);
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
            lblPassword.Size = new Size(164, 20);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "NUEVA CONTRASEÑA:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(190, 149);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(250, 27);
            txtPassword.TabIndex = 8;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // chkMostrarPassword
            // 
            chkMostrarPassword.Location = new Point(190, 177);
            chkMostrarPassword.Name = "chkMostrarPassword";
            chkMostrarPassword.Size = new Size(104, 24);
            chkMostrarPassword.TabIndex = 9;
            chkMostrarPassword.Text = "Mostrar contraseña";
            // 
            // pbFoto
            // 
            pbFoto.BackColor = SystemColors.Control;
            pbFoto.BorderStyle = BorderStyle.FixedSingle;
            pbFoto.Location = new Point(491, 15);
            pbFoto.Name = "pbFoto";
            pbFoto.Size = new Size(120, 120);
            pbFoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbFoto.TabIndex = 10;
            pbFoto.TabStop = false;
            // 
            // btnSeleccionarFoto
            // 
            btnSeleccionarFoto.BackColor = Color.LemonChiffon;
            btnSeleccionarFoto.Location = new Point(491, 149);
            btnSeleccionarFoto.Name = "btnSeleccionarFoto";
            btnSeleccionarFoto.Size = new Size(120, 30);
            btnSeleccionarFoto.TabIndex = 11;
            btnSeleccionarFoto.Text = "SELECCIONAR";
            btnSeleccionarFoto.UseVisualStyleBackColor = false;
            btnSeleccionarFoto.Click += btnSeleccionarFoto_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Aquamarine;
            btnGuardar.Location = new Point(12, 258);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 30);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.MistyRose;
            btnCancelar.Location = new Point(491, 258);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 30);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmEditarPerfilAdmin
            // 
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(620, 303);
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
            Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "FrmEditarPerfilAdmin";
            Text = "EDITAR PERFIL ADMINISTRADOR";
            Load += FrmEditarPerfilAdmin_Load;
            ((System.ComponentModel.ISupportInitialize)pbFoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
