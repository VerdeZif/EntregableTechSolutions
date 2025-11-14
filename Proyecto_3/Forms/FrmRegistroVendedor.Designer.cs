namespace Presentacion.Forms
{
    partial class FrmRegistroVendedor
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtPassword;
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
            groupBoxDatos = new GroupBox();
            pbFoto = new PictureBox();
            btnSeleccionarFoto = new Button();
            txtPassword = new TextBox();
            txtUsuario = new TextBox();
            txtNombre = new TextBox();
            lblPassword = new Label();
            lblUsuario = new Label();
            lblNombre = new Label();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            groupBoxLista = new GroupBox();
            dgvVendedores = new DataGridView();
            button1 = new Button();
            groupBoxDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbFoto).BeginInit();
            groupBoxLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVendedores).BeginInit();
            SuspendLayout();
            // 
            // groupBoxDatos
            // 
            groupBoxDatos.BackColor = SystemColors.GradientActiveCaption;
            groupBoxDatos.Controls.Add(button1);
            groupBoxDatos.Controls.Add(pbFoto);
            groupBoxDatos.Controls.Add(btnSeleccionarFoto);
            groupBoxDatos.Controls.Add(txtPassword);
            groupBoxDatos.Controls.Add(txtUsuario);
            groupBoxDatos.Controls.Add(txtNombre);
            groupBoxDatos.Controls.Add(lblPassword);
            groupBoxDatos.Controls.Add(lblUsuario);
            groupBoxDatos.Controls.Add(lblNombre);
            groupBoxDatos.Controls.Add(btnAgregar);
            groupBoxDatos.Controls.Add(btnEditar);
            groupBoxDatos.Controls.Add(btnEliminar);
            groupBoxDatos.Dock = DockStyle.Top;
            groupBoxDatos.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxDatos.Location = new Point(0, 0);
            groupBoxDatos.Name = "groupBoxDatos";
            groupBoxDatos.Size = new Size(800, 180);
            groupBoxDatos.TabIndex = 1;
            groupBoxDatos.TabStop = false;
            groupBoxDatos.Text = "DATOS DEL VENDEDOR";
            // 
            // pbFoto
            // 
            pbFoto.BackColor = SystemColors.Control;
            pbFoto.BorderStyle = BorderStyle.FixedSingle;
            pbFoto.Location = new Point(637, 15);
            pbFoto.Name = "pbFoto";
            pbFoto.Size = new Size(151, 126);
            pbFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pbFoto.TabIndex = 0;
            pbFoto.TabStop = false;
            // 
            // btnSeleccionarFoto
            // 
            btnSeleccionarFoto.BackColor = Color.LemonChiffon;
            btnSeleccionarFoto.Location = new Point(657, 150);
            btnSeleccionarFoto.Name = "btnSeleccionarFoto";
            btnSeleccionarFoto.Size = new Size(115, 30);
            btnSeleccionarFoto.TabIndex = 1;
            btnSeleccionarFoto.Text = "SELECCIONAR";
            btnSeleccionarFoto.UseVisualStyleBackColor = false;
            btnSeleccionarFoto.Click += btnSeleccionarFoto_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(141, 87);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(245, 27);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(141, 57);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(245, 27);
            txtUsuario.TabIndex = 3;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(141, 27);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(245, 27);
            txtNombre.TabIndex = 4;
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(20, 90);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(115, 20);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "CONTRASEÑA:";
            // 
            // lblUsuario
            // 
            lblUsuario.Location = new Point(20, 60);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(80, 20);
            lblUsuario.TabIndex = 6;
            lblUsuario.Text = "USUARIO:";
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(20, 30);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(80, 20);
            lblNombre.TabIndex = 7;
            lblNombre.Text = "NOMBRE:";
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.Thistle;
            btnAgregar.Location = new Point(433, 20);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(100, 30);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "AGREGAR";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.Aquamarine;
            btnEditar.Location = new Point(433, 57);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 30);
            btnEditar.TabIndex = 9;
            btnEditar.Text = "EDITAR";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.MistyRose;
            btnEliminar.Location = new Point(433, 93);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(96, 30);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // groupBoxLista
            // 
            groupBoxLista.BackColor = SystemColors.GradientInactiveCaption;
            groupBoxLista.Controls.Add(dgvVendedores);
            groupBoxLista.Dock = DockStyle.Fill;
            groupBoxLista.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxLista.Location = new Point(0, 180);
            groupBoxLista.Name = "groupBoxLista";
            groupBoxLista.Size = new Size(800, 270);
            groupBoxLista.TabIndex = 0;
            groupBoxLista.TabStop = false;
            groupBoxLista.Text = "LISTA DE VENDEDORES";
            // 
            // dgvVendedores
            // 
            dgvVendedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVendedores.ColumnHeadersHeight = 25;
            dgvVendedores.Dock = DockStyle.Fill;
            dgvVendedores.Location = new Point(3, 23);
            dgvVendedores.MultiSelect = false;
            dgvVendedores.Name = "dgvVendedores";
            dgvVendedores.ReadOnly = true;
            dgvVendedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVendedores.Size = new Size(794, 244);
            dgvVendedores.TabIndex = 0;
            dgvVendedores.CellClick += dgvVendedores_CellClick;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.ForeColor = Color.White;
            button1.Location = new Point(433, 129);
            button1.Name = "button1";
            button1.Size = new Size(96, 30);
            button1.TabIndex = 11;
            button1.Text = "REGRESAR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // FrmRegistroVendedor
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(groupBoxLista);
            Controls.Add(groupBoxDatos);
            Name = "FrmRegistroVendedor";
            Text = "REGISTRO DE VENDEDORES";
            Load += FrmRegistroVendedor_Load;
            groupBoxDatos.ResumeLayout(false);
            groupBoxDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbFoto).EndInit();
            groupBoxLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVendedores).EndInit();
            ResumeLayout(false);
        }
        private Button button1;
    }
}
