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
            pbFoto.BackColor = SystemColors.Control;
            pbFoto.BorderStyle = BorderStyle.FixedSingle;
            pbFoto.Location = new Point(20, 20);
            pbFoto.Name = "pbFoto";
            pbFoto.Size = new Size(168, 136);
            pbFoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbFoto.TabIndex = 0;
            pbFoto.TabStop = false;
            // 
            // lblNombre
            // 
            lblNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNombre.Location = new Point(194, 30);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(450, 25);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "NOMBRE DEL CLIENTE";
            // 
            // lblCorreo
            // 
            lblCorreo.Font = new Font("Segoe UI", 10F);
            lblCorreo.Location = new Point(194, 60);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(450, 25);
            lblCorreo.TabIndex = 2;
            lblCorreo.Text = "CORREO:";
            lblCorreo.Click += lblCorreo_Click;
            // 
            // lblTelefono
            // 
            lblTelefono.Font = new Font("Segoe UI", 10F);
            lblTelefono.Location = new Point(194, 90);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(450, 25);
            lblTelefono.TabIndex = 3;
            lblTelefono.Text = "TELEFONO:";
            // 
            // lblDireccion
            // 
            lblDireccion.Font = new Font("Segoe UI", 10F);
            lblDireccion.Location = new Point(194, 120);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(450, 25);
            lblDireccion.TabIndex = 4;
            lblDireccion.Text = "DIRECCION:";
            lblDireccion.Click += lblDireccion_Click;
            // 
            // btnEditarDatos
            // 
            btnEditarDatos.BackColor = SystemColors.Info;
            btnEditarDatos.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditarDatos.Location = new Point(615, 20);
            btnEditarDatos.Name = "btnEditarDatos";
            btnEditarDatos.Size = new Size(155, 35);
            btnEditarDatos.TabIndex = 5;
            btnEditarDatos.Text = "GESTIONAR PERFIL";
            btnEditarDatos.UseVisualStyleBackColor = false;
            btnEditarDatos.Click += btnEditarDatos_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.MistyRose;
            btnCerrarSesion.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrarSesion.Location = new Point(615, 65);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(155, 35);
            btnCerrarSesion.TabIndex = 6;
            btnCerrarSesion.Text = "CERRAR SESION";
            btnCerrarSesion.UseVisualStyleBackColor = false;
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
            lblTituloHistorial.Text = "HISTORIAL DE COMPRAS";
            // 
            // FrmClientes
            // 
            BackColor = SystemColors.GradientInactiveCaption;
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
            Text = "PANEL DE CLIENTE";
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
