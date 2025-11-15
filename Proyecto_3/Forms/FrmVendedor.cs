using Negocio.Servicios; // Capa de negocio para usuarios y ventas

namespace Presentacion.Forms
{
    public partial class FrmVendedor : Form
    {
        // Id del vendedor actualmente logueado
        private readonly int _vendedorId;

        // Instancias de servicios de negocio
        private readonly UsuarioNegocio _usuarioNegocio;
        private readonly VentaNegocio _ventaNegocio;

        // Constructor del formulario, recibe el id del vendedor
        public FrmVendedor(int vendedorId)
        {
            InitializeComponent();

            _vendedorId = vendedorId;
            _usuarioNegocio = new UsuarioNegocio();
            _ventaNegocio = new VentaNegocio();

            // Establecer imagen de fondo
            string rutaImagen = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Imagen",
                "fondo.jpg"
            );

            this.BackgroundImage = Image.FromFile(rutaImagen);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        // Evento al cargar el formulario
        private void FrmVendedor_Load(object sender, EventArgs e)
        {
            CargarDatosVendedor();     // Carga información del vendedor
            CargarHistorialVentas();   // Carga historial de ventas
        }

        // Cargar datos del vendedor (nombre, rol, foto)
        private void CargarDatosVendedor()
        {
            var vendedor = _usuarioNegocio.ObtenerPorId(_vendedorId);

            if (vendedor == null)
            {
                MessageBox.Show("No se pudieron cargar los datos del vendedor.");
                return;
            }

            lblNombre.Text = vendedor.NombreCompleto; // Mostrar nombre
            lblRole.Text = "Vendedor";                // Mostrar rol fijo

            // Cargar foto si existe
            if (vendedor.FotoPerfil != null && vendedor.FotoPerfil.Length > 0)
            {
                using (var ms = new MemoryStream(vendedor.FotoPerfil))
                {
                    pbFoto.Image = Image.FromStream(ms);
                }
            }
        }

        // Cargar historial de ventas del vendedor
        private void CargarHistorialVentas()
        {
            var ventas = _ventaNegocio.ListarVentasPorVendedor(_vendedorId);
            dgvVentas.DataSource = ventas; // Vincular al DataGridView
        }

        // Cerrar sesión y volver al login
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            new FrmLogin().Show(); // Abrir login
            this.Close();          // Cerrar formulario actual
        }

        // Abrir formulario para editar perfil del vendedor
        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            using (FrmEditarPerfilVendedor editar = new FrmEditarPerfilVendedor(_vendedorId))
            {
                editar.ShowDialog();   // Modal
                CargarDatosVendedor(); // Recargar datos después de editar
            }
        }

        // Abrir formulario para gestionar clientes
        private void btnGestionarClientes_Click(object sender, EventArgs e)
        {
            // Se abre FrmRegistroClientes sin pasar rol específico
            using var frm = new FrmRegistroClientes();
            frm.ShowDialog();
        }

        // Abrir formulario para gestionar productos
        private void btnGestionarProductos_Click(object sender, EventArgs e)
        {
            new FrmRegistroProductos().ShowDialog();
        }

        // Abrir formulario para registrar ventas
        private void btnGestionarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener objeto vendedor
                var vendedor = _usuarioNegocio.ObtenerPorId(_vendedorId);
                if (vendedor == null)
                {
                    MessageBox.Show("No se pudo cargar la información del vendedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Abrir formulario de ventas pasándole el objeto vendedor
                using (FrmVentas frmVentas = new FrmVentas(vendedor))
                {
                    frmVentas.ShowDialog();
                }

                // Recargar historial de ventas después de registrar una nueva venta
                CargarHistorialVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento vacío (puede eliminarse o implementarse)
        private void groupBoxAcciones_Enter(object sender, EventArgs e)
        {

        }

        // Abrir detalle de venta al hacer doble clic en una fila del DataGridView
        private void dgvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    // Obtener el ID de la venta
                    int ventaId = Convert.ToInt32(dgvVentas.Rows[e.RowIndex].Cells["VentaId"].Value);

                    // Abrir formulario de detalle individual
                    FrmReporteVentaIndividual frm = new FrmReporteVentaIndividual(ventaId);
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir el detalle: " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }
    }
}
