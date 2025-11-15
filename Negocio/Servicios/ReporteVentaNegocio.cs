using Datos.Repositorio;
using Entidad.Models;

namespace Negocio.Servicios
{
    // ==============================
    // CAPA DE NEGOCIO PARA REPORTES DE VENTAS
    // Encapsula la lógica de negocio relacionada con los reportes
    // de ventas, productos más vendidos, ventas por usuario y detalle de venta.
    // ==============================
    public class ReporteVentaNegocio
    {
        // Instancia de la clase de datos para interactuar con la base de datos
        private readonly ReporteVentaDatos _reporteVentaDatos;

        // Constructor: inicializa la instancia de ReporteVentaDatos
        public ReporteVentaNegocio()
        {
            _reporteVentaDatos = new ReporteVentaDatos();
        }

        // ==============================
        // REPORTE DE VENTAS POR FECHA
        // Devuelve todas las ventas registradas entre fechaInicio y fechaFin
        // ==============================
        public List<ReporteVenta> ObtenerReportePorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return _reporteVentaDatos.ObtenerVentasPorFecha(fechaInicio, fechaFin);
        }

        // ==============================
        // REPORTE GENERAL DE VENTAS
        // Devuelve todas las ventas registradas sin filtrar por fechas
        // ==============================
        public List<ReporteVenta> ObtenerReporteGeneral()
        {
            return _reporteVentaDatos.ObtenerVentasPorFecha(DateTime.MinValue, DateTime.MaxValue);
        }

        // ==============================
        // PRODUCTOS MÁS VENDIDOS
        // Obtiene un listado de productos vendidos, con cantidad total y total recaudado
        // dentro del rango de fechas indicado
        // ==============================
        public List<ReporteVenta> ObtenerProductosMasVendidos(DateTime fechaInicio, DateTime fechaFin)
        {
            return _reporteVentaDatos.ObtenerProductosMasVendidos(fechaInicio, fechaFin);
        }

        // ==============================
        // TOTAL DE VENTAS POR USUARIO
        // Devuelve la cantidad de ventas y total recaudado por cada usuario
        // dentro del rango de fechas indicado
        // ==============================
        public List<ReporteVenta> ObtenerTotalVentasPorUsuario(DateTime fechaInicio, DateTime fechaFin)
        {
            return _reporteVentaDatos.ObtenerTotalVentasPorUsuario(fechaInicio, fechaFin);
        }

        // ==============================
        // DETALLE DE UNA VENTA
        // Obtiene los detalles completos de una venta específica según su ID
        // ==============================
        public List<DetalleVenta> ObtenerDetalleVenta(int ventaId)
        {
            return _reporteVentaDatos.ObtenerDetalleVenta(ventaId);
        }
    }
}
