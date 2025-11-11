namespace Presentacion.Forms
{
    partial class FrmVentas
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private Label lblCliente;
        private Label lblProducto;
        private Label lblCantidad;
        private Label lblVendedor;
        private ComboBox cmbCliente;
        private ComboBox cmbProducto;
        private NumericUpDown numCantidad;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnRegistrarVenta;
        private DataGridView dgvDetalles;
        private Label lblTotal;

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
            lblCliente = new Label();
            lblProducto = new Label();
            lblCantidad = new Label();
            lblVendedor = new Label();
            cmbCliente = new ComboBox();
            cmbProducto = new ComboBox();
            numCantidad = new NumericUpDown();
            btnAgregar = new Button();
            btnEliminar = new Button();
            btnRegistrarVenta = new Button();
            dgvDetalles = new DataGridView();
            lblTotal = new Label();

            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();

            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(175, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(207, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registro de Ventas";

            // lblCliente
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(22, 60);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(47, 15);
            lblCliente.TabIndex = 1;
            lblCliente.Text = "Cliente:";

            // cmbCliente
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.Location = new Point(105, 56);
            cmbCliente.Size = new Size(219, 23);
            cmbCliente.TabIndex = 2;

            // lblProducto
            lblProducto.AutoSize = true;
            lblProducto.Location = new Point(22, 95);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(59, 15);
            lblProducto.TabIndex = 3;
            lblProducto.Text = "Producto:";

            // cmbProducto
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducto.Location = new Point(105, 90);
            cmbProducto.Size = new Size(219, 23);
            cmbProducto.TabIndex = 4;

            // lblCantidad
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(22, 130);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(58, 15);
            lblCantidad.TabIndex = 5;
            lblCantidad.Text = "Cantidad:";

            // numCantidad
            numCantidad.Location = new Point(105, 128);
            numCantidad.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(105, 23);
            numCantidad.TabIndex = 6;
            numCantidad.Value = 1;

            // lblVendedor
            lblVendedor.AutoSize = true;
            lblVendedor.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblVendedor.Location = new Point(350, 60);
            lblVendedor.Name = "lblVendedor";
            lblVendedor.Size = new Size(72, 19);
            lblVendedor.TabIndex = 7;
            lblVendedor.Text = "Vendedor:";

            // btnAgregar
            btnAgregar.Location = new Point(350, 90);
            btnAgregar.Size = new Size(144, 23);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar Producto";
            btnAgregar.Click += btnAgregar_Click;

            // btnEliminar
            btnEliminar.Location = new Point(350, 124);
            btnEliminar.Size = new Size(144, 23);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar Seleccionado";
            btnEliminar.Click += btnEliminar_Click;

            // dgvDetalles
            dgvDetalles.Location = new Point(35, 170);
            dgvDetalles.Size = new Size(525, 200);
            dgvDetalles.ReadOnly = true;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.TabIndex = 10;

            // lblTotal
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(420, 380);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(107, 21);
            lblTotal.TabIndex = 11;
            lblTotal.Text = "Total: S/ 0.00";

            // btnRegistrarVenta
            btnRegistrarVenta.Location = new Point(220, 415);
            btnRegistrarVenta.Size = new Size(158, 30);
            btnRegistrarVenta.TabIndex = 12;
            btnRegistrarVenta.Text = "Registrar Venta";
            btnRegistrarVenta.Click += btnRegistrarVenta_Click;

            // FrmVentas
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(614, 468);
            Controls.Add(lblTitulo);
            Controls.Add(lblCliente);
            Controls.Add(cmbCliente);
            Controls.Add(lblProducto);
            Controls.Add(cmbProducto);
            Controls.Add(lblCantidad);
            Controls.Add(numCantidad);
            Controls.Add(lblVendedor);
            Controls.Add(btnAgregar);
            Controls.Add(btnEliminar);
            Controls.Add(dgvDetalles);
            Controls.Add(lblTotal);
            Controls.Add(btnRegistrarVenta);
            Name = "FrmVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Ventas";
            Load += FrmVentas_Load;

            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
