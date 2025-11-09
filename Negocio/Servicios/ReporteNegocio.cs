using Datos.Database;
using Datos.Repositorio;
using Entidad.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Servicios
{
    public class ReporteNegocio
    {
        private readonly ReporteDatos _reporteDatos;

        public ReporteNegocio()
        {
            _reporteDatos = new ReporteDatos();
        }


        // Reporte de ventas por fecha
        public List<ReporteVenta> ObtenerReportePorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return _reporteDatos.ObtenerVentasPorFecha(fechaInicio, fechaFin);
        }

        // Reporte general de ventas    
        public List<ReporteVenta> ObtenerReporteGeneral()
        {
            return _reporteDatos.ObtenerVentasPorFecha(DateTime.MinValue, DateTime.MaxValue);
        }
        public List<DetalleVenta> ObtenerDetalleVenta(int ventaId)
        {
            return _reporteDatos.ObtenerDetalleVenta(ventaId);
        }
    }
}