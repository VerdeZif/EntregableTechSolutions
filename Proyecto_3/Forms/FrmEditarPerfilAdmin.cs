using Entidad.Models;
using Negocio.Servicios;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace Presentacion.Forms
{
    public partial class FrmEditarPerfilAdmin : Form
    {
        private readonly int _adminId;
        private readonly UsuarioNegocio _usuarioNegocio;
        private Usuario _admin;

        public FrmEditarPerfilAdmin(int adminId)
        {
            InitializeComponent();
            _adminId = adminId;
            _usuarioNegocio = new UsuarioNegocio();
            string rutaImagen = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Imagen",
                "fondo.jpg"
            );

            this.BackgroundImage = Image.FromFile(rutaImagen);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void FrmEditarPerfilAdmin_Load(object sender, EventArgs e)
        {
            CargarDatos();

            // Contraseña nueva: inicialmente oculta
            txtPassword.UseSystemPasswordChar = true;

            // Contraseña actual: siempre oculta y solo visual
            txtPasswordActual.Text = "********";
            txtPasswordActual.ReadOnly = true;
            txtPasswordActual.BackColor = SystemColors.Control;
            txtPasswordActual.TabStop = false;

            // CheckBox para mostrar u ocultar nueva contraseña
            chkMostrarPassword.CheckedChanged += (s, ev) =>
            {
                txtPassword.UseSystemPasswordChar = !chkMostrarPassword.Checked;
            };
        }

        private void CargarDatos()
        {
            _admin = _usuarioNegocio.ObtenerPorId(_adminId);
            if (_admin == null)
            {
                MessageBox.Show("No se pudieron cargar los datos del administrador.");
                this.Close();
                return;
            }

            txtNombre.Text = _admin.NombreCompleto;
            txtUsername.Text = _admin.Username;
            txtPassword.Text = string.Empty; // nunca mostrar la contraseña real

            if (_admin.FotoPerfil != null && _admin.FotoPerfil.Length > 0)
            {
                using var ms = new MemoryStream(_admin.FotoPerfil);
                pbFoto.Image = Image.FromStream(ms);
            }
        }

        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbFoto.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Validación");
                return;
            }

            _admin.NombreCompleto = txtNombre.Text.Trim();
            _admin.Username = txtUsername.Text.Trim();

            string nuevaPassword = txtPassword.Text.Trim();
            if (!string.IsNullOrWhiteSpace(nuevaPassword))
            {
                // Actualizar contraseña
                _admin.PasswordHash = _usuarioNegocio.GenerarHash(nuevaPassword);
            }

            if (pbFoto.Image != null)
            {
                using var ms = new MemoryStream();
                pbFoto.Image.Save(ms, pbFoto.Image.RawFormat);
                _admin.FotoPerfil = ms.ToArray();
            }

            bool actualizado = _usuarioNegocio.ActualizarUsuario(_admin);
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