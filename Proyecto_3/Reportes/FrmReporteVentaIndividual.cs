using Negocio.Servicios;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;

namespace Presentacion.Forms
{
    public partial class FrmReporteVentaIndividual : Form
    {
        private readonly ReporteNegocio _reporteNegocio = new ReporteNegocio();
        private readonly int _ventaId;
        private Bitmap _ticketPreview;

        public FrmReporteVentaIndividual(int ventaId)
        {
            InitializeComponent();
            _ventaId = ventaId;
        }

        private void FrmReporteVentaIndividual_Load(object sender, EventArgs e)
        {
            CargarTicket();
        }

        private void CargarTicket()
        {
            try
            {
                var detalle = _reporteNegocio.ObtenerDetalleVenta(_ventaId);
                if (detalle == null || detalle.Count == 0)
                {
                    MessageBox.Show("No se encontró información para esta venta.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var primera = detalle[0];
                string ticket = "*************** TICKET DE VENTA ***************\n\n";
                ticket += $"ID Venta: {primera.VentaId}\n";
                ticket += $"Cliente: {primera.NombreCliente}\n";
                ticket += $"Vendedor: {primera.NombreUsuario}\n";
                ticket += $"Fecha: {primera.FechaVenta:dd/MM/yyyy HH:mm}\n";
                ticket += "----------------------------------------------\n";
                ticket += "Producto              Cant.  P.Unit   Subtotal\n";
                ticket += "----------------------------------------------\n";

                foreach (var d in detalle)
                {
                    string prod = d.NombreProducto.Length > 18 ? d.NombreProducto.Substring(0, 18) : d.NombreProducto.PadRight(18);
                    ticket += $"{prod}{d.Cantidad,6}{d.PrecioUnitario,9:C2}{d.Subtotal,10:C2}\n";
                }

                ticket += "----------------------------------------------\n";
                ticket += $"TOTAL: {primera.TotalVenta.ToString("C2", new CultureInfo("es-PE"))}\n";
                ticket += "**********************************************";

                GenerarPrevisualizacion(ticket);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el ticket: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarPrevisualizacion(string contenido)
        {
            int width = 350;
            int height = 600;
            _ticketPreview = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(_ticketPreview))
            {
                g.Clear(Color.White);
                g.DrawString(contenido, new Font("Consolas", 9), Brushes.Black, new RectangleF(10, 10, width - 20, height - 20));
            }
            pictureBoxPreview.Image = _ticketPreview;
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "Archivo PDF|*.pdf",
                    FileName = $"Ticket_Venta_{_ventaId}.pdf"
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        ExportarTicketPDF(sfd.FileName);
                        MessageBox.Show("PDF generado correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a PDF: " + ex.Message);
            }
        }

        private void ExportarTicketPDF(string ruta)
        {
            var doc = new PdfDocument();
            var page = doc.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            // Dibujar la imagen renderizada (previsualización)
            using (MemoryStream ms = new MemoryStream())
            {
                _ticketPreview.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;
                var img = XImage.FromStream(() => new MemoryStream(ms.ToArray()));
                gfx.DrawImage(img, 20, 20);
            }

            doc.Save(ruta);
        }


        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (_ticketPreview == null)
            {
                MessageBox.Show("No hay ticket para imprimir.");
                return;
            }

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (s, ev) =>
            {
                ev.Graphics.DrawImage(_ticketPreview, 10, 10);
            };

            PrintDialog printDialog = new PrintDialog { Document = pd };
            if (printDialog.ShowDialog() == DialogResult.OK)
                pd.Print();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
