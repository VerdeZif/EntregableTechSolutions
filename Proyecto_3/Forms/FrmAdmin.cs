using Entidad.Models;
using Negocio.Servicios;

namespace Presentacion.Forms
{
    // ==============================
    // FORMULARIO PRINCIPAL DEL ADMINISTRADOR
    // Muestra ventas, permite gestionar clientes, vendedores, productos y reportes.
    // ==============================
    public partial class FrmAdmin : Form
    {
        // Instancias de la capa de negocio
        private readonly UsuarioNegocio _usuarioNegocio = new UsuarioNegocio();
        private readonly VentaNegocio _VentaNegocio = new VentaNegocio();

        // Almacena los datos del administrador actual
        private Usuario _admin;

        // Constructor: recibe el UserId del administrador
        public FrmAdmin(int adminUserId)
        {
            InitializeComponent();

            // Carga la información del administrador
            CargarDatosAdmin(adminUserId);

            // Carga todas las ventas en el DataGridView
            CargarVentas();

            // Configura imagen de fondo del formulario
            string rutaImagen = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Imagen",
                "fondo.jpg"
            );

            this.BackgroundImage = Image.FromFile(rutaImagen);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        // ==============================
        // CARGAR DATOS DEL ADMINISTRADOR
        // ==============================
        private void CargarDatosAdmin(int adminUserId)
        {
            try
            {
                _admin = _usuarioNegocio.ObtenerPorId(adminUserId);

                if (_admin != null)
                {
                    txtAdminNombre.Text = _admin.NombreCompleto;

                    // Carga la foto del administrador si existe
                    pbAdminFoto.Image = _admin.FotoPerfil != null ?
                        Image.FromStream(new MemoryStream(_admin.FotoPerfil)) : null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del administrador: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==============================
        // CARGAR VENTAS EN EL DATAGRIDVIEW
        // ==============================
        private void CargarVentas()
        {
            try
            {
                var ventas = _VentaNegocio.ListarVentas(); // Devuelve todas las ventas
                dgvVentas.DataSource = ventas;

                // Configuración de selección y visualización
                dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvVentas.MultiSelect = false;
                dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las ventas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==============================
        // EVENTO AL CARGAR FORMULARIO
        // ==============================
        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            // Actualmente no se requiere acción adicional al cargar
        }

        // ==============================
        // BOTONES DE GESTIÓN
        // ==============================

        // Gestionar clientes
        private void btnGestionClientes_Click(object sender, EventArgs e)
        {
            using var frm = new FrmRegistroClientes();
            frm.ShowDialog();
        }

        // Gestionar vendedores
        private void btnGestionVendedores_Click(object sender, EventArgs e)
        {
            using var frm = new FrmRegistroVendedor();
            frm.ShowDialog();
        }

        // Gestionar productos
        private void btnGestionProductos_Click(object sender, EventArgs e)
        {
            using var frm = new FrmRegistroProductos();
            frm.ShowDialog();
        }

        // Ver reportes generales
        private void btnVerReportes_Click(object sender, EventArgs e)
        {
            try
            {
                using var frm = new FrmReporte(); // Abre formulario de reportes
                frm.ShowDialog(); // Modal
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de reportes: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Editar perfil del administrador
        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                using var frm = new FrmEditarPerfilAdmin(_admin.UserId);
                frm.ShowDialog();

                // Recargar datos en caso de actualización
                CargarDatosAdmin(_admin.UserId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de edición: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cerrar sesión y volver al login
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario actual

            using var frmLogin = new FrmLogin();
            frmLogin.ShowDialog();

            this.Close(); // Cierra el formulario después de iniciar sesión de nuevo
        }

        private void groupBoxGestion_Enter(object sender, EventArgs e) { }

        private void lblAdminNombre_Click(object sender, EventArgs e) { }
    }
}
