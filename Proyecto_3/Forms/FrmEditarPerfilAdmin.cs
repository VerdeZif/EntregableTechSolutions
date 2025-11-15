using Entidad.Models;
using Negocio.Servicios;

namespace Presentacion.Forms
{
    // ==============================
    // FORMULARIO PARA EDITAR EL PERFIL DEL ADMINISTRADOR
    // ==============================
    public partial class FrmEditarPerfilAdmin : Form
    {
        // ==============================
        // Campos privados
        // ==============================
        private readonly int _adminId;             // ID del administrador actual
        private readonly UsuarioNegocio _usuarioNegocio; // Capa de negocio de usuarios
        private Usuario _admin;                    // Objeto del administrador cargado

        // ==============================
        // Constructor
        // ==============================
        public FrmEditarPerfilAdmin(int adminId)
        {
            InitializeComponent();
            _adminId = adminId;
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
        private void FrmEditarPerfilAdmin_Load(object sender, EventArgs e)
        {
            CargarDatos(); // Cargar información del administrador

            // Configuración de campos de contraseña
            txtPassword.UseSystemPasswordChar = true;  // nueva contraseña oculta por defecto

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
        // CARGAR DATOS DEL ADMINISTRADOR
        // ==============================
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

            // Cargar la foto del administrador si existe
            if (_admin.FotoPerfil != null && _admin.FotoPerfil.Length > 0)
            {
                using var ms = new MemoryStream(_admin.FotoPerfil);
                pbFoto.Image = Image.FromStream(ms);
            }
        }

        // ==============================
        // SELECCIONAR NUEVA FOTO
        // ==============================
        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbFoto.Image = Image.FromFile(ofd.FileName);
            }
        }

        // ==============================
        // GUARDAR CAMBIOS DEL PERFIL
        // ==============================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Validación");
                return;
            }

            // Actualizar datos del objeto administrador
            _admin.NombreCompleto = txtNombre.Text.Trim();
            _admin.Username = txtUsername.Text.Trim();

            // Actualizar contraseña si se ingresó nueva
            string nuevaPassword = txtPassword.Text.Trim();
            if (!string.IsNullOrWhiteSpace(nuevaPassword))
            {
                _admin.PasswordHash = _usuarioNegocio.GenerarHash(nuevaPassword);
            }

            // Guardar foto si se seleccionó
            if (pbFoto.Image != null)
            {
                // Crear una copia de la imagen
                using var bitmapCopia = new Bitmap(pbFoto.Image);
                using var ms = new MemoryStream();
                bitmapCopia.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // siempre PNG
                _admin.FotoPerfil = ms.ToArray();
            }

            // Guardar cambios en la base de datos
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

        // ==============================
        // CANCELAR EDICIÓN
        // ==============================
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
