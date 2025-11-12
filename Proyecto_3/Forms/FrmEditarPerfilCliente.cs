using Entidad.Models;
using Negocio.Servicios;
using System.Text.RegularExpressions;

namespace Presentacion.Forms
{
    public partial class FrmEditarPerfilCliente : Form
    {
        private readonly int _clienteId;
        private readonly ClienteNegocio _clienteNegocio;
        private readonly UsuarioNegocio _usuarioNegocio;
        private Cliente _cliente;
        private Usuario? _usuario;

        public FrmEditarPerfilCliente(int clienteId)
        {
            InitializeComponent();
            _clienteId = clienteId;
            _clienteNegocio = new ClienteNegocio();
            _usuarioNegocio = new UsuarioNegocio();
        }

        private void FrmEditarPerfilCliente_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            // Obtener cliente
            _cliente = _clienteNegocio.ObtenerClientePorId(_clienteId);
            if (_cliente == null)
            {
                MessageBox.Show("No se pudieron cargar los datos del cliente.");
                this.Close();
                return;
            }

            // Cargar datos personales
            txtNombre.Text = _cliente.Nombre;
            txtCorreo.Text = _cliente.Correo;
            txtTelefono.Text = _cliente.Telefono;
            txtDireccion.Text = _cliente.Direccion;

            if (_cliente.Foto != null && _cliente.Foto.Length > 0)
            {
                using (var ms = new MemoryStream(_cliente.Foto))
                {
                    pbFoto.Image = Image.FromStream(ms);
                }
            }

            // Obtener usuario (para Username y Password)
            _usuario = _usuarioNegocio.ObtenerPorId(_cliente.UserId);
            if (_usuario != null)
            {
                txtUsername.Text = _usuario.Username;
                // No mostramos contraseña (por seguridad)
                txtPassword.Text = string.Empty;
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
            // Validar campos del cliente
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos personales.", "Validación");
                return;
            }

            // Validar correo
            if (!Regex.IsMatch(txtCorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Ingrese un correo válido.", "Validación");
                return;
            }

            // Validar usuario
            if (_usuario != null && string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("El nombre de usuario no puede estar vacío.", "Validación");
                return;
            }

            // Actualizar datos del cliente
            _cliente.Nombre = txtNombre.Text.Trim();
            _cliente.Correo = txtCorreo.Text.Trim();
            _cliente.Telefono = txtTelefono.Text.Trim();
            _cliente.Direccion = txtDireccion.Text.Trim();

            if (pbFoto.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pbFoto.Image.Save(ms, pbFoto.Image.RawFormat);
                    _cliente.Foto = ms.ToArray();
                }
            }

            bool clienteActualizado = _clienteNegocio.ActualizarCliente(_cliente);

            // Actualizar datos del usuario
            bool usuarioActualizado = true;
            if (_usuario != null)
            {
                _usuario.Username = txtUsername.Text.Trim();

                string nuevaPassword = txtPassword.Text.Trim();
                if (!string.IsNullOrWhiteSpace(nuevaPassword))
                {
                    usuarioActualizado = _usuarioNegocio.ActualizarUsuario(_usuario, nuevaPassword);
                }
                else
                {
                    usuarioActualizado = _usuarioNegocio.ActualizarUsuario(_usuario);
                }
            }

            if (clienteActualizado && usuarioActualizado)
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
