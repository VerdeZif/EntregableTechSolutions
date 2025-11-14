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
            button1 = new Button();
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
            lblTitulo.Size = new Size(240, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REGISTRO DE VENTAS";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblCliente.Location = new Point(22, 60);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(69, 20);
            lblCliente.TabIndex = 1;
            lblCliente.Text = "CLIENTE:";
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblProducto.Location = new Point(22, 95);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(91, 20);
            lblProducto.TabIndex = 3;
            lblProducto.Text = "PRODUCTO:";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCantidad.Location = new Point(22, 130);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(88, 20);
            lblCantidad.TabIndex = 5;
            lblCantidad.Text = "CANTIDAD:";
            // 
            // lblVendedor
            // 
            lblVendedor.AutoSize = true;
            lblVendedor.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblVendedor.Location = new Point(350, 61);
            lblVendedor.Name = "lblVendedor";
            lblVendedor.Size = new Size(93, 20);
            lblVendedor.TabIndex = 7;
            lblVendedor.Text = "VENDEDOR:";
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.Location = new Point(116, 56);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(219, 23);
            cmbCliente.TabIndex = 2;
            // 
            // cmbProducto
            // 
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducto.Location = new Point(116, 91);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(219, 23);
            cmbProducto.TabIndex = 4;
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(116, 129);
            numCantidad.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(105, 23);
            numCantidad.TabIndex = 6;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.NavajoWhite;
            btnAgregar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.Location = new Point(350, 86);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(210, 31);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "AGREGAR PRODUCTO";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.MistyRose;
            btnEliminar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(350, 124);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(210, 38);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "ELIMINAR SELECCIONADO";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnRegistrarVenta
            // 
            btnRegistrarVenta.BackColor = Color.LemonChiffon;
            btnRegistrarVenta.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrarVenta.Location = new Point(220, 415);
            btnRegistrarVenta.Name = "btnRegistrarVenta";
            btnRegistrarVenta.Size = new Size(158, 30);
            btnRegistrarVenta.TabIndex = 12;
            btnRegistrarVenta.Text = "REGISTRAR VENTA";
            btnRegistrarVenta.UseVisualStyleBackColor = false;
            btnRegistrarVenta.Click += btnRegistrarVenta_Click;
            // 
            // dgvDetalles
            // 
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.Location = new Point(35, 170);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(525, 200);
            dgvDetalles.TabIndex = 10;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(425, 385);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(115, 21);
            lblTotal.TabIndex = 11;
            lblTotal.Text = "TOTAL: S/ 0.00";
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(35, 415);
            button1.Name = "button1";
            button1.Size = new Size(158, 30);
            button1.TabIndex = 13;
            button1.Text = "REGRESAR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // FrmVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(614, 475);
            Controls.Add(button1);
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
            Text = "REGISTRO DE VENTAS";
            Load += FrmVentas_Load;
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
    }
}
