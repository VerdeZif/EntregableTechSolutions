using Negocio.Servicios;
using System.Globalization;

namespace Presentacion.Forms
{
    public partial class FrmReportes : Form
    {
        private readonly ReporteVentaNegocio _reporteNegocio = new ReporteVentaNegocio();

        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddDays(-7);
            dtpHasta.Value = DateTime.Now;
            CargarReportes();
        }

        private void CargarReportes()
        {
            try
            {
                var desde = dtpDesde.Value.Date;
                var hasta = dtpHasta.Value.Date;

                // Obtener reporte de ventas por fecha
                var lista = _reporteNegocio.ObtenerReportePorFecha(desde, hasta);

                dgvReportes.DataSource = lista;

                // Eliminar columna TotalVentas si existe
                if (dgvReportes.Columns["TotalVentas"] != null)
                    dgvReportes.Columns.Remove("TotalVentas");

                // Ocultar TotalRecaudado para evitar duplicados
                if (dgvReportes.Columns["TotalRecaudado"] != null)
                    dgvReportes.Columns["TotalRecaudado"].Visible = false;

                // Ajustar columnas y encabezados
                if (dgvReportes.Columns["VentaId"] != null)
                    dgvReportes.Columns["VentaId"].HeaderText = "ID Venta";

                if (dgvReportes.Columns["Fecha"] != null)
                    dgvReportes.Columns["Fecha"].HeaderText = "Fecha";

                if (dgvReportes.Columns["Cliente"] != null)
                    dgvReportes.Columns["Cliente"].HeaderText = "Cliente";

                if (dgvReportes.Columns["Usuario"] != null)
                    dgvReportes.Columns["Usuario"].HeaderText = "Vendedor";

                if (dgvReportes.Columns["Producto"] != null)
                    dgvReportes.Columns["Producto"].HeaderText = "Producto";

                if (dgvReportes.Columns["CantidadVendida"] != null)
                    dgvReportes.Columns["CantidadVendida"].HeaderText = "Cant. Vendida";

                if (dgvReportes.Columns["Total"] != null)
                {
                    dgvReportes.Columns["Total"].HeaderText = "Total Venta";
                    dgvReportes.Columns["Total"].DefaultCellStyle.Format = "C2";
                    dgvReportes.Columns["Total"].DefaultCellStyle.FormatProvider = new CultureInfo("es-PE");

                    // Mover Total al final, después de CantidadVendida
                    int cantIndex = dgvReportes.Columns["CantidadVendida"].DisplayIndex;
                    dgvReportes.Columns["Total"].DisplayIndex = cantIndex + 1;
                }

                dgvReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvReportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvReportes.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los reportes: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarReportes();
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvReportes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta para ver el detalle.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int ventaId = Convert.ToInt32(dgvReportes.CurrentRow.Cells["VentaId"].Value);
            FrmReporteVenta frm = new FrmReporteVenta(ventaId);
            frm.ShowDialog();
        }
    }
}
