namespace Presentacion.Forms
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Label lblUsuarioActivo;
        private Button btnClientes;
        private Button btnProductos;
        private Button btnVentas;
        private Button btnReportes;
        private Button btnCerrarSesion;
        private Button btnUsuarios;

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
            lblUsuarioActivo = new Label();
            btnClientes = new Button();
            btnProductos = new Button();
            btnVentas = new Button();
            btnReportes = new Button();
            btnCerrarSesion = new Button();
            btnUsuarios = new Button();
            SuspendLayout();

            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.Location = new Point(220, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(366, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "TechSolutions - Panel Principal";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // lblUsuarioActivo
            lblUsuarioActivo.AutoSize = true;
            lblUsuarioActivo.Font = new Font("Segoe UI", 11F);
            lblUsuarioActivo.Location = new Point(20, 80);
            lblUsuarioActivo.Name = "lblUsuarioActivo";
            lblUsuarioActivo.Size = new Size(0, 20);
            lblUsuarioActivo.TabIndex = 1;

            // btnClientes
            btnClientes.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClientes.Location = new Point(129, 130);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(200, 50);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;

            // btnProductos
            btnProductos.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnProductos.Location = new Point(474, 130);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(200, 50);
            btnProductos.TabIndex = 3;
            btnProductos.Text = "Productos";
            btnProductos.UseVisualStyleBackColor = true;
            btnProductos.Click += btnProductos_Click;

            // btnVentas
            btnVentas.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnVentas.Location = new Point(129, 221);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(200, 50);
            btnVentas.TabIndex = 4;
            btnVentas.Text = "Ventas";
            btnVentas.UseVisualStyleBackColor = true;
            btnVentas.Click += btnVentas_Click;

            // btnReportes
            btnReportes.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnReportes.Location = new Point(474, 221);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(200, 50);
            btnReportes.TabIndex = 5;
            btnReportes.Text = "Reportes";
            btnReportes.UseVisualStyleBackColor = true;
            btnReportes.Click += btnReportes_Click;

            // btnCerrarSesion
            btnCerrarSesion.Font = new Font("Segoe UI", 10F);
            btnCerrarSesion.Location = new Point(620, 350);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(140, 35);
            btnCerrarSesion.TabIndex = 6;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;

            // btnUsuarios
            btnUsuarios.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUsuarios.Location = new Point(300, 310); // Ajusta posición
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(200, 50);
            btnUsuarios.TabIndex = 7;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnUsuarios_Click;

            // FrmMain
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 420);
            Controls.Add(lblTitulo);
            Controls.Add(lblUsuarioActivo);
            Controls.Add(btnClientes);
            Controls.Add(btnProductos);
            Controls.Add(btnVentas);
            Controls.Add(btnReportes);
            Controls.Add(btnCerrarSesion);
            Controls.Add(btnUsuarios);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TechSolutions - Panel Principal";
            Load += FrmMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
