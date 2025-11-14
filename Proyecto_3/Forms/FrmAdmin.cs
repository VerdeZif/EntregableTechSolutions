using Entidad.Models;
using Negocio.Servicios;

namespace Presentacion.Forms
{
    public partial class FrmAdmin : Form
    {
        private readonly UsuarioNegocio _usuarioNegocio = new UsuarioNegocio();
        private readonly VentaNegocio _VentaNegocio = new VentaNegocio();
        private Usuario _admin;

        public FrmAdmin(int adminUserId)
        {
            InitializeComponent();
            CargarDatosAdmin(adminUserId);
            CargarVentas();
            string rutaImagen = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Imagen",
                "fondo.jpg"
            );

            this.BackgroundImage = Image.FromFile(rutaImagen);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void CargarDatosAdmin(int adminUserId)
        {
            try
            {
                _admin = _usuarioNegocio.ObtenerPorId(adminUserId);
                if (_admin != null)
                {
                    txtAdminNombre.Text = _admin.NombreCompleto;
                    pbAdminFoto.Image = _admin.FotoPerfil != null ?
                        Image.FromStream(new MemoryStream(_admin.FotoPerfil)) : null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del administrador: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarVentas()
        {
            try
            {
                var ventas = _VentaNegocio.ListarVentas(); // Debe devolver IdVenta, Fecha, Cliente, Total
                dgvVentas.DataSource = ventas;

                dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvVentas.MultiSelect = false;
                dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            // Nada más que hacer al cargar
        }

        private void btnGestionClientes_Click(object sender, EventArgs e)
        {
            using var frm = new FrmRegistroClientes();//_admin.RoleId
            frm.ShowDialog();
        }

        private void btnGestionVendedores_Click(object sender, EventArgs e)
        {
            using var frm = new FrmRegistroVendedor();
            frm.ShowDialog();
        }

        private void btnGestionProductos_Click(object sender, EventArgs e)
        {
            using var frm = new FrmRegistroProductos();
            frm.ShowDialog();
        }

        private void btnVerReportes_Click(object sender, EventArgs e)
        {
            try
            {
                using var frm = new FrmReporte(); // Abre el formulario general de reportes
                frm.ShowDialog(); // Muestra el formulario de forma modal
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de reportes: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrir el formulario de edición del administrador
                using var frm = new FrmEditarPerfilAdmin(_admin.UserId);
                frm.ShowDialog();

                // Recargar datos del admin en caso de que se hayan actualizado
                CargarDatosAdmin(_admin.UserId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de edición: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Ocultar este formulario
            this.Hide();

            // Abrir FrmLogin
            using var frmLogin = new FrmLogin();
            frmLogin.ShowDialog();

            // Cerrar este formulario después de cerrar sesión
            this.Close();
        }

        private void groupBoxGestion_Enter(object sender, EventArgs e)
        {

        }

        private void lblAdminNombre_Click(object sender, EventArgs e)
        {

        }
    }
}
