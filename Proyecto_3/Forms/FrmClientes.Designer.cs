namespace Presentacion.Forms
{
    partial class FrmClientes
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Label lblNombre;
        private Label lblCorreo;
        private Label lblTelefono;
        private Label lblDireccion;
        private TextBox txtNombre;
        private TextBox txtCorreo;
        private TextBox txtTelefono;
        private TextBox txtDireccion;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnSeleccionarFoto;
        private PictureBox pbFoto;
        private DataGridView dgvClientes;

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
            lblNombre = new Label();
            lblCorreo = new Label();
            lblTelefono = new Label();
            lblDireccion = new Label();
            txtNombre = new TextBox();
            txtCorreo = new TextBox();
            txtTelefono = new TextBox();
            txtDireccion = new TextBox();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnSeleccionarFoto = new Button();
            pbFoto = new PictureBox();
            dgvClientes = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFoto).BeginInit();
            SuspendLayout();

            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitulo.Location = new System.Drawing.Point(200, 20);
            lblTitulo.Text = "Gestión de Clientes";

            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new System.Drawing.Point(40, 80);
            lblNombre.Text = "Nombre:";

            // 
            // txtNombre
            // 
            txtNombre.Location = new System.Drawing.Point(140, 75);
            txtNombre.Width = 250;

            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new System.Drawing.Point(40, 120);
            lblCorreo.Text = "Correo:";

            // 
            // txtCorreo
            // 
            txtCorreo.Location = new System.Drawing.Point(140, 115);
            txtCorreo.Width = 250;

            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new System.Drawing.Point(40, 160);
            lblTelefono.Text = "Teléfono:";

            // 
            // txtTelefono
            // 
            txtTelefono.Location = new System.Drawing.Point(140, 155);
            txtTelefono.Width = 250;

            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new System.Drawing.Point(40, 200);
            lblDireccion.Text = "Dirección:";

            // 
            // txtDireccion
            // 
            txtDireccion.Location = new System.Drawing.Point(140, 195);
            txtDireccion.Width = 250;

            // 
            // btnAgregar
            // 
            btnAgregar.Text = "Agregar";
            btnAgregar.Location = new System.Drawing.Point(420, 75);
            btnAgregar.Click += btnAgregar_Click;

            // 
            // btnEditar
            // 
            btnEditar.Text = "Editar";
            btnEditar.Location = new System.Drawing.Point(420, 115);
            btnEditar.Click += btnEditar_Click;

            // 
            // btnEliminar
            // 
            btnEliminar.Text = "Eliminar";
            btnEliminar.Location = new System.Drawing.Point(420, 155);
            btnEliminar.Click += btnEliminar_Click;

            // 
            // btnSeleccionarFoto
            // 
            btnSeleccionarFoto.Text = "Seleccionar Foto";
            btnSeleccionarFoto.Location = new System.Drawing.Point(420, 195);
            btnSeleccionarFoto.Click += btnSeleccionarFoto_Click;

            // 
            // pbFoto
            // 
            pbFoto.Location = new System.Drawing.Point(600, 75);
            pbFoto.Size = new System.Drawing.Size(120, 120);
            pbFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pbFoto.SizeMode = PictureBoxSizeMode.StretchImage;

            // 
            // dgvClientes
            // 
            dgvClientes.Location = new System.Drawing.Point(40, 250);
            dgvClientes.Size = new System.Drawing.Size(680, 200);
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.ReadOnly = true;
            dgvClientes.CellClick += dgvClientes_CellClick;

            // 
            // FrmClientes
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 480);
            Controls.Add(lblTitulo);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblCorreo);
            Controls.Add(txtCorreo);
            Controls.Add(lblTelefono);
            Controls.Add(txtTelefono);
            Controls.Add(lblDireccion);
            Controls.Add(txtDireccion);
            Controls.Add(btnAgregar);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(btnSeleccionarFoto);
            Controls.Add(pbFoto);
            Controls.Add(dgvClientes);
            Name = "FrmClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Clientes";
            Load += FrmClientes_Load;

            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
