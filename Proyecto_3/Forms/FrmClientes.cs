using Negocio.Servicios;

namespace Presentacion.Forms
{
    // ==============================
    // FORMULARIO DE CLIENTE
    // Muestra los datos del cliente, historial de compras y permite editar su perfil
    // ==============================
    public partial class FrmClientes : Form
    {
        // ==============================
        // Campos privados
        // ==============================
        private readonly int _clienteId; // ID del cliente actual
        private readonly ClienteNegocio _clienteNegocio; // Capa de negocio de clientes
        private readonly VentaNegocio _ventaNegocio;     // Capa de negocio de ventas

        // ==============================
        // Constructor: recibe el clienteId
        // ==============================
        public FrmClientes(int clienteId)
        {
            InitializeComponent();

            _clienteId = clienteId;
            _clienteNegocio = new ClienteNegocio();
            _ventaNegocio = new VentaNegocio();

            // Configura imagen de fondo
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
        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarDatosCliente();      // Carga información personal del cliente
            CargarHistorialCompras();  // Carga su historial de compras
        }

        // ==============================
        // CARGAR DATOS DEL CLIENTE
        // ==============================
        private void CargarDatosCliente()
        {
            var cliente = _clienteNegocio.ObtenerClientePorId(_clienteId);

            if (cliente == null)
            {
                MessageBox.Show("No se pudieron cargar los datos del cliente.");
                return;
            }

            lblNombre.Text = cliente.Nombre;
            lblCorreo.Text = "Correo: " + cliente.Correo;
            lblTelefono.Text = "Teléfono: " + cliente.Telefono;
            lblDireccion.Text = "Dirección: " + cliente.Direccion;

            // Cargar la foto del cliente si existe
            if (cliente.Foto != null && cliente.Foto.Length > 0)
            {
                using (var ms = new MemoryStream(cliente.Foto))
                {
                    pbFoto.Image = Image.FromStream(ms);
                }
            }
        }

        // ==============================
        // CARGAR HISTORIAL DE COMPRAS DEL CLIENTE
        // ==============================
        private void CargarHistorialCompras()
        {
            var compras = _ventaNegocio.ListarComprasPorCliente(_clienteId);
            dgvCompras.DataSource = compras;

            // Configurar DataGridView (opcional)
            dgvCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompras.MultiSelect = false;
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ==============================
        // CERRAR SESIÓN
        // ==============================
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            new FrmLogin().Show(); // Abrir formulario de login
            this.Close();           // Cerrar el formulario actual
        }

        // ==============================
        // EDITAR DATOS DEL CLIENTE
        // ==============================
        private void btnEditarDatos_Click(object sender, EventArgs e)
        {
            using (FrmEditarPerfilCliente editar = new FrmEditarPerfilCliente(_clienteId))
            {
                editar.ShowDialog();  // Abrir formulario de edición
                CargarDatosCliente(); // Recargar datos después de editar
            }
        }

        // ==============================
        // EVENTOS VACÍOS (pueden eliminarse o implementarse)
        // ==============================
        private void lblDireccion_Click(object sender, EventArgs e) { }
        private void lblCorreo_Click(object sender, EventArgs e) { }
    }
}
