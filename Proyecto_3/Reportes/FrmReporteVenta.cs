using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Negocio.Servicios;
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;

namespace Presentacion.Forms
{
    public partial class FrmReporteVenta : Form
    {
        private readonly ReporteNegocio _reporteNegocio = new ReporteNegocio();
        private readonly int _ventaId;

        public FrmReporteVenta(int ventaId)
        {
            InitializeComponent();
            _ventaId = ventaId;
        }

        private void FrmReporteVenta_Load(object sender, EventArgs e)
        {
            CargarDetalleVenta();
        }

        private void CargarDetalleVenta()
        {
            try
            {
                var detalle = _reporteNegocio.ObtenerDetalleVenta(_ventaId);

                if (detalle == null || detalle.Count == 0)
                {
                    MessageBox.Show("No se encontró detalle para esta venta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Encabezado
                lblVentaId.Text = $"Venta N°: {_ventaId}";
                lblFecha.Text = $"Fecha: {detalle[0].FechaVenta:dd/MM/yyyy}";
                lblCliente.Text = $"Cliente: {detalle[0].NombreCliente}";
                lblTotal.Text = $"Total: S/. {detalle[0].TotalVenta:F2}";

                // Limpiar panel detalle
                pnlDetalle.Controls.Clear();

                int y = 0;
                foreach (var item in detalle)
                {
                    Label lblProducto = new Label
                    {
                        Text = item.NombreProducto,
                        Location = new Point(10, y),
                        AutoSize = true,
                        Font = new Font("Consolas", 10, FontStyle.Regular)
                    };
                    Label lblCantidad = new Label
                    {
                        Text = item.Cantidad.ToString(),
                        Location = new Point(200, y),
                        AutoSize = true,
                        Font = new Font("Consolas", 10, FontStyle.Regular)
                    };
                    Label lblPrecio = new Label
                    {
                        Text = $"S/. {item.PrecioUnitario:F2}",
                        Location = new Point(250, y),
                        AutoSize = true,
                        Font = new Font("Consolas", 10, FontStyle.Regular)
                    };
                    Label lblSubtotal = new Label
                    {
                        Text = $"S/. {item.Subtotal:F2}",
                        Location = new Point(350, y),
                        AutoSize = true,
                        Font = new Font("Consolas", 10, FontStyle.Regular)
                    };

                    pnlDetalle.Controls.Add(lblProducto);
                    pnlDetalle.Controls.Add(lblCantidad);
                    pnlDetalle.Controls.Add(lblPrecio);
                    pnlDetalle.Controls.Add(lblSubtotal);

                    y += 25;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el detalle de venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            var detalle = _reporteNegocio.ObtenerDetalleVenta(_ventaId);
            if (detalle == null || detalle.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Información");
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo PDF|*.pdf";
            sfd.FileName = $"Venta_{_ventaId}.pdf";

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                PdfDocument doc = new PdfDocument();
                PdfPage page = doc.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont font = new XFont("Consolas", 10, XFontStyle.Regular);

                int y = 40;
                gfx.DrawString($"Venta N°: {_ventaId}", new XFont("Consolas", 12, XFontStyle.Bold), XBrushes.Black, new XRect(10, y, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                y += 20;
                gfx.DrawString(lblFecha.Text, font, XBrushes.Black, new XRect(10, y, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                y += 20;
                gfx.DrawString(lblCliente.Text, font, XBrushes.Black, new XRect(10, y, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                y += 30;

                // Encabezado de tabla
                gfx.DrawString("Producto", font, XBrushes.Black, new XRect(10, y, 150, page.Height.Point), XStringFormats.TopLeft);
                gfx.DrawString("Cant.", font, XBrushes.Black, new XRect(200, y, 50, page.Height.Point), XStringFormats.TopLeft);
                gfx.DrawString("Precio", font, XBrushes.Black, new XRect(250, y, 80, page.Height.Point), XStringFormats.TopLeft);
                gfx.DrawString("Subtotal", font, XBrushes.Black, new XRect(350, y, 80, page.Height.Point), XStringFormats.TopLeft);
                y += 20;

                foreach (var item in detalle)
                {
                    gfx.DrawString(item.NombreProducto, font, XBrushes.Black, new XRect(10, y, 150, page.Height.Point), XStringFormats.TopLeft);
                    gfx.DrawString(item.Cantidad.ToString(), font, XBrushes.Black, new XRect(200, y, 50, page.Height.Point), XStringFormats.TopLeft);
                    gfx.DrawString($"S/. {item.PrecioUnitario:F2}", font, XBrushes.Black, new XRect(250, y, 80, page.Height.Point), XStringFormats.TopLeft);
                    gfx.DrawString($"S/. {item.Subtotal:F2}", font, XBrushes.Black, new XRect(350, y, 80, page.Height.Point), XStringFormats.TopLeft);
                    y += 20;
                }

                y += 20;
                gfx.DrawString(lblTotal.Text, new XFont("Consolas", 12, XFontStyle.Bold), XBrushes.Black, new XRect(10, y, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                doc.Save(sfd.FileName);
                MessageBox.Show("PDF generado correctamente.", "Éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar PDF: " + ex.Message, "Error");
            }
        }
    }
}
