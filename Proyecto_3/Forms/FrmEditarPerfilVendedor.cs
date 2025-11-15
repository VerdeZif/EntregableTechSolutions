using Entidad.Models;
using Negocio.Servicios;

namespace Presentacion.Forms
{
    // ==============================
    // FORMULARIO PARA EDITAR PERFIL DEL VENDEDOR
    // ==============================
    public partial class FrmEditarPerfilVendedor : Form
    {
        // ==============================
        // Campos privados
        // ==============================
        private readonly int _vendedorId;            // ID del vendedor a editar
        private readonly UsuarioNegocio _usuarioNegocio; // Capa de negocio de usuarios
        private Usuario _vendedor;                   // Objeto Usuario del vendedor

        // ==============================
        // Constructor
        // ==============================
        public FrmEditarPerfilVendedor(int vendedorId)
        {
            InitializeComponent();
            _vendedorId = vendedorId;
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
        private void FrmEditarPerfilVendedor_Load(object sender, EventArgs e)
        {
            CargarDatos(); // Cargar información del vendedor

            // Contraseña actual: enmascarada y no editable
            txtPasswordActual.Text = "********";
            txtPasswordActual.UseSystemPasswordChar = true;
            txtPasswordActual.ReadOnly = true;
            txtPasswordActual.BackColor = SystemColors.Control;
            txtPasswordActual.TabStop = false;

            // Nueva contraseña: enmascarada inicialmente
            txtNuevaPassword.UseSystemPasswordChar = true;

            // CheckBox controla visibilidad de la nueva contraseña
            chkMostrarPassword.CheckedChanged += ChkMostrarPassword_CheckedChanged;

            // Mensaje informativo
            lblInfo.Text = "La contraseña actual no se puede mostrar por seguridad.";
        }

        // ==============================
        // CARGAR DATOS DEL VENDEDOR
        // ==============================
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

            // Cargar foto si existe
            if (_vendedor.FotoPerfil != null && _vendedor.FotoPerfil.Length > 0)
            {
                using (var ms = new MemoryStream(_vendedor.FotoPerfil))
                {
                    pbFoto.Image = Image.FromStream(ms);
                }
            }
        }

        // ==============================
        // CHECKBOX PARA MOSTRAR/OCULTAR NUEVA CONTRASEÑA
        // ==============================
        private void ChkMostrarPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool mostrar = chkMostrarPassword.Checked;
            txtNuevaPassword.UseSystemPasswordChar = !mostrar;
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
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios (nombre y username).");
                return;
            }

            // Actualizar datos del vendedor
            _vendedor.NombreCompleto = txtNombre.Text.Trim();
            _vendedor.Username = txtUsername.Text.Trim();

            // Guardar foto si se seleccionó
            if (pbFoto.Image != null)
            {
                using (var bitmapCopia = new Bitmap(pbFoto.Image))
                using (MemoryStream ms = new MemoryStream())
                {
                    bitmapCopia.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    _vendedor.FotoPerfil = ms.ToArray();
                }
            }

            // Determinar si se cambia la contraseña
            string? nuevaPassword = string.IsNullOrWhiteSpace(txtNuevaPassword.Text)
                ? null
                : txtNuevaPassword.Text.Trim();

            // Actualizar usuario en la base de datos
            bool actualizado = _usuarioNegocio.ActualizarUsuario(_vendedor, nuevaPassword);

            // Mensajes finales
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

        // ==============================
        // CANCELAR EDICIÓN
        // ==============================
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblInfo_Click(object sender, EventArgs e)
        {
            // Evento vacío generado por el diseñador
        }
    }
}
