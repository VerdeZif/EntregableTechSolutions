namespace Presentacion.Forms
{
    partial class FrmProducto
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.Button btnSeleccionarImagen;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.NumericUpDown numStock;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblImagen;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.btnSeleccionarImagen = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblImagen = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            this.SuspendLayout();

            // pbImagen
            this.pbImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImagen.Location = new System.Drawing.Point(20, 30);
            this.pbImagen.Size = new System.Drawing.Size(120, 120);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // btnSeleccionarImagen
            this.btnSeleccionarImagen.Text = "Seleccionar Imagen";
            this.btnSeleccionarImagen.Location = new System.Drawing.Point(20, 160);
            this.btnSeleccionarImagen.Click += new System.EventHandler(this.btnSeleccionarImagen_Click);

            // Labels de detalle
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Location = new System.Drawing.Point(160, 30);
            this.lblDescripcion.Text = "Descripción:";
            this.lblDescripcion.Location = new System.Drawing.Point(160, 70);
            this.lblPrecio.Text = "Precio:";
            this.lblPrecio.Location = new System.Drawing.Point(160, 110);
            this.lblStock.Text = "Stock:";
            this.lblStock.Location = new System.Drawing.Point(160, 150);
            this.lblImagen.Text = "Imagen:";
            this.lblImagen.Location = new System.Drawing.Point(20, 10);

            // TextBoxes
            this.txtNombre.Location = new System.Drawing.Point(250, 30);
            this.txtDescripcion.Location = new System.Drawing.Point(250, 70);
            this.txtPrecio.Location = new System.Drawing.Point(250, 110);
            this.numStock.Location = new System.Drawing.Point(250, 150);

            // Botones
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(250, 200);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(350, 200);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            this.btnEditar.Text = "Editar";
            this.btnEditar.Location = new System.Drawing.Point(450, 30);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(550, 250);
            this.Controls.Add(this.pbImagen);
            this.Controls.Add(this.btnSeleccionarImagen);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.numStock);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblImagen);
            this.Name = "FrmProducto";
            this.Text = "Detalle Producto";
            this.Load += new System.EventHandler(this.FrmProducto_Load);

            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
