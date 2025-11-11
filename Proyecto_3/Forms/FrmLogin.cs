using Datos.Repositorio;
using Entidad.Models;
using Negocio.Seguridad;

namespace Presentacion.Forms
{
    public partial class FrmLogin : Form
    {
        private readonly AuthService _servicioAuth = new AuthService();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text.Trim();
            string pass = txtPassword.Text.Trim();

            Usuario usuario = _servicioAuth.Login(user, pass);

            if (usuario == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error");
                return;
            }

            string mensajeBienvenida = $"¡Bienvenido, {usuario.NombreCompleto}!";

            // Clientes
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

            // Vendedores
            if (usuario.RoleId == 2)
            {
                MessageBox.Show(mensajeBienvenida, "Bienvenida");
                new FrmVendedor(usuario.UserId).Show();
                this.Hide();
                return;
            }

            // Administradores
            if (usuario.RoleId == 1)
            {
                MessageBox.Show(mensajeBienvenida, "Bienvenida");
                new FrmAdmin(usuario.UserId).Show();
                this.Hide();
                return;
            }

            MessageBox.Show("Rol de usuario no reconocido.");
        }

        private void chkVerContra_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkVerContra.Checked;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true; // ocultar contraseña al inicio
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}
