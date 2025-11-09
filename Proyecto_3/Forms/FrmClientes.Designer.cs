namespace Presentacion.Forms
{
    partial class FrmClientes
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Label lblNombre;
        private Label lblCorreo;
        private Label lblTelefono;
        private TextBox txtNombre;
        private TextBox txtCorreo;
        private TextBox txtTelefono;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
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
            txtNombre = new TextBox();
            txtCorreo = new TextBox();
            txtTelefono = new TextBox();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            dgvClientes = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();

            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(200, 20);
            lblTitulo.Text = "Gestión de Clientes";

            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(40, 80);
            lblNombre.Text = "Nombre:";

            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(140, 75);
            txtNombre.Width = 250;

            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(40, 120);
            lblCorreo.Text = "Correo:";

            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(140, 115);
            txtCorreo.Width = 250;

            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(40, 160);
            lblTelefono.Text = "Teléfono:";

            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(140, 155);
            txtTelefono.Width = 250;

            // 
            // btnAgregar
            // 
            btnAgregar.Text = "Agregar";
            btnAgregar.Location = new Point(420, 75);
            btnAgregar.Click += btnAgregar_Click;

            // 
            // btnEditar
            // 
            btnEditar.Text = "Editar";
            btnEditar.Location = new Point(420, 115);
            btnEditar.Click += btnEditar_Click;

            // 
            // btnEliminar
            // 
            btnEliminar.Text = "Eliminar";
            btnEliminar.Location = new Point(420, 155);
            btnEliminar.Click += btnEliminar_Click;

            // 
            // dgvClientes
            // 
            dgvClientes.Location = new Point(40, 220);
            dgvClientes.Size = new Size(600, 200);
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.ReadOnly = true;
            dgvClientes.CellClick += dgvClientes_CellClick;

            // 
            // FrmClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 460);
            Controls.Add(lblTitulo);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblCorreo);
            Controls.Add(txtCorreo);
            Controls.Add(lblTelefono);
            Controls.Add(txtTelefono);
            Controls.Add(btnAgregar);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(dgvClientes);
            Name = "FrmClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Clientes";
            Load += FrmClientes_Load;

            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
