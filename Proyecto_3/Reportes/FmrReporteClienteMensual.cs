using Entidad.Models;           // Clases de entidades: Usuario, Cliente, ReporteVenta, etc.
using Negocio.Servicios;        // Servicios de negocio: ReporteNegocio
using PdfSharpCore.Drawing;     // Para dibujar en PDF
using PdfSharpCore.Pdf;         // Para generar PDFs
using System;
using System.Collections.Generic;
using System.Drawing;            // Para gráficos y colores
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Forms
{
    public partial class FrmReporteClienteMensual : Form
    {
        private readonly ReporteNegocio _reporteNegocio = new ReporteNegocio(); // Servicio para obtener reportes
        private List<ReporteVenta> listaReporte; // Lista que contendrá los datos del reporte

        // Propiedades para seleccionar mes y año
        public int MesSeleccionado { get; set; }
        public int AnioSeleccionado { get; set; }

        // Constructor principal
        public FrmReporteClienteMensual()
        {
            InitializeComponent();

            // Establecer imagen de fondo
            string rutaImagen = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Imagen",
                "fondo.jpg"
            );
            this.BackgroundImage = Image.FromFile(rutaImagen);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        // Constructor opcional que recibe mes y año
        public FrmReporteClienteMensual(int mes, int anio) : this()
        {
            MesSeleccionado = mes;
            AnioSeleccionado = anio;
        }

        // Evento al cargar el formulario
        private void FrmReporteClienteMensual_Load(object sender, EventArgs e)
        {
            CargarMeses();
            CargarAnios();

            // Si se pasó mes y año desde el constructor, seleccionarlos automáticamente
            if (MesSeleccionado > 0 && AnioSeleccionado > 0)
            {
                cbMes.SelectedValue = MesSeleccionado;
                cbAnio.SelectedItem = AnioSeleccionado;
                GenerarReporte();
            }
        }

        // Cargar meses en ComboBox
        private void CargarMeses()
        {
            cbMes.DataSource = Enumerable.Range(1, 12)
                .Select(m => new
                {
                    Valor = m,
                    Nombre = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(m)
                })
                .ToList();
            cbMes.DisplayMember = "Nombre"; // Mostrar nombre del mes
            cbMes.ValueMember = "Valor";     // Valor interno (1-12)
            cbMes.SelectedIndex = DateTime.Now.Month - 1; // Seleccionar mes actual
        }

        // Cargar años en ComboBox
        private void CargarAnios()
        {
            cbAnio.DataSource = Enumerable.Range(DateTime.Now.Year - 5, 6).ToList(); // Últimos 5 años + año actual
            cbAnio.SelectedItem = DateTime.Now.Year; // Seleccionar año actual
        }

        // Botón generar reporte
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }

        // Método principal para generar el reporte
        private void GenerarReporte()
        {
            int mes = Convert.ToInt32(cbMes.SelectedValue);
            int anio = Convert.ToInt32(cbAnio.SelectedItem);

            // Obtener datos desde la capa de negocio
            listaReporte = _reporteNegocio.ObtenerReporteMensualPorCliente(anio, mes);

            // ---- Configurar DataGridView ----
            dgvReporte.DataSource = null;
            dgvReporte.Columns.Clear();
            dgvReporte.AutoGenerateColumns = false;

            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn { Name = "Cliente", HeaderText = "Cliente", DataPropertyName = "Cliente" });
            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn { Name = "TotalVentas", HeaderText = "Total Ventas", DataPropertyName = "TotalVentas" });
            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn { Name = "TotalRecaudado", HeaderText = "Total Recaudado (S/)", DataPropertyName = "TotalRecaudado", DefaultCellStyle = { Format = "N2" } });

            dgvReporte.DataSource = listaReporte;
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporte.ReadOnly = true;

            // ---- Mostrar vista previa en panel lateral ----
            MostrarVistaPrevia(listaReporte);
        }

        // Mostrar vista previa dentro de un panel (simulación de reporte visual)
        private void MostrarVistaPrevia(List<ReporteVenta> lista)
        {
            panelVistaPrevia.Controls.Clear();
            int y = 10;

            // Título
            Label lblTitulo = new Label
            {
                Text = "Reporte Mensual por Cliente",
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(10, y),
                AutoSize = true
            };
            panelVistaPrevia.Controls.Add(lblTitulo);
            y += 35;

            // Mes/Año
            Label lblFecha = new Label
            {
                Text = $"Mes: {cbMes.Text} / Año: {cbAnio.SelectedItem}",
                Font = new Font("Arial", 10),
                Location = new Point(10, y),
                AutoSize = true
            };
            panelVistaPrevia.Controls.Add(lblFecha);
            y += 25;

            // Encabezado
            Panel encabezado = new Panel
            {
                Location = new Point(10, y),
                Size = new Size(panelVistaPrevia.Width - 20, 25),
                BackColor = Color.LightGray
            };
            encabezado.Controls.Add(new Label { Text = "Cliente", Location = new Point(0, 0), Width = 150, Font = new Font("Arial", 9, FontStyle.Bold) });
            encabezado.Controls.Add(new Label { Text = "Total Ventas", Location = new Point(160, 0), Width = 100, Font = new Font("Arial", 9, FontStyle.Bold) });
            encabezado.Controls.Add(new Label { Text = "Total Recaudado (S/)", Location = new Point(270, 0), Width = 120, Font = new Font("Arial", 9, FontStyle.Bold) });
            panelVistaPrevia.Controls.Add(encabezado);
            y += 30;

            // Filas
            foreach (var item in lista)
            {
                Panel fila = new Panel
                {
                    Location = new Point(10, y),
                    Size = new Size(panelVistaPrevia.Width - 20, 25),
                    BorderStyle = BorderStyle.FixedSingle
                };
                fila.Controls.Add(new Label { Text = item.Cliente ?? "", Location = new Point(0, 0), Width = 150, Font = new Font("Arial", 9) });
                fila.Controls.Add(new Label { Text = (item.TotalVentas ?? 0).ToString(), Location = new Point(160, 0), Width = 100, Font = new Font("Arial", 9) });
                fila.Controls.Add(new Label { Text = (item.TotalRecaudado ?? 0m).ToString("N2"), Location = new Point(270, 0), Width = 120, Font = new Font("Arial", 9) });
                panelVistaPrevia.Controls.Add(fila);
                y += 28;
            }

            // Total general
            int totalVentas = lista.Sum(r => r.TotalVentas ?? 0);
            decimal totalRecaudado = lista.Sum(r => r.TotalRecaudado ?? 0m);
            Label lblTotal = new Label
            {
                Text = $"Total General: {totalVentas} ventas | Recaudado: S/ {totalRecaudado:N2}",
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(10, y + 10),
                AutoSize = true
            };
            panelVistaPrevia.Controls.Add(lblTotal);
        }

        // Exportar reporte a PDF
        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            if (listaReporte == null || listaReporte.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso");
                return;
            }

            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Archivos PDF|*.pdf";
                    sfd.Title = "Guardar reporte como PDF";
                    sfd.FileName = "ReporteClienteMensual.pdf";

                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    using (var pdf = new PdfDocument())
                    {
                        var page = pdf.AddPage();
                        var gfx = XGraphics.FromPdfPage(page);
                        var font = new XFont("Arial", 10);

                        int y = 40;

                        // Título
                        gfx.DrawString("Reporte Mensual por Cliente", new XFont("Arial", 14, XFontStyle.Bold), XBrushes.Black,
                            new XRect(0, y, page.Width, 0), XStringFormats.TopCenter);
                        y += 40;

                        // Mes/Año
                        gfx.DrawString($"Mes: {cbMes.Text} / Año: {cbAnio.SelectedItem}", font, XBrushes.Black,
                            new XRect(40, y, page.Width - 80, 0), XStringFormats.TopLeft);
                        y += 30;

                        // Encabezado
                        gfx.DrawRectangle(XBrushes.LightGray, 40, y, page.Width - 80, 20);
                        gfx.DrawString("Cliente", font, XBrushes.Black, new XRect(45, y + 3, 150, 0), XStringFormats.TopLeft);
                        gfx.DrawString("Total Ventas", font, XBrushes.Black, new XRect(200, y + 3, 100, 0), XStringFormats.TopLeft);
                        gfx.DrawString("Total Recaudado (S/)", font, XBrushes.Black, new XRect(310, y + 3, 120, 0), XStringFormats.TopLeft);
                        y += 25;

                        // Filas del reporte
                        foreach (var item in listaReporte)
                        {
                            gfx.DrawRectangle(XBrushes.White, 40, y, page.Width - 80, 20);
                            gfx.DrawString(item.Cliente ?? "", font, XBrushes.Black, new XRect(45, y + 3, 150, 0), XStringFormats.TopLeft);
                            gfx.DrawString((item.TotalVentas ?? 0).ToString(), font, XBrushes.Black, new XRect(200, y + 3, 100, 0), XStringFormats.TopLeft);
                            gfx.DrawString((item.TotalRecaudado ?? 0m).ToString("N2"), font, XBrushes.Black, new XRect(310, y + 3, 120, 0), XStringFormats.TopLeft);

                            y += 22;

                            // Nueva página si se pasa del límite
                            if (y > page.Height - 50)
                            {
                                page = pdf.AddPage();
                                gfx = XGraphics.FromPdfPage(page);
                                y = 40;
                            }
                        }

                        // Total general
                        int totalVentas = listaReporte.Sum(r => r.TotalVentas ?? 0);
                        decimal totalRecaudado = listaReporte.Sum(r => r.TotalRecaudado ?? 0m);
                        y += 10;
                        gfx.DrawString($"Total General: {totalVentas} ventas | Recaudado: S/ {totalRecaudado:N2}",
                            font, XBrushes.Black, new XRect(40, y, page.Width - 80, 0), XStringFormats.TopLeft);

                        pdf.Save(sfd.FileName);
                        MessageBox.Show($"PDF exportado correctamente en:\n{sfd.FileName}", "Éxito");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Simulación de impresión
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Simulación de impresión del reporte.");
            }
        }

        // Cerrar formulario
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
