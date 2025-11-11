using Entidad.Models;
using Negocio.Servicios;
using System.IO;

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
        }

        private void FrmEditarPerfilVendedor_Load(object sender, EventArgs e)
        {
            CargarDatos();
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
            // Validar campos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios (nombre y username).", "Validación");
                return;
            }

            // Actualizar datos
            _vendedor.NombreCompleto = txtNombre.Text.Trim();
            _vendedor.Username = txtUsername.Text.Trim();

            // Actualizar foto si existe
            if (pbFoto.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pbFoto.Image.Save(ms, pbFoto.Image.RawFormat);
                    _vendedor.FotoPerfil = ms.ToArray();
                }
            }

            // Si se ingresa nueva contraseña
            string? nuevaPassword = string.IsNullOrWhiteSpace(txtPassword.Text)
                ? null
                : txtPassword.Text.Trim();

            bool actualizado = _usuarioNegocio.ActualizarUsuario(_vendedor, nuevaPassword);

            if (actualizado)
            {
                MessageBox.Show("Perfil actualizado correctamente.", "Éxito");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar el perfil.", "Error");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
