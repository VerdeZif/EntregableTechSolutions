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

            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            SuspendLayout();

            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(200, 20);
            lblTitulo.Text = "Registro de Ventas";

            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(40, 80);
            lblCliente.Text = "Cliente:";

            cmbCliente.Location = new Point(120, 75);
            cmbCliente.Width = 250;
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;

            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Location = new Point(40, 120);
            lblProducto.Text = "Producto:";

            cmbProducto.Location = new Point(120, 115);
            cmbProducto.Width = 250;
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;

            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(40, 160);
            lblCantidad.Text = "Cantidad:";

            numCantidad.Location = new Point(120, 155);
            numCantidad.Maximum = 1000;

            // 
            // lblVendedor
            // 
            lblVendedor.AutoSize = true;
            lblVendedor.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblVendedor.Location = new Point(400, 80);
            lblVendedor.Text = "Vendedor:";

            // 
            // Botones
            // 
            btnAgregar.Text = "Agregar Producto";
            btnAgregar.Location = new Point(400, 115);
            btnAgregar.Click += btnAgregar_Click;

            btnEliminar.Text = "Eliminar Seleccionado";
            btnEliminar.Location = new Point(400, 155);
            btnEliminar.Click += btnEliminar_Click;

            btnRegistrarVenta.Text = "Registrar Venta";
            btnRegistrarVenta.Location = new Point(250, 450);
            btnRegistrarVenta.Size = new Size(180, 40);
            btnRegistrarVenta.Click += btnRegistrarVenta_Click;

            // 
            // dgvDetalles
            // 
            dgvDetalles.Location = new Point(40, 210);
            dgvDetalles.Size = new Size(600, 200);
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.ReadOnly = true;

            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(460, 420);
            lblTotal.Text = "Total: S/ 0.00";

            // 
            // FrmVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 520);
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

            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
