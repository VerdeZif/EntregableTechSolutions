using Datos.Repositorio;
using Entidad.Models;

namespace Negocio.Servicios
{
    public class ReporteVentaNegocio
    {
        private readonly ReporteVentaDatos _reporteVentaDatos;

        public ReporteVentaNegocio()
        {
            _reporteVentaDatos = new ReporteVentaDatos();
        }

        // ===============================
        // REPORTE POR FECHA
        // ===============================
        public List<ReporteVenta> ObtenerReportePorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return _reporteVentaDatos.ObtenerVentasPorFecha(fechaInicio, fechaFin);
        }

        // ===============================
        // REPORTE GENERAL
        // ===============================
        public List<ReporteVenta> ObtenerReporteGeneral()
        {
            return _reporteVentaDatos.ObtenerVentasPorFecha(DateTime.MinValue, DateTime.MaxValue);
        }

        // ===============================s
        // PRODUCTOS MÁS VENDIDOS
        // ===============================
        public List<ReporteVenta> ObtenerProductosMasVendidos(DateTime fechaInicio, DateTime fechaFin)
        {
            return _reporteVentaDatos.ObtenerProductosMasVendidos(fechaInicio, fechaFin);
        }

        // ===============================
        // TOTAL VENTAS POR USUARIO
        // ===============================
        public List<ReporteVenta> ObtenerTotalVentasPorUsuario(DateTime fechaInicio, DateTime fechaFin)
        {
            return _reporteVentaDatos.ObtenerTotalVentasPorUsuario(fechaInicio, fechaFin);
        }

        // ===============================
        // DETALLE DE UNA VENTA
        // ===============================
        public List<DetalleVenta> ObtenerDetalleVenta(int ventaId)
        {
            return _reporteVentaDatos.ObtenerDetalleVenta(ventaId);
        }
    }
}
