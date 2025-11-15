using Negocio.Servicios; // Capa de negocio para obtener reportes
using System.Data;


namespace Presentacion.Forms
{
    public partial class FrmReporte : Form
    {
        // Instancia de la capa de negocio para reportes
        private readonly ReporteNegocio _reporteNegocio = new ReporteNegocio();

        public FrmReporte()
        {
            InitializeComponent();

            // Configuración de la imagen de fondo del formulario
            string rutaImagen = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Imagen",
                "fondo.jpg"
            );

            this.BackgroundImage = Image.FromFile(rutaImagen);
            this.BackgroundImageLayout = ImageLayout.Stretch; // Ajusta la imagen al tamaño del formulario
        }

        // Evento que se ejecuta al cargar el formulario
        private void FrmReporte_Load(object sender, EventArgs e)
        {
            CargarCombos();  // Cargar listas desplegables de clientes y vendedores
            CargarVentas();  // Cargar tabla de ventas
        }

        // Cargar combos de clientes y vendedores
        private void CargarCombos()
        {
            try
            {
                // Clientes
                cbCliente.DataSource = _reporteNegocio.ObtenerClientes();
                cbCliente.DisplayMember = "Nombre";
                cbCliente.ValueMember = "ClienteId";
                cbCliente.SelectedIndex = -1; // No seleccionar nada inicialmente

                // Vendedores
                var vendedores = _reporteNegocio.ObtenerVendedores().ToList();
                cbVendedor.DataSource = vendedores;
                cbVendedor.DisplayMember = "NombreCompleto";
                cbVendedor.ValueMember = "UserId";
                cbVendedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar listas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cargar las ventas en el DataGridView según filtros
        private void CargarVentas()
        {
            try
            {
                // Si el checkbox de rango de fechas está marcado, usar las fechas; si no, null
                DateTime? fechaInicio = chkRangoFechas.Checked ? dtpInicio.Value.Date : (DateTime?)null;
                DateTime? fechaFin = chkRangoFechas.Checked ? dtpFin.Value.Date.AddDays(1).AddSeconds(-1) : (DateTime?)null;

                // Obtener cliente y vendedor seleccionados
                int? clienteId = cbCliente.SelectedIndex >= 0 ? (int?)cbCliente.SelectedValue : null;
                int? vendedorId = cbVendedor.SelectedIndex >= 0 ? (int?)cbVendedor.SelectedValue : null;

                // Obtener lista filtrada de ventas
                var lista = _reporteNegocio.ObtenerVentasFiltradas(
                    fechaInicio, fechaFin, clienteId, vendedorId, null, null
                );

                // Configuración de columnas del DataGridView
                dgvVentas.AutoGenerateColumns = false;
                dgvVentas.Columns.Clear();
                dgvVentas.DataSource = lista;

                // Columnas manuales
                dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "VentaId",
                    DataPropertyName = "VentaId",
                    HeaderText = "ID Venta",
                    Width = 80
                });
                dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Fecha",
                    DataPropertyName = "Fecha",
                    HeaderText = "Fecha",
                    Width = 120,
                    DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" } // Formato de fecha
                });
                dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Cliente",
                    DataPropertyName = "Cliente",
                    HeaderText = "Cliente",
                    Width = 180
                });
                dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Usuario",
                    DataPropertyName = "Usuario",
                    HeaderText = "Vendedor",
                    Width = 180
                });
                dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Total",
                    DataPropertyName = "Total",
                    HeaderText = "Total (S/)",
                    Width = 100,
                    DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
                });

                // Ajustes de visualización
                dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvVentas.ReadOnly = true;
                dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Habilitar/deshabilitar filtros de fechas
        private void chkRangoFechas_CheckedChanged(object sender, EventArgs e)
        {
            dtpInicio.Enabled = dtpFin.Enabled = chkRangoFechas.Checked;
        }

        // Botón buscar ventas
        private void btnBuscar_Click(object sender, EventArgs e) => CargarVentas();

        // Botón limpiar filtros
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            chkRangoFechas.Checked = false;
            cbCliente.SelectedIndex = -1;
            cbVendedor.SelectedIndex = -1;
            CargarVentas();
        }

        // Ver detalle de la venta seleccionada
        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVentas.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una venta para ver su detalle.", "Aviso");
                    return;
                }

                // Buscar columna que contenga "VentaId"
                string colId = dgvVentas.Columns
                    .Cast<DataGridViewColumn>()
                    .FirstOrDefault(c => c.DataPropertyName.ToLower().Contains("ventaid"))?.Name;

                if (colId == null)
                {
                    MessageBox.Show("No se encontró la columna del ID de venta.", "Error");
                    return;
                }

                int ventaId = Convert.ToInt32(dgvVentas.CurrentRow.Cells[colId].Value);

                // Abrir formulario de detalle de venta
                new FrmReporteVentaIndividual(ventaId).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el detalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Simulación de impresión (se puede reemplazar por PrintDocument real)
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Simulación de impresión de reporte (puedes implementar PrintDocument).");
            }
        }

        // Abrir detalle de venta al hacer doble clic en la fila
        private void dgvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int ventaId = Convert.ToInt32(dgvVentas.Rows[e.RowIndex].Cells["VentaId"].Value);
                    var frmDetalle = new FrmReporteVentaIndividual(ventaId);
                    frmDetalle.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir el detalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Abrir reporte mensual de vendedor
        private void btnReporteVendedorMensual_Click_1(object sender, EventArgs e)
        {
            var frmVendedor = new FrmReporteVendedorMensual();
            frmVendedor.ShowDialog(); // Modal
        }

        // Abrir reporte mensual de cliente
        private void btnReporteClienteMensual_Click(object sender, EventArgs e)
        {
            var frmVendedor = new FrmReporteClienteMensual();
            frmVendedor.ShowDialog();
        }

        // Abrir reporte mensual de producto
        private void btnReporteProductoMensual_Click(object sender, EventArgs e)
        {
            var frmVendedor = new FrmReporteProductoMensual();
            frmVendedor.ShowDialog();
        }

        // Botón cerrar formulario
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
