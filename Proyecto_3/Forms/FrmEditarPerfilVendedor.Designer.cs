namespace Presentacion.Forms
{
    partial class FrmEditarPerfilVendedor
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblNombreTitulo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Button btnSeleccionarFoto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblNombreTitulo = new Label();
            txtNombre = new TextBox();
            pbFoto = new PictureBox();
            btnSeleccionarFoto = new Button();
            btnGuardar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)pbFoto).BeginInit();
            SuspendLayout();
            // 
            // lblNombreTitulo
            // 
            lblNombreTitulo.AutoSize = true;
            lblNombreTitulo.Location = new Point(12, 15);
            lblNombreTitulo.Name = "lblNombreTitulo";
            lblNombreTitulo.Size = new Size(108, 15);
            lblNombreTitulo.TabIndex = 0;
            lblNombreTitulo.Text = "Nombre completo:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(130, 12);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(250, 23);
            txtNombre.TabIndex = 1;
            // 
            // pbFoto
            // 
            pbFoto.Location = new Point(24, 59);
            pbFoto.Name = "pbFoto";
            pbFoto.Size = new Size(120, 120);
            pbFoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbFoto.TabIndex = 2;
            pbFoto.TabStop = false;
            // 
            // btnSeleccionarFoto
            // 
            btnSeleccionarFoto.Location = new Point(24, 196);
            btnSeleccionarFoto.Name = "btnSeleccionarFoto";
            btnSeleccionarFoto.Size = new Size(120, 30);
            btnSeleccionarFoto.TabIndex = 3;
            btnSeleccionarFoto.Text = "Seleccionar Foto";
            btnSeleccionarFoto.Click += btnSeleccionarFoto_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(220, 90);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 30);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(220, 139);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 30);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmEditarPerfilVendedor
            // 
            ClientSize = new Size(400, 250);
            Controls.Add(lblNombreTitulo);
            Controls.Add(txtNombre);
            Controls.Add(pbFoto);
            Controls.Add(btnSeleccionarFoto);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Name = "FrmEditarPerfilVendedor";
            Text = "Editar Perfil Vendedor";
            Load += FrmEditarPerfilVendedor_Load;
            ((System.ComponentModel.ISupportInitialize)pbFoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
