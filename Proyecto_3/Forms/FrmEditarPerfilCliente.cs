using Entidad.Models;
using Negocio.Servicios;
using System.Text.RegularExpressions;

namespace Presentacion.Forms
{
    // ==============================
    // FORMULARIO PARA EDITAR EL PERFIL DEL CLIENTE
    // ==============================
    public partial class FrmEditarPerfilCliente : Form
    {
        // ==============================
        // Campos privados
        // ==============================
        private readonly int _clienteId;                // ID del cliente a editar
        private readonly ClienteNegocio _clienteNegocio; // Capa de negocio de clientes
        private readonly UsuarioNegocio _usuarioNegocio; // Capa de negocio de usuarios
        private Cliente _cliente;                        // Objeto Cliente cargado
        private Usuario? _usuario;                       // Objeto Usuario vinculado (para login)

        // ==============================
        // Constructor
        // ==============================
        public FrmEditarPerfilCliente(int clienteId)
        {
            InitializeComponent();
            _clienteId = clienteId;
            _clienteNegocio = new ClienteNegocio();
            _usuarioNegocio = new UsuarioNegocio();

            // Configurar imagen de fondo
            string rutaImagen = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Imagen",
                "fondo.jpg"
            );
            this.BackgroundImage = Image.FromFile(rutaImagen);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        // ==============================
        // EVENTO LOAD DEL FORMULARIO
        // ==============================
        private void FrmEditarPerfilCliente_Load(object sender, EventArgs e)
        {
            CargarDatos(); // Cargar información del cliente

            // Configuración de campos de contraseña
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.PasswordChar = '\0'; // Asegurar que no haya otro caracter

            txtPasswordActual.Text = "********";       // contraseña actual oculta
            txtPasswordActual.ReadOnly = true;
            txtPasswordActual.BackColor = SystemColors.Control;
            txtPasswordActual.TabStop = false;

            // Mostrar u ocultar nueva contraseña con checkbox
            chkMostrarPassword.CheckedChanged += (s, ev) =>
            {
                txtPassword.UseSystemPasswordChar = !chkMostrarPassword.Checked;
            };
        }

        // ==============================
        // CARGAR DATOS DEL CLIENTE
        // ==============================
        private void CargarDatos()
        {
            // Obtener datos del cliente
            _cliente = _clienteNegocio.ObtenerClientePorId(_clienteId);
            if (_cliente == null)
            {
                MessageBox.Show("No se pudieron cargar los datos del cliente.");
                this.Close();
                return;
            }

            // Llenar los campos del formulario
            txtNombre.Text = _cliente.Nombre;
            txtCorreo.Text = _cliente.Correo;
            txtTelefono.Text = _cliente.Telefono;
            txtDireccion.Text = _cliente.Direccion;

            // Cargar foto si existe
            if (_cliente.Foto != null && _cliente.Foto.Length > 0)
            {
                using (var ms = new MemoryStream(_cliente.Foto))
                {
                    using (var tempImage = Image.FromStream(ms))
                    {
                        pbFoto.Image = new Bitmap(tempImage); // copia independiente
                    }
                }
            }

            // Obtener usuario vinculado (para login)
            _usuario = _usuarioNegocio.ObtenerPorId(_cliente.UserId);
            if (_usuario != null)
            {
                txtUsername.Text = _usuario.Username;
                txtPassword.Text = string.Empty; // nunca mostrar la contraseña real
            }
        }

        // ==============================
        // SELECCIONAR NUEVA FOTO
        // ==============================
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

        // ==============================
        // GUARDAR CAMBIOS DEL PERFIL
        // ==============================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos personales.", "Validación");
                return;
            }

            // Validar formato de correo
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

            // Guardar foto si se seleccionó
            if (pbFoto.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pbFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // mejor usar PNG
                    _cliente.Foto = ms.ToArray();
                }
            }

            // Guardar cambios en la base de datos
            bool clienteActualizado = _clienteNegocio.ActualizarCliente(_cliente);

            // Actualizar datos del usuario
            bool usuarioActualizado = true;
            if (_usuario != null)
            {
                _usuario.Username = txtUsername.Text.Trim();
                _usuario.NombreCompleto = _cliente.Nombre;
                _usuario.FotoPerfil = _cliente.Foto;

                string nuevaPassword = txtPassword.Text.Trim();

                if (!string.IsNullOrWhiteSpace(nuevaPassword))
                    usuarioActualizado = _usuarioNegocio.ActualizarUsuario(_usuario, nuevaPassword);
                else
                    usuarioActualizado = _usuarioNegocio.ActualizarUsuario(_usuario);
            }

            // Mensajes finales
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

        // ==============================
        // CANCELAR EDICIÓN
        // ==============================
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {
            // Este evento está vacío, solo lo genera el diseñador
        }
    }
}

