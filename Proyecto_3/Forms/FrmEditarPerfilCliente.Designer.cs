namespace Presentacion.Forms
{
    partial class FrmEditarPerfilCliente
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Button btnSeleccionarFoto;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblFoto;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.btnSeleccionarFoto = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblFoto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFoto
            // 
            this.pbFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFoto.Location = new System.Drawing.Point(20, 30);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(120, 120);
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // btnSeleccionarFoto
            // 
            this.btnSeleccionarFoto.Location = new System.Drawing.Point(20, 160);
            this.btnSeleccionarFoto.Name = "btnSeleccionarFoto";
            this.btnSeleccionarFoto.Size = new System.Drawing.Size(120, 30);
            this.btnSeleccionarFoto.Text = "Seleccionar Foto";
            this.btnSeleccionarFoto.Click += new System.EventHandler(this.btnSeleccionarFoto_Click);
            // 
            // Labels y TextBoxes
            // 
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Location = new System.Drawing.Point(160, 30);
            this.txtNombre.Location = new System.Drawing.Point(250, 30);

            this.lblCorreo.Text = "Correo:";
            this.lblCorreo.Location = new System.Drawing.Point(160, 70);
            this.txtCorreo.Location = new System.Drawing.Point(250, 70);

            this.lblTelefono.Text = "Teléfono:";
            this.lblTelefono.Location = new System.Drawing.Point(160, 110);
            this.txtTelefono.Location = new System.Drawing.Point(250, 110);

            this.lblDireccion.Text = "Dirección:";
            this.lblDireccion.Location = new System.Drawing.Point(160, 150);
            this.txtDireccion.Location = new System.Drawing.Point(250, 150);

            // Botones
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(250, 200);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(350, 200);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(500, 250);
            this.Controls.Add(this.pbFoto);
            this.Controls.Add(this.btnSeleccionarFoto);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblDireccion);
            this.Name = "FrmEditarPerfilCliente";
            this.Text = "Editar Perfil";
            this.Load += new System.EventHandler(this.FrmEditarPerfilCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
