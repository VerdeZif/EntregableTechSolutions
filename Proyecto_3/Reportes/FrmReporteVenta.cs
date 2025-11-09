using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Windows.Forms;
using Negocio.Servicios;

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

                dgvDetalle.DataSource = detalle;

                // Mostrar resumen
                lblVentaId.Text = $"Venta N°: {_ventaId}";
                lblFecha.Text = $"Fecha: {detalle[0].FechaVenta:dd/MM/yyyy}";
                lblCliente.Text = $"Cliente: {detalle[0].NombreCliente}";
                lblTotal.Text = $"Total: S/. {detalle[0].TotalVenta:F2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el detalle de venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
