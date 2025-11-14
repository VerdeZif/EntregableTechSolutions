namespace Presentacion.Forms
{
    partial class FrmRegistroProductos
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
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbImagen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(158, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(236, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Productos";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(35, 60);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(35, 90);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(72, 15);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Descripción:";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(35, 120);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(43, 15);
            lblPrecio.TabIndex = 5;
            lblPrecio.Text = "Precio:";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(35, 150);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(39, 15);
            lblStock.TabIndex = 7;
            lblStock.Text = "Stock:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(122, 56);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(219, 23);
            txtNombre.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(122, 86);
            txtDescripcion.Margin = new Padding(3, 2, 3, 2);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(219, 23);
            txtDescripcion.TabIndex = 4;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(122, 116);
            txtPrecio.Margin = new Padding(3, 2, 3, 2);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(219, 23);
            txtPrecio.TabIndex = 6;
            // 
            // numStock
            // 
            numStock.Location = new Point(122, 146);
            numStock.Margin = new Padding(3, 2, 3, 2);
            numStock.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(88, 23);
            numStock.TabIndex = 8;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(368, 56);
            btnAgregar.Margin = new Padding(3, 2, 3, 2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(66, 23);
            btnAgregar.TabIndex = 9;
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(368, 86);
            btnEditar.Margin = new Padding(3, 2, 3, 2);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(66, 23);
            btnEditar.TabIndex = 10;
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(368, 116);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(66, 23);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnSeleccionarImagen
            // 
            btnSeleccionarImagen.Location = new Point(469, 145);
            btnSeleccionarImagen.Margin = new Padding(3, 2, 3, 2);
            btnSeleccionarImagen.Name = "btnSeleccionarImagen";
            btnSeleccionarImagen.Size = new Size(78, 26);
            btnSeleccionarImagen.TabIndex = 13;
            btnSeleccionarImagen.Text = "Seleccionar";
            btnSeleccionarImagen.Click += btnSeleccionarImagen_Click;
            // 
            // pbImagen
            // 
            pbImagen.BorderStyle = BorderStyle.FixedSingle;
            pbImagen.Location = new Point(455, 56);
            pbImagen.Margin = new Padding(3, 2, 3, 2);
            pbImagen.Name = "pbImagen";
            pbImagen.Size = new Size(105, 83);
            pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImagen.TabIndex = 12;
            pbImagen.TabStop = false;
            // 
            // dgvProductos
            // 
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.Location = new Point(35, 188);
            dgvProductos.Margin = new Padding(3, 2, 3, 2);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(525, 150);
            dgvProductos.TabIndex = 14;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // FrmRegistroProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 360);
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
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmRegistroProductos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Productos";
            Load += FrmProductos_Load;
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbImagen).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
