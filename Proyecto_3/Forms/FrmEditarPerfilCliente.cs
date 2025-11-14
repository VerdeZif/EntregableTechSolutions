using Entidad.Models;
using Negocio.Servicios;
using System.Text.RegularExpressions;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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

            // Contraseña nueva enmascarada inicialmente
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.PasswordChar = '\0'; // Asegúrate de que no haya otro caracter asignado

            // Contraseña actual: siempre enmascarada
            txtPasswordActual.Text = "********";
            txtPasswordActual.ReadOnly = true;
            txtPasswordActual.BackColor = SystemColors.Control;
            txtPasswordActual.TabStop = false;

            // CheckBox controla la visibilidad de la contraseña nueva
            chkMostrarPassword.CheckedChanged += (s, ev) =>
            {
                txtPassword.UseSystemPasswordChar = !chkMostrarPassword.Checked;
            };
        }

        private void CargarDatos()
        {
            _cliente = _clienteNegocio.ObtenerClientePorId(_clienteId);
            if (_cliente == null)
            {
                MessageBox.Show("No se pudieron cargar los datos del cliente.");
                this.Close();
                return;
            }

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

            // Obtener usuario (Username y contraseña)
            _usuario = _usuarioNegocio.ObtenerPorId(_cliente.UserId);
            if (_usuario != null)
            {
                txtUsername.Text = _usuario.Username;
                txtPassword.Text = string.Empty; // Nunca mostrar la contraseña real
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
                _usuario.NombreCompleto = _cliente.Nombre;
                _usuario.FotoPerfil = _cliente.Foto;

                string nuevaPassword = txtPassword.Text.Trim();

                if (!string.IsNullOrWhiteSpace(nuevaPassword))
                    usuarioActualizado = _usuarioNegocio.ActualizarUsuario(_usuario, nuevaPassword);
                else
                    usuarioActualizado = _usuarioNegocio.ActualizarUsuario(_usuario);
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

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }
    }
}
