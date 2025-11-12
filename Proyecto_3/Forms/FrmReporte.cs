using Negocio.Servicios;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Forms
{
    public partial class FrmReporte : Form
    {
        private readonly ReporteNegocio _reporteNegocio = new ReporteNegocio();

        public FrmReporte()
        {
            InitializeComponent();
        }

        private void FrmReporte_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarVentas();
        }

        private void CargarCombos()
        {
            try
            {
                // Clientes
                cbCliente.DataSource = _reporteNegocio.ObtenerClientes();
                cbCliente.DisplayMember = "Nombre";
                cbCliente.ValueMember = "ClienteId";
                cbCliente.SelectedIndex = -1;

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

        private void CargarVentas()
        {
            try
            {
                DateTime? fechaInicio = chkRangoFechas.Checked ? dtpInicio.Value.Date : (DateTime?)null;
                DateTime? fechaFin = chkRangoFechas.Checked ? dtpFin.Value.Date.AddDays(1).AddSeconds(-1) : (DateTime?)null;

                int? clienteId = cbCliente.SelectedIndex >= 0 ? (int?)cbCliente.SelectedValue : null;
                int? vendedorId = cbVendedor.SelectedIndex >= 0 ? (int?)cbVendedor.SelectedValue : null;

                var lista = _reporteNegocio.ObtenerVentasFiltradas(
                    fechaInicio, fechaFin, clienteId, vendedorId, null, null
                );

                dgvVentas.AutoGenerateColumns = false;
                dgvVentas.Columns.Clear();
                dgvVentas.DataSource = lista;

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
                    DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" }
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

                dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvVentas.ReadOnly = true;
                dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkRangoFechas_CheckedChanged(object sender, EventArgs e)
        {
            dtpInicio.Enabled = dtpFin.Enabled = chkRangoFechas.Checked;
        }

        private void btnBuscar_Click(object sender, EventArgs e) => CargarVentas();

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            chkRangoFechas.Checked = false;
            cbCliente.SelectedIndex = -1;
            cbVendedor.SelectedIndex = -1;
            CargarVentas();
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVentas.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una venta para ver su detalle.", "Aviso");
                    return;
                }

                string colId = dgvVentas.Columns
                    .Cast<DataGridViewColumn>()
                    .FirstOrDefault(c => c.DataPropertyName.ToLower().Contains("ventaid"))?.Name;

                if (colId == null)
                {
                    MessageBox.Show("No se encontró la columna del ID de venta.", "Error");
                    return;
                }

                int ventaId = Convert.ToInt32(dgvVentas.CurrentRow.Cells[colId].Value);
                new FrmReporteVentaIndividual(ventaId).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el detalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            if (dgvVentas.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso");
                return;
            }

            try
            {
                using (var pdf = new PdfDocument())
                {
                    var page = pdf.AddPage();
                    var gfx = XGraphics.FromPdfPage(page);
                    var font = new XFont("Arial", 10);

                    gfx.DrawString("Reporte de Ventas", new XFont("Arial", 14, XFontStyle.Bold),
                        XBrushes.Black, new XRect(0, 20, page.Width, 20), XStringFormats.TopCenter);

                    int y = 60;
                    gfx.DrawString("Fecha de generación: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                        font, XBrushes.Black, new XRect(40, y, page.Width, 20));

                    y += 20;
                    foreach (DataGridViewRow row in dgvVentas.Rows)
                    {
                        string linea = $"Venta #{row.Cells["VentaId"].Value} | Cliente: {row.Cells["Cliente"].Value} | Total: S/ {row.Cells["Total"].Value}";
                        gfx.DrawString(linea, font, XBrushes.Black, new XRect(40, y, page.Width - 80, 20));
                        y += 18;

                        if (y > page.Height - 40)
                        {
                            page = pdf.AddPage();
                            gfx = XGraphics.FromPdfPage(page);
                            y = 40;
                        }
                    }

                    string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ReporteVentas.pdf");
                    pdf.Save(ruta);
                    MessageBox.Show($"PDF exportado correctamente en:\n{ruta}", "Éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Simulación de impresión de reporte (puedes implementar PrintDocument).");
            }
        }

        private void dgvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Evita errores si hacen doble clic en el encabezado
            {
                try
                {
                    // Obtener el ID de la venta desde la fila seleccionada
                    int ventaId = Convert.ToInt32(dgvVentas.Rows[e.RowIndex].Cells["VentaId"].Value);

                    // Abrir el formulario de detalle
                    var frmDetalle = new FrmReporteVentaIndividual(ventaId);
                    frmDetalle.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir el detalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReporteVendedorMensual_Click_1(object sender, EventArgs e)
        {
            var frmVendedor = new FrmReporteVendedorMensual();
            frmVendedor.ShowDialog(); // Modal
        }

        private void btnReporteClienteMensual_Click(object sender, EventArgs e)
        {
            var frmVendedor = new FrmReporteClienteMensual();
            frmVendedor.ShowDialog();
        }

        private void btnReporteProductoMensual_Click(object sender, EventArgs e)
        {
            var frmVendedor = new FrmReporteProductoMensual();
            frmVendedor.ShowDialog();
        }
    }
}
