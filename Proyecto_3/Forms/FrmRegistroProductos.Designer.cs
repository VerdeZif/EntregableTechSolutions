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
            lblTitulo.Location = new Point(254, 20);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(279, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "GESTION DE PRODUCTOS";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(45, 80);
            lblNombre.Margin = new Padding(4, 0, 4, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(76, 20);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "NOMBRE:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(45, 120);
            lblDescripcion.Margin = new Padding(4, 0, 4, 0);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(107, 20);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "DESCRIPCION:";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(45, 160);
            lblPrecio.Margin = new Padding(4, 0, 4, 0);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(63, 20);
            lblPrecio.TabIndex = 5;
            lblPrecio.Text = "PRECIO:";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(45, 200);
            lblStock.Margin = new Padding(4, 0, 4, 0);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(57, 20);
            lblStock.TabIndex = 7;
            lblStock.Text = "STOCK:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(157, 75);
            txtNombre.Margin = new Padding(4, 3, 4, 3);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(280, 27);
            txtNombre.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(157, 115);
            txtDescripcion.Margin = new Padding(4, 3, 4, 3);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(280, 27);
            txtDescripcion.TabIndex = 4;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(157, 155);
            txtPrecio.Margin = new Padding(4, 3, 4, 3);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(280, 27);
            txtPrecio.TabIndex = 6;
            // 
            // numStock
            // 
            numStock.Location = new Point(157, 195);
            numStock.Margin = new Padding(4, 3, 4, 3);
            numStock.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(113, 27);
            numStock.TabIndex = 8;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.Thistle;
            btnAgregar.Location = new Point(457, 78);
            btnAgregar.Margin = new Padding(4, 3, 4, 3);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(85, 31);
            btnAgregar.TabIndex = 9;
            btnAgregar.Text = "AGREGAR";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.Aquamarine;
            btnEditar.Location = new Point(457, 118);
            btnEditar.Margin = new Padding(4, 3, 4, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(85, 31);
            btnEditar.TabIndex = 10;
            btnEditar.Text = "EDITAR";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.MistyRose;
            btnEliminar.Location = new Point(457, 155);
            btnEliminar.Margin = new Padding(4, 3, 4, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(85, 31);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnSeleccionarImagen
            // 
            btnSeleccionarImagen.BackColor = Color.LemonChiffon;
            btnSeleccionarImagen.Location = new Point(595, 200);
            btnSeleccionarImagen.Margin = new Padding(4, 3, 4, 3);
            btnSeleccionarImagen.Name = "btnSeleccionarImagen";
            btnSeleccionarImagen.Size = new Size(117, 35);
            btnSeleccionarImagen.TabIndex = 13;
            btnSeleccionarImagen.Text = "SELECCIONAR";
            btnSeleccionarImagen.UseVisualStyleBackColor = false;
            btnSeleccionarImagen.Click += btnSeleccionarImagen_Click;
            // 
            // pbImagen
            // 
            pbImagen.BackColor = SystemColors.Control;
            pbImagen.BorderStyle = BorderStyle.FixedSingle;
            pbImagen.Location = new Point(561, 75);
            pbImagen.Margin = new Padding(4, 3, 4, 3);
            pbImagen.Name = "pbImagen";
            pbImagen.Size = new Size(196, 119);
            pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImagen.TabIndex = 12;
            pbImagen.TabStop = false;
            // 
            // dgvProductos
            // 
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.ColumnHeadersHeight = 25;
            dgvProductos.Location = new Point(45, 253);
            dgvProductos.Margin = new Padding(4, 3, 4, 3);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(712, 200);
            dgvProductos.TabIndex = 14;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // FrmRegistroProductos
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(787, 480);
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
            Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmRegistroProductos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GESTION DE PRODUCTOS";
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
