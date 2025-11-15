using Datos.Repositorio;
using Entidad.Models;
using Negocio.Seguridad;

namespace Presentacion.Forms
{
    // ==============================
    // FORMULARIO DE LOGIN
    // ==============================
    public partial class FrmLogin : Form
    {
        // Servicio de autenticación
        private readonly AuthService _servicioAuth = new AuthService();

        // ==============================
        // Constructor
        // ==============================
        public FrmLogin()
        {
            InitializeComponent();

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
        // BOTÓN LOGIN
        // ==============================
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text.Trim();
            string pass = txtPassword.Text.Trim();

            // Validar login usando AuthService
            Usuario usuario = _servicioAuth.Login(user, pass);

            if (usuario == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error");
                return;
            }

            string mensajeBienvenida = $"¡Bienvenido, {usuario.NombreCompleto}!";

            // ==============================
            // CLIENTES (RoleId = 3)
            // ==============================
            if (usuario.RoleId == 3)
            {
                var clienteDatos = new ClienteDatos();
                var cliente = clienteDatos.ObtenerNombrePorUsuario(usuario.Username);

                if (cliente != null)
                {
                    MessageBox.Show(mensajeBienvenida, "Bienvenida");
                    new FrmClientes(cliente.ClienteId).Show();
                    this.Hide();
                    return;
                }

                MessageBox.Show("El usuario no tiene cliente asignado.");
                return;
            }

            // ==============================
            // VENDEDORES (RoleId = 2)
            // ==============================
            if (usuario.RoleId == 2)
            {
                MessageBox.Show(mensajeBienvenida, "Bienvenida");
                new FrmVendedor(usuario.UserId).Show();
                this.Hide();
                return;
            }

            // ==============================
            // ADMINISTRADORES (RoleId = 1)
            // ==============================
            if (usuario.RoleId == 1)
            {
                MessageBox.Show(mensajeBienvenida, "Bienvenida");
                new FrmAdmin(usuario.UserId).Show();
                this.Hide();
                return;
            }

            // Rol no reconocido
            MessageBox.Show("Rol de usuario no reconocido.");
        }

        // ==============================
        // CHECKBOX MOSTRAR/OCULTAR CONTRASEÑA
        // ==============================
        private void chkVerContra_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkVerContra.Checked;
        }

        // ==============================
        // LOAD DEL FORMULARIO
        // ==============================
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // Asegurar que la contraseña esté oculta al iniciar
            txtPassword.UseSystemPasswordChar = true;
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }
    }
}
