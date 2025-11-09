namespace Presentacion.Forms
{
    partial class FrmProductos
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Label lblNombre;
        private Label lblDescripcion;
        private Label lblPrecio;
        private Label lblStock;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private TextBox txtPrecio;
        private NumericUpDown numStock;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnSeleccionarImagen;
        private PictureBox pbImagen;
        private DataGridView dgvProductos;

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
            lblDescripcion = new Label();
            lblPrecio = new Label();
            lblStock = new Label();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            txtPrecio = new TextBox();
            numStock = new NumericUpDown();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnSeleccionarImagen = new Button();
            pbImagen = new PictureBox();
            dgvProductos = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbImagen).BeginInit();
            SuspendLayout();

            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(180, 20);
            lblTitulo.Text = "Gestión de Productos";

            // lblNombre
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(40, 80);
            lblNombre.Text = "Nombre:";

            // txtNombre
            txtNombre.Location = new Point(140, 75);
            txtNombre.Width = 250;

            // lblDescripcion
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(40, 120);
            lblDescripcion.Text = "Descripción:";

            // txtDescripcion
            txtDescripcion.Location = new Point(140, 115);
            txtDescripcion.Width = 250;

            // lblPrecio
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(40, 160);
            lblPrecio.Text = "Precio:";

            // txtPrecio
            txtPrecio.Location = new Point(140, 155);
            txtPrecio.Width = 250;

            // lblStock
            lblStock.AutoSize = true;
            lblStock.Location = new Point(40, 200);
            lblStock.Text = "Stock:";

            // numStock
            numStock.Location = new Point(140, 195);
            numStock.Width = 100;
            numStock.Maximum = 10000;

            // btnAgregar
            btnAgregar.Text = "Agregar";
            btnAgregar.Location = new Point(420, 75);
            btnAgregar.Click += btnAgregar_Click;

            // btnEditar
            btnEditar.Text = "Editar";
            btnEditar.Location = new Point(420, 115);
            btnEditar.Click += btnEditar_Click;

            // btnEliminar
            btnEliminar.Text = "Eliminar";
            btnEliminar.Location = new Point(420, 155);
            btnEliminar.Click += btnEliminar_Click;

            // pbImagen
            pbImagen.BorderStyle = BorderStyle.FixedSingle;
            pbImagen.Location = new Point(520, 50);
            pbImagen.Size = new Size(100, 100);
            pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            // btnSeleccionarImagen
            btnSeleccionarImagen.Text = "Seleccionar Imagen";
            btnSeleccionarImagen.Location = new Point(520, 160);
            btnSeleccionarImagen.Click += btnSeleccionarImagen_Click;

            // dgvProductos
            dgvProductos.Location = new Point(40, 250);
            dgvProductos.Size = new Size(600, 200);
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.ReadOnly = true;
            dgvProductos.CellClick += dgvProductos_CellClick;

            // FrmProductos
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 480);
            Controls.Add(lblTitulo);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblDescripcion);
            Controls.Add(txtDescripcion);
            Controls.Add(lblPrecio);
            Controls.Add(txtPrecio);
            Controls.Add(lblStock);
            Controls.Add(numStock);
            Controls.Add(btnAgregar);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(pbImagen);
            Controls.Add(btnSeleccionarImagen);
            Controls.Add(dgvProductos);
            Name = "FrmProductos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Productos";
            Load += FrmProductos_Load;

            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbImagen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
