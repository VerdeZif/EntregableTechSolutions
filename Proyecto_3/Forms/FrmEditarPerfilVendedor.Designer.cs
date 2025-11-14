namespace Presentacion.Forms
{
    partial class FrmEditarPerfilVendedor
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblNombreTitulo;
        private TextBox txtNombre;
        private Label lblUsername;
        private TextBox txtUsername;

        private Label lblPasswordActual;
        private TextBox txtPasswordActual;

        private Label lblNuevaPassword;
        private TextBox txtNuevaPassword;

        private CheckBox chkMostrarPassword;

        private Label lblInfo; // Mensaje informativo

        private PictureBox pbFoto;
        private Button btnSeleccionarFoto;
        private Button btnGuardar;
        private Button btnCancelar;

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
            lblPasswordActual = new Label();
            txtPasswordActual = new TextBox();
            lblNuevaPassword = new Label();
            txtNuevaPassword = new TextBox();
            chkMostrarPassword = new CheckBox();
            lblInfo = new Label();
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
            lblNombreTitulo.Location = new Point(20, 20);
            lblNombreTitulo.Name = "lblNombreTitulo";
            lblNombreTitulo.Size = new Size(156, 20);
            lblNombreTitulo.TabIndex = 0;
            lblNombreTitulo.Text = "NOMBRE COMPLETO:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(197, 17);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(220, 27);
            txtNombre.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(20, 55);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(77, 20);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "USUARIO:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(197, 52);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(220, 27);
            txtUsername.TabIndex = 3;
            // 
            // lblPasswordActual
            // 
            lblPasswordActual.AutoSize = true;
            lblPasswordActual.Location = new Point(20, 90);
            lblPasswordActual.Name = "lblPasswordActual";
            lblPasswordActual.Size = new Size(169, 20);
            lblPasswordActual.TabIndex = 4;
            lblPasswordActual.Text = "CONTRASEÑA ACTUAL:";
            // 
            // txtPasswordActual
            // 
            txtPasswordActual.BackColor = SystemColors.Control;
            txtPasswordActual.Location = new Point(197, 87);
            txtPasswordActual.Name = "txtPasswordActual";
            txtPasswordActual.ReadOnly = true;
            txtPasswordActual.Size = new Size(220, 27);
            txtPasswordActual.TabIndex = 5;
            txtPasswordActual.TabStop = false;
            txtPasswordActual.UseSystemPasswordChar = true;
            // 
            // lblNuevaPassword
            // 
            lblNuevaPassword.AutoSize = true;
            lblNuevaPassword.Location = new Point(20, 155);
            lblNuevaPassword.Name = "lblNuevaPassword";
            lblNuevaPassword.Size = new Size(164, 20);
            lblNuevaPassword.TabIndex = 6;
            lblNuevaPassword.Text = "NUEVA CONTRASEÑA:";
            // 
            // txtNuevaPassword
            // 
            txtNuevaPassword.Location = new Point(197, 152);
            txtNuevaPassword.Name = "txtNuevaPassword";
            txtNuevaPassword.Size = new Size(220, 27);
            txtNuevaPassword.TabIndex = 7;
            txtNuevaPassword.UseSystemPasswordChar = true;
            // 
            // chkMostrarPassword
            // 
            chkMostrarPassword.Location = new Point(197, 185);
            chkMostrarPassword.Name = "chkMostrarPassword";
            chkMostrarPassword.Size = new Size(104, 24);
            chkMostrarPassword.TabIndex = 8;
            chkMostrarPassword.Text = "Mostrar nueva contraseña";
            // 
            // lblInfo
            // 
            lblInfo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblInfo.ForeColor = Color.Gray;
            lblInfo.Location = new Point(197, 117);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(220, 32);
            lblInfo.TabIndex = 9;
            lblInfo.Text = "La contraseña actual no se puede mostrar por seguridad.";
            lblInfo.Click += lblInfo_Click;
            // 
            // pbFoto
            // 
            pbFoto.BackColor = SystemColors.Control;
            pbFoto.BorderStyle = BorderStyle.FixedSingle;
            pbFoto.Location = new Point(453, 17);
            pbFoto.Name = "pbFoto";
            pbFoto.Size = new Size(120, 120);
            pbFoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbFoto.TabIndex = 10;
            pbFoto.TabStop = false;
            // 
            // btnSeleccionarFoto
            // 
            btnSeleccionarFoto.BackColor = Color.LemonChiffon;
            btnSeleccionarFoto.Location = new Point(453, 147);
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
            btnGuardar.ForeColor = SystemColors.ControlText;
            btnGuardar.Location = new Point(20, 235);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 35);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.MistyRose;
            btnCancelar.Location = new Point(453, 235);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 35);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmEditarPerfilVendedor
            // 
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(587, 324);
            Controls.Add(lblNombreTitulo);
            Controls.Add(txtNombre);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblPasswordActual);
            Controls.Add(txtPasswordActual);
            Controls.Add(lblNuevaPassword);
            Controls.Add(txtNuevaPassword);
            Controls.Add(chkMostrarPassword);
            Controls.Add(lblInfo);
            Controls.Add(pbFoto);
            Controls.Add(btnSeleccionarFoto);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "FrmEditarPerfilVendedor";
            Text = "EDITAR PERFIL DEL VENDEDOR";
            Load += FrmEditarPerfilVendedor_Load;
            ((System.ComponentModel.ISupportInitialize)pbFoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}