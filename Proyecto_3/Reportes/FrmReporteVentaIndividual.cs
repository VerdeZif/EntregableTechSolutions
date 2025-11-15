using Negocio.Servicios;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System.Diagnostics;
using System.Globalization;
using System.Drawing.Printing;

namespace Presentacion.Forms
{
    // Formulario para mostrar, exportar e imprimir un ticket de venta individual
    public partial class FrmReporteVentaIndividual : Form
    {
        // Servicio para obtener datos de reportes
        private readonly ReporteNegocio _reporteNegocio = new ReporteNegocio();

        // ID de la venta a mostrar
        private readonly int _ventaId;

        // Bitmap que contiene la previsualización del ticket
        private Bitmap _ticketPreview;

        // Constructor recibe el ID de venta
        public FrmReporteVentaIndividual(int ventaId)
        {
            InitializeComponent();
            _ventaId = ventaId;

            // Configurar imagen de fondo
            string rutaImagen = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Imagen",
                "fondo.jpg"
            );

            this.BackgroundImage = Image.FromFile(rutaImagen);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        // Evento Load del formulario
        private void FrmReporteVentaIndividual_Load(object sender, EventArgs e)
        {
            CargarTicket(); // Cargar y mostrar ticket
        }

        // Cargar los datos de la venta y construir el ticket
        private void CargarTicket()
        {
            try
            {
                // Obtener detalle de la venta desde el negocio
                var detalle = _reporteNegocio.ObtenerDetalleVenta(_ventaId);

                // Validar si hay datos
                if (detalle == null || detalle.Count == 0)
                {
                    MessageBox.Show("No se encontró información para esta venta.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Tomar datos generales de la primera fila
                var primera = detalle[0];

                // Construir ticket como texto
                string ticket = "*************** TICKET DE VENTA ***************\n\n";
                ticket += $"ID Venta: {primera.VentaId}\n";
                ticket += $"Cliente: {primera.NombreCliente}\n";
                ticket += $"Vendedor: {primera.NombreUsuario}\n";
                ticket += $"Fecha: {primera.FechaVenta:dd/MM/yyyy HH:mm}\n";
                ticket += "----------------------------------------------\n";
                ticket += "Producto              Cant.  P.Unit   Subtotal\n";
                ticket += "----------------------------------------------\n";

                // Agregar productos al ticket con formato de columnas fijas
                foreach (var d in detalle)
                {
                    string prod = d.NombreProducto.Length > 18
                        ? d.NombreProducto.Substring(0, 18) // cortar si es muy largo
                        : d.NombreProducto.PadRight(18);    // rellenar si es corto

                    string cant = d.Cantidad.ToString().PadLeft(4);
                    string precio = d.PrecioUnitario.ToString("C2", new CultureInfo("es-PE")).PadLeft(10);
                    string subtotal = d.Subtotal.ToString("C2", new CultureInfo("es-PE")).PadLeft(10);

                    ticket += $"{prod} {cant} {precio} {subtotal}\n";
                }

                ticket += "----------------------------------------------\n";
                ticket += $"TOTAL: {primera.TotalVenta.ToString("C2", new CultureInfo("es-PE"))}\n";
                ticket += "**********************************************";

                // Generar imagen de previsualización del ticket
                GenerarPrevisualizacion(ticket);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el ticket: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Crear imagen del ticket para previsualización
        private void GenerarPrevisualizacion(string contenido)
        {
            int width = 350;   // ancho del ticket
            int height = 600;  // alto del ticket
            _ticketPreview = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(_ticketPreview))
            {
                g.Clear(Color.White); // fondo blanco
                g.DrawString(contenido, new Font("Consolas", 9), Brushes.Black, new RectangleF(10, 10, width - 20, height - 20));
            }

            // Mostrar la imagen en el PictureBox
            pictureBoxPreview.Image = _ticketPreview;
        }

        // Exportar ticket a PDF
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

                        // Abrir PDF automáticamente
                        Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a PDF: " + ex.Message);
            }
        }

        // Método para generar PDF usando la previsualización como imagen
        private void ExportarTicketPDF(string ruta)
        {
            var doc = new PdfDocument();
            var page = doc.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            // Convertir Bitmap a imagen compatible con PDF
            using (MemoryStream ms = new MemoryStream())
            {
                _ticketPreview.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;
                var img = XImage.FromStream(() => new MemoryStream(ms.ToArray()));
                gfx.DrawImage(img, 20, 20); // dibujar imagen en PDF
            }

            doc.Save(ruta);
        }

        // Imprimir el ticket
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
                // Dibujar ticket en la página de impresión
                ev.Graphics.DrawImage(_ticketPreview, 10, 10);
            };

            PrintDialog printDialog = new PrintDialog { Document = pd };

            if (printDialog.ShowDialog() == DialogResult.OK)
                pd.Print();
        }

        // Cerrar formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
