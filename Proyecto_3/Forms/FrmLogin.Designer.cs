namespace Presentacion.Forms
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkVerContra;
        private System.Windows.Forms.Button btnLogin;

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
            lblTitulo = new Label();
            lblUsuario = new Label();
            lblPassword = new Label();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            chkVerContra = new CheckBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.Location = new Point(12, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(360, 40);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Iniciar Sesión";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Click += lblTitulo_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(40, 90);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(50, 15);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(40, 130);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 15);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Contraseña:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(120, 87);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(200, 23);
            txtUsuario.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(120, 127);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // chkVerContra
            // 
            chkVerContra.AutoSize = true;
            chkVerContra.Location = new Point(120, 160);
            chkVerContra.Name = "chkVerContra";
            chkVerContra.Size = new Size(128, 19);
            chkVerContra.TabIndex = 5;
            chkVerContra.Text = "Mostrar contraseña";
            chkVerContra.UseVisualStyleBackColor = true;
            chkVerContra.CheckedChanged += chkVerContra_CheckedChanged;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(120, 200);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(200, 30);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Iniciar Sesión";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // FrmLogin
            // 
            ClientSize = new Size(384, 261);
            Controls.Add(btnLogin);
            Controls.Add(chkVerContra);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += FrmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
