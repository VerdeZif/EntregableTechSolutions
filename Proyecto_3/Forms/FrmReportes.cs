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
using Entidad.Models;

namespace Presentacion.Forms
{
    public partial class FrmReportes : Form
    {
        private readonly ReporteNegocio _reporteNegocio = new ReporteNegocio();

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

                dgvReportes.DataSource = _reporteNegocio.ObtenerReportePorFecha(desde, hasta);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los reportes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Seleccione una venta para ver el detalle.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int ventaId = Convert.ToInt32(dgvReportes.CurrentRow.Cells["VentaId"].Value);
            FrmReporteVenta frm = new FrmReporteVenta(ventaId);
            frm.ShowDialog();
        }
    }
}
