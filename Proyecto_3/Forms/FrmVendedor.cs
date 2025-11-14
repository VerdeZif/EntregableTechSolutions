using Negocio.Servicios;

namespace Presentacion.Forms
{
    public partial class FrmVendedor : Form
    {
        private readonly int _vendedorId;
        private readonly UsuarioNegocio _usuarioNegocio;
        private readonly VentaNegocio _ventaNegocio;

        public FrmVendedor(int vendedorId)
        {
            InitializeComponent();
            _vendedorId = vendedorId;
            _usuarioNegocio = new UsuarioNegocio();
            _ventaNegocio = new VentaNegocio();
        }

        private void FrmVendedor_Load(object sender, EventArgs e)
        {
            CargarDatosVendedor();
            CargarHistorialVentas();
        }

        private void CargarDatosVendedor()
        {
            var vendedor = _usuarioNegocio.ObtenerPorId(_vendedorId);

            if (vendedor == null)
            {
                MessageBox.Show("No se pudieron cargar los datos del vendedor.");
                return;
            }

            lblNombre.Text = vendedor.NombreCompleto;
            lblRole.Text = "Vendedor";

            if (vendedor.FotoPerfil != null && vendedor.FotoPerfil.Length > 0)
            {
                using (var ms = new MemoryStream(vendedor.FotoPerfil))
                {
                    pbFoto.Image = Image.FromStream(ms);
                }
            }
        }

        private void CargarHistorialVentas()
        {
            var ventas = _ventaNegocio.ListarVentasPorVendedor(_vendedorId);
            dgvVentas.DataSource = ventas;
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            new FrmLogin().Show();
            this.Close();
        }

        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            using (FrmEditarPerfilVendedor editar = new FrmEditarPerfilVendedor(_vendedorId))
            {
                editar.ShowDialog();
                CargarDatosVendedor();
            }
        }

        private void btnGestionarClientes_Click(object sender, EventArgs e)
        {
            // Obtener el usuario actual (el vendedor)
            //var vendedor = _usuarioNegocio.ObtenerPorId(_vendedorId);

            //if (vendedor == null)
            //{
            //    MessageBox.Show("No se pudo cargar la información del vendedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            // Enviar el rol (no el ID)
            using var frm = new FrmRegistroClientes();// ✅ Se pasa el id del usuario logueado
            frm.ShowDialog();
        }

        private void btnGestionarProductos_Click(object sender, EventArgs e)
        {
            new FrmRegistroProductos().ShowDialog();
        }

        private void btnGestionarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el objeto Usuario del vendedor
                var vendedor = _usuarioNegocio.ObtenerPorId(_vendedorId);
                if (vendedor == null)
                {
                    MessageBox.Show("No se pudo cargar la información del vendedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Abrir FrmVentas pasándole el objeto Usuario
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

        private void groupBoxAcciones_Enter(object sender, EventArgs e)
        {

        }

        private void dgvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    // Obtiene el ID de la venta seleccionada
                    int ventaId = Convert.ToInt32(dgvVentas.Rows[e.RowIndex].Cells["VentaId"].Value);

                    // Abre el reporte individual con el ID de la venta
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
