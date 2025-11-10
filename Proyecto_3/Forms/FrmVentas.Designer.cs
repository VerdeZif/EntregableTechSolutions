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
            label1 = new Label();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(175, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(207, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registro de Ventas";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(22, 56);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(47, 15);
            lblCliente.TabIndex = 1;
            lblCliente.Text = "Cliente:";
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Location = new Point(22, 90);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(59, 15);
            lblProducto.TabIndex = 3;
            lblProducto.Text = "Producto:";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(22, 160);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(58, 15);
            lblCantidad.TabIndex = 5;
            lblCantidad.Text = "Cantidad:";
            // 
            // lblVendedor
            // 
            lblVendedor.AutoSize = true;
            lblVendedor.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblVendedor.Location = new Point(350, 60);
            lblVendedor.Name = "lblVendedor";
            lblVendedor.Size = new Size(72, 19);
            lblVendedor.TabIndex = 7;
            lblVendedor.Text = "Vendedor:";
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.Location = new Point(105, 56);
            cmbCliente.Margin = new Padding(3, 2, 3, 2);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(219, 23);
            cmbCliente.TabIndex = 2;
            // 
            // cmbProducto
            // 
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducto.Location = new Point(105, 90);
            cmbProducto.Margin = new Padding(3, 2, 3, 2);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(219, 23);
            cmbProducto.TabIndex = 4;
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(105, 158);
            numCantidad.Margin = new Padding(3, 2, 3, 2);
            numCantidad.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(105, 23);
            numCantidad.TabIndex = 6;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(350, 90);
            btnAgregar.Margin = new Padding(3, 2, 3, 2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(144, 21);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar Producto";
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(350, 124);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(144, 21);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar Seleccionado";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnRegistrarVenta
            // 
            btnRegistrarVenta.Location = new Point(224, 415);
            btnRegistrarVenta.Margin = new Padding(3, 2, 3, 2);
            btnRegistrarVenta.Name = "btnRegistrarVenta";
            btnRegistrarVenta.Size = new Size(158, 30);
            btnRegistrarVenta.TabIndex = 12;
            btnRegistrarVenta.Text = "Registrar Venta";
            btnRegistrarVenta.Click += btnRegistrarVenta_Click;
            // 
            // dgvDetalles
            // 
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.Location = new Point(35, 210);
            dgvDetalles.Margin = new Padding(3, 2, 3, 2);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(525, 150);
            dgvDetalles.TabIndex = 10;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(453, 371);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(107, 21);
            lblTotal.TabIndex = 11;
            lblTotal.Text = "Total: S/ 0.00";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 127);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 13;
            label1.Text = "Descripción:";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(105, 122);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(219, 23);
            textBox1.TabIndex = 14;
            // 
            // FrmVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(614, 468);
            Controls.Add(textBox1);
            Controls.Add(label1);
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
            Margin = new Padding(3, 2, 3, 2);
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

        private Label label1;
        private TextBox textBox1;
    }
}
