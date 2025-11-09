namespace Presentacion.Forms
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblUsuario = new Label();
            lblClave = new Label();
            txtUsuario = new TextBox();
            txtClave = new TextBox();
            chkMostrarClave = new CheckBox();
            btnLogin = new Button();
            lblMensaje = new Label();
            SuspendLayout();

            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.FromArgb(40, 40, 40);
            lblTitulo.Location = new Point(65, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(350, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "TechSolutions - Iniciar Sesión";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsuario.Location = new Point(50, 90);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(67, 20);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario:";

            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblClave.Location = new Point(50, 150);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(91, 20);
            lblClave.TabIndex = 2;
            lblClave.Text = "Contraseña:";

            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsuario.Location = new Point(180, 87);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(220, 27);
            txtUsuario.TabIndex = 3;

            // 
            // txtClave
            // 
            txtClave.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtClave.Location = new Point(180, 147);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(220, 27);
            txtClave.TabIndex = 4;

            // 
            // chkMostrarClave
            // 
            chkMostrarClave.AutoSize = true;
            chkMostrarClave.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkMostrarClave.Location = new Point(180, 180);
            chkMostrarClave.Name = "chkMostrarClave";
            chkMostrarClave.Size = new Size(150, 23);
            chkMostrarClave.TabIndex = 5;
            chkMostrarClave.Text = "Mostrar contraseña";
            chkMostrarClave.UseVisualStyleBackColor = true;

            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 120, 215);
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(180, 220);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(150, 38);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Iniciar Sesión";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;

            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblMensaje.ForeColor = Color.Red;
            lblMensaje.Location = new Point(50, 275);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(0, 15);
            lblMensaje.TabIndex = 7;

            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 320);
            Controls.Add(lblTitulo);
            Controls.Add(lblUsuario);
            Controls.Add(lblClave);
            Controls.Add(txtUsuario);
            Controls.Add(txtClave);
            Controls.Add(chkMostrarClave);
            Controls.Add(btnLogin);
            Controls.Add(lblMensaje);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TechSolutions - Login";
            Load += FrmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblUsuario;
        private Label lblClave;
        private TextBox txtUsuario;
        private TextBox txtClave;
        private CheckBox chkMostrarClave;
        private Button btnLogin;
        private Label lblMensaje;
    }
}
