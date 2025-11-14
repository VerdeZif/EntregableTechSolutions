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

            // lblNombre
            lblNombreTitulo.AutoSize = true;
            lblNombreTitulo.Location = new Point(20, 20);
            lblNombreTitulo.Text = "Nombre completo:";
            txtNombre.Location = new Point(160, 17);
            txtNombre.Size = new Size(220, 23);

            // Username
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(20, 55);
            lblUsername.Text = "Username:";
            txtUsername.Location = new Point(160, 52);
            txtUsername.Size = new Size(220, 23);

            // Contraseña actual
            lblPasswordActual.AutoSize = true;
            lblPasswordActual.Location = new Point(20, 90);
            lblPasswordActual.Text = "Contraseña actual:";
            txtPasswordActual.Location = new Point(160, 87);
            txtPasswordActual.Size = new Size(220, 23);
            txtPasswordActual.UseSystemPasswordChar = true;
            txtPasswordActual.ReadOnly = true;
            txtPasswordActual.BackColor = SystemColors.Control;
            txtPasswordActual.TabStop = false;

            // Nueva contraseña
            lblNuevaPassword.AutoSize = true;
            lblNuevaPassword.Location = new Point(20, 125);
            lblNuevaPassword.Text = "Nueva contraseña:";
            txtNuevaPassword.Location = new Point(160, 122);
            txtNuevaPassword.Size = new Size(220, 23);
            txtNuevaPassword.UseSystemPasswordChar = true;

            // CheckBox mostrar nueva contraseña
            chkMostrarPassword.Location = new Point(160, 155);
            chkMostrarPassword.Text = "Mostrar nueva contraseña";

            // Mensaje informativo
            lblInfo.Location = new Point(160, 180);
            lblInfo.Size = new Size(220, 35);
            lblInfo.Text = "La contraseña actual no se puede mostrar por seguridad.";
            lblInfo.ForeColor = Color.Gray;

            // Imagen
            pbFoto.BorderStyle = BorderStyle.FixedSingle;
            pbFoto.Location = new Point(20, 220);
            pbFoto.Size = new Size(120, 120);
            pbFoto.SizeMode = PictureBoxSizeMode.Zoom;

            btnSeleccionarFoto.Location = new Point(20, 350);
            btnSeleccionarFoto.Size = new Size(120, 30);
            btnSeleccionarFoto.Text = "Seleccionar Foto";
            btnSeleccionarFoto.Click += btnSeleccionarFoto_Click;

            btnGuardar.Location = new Point(260, 220);
            btnGuardar.Size = new Size(120, 35);
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;

            btnCancelar.Location = new Point(260, 265);
            btnCancelar.Size = new Size(120, 35);
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;

            // Form
            ClientSize = new Size(420, 400);
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

            Text = "Editar Perfil del Vendedor";
            Load += FrmEditarPerfilVendedor_Load;

            ((System.ComponentModel.ISupportInitialize)pbFoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
