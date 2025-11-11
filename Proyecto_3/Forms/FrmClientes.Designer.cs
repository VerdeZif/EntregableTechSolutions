namespace Presentacion.Forms
{
    partial class FrmClientes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            pbFoto = new PictureBox();
            lblNombre = new Label();
            lblCorreo = new Label();
            lblTelefono = new Label();
            lblDireccion = new Label();
            btnEditarDatos = new Button();
            btnCerrarSesion = new Button();
            dgvCompras = new DataGridView();
            lblTituloHistorial = new Label();
            ((System.ComponentModel.ISupportInitialize)pbFoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).BeginInit();
            SuspendLayout();
            // 
            // pbFoto
            // 
            pbFoto.BorderStyle = BorderStyle.FixedSingle;
            pbFoto.Location = new Point(20, 20);
            pbFoto.Name = "pbFoto";
            pbFoto.Size = new Size(120, 120);
            pbFoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbFoto.TabIndex = 0;
            pbFoto.TabStop = false;
            // 
            // lblNombre
            // 
            lblNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNombre.Location = new Point(160, 25);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(450, 25);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre del Cliente";
            // 
            // lblCorreo
            // 
            lblCorreo.Font = new Font("Segoe UI", 10F);
            lblCorreo.Location = new Point(160, 55);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(450, 25);
            lblCorreo.TabIndex = 2;
            lblCorreo.Text = "Correo:";
            lblCorreo.Click += lblCorreo_Click;
            // 
            // lblTelefono
            // 
            lblTelefono.Font = new Font("Segoe UI", 10F);
            lblTelefono.Location = new Point(160, 85);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(450, 25);
            lblTelefono.TabIndex = 3;
            lblTelefono.Text = "Teléfono:";
            // 
            // lblDireccion
            // 
            lblDireccion.Font = new Font("Segoe UI", 10F);
            lblDireccion.Location = new Point(160, 115);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(450, 25);
            lblDireccion.TabIndex = 4;
            lblDireccion.Text = "Dirección:";
            lblDireccion.Click += lblDireccion_Click;
            // 
            // btnEditarDatos
            // 
            btnEditarDatos.Location = new Point(650, 20);
            btnEditarDatos.Name = "btnEditarDatos";
            btnEditarDatos.Size = new Size(120, 35);
            btnEditarDatos.TabIndex = 5;
            btnEditarDatos.Text = "Gestionar Perfil";
            btnEditarDatos.UseVisualStyleBackColor = true;
            btnEditarDatos.Click += btnEditarDatos_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(650, 65);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(120, 35);
            btnCerrarSesion.TabIndex = 6;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // dgvCompras
            // 
            dgvCompras.AllowUserToAddRows = false;
            dgvCompras.AllowUserToDeleteRows = false;
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCompras.Location = new Point(20, 200);
            dgvCompras.Name = "dgvCompras";
            dgvCompras.ReadOnly = true;
            dgvCompras.Size = new Size(750, 280);
            dgvCompras.TabIndex = 7;
            // 
            // lblTituloHistorial
            // 
            lblTituloHistorial.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTituloHistorial.Location = new Point(20, 170);
            lblTituloHistorial.Name = "lblTituloHistorial";
            lblTituloHistorial.Size = new Size(250, 25);
            lblTituloHistorial.TabIndex = 8;
            lblTituloHistorial.Text = "Historial de Compras:";
            // 
            // FrmClientes
            // 
            ClientSize = new Size(800, 500);
            Controls.Add(lblTituloHistorial);
            Controls.Add(dgvCompras);
            Controls.Add(btnCerrarSesion);
            Controls.Add(btnEditarDatos);
            Controls.Add(lblDireccion);
            Controls.Add(lblTelefono);
            Controls.Add(lblCorreo);
            Controls.Add(lblNombre);
            Controls.Add(pbFoto);
            Name = "FrmClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Panel del Cliente";
            Load += FrmClientes_Load;
            ((System.ComponentModel.ISupportInitialize)pbFoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Button btnEditarDatos;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.Label lblTituloHistorial;
    }
}
