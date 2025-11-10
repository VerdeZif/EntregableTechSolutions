namespace Presentacion.Forms
{
    partial class FrmRegistroVendedor
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Button btnSeleccionarFoto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvVendedores;
        private System.Windows.Forms.GroupBox groupBoxDatos;
        private System.Windows.Forms.GroupBox groupBoxLista;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBoxDatos = new System.Windows.Forms.GroupBox();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.btnSeleccionarFoto = new System.Windows.Forms.Button();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.groupBoxLista = new System.Windows.Forms.GroupBox();
            this.dgvVendedores = new System.Windows.Forms.DataGridView();

            // groupBoxDatos
            this.groupBoxDatos.Controls.Add(this.pbFoto);
            this.groupBoxDatos.Controls.Add(this.btnSeleccionarFoto);
            this.groupBoxDatos.Controls.Add(this.txtTelefono);
            this.groupBoxDatos.Controls.Add(this.txtCorreo);
            this.groupBoxDatos.Controls.Add(this.txtPassword);
            this.groupBoxDatos.Controls.Add(this.txtUsuario);
            this.groupBoxDatos.Controls.Add(this.txtNombre);
            this.groupBoxDatos.Controls.Add(this.lblTelefono);
            this.groupBoxDatos.Controls.Add(this.lblCorreo);
            this.groupBoxDatos.Controls.Add(this.lblPassword);
            this.groupBoxDatos.Controls.Add(this.lblUsuario);
            this.groupBoxDatos.Controls.Add(this.lblNombre);
            this.groupBoxDatos.Controls.Add(this.btnAgregar);
            this.groupBoxDatos.Controls.Add(this.btnEditar);
            this.groupBoxDatos.Controls.Add(this.btnEliminar);
            this.groupBoxDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxDatos.Height = 200;
            this.groupBoxDatos.Text = "Datos del Vendedor";

            // lblNombre
            this.lblNombre.Location = new System.Drawing.Point(20, 30);
            this.lblNombre.Size = new System.Drawing.Size(80, 20);
            this.lblNombre.Text = "Nombre:";
            this.txtNombre.Location = new System.Drawing.Point(110, 27);
            this.txtNombre.Size = new System.Drawing.Size(200, 22);

            // lblUsuario
            this.lblUsuario.Location = new System.Drawing.Point(20, 60);
            this.lblUsuario.Size = new System.Drawing.Size(80, 20);
            this.lblUsuario.Text = "Usuario:";
            this.txtUsuario.Location = new System.Drawing.Point(110, 57);
            this.txtUsuario.Size = new System.Drawing.Size(200, 22);

            // lblPassword
            this.lblPassword.Location = new System.Drawing.Point(20, 90);
            this.lblPassword.Size = new System.Drawing.Size(80, 20);
            this.lblPassword.Text = "Contraseña:";
            this.txtPassword.Location = new System.Drawing.Point(110, 87);
            this.txtPassword.Size = new System.Drawing.Size(200, 22);
            this.txtPassword.UseSystemPasswordChar = true;

            // lblCorreo
            this.lblCorreo.Location = new System.Drawing.Point(350, 30);
            this.lblCorreo.Size = new System.Drawing.Size(80, 20);
            this.lblCorreo.Text = "Correo:";
            this.txtCorreo.Location = new System.Drawing.Point(440, 27);
            this.txtCorreo.Size = new System.Drawing.Size(200, 22);

            // lblTelefono
            this.lblTelefono.Location = new System.Drawing.Point(350, 60);
            this.lblTelefono.Size = new System.Drawing.Size(80, 20);
            this.lblTelefono.Text = "Teléfono:";
            this.txtTelefono.Location = new System.Drawing.Point(440, 57);
            this.txtTelefono.Size = new System.Drawing.Size(200, 22);

            // pbFoto
            this.pbFoto.Location = new System.Drawing.Point(680, 27);
            this.pbFoto.Size = new System.Drawing.Size(100, 100);
            this.pbFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            // btnSeleccionarFoto
            this.btnSeleccionarFoto.Location = new System.Drawing.Point(680, 135);
            this.btnSeleccionarFoto.Size = new System.Drawing.Size(100, 30);
            this.btnSeleccionarFoto.Text = "Seleccionar Foto";
            this.btnSeleccionarFoto.Click += new System.EventHandler(this.btnSeleccionarFoto_Click);

            // btnAgregar
            this.btnAgregar.Location = new System.Drawing.Point(20, 130);
            this.btnAgregar.Size = new System.Drawing.Size(90, 30);
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            // btnEditar
            this.btnEditar.Location = new System.Drawing.Point(130, 130);
            this.btnEditar.Size = new System.Drawing.Size(90, 30);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            // btnEliminar
            this.btnEliminar.Location = new System.Drawing.Point(240, 130);
            this.btnEliminar.Size = new System.Drawing.Size(90, 30);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // groupBoxLista
            this.groupBoxLista.Controls.Add(this.dgvVendedores);
            this.groupBoxLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLista.Text = "Lista de Vendedores";

            // dgvVendedores
            this.dgvVendedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVendedores.ReadOnly = true;
            this.dgvVendedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendedores.MultiSelect = false;
            this.dgvVendedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVendedores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVendedores_CellClick);

            // FrmRegistroVendedor
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxLista);
            this.Controls.Add(this.groupBoxDatos);
            this.Text = "Registro de Vendedores";
            this.Load += new System.EventHandler(this.FrmRegistroVendedor_Load);
        }
    }
}
