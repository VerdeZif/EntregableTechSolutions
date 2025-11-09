namespace Presentacion.Forms
{
    partial class FrmUsuarios
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Label lblUsuario;
        private Label lblNombre;
        private Label lblClave;
        private Label lblRol;
        private TextBox txtUsuario;
        private TextBox txtNombre;
        private TextBox txtClave;
        private ComboBox cbRol;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnSeleccionarFoto;
        private DataGridView dgvUsuarios;
        private PictureBox pictureBoxFoto;

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
            lblNombre = new Label();
            lblClave = new Label();
            lblRol = new Label();
            txtUsuario = new TextBox();
            txtNombre = new TextBox();
            txtClave = new TextBox();
            cbRol = new ComboBox();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnSeleccionarFoto = new Button();
            dgvUsuarios = new DataGridView();
            pictureBoxFoto = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFoto).BeginInit();
            SuspendLayout();

            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new System.Drawing.Point(200, 20);
            lblTitulo.Text = "Gestión de Usuarios";

            // lblUsuario
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new System.Drawing.Point(40, 80);
            lblUsuario.Text = "Usuario:";
            txtUsuario.Location = new System.Drawing.Point(140, 75);
            txtUsuario.Width = 250;

            // lblNombre
            lblNombre.AutoSize = true;
            lblNombre.Location = new System.Drawing.Point(40, 120);
            lblNombre.Text = "Nombre Completo:";
            txtNombre.Location = new System.Drawing.Point(180, 115);
            txtNombre.Width = 250;

            // lblClave
            lblClave.AutoSize = true;
            lblClave.Location = new System.Drawing.Point(40, 160);
            lblClave.Text = "Contraseña:";
            txtClave.Location = new System.Drawing.Point(140, 155);
            txtClave.Width = 250;
            txtClave.UseSystemPasswordChar = true;

            // lblRol
            lblRol.AutoSize = true;
            lblRol.Location = new System.Drawing.Point(40, 200);
            lblRol.Text = "Rol:";
            cbRol.Location = new System.Drawing.Point(140, 195);
            cbRol.Width = 200;
            cbRol.DropDownStyle = ComboBoxStyle.DropDownList;

            // btnAgregar
            btnAgregar.Text = "Agregar";
            btnAgregar.Location = new System.Drawing.Point(420, 75);
            btnAgregar.Click += btnAgregar_Click;

            // btnEditar
            btnEditar.Text = "Editar";
            btnEditar.Location = new System.Drawing.Point(420, 115);
            btnEditar.Click += btnEditar_Click;

            // btnEliminar
            btnEliminar.Text = "Eliminar";
            btnEliminar.Location = new System.Drawing.Point(420, 155);
            btnEliminar.Click += btnEliminar_Click;

            // pictureBoxFoto
            pictureBoxFoto.Location = new System.Drawing.Point(140, 230);
            pictureBoxFoto.Size = new System.Drawing.Size(120, 120);
            pictureBoxFoto.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxFoto.SizeMode = PictureBoxSizeMode.StretchImage;

            // btnSeleccionarFoto
            btnSeleccionarFoto.Text = "Seleccionar Foto";
            btnSeleccionarFoto.Location = new System.Drawing.Point(280, 280);
            btnSeleccionarFoto.Click += btnSeleccionarFoto_Click;

            // dgvUsuarios
            dgvUsuarios.Location = new System.Drawing.Point(40, 370);
            dgvUsuarios.Size = new System.Drawing.Size(600, 200);
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;

            // FrmUsuarios
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 600);
            Controls.Add(lblTitulo);
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblClave);
            Controls.Add(txtClave);
            Controls.Add(lblRol);
            Controls.Add(cbRol);
            Controls.Add(btnAgregar);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(pictureBoxFoto);
            Controls.Add(btnSeleccionarFoto);
            Controls.Add(dgvUsuarios);
            Name = "FrmUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Usuarios";
            Load += FrmUsuarios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
