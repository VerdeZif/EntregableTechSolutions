using Entidad.Models;
using Negocio.Servicios;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Presentacion.Forms
{
    public partial class FrmEditarPerfilVendedor : Form
    {
        private readonly int _vendedorId;
        private readonly UsuarioNegocio _usuarioNegocio;
        private Usuario _vendedor;

        public FrmEditarPerfilVendedor(int vendedorId)
        {
            InitializeComponent();
            _vendedorId = vendedorId;
            _usuarioNegocio = new UsuarioNegocio();
            string rutaImagen = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Imagen",
                "fondo.jpg"
            );

            this.BackgroundImage = Image.FromFile(rutaImagen);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void FrmEditarPerfilVendedor_Load(object sender, EventArgs e)
        {
            CargarDatos();

            // Contraseña actual: siempre enmascarada
            txtPasswordActual.Text = "********";
            txtPasswordActual.UseSystemPasswordChar = true;
            txtPasswordActual.ReadOnly = true;
            txtPasswordActual.BackColor = SystemColors.Control;
            txtPasswordActual.TabStop = false;

            // Nueva contraseña: enmascarada inicialmente
            txtNuevaPassword.UseSystemPasswordChar = true;

            // CheckBox controla solo la nueva contraseña
            chkMostrarPassword.CheckedChanged += ChkMostrarPassword_CheckedChanged;

            // Mensaje informativo
            lblInfo.Text = "La contraseña actual no se puede mostrar por seguridad.";
        }

        private void CargarDatos()
        {
            _vendedor = _usuarioNegocio.ObtenerPorId(_vendedorId);
            if (_vendedor == null)
            {
                MessageBox.Show("No se pudieron cargar los datos del vendedor.");
                this.Close();
                return;
            }

            txtNombre.Text = _vendedor.NombreCompleto;
            txtUsername.Text = _vendedor.Username;

            if (_vendedor.FotoPerfil != null && _vendedor.FotoPerfil.Length > 0)
            {
                using (var ms = new MemoryStream(_vendedor.FotoPerfil))
                {
                    pbFoto.Image = Image.FromStream(ms);
                }
            }
        }

        private void ChkMostrarPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool mostrar = chkMostrarPassword.Checked;
            txtNuevaPassword.UseSystemPasswordChar = !mostrar;
        }

        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pbFoto.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios (nombre y username).");
                return;
            }

            _vendedor.NombreCompleto = txtNombre.Text.Trim();
            _vendedor.Username = txtUsername.Text.Trim();

            if (pbFoto.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pbFoto.Image.Save(ms, pbFoto.Image.RawFormat);
                    _vendedor.FotoPerfil = ms.ToArray();
                }
            }

            string? nuevaPassword = string.IsNullOrWhiteSpace(txtNuevaPassword.Text)
                ? null
                : txtNuevaPassword.Text.Trim();

            bool actualizado = _usuarioNegocio.ActualizarUsuario(_vendedor, nuevaPassword);

            if (actualizado)
            {
                MessageBox.Show("Perfil actualizado correctamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar el perfil.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblInfo_Click(object sender, EventArgs e)
        {

        }
    }
}