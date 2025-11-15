using Datos.Repositorio;
using Entidad.Models;

namespace Negocio.Servicios
{
    // ==============================
    // CAPA DE NEGOCIO PARA REPORTES
    // Encapsula la lógica de negocio para la obtención de reportes de ventas,
    // clientes, vendedores y detalle de ventas.
    // ==============================
    public class ReporteNegocio
    {
        // Instancia de la clase de datos para interactuar con la base de datos
        private readonly ReporteDatos _reporteDatos;

        // Constructor: inicializa la instancia de ReporteDatos
        public ReporteNegocio()
        {
            _reporteDatos = new ReporteDatos();
        }

        // ==============================
        // REPORTE DE VENTAS POR FECHA
        // Obtiene todas las ventas registradas entre fechaInicio y fechaFin
        // ==============================
        public List<ReporteVenta> ObtenerReportePorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return _reporteDatos.ObtenerVentasPorFecha(fechaInicio, fechaFin);
        }

        // ==============================
        // REPORTE GENERAL DE VENTAS
        // Devuelve todas las ventas registradas sin filtrar por fechas
        // ==============================
        public List<ReporteVenta> ObtenerReporteGeneral()
        {
            return _reporteDatos.ObtenerVentasPorFecha(DateTime.MinValue, DateTime.MaxValue);
        }

        // ==============================
        // DETALLE DE VENTA
        // Obtiene los detalles de una venta específica según su ID
        // ==============================
        public List<DetalleVenta> ObtenerDetalleVenta(int ventaId)
        {
            return _reporteDatos.ObtenerDetalleVenta(ventaId);
        }

        // ==============================
        // LISTA DE CLIENTES
        // Devuelve todos los clientes registrados en la base de datos
        // ==============================
        public List<Cliente> ObtenerClientes()
        {
            return _reporteDatos.ObtenerClientes();
        }

        // ==============================
        // LISTA DE VENDEDORES
        // Devuelve todos los usuarios con rol de vendedor
        // ==============================
        public List<Usuario> ObtenerVendedores()
        {
            return _reporteDatos.ObtenerVendedores();
        }

        // ==============================
        // VENTAS FILTRADAS
        // Permite filtrar ventas por fecha, cliente, vendedor o rango de total
        // Todos los parámetros son opcionales
        // ==============================
        public List<ReporteVenta> ObtenerVentasFiltradas(
            DateTime? fechaInicio,
            DateTime? fechaFin,
            int? clienteId,
            int? vendedorId,
            decimal? totalMin,
            decimal? totalMax)
        {
            return _reporteDatos.ObtenerVentasFiltradas(fechaInicio, fechaFin, clienteId, vendedorId, totalMin, totalMax);
        }

        // ==============================
        // REPORTE MENSUAL POR VENDEDOR
        // Devuelve un resumen de ventas agrupadas por vendedor para un mes específico
        // ==============================
        public List<ReporteVenta> ObtenerReporteMensualPorVendedor(int anio, int mes)
        {
            return _reporteDatos.ObtenerReporteMensualPorVendedor(anio, mes);
        }

        // ==============================
        // REPORTE MENSUAL POR CLIENTE
        // Devuelve un resumen de ventas agrupadas por cliente para un mes específico
        // ==============================
        public List<ReporteVenta> ObtenerReporteMensualPorCliente(int anio, int mes)
        {
            return _reporteDatos.ObtenerReporteMensualPorCliente(anio, mes);
        }

        // ==============================
        // REPORTE MENSUAL POR PRODUCTO
        // Devuelve un resumen de ventas agrupadas por producto para un mes específico
        // ==============================
        public List<ReporteVenta> ObtenerReporteMensualPorProducto(int anio, int mes)
        {
            return _reporteDatos.ObtenerReporteMensualPorProducto(anio, mes);
        }
    }
}
