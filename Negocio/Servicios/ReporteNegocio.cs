using Datos.Repositorio;
using Entidad.Models;
using System;
using System.Collections.Generic;

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

        // Detalle de venta
        public List<DetalleVenta> ObtenerDetalleVenta(int ventaId)
        {
            return _reporteDatos.ObtenerDetalleVenta(ventaId);
        }

        // 🔹 Nuevo: Obtener lista de clientes
        public List<Cliente> ObtenerClientes()
        {
            return _reporteDatos.ObtenerClientes();
        }

        // 🔹 Nuevo: Obtener lista de vendedores
        public List<Usuario> ObtenerVendedores()
        {
            return _reporteDatos.ObtenerVendedores();
        }

        // 🔹 Nuevo: Obtener ventas filtradas (por fecha, cliente, vendedor)
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

        public List<ReporteVenta> ObtenerReporteMensualPorVendedor(int anio, int mes)
        {
            return _reporteDatos.ObtenerReporteMensualPorVendedor(anio, mes);
        }

        public List<ReporteVenta> ObtenerReporteMensualPorCliente(int anio, int mes)
        {
            return _reporteDatos.ObtenerReporteMensualPorCliente(anio, mes);
        }

        public List<ReporteVenta> ObtenerReporteMensualPorProducto(int anio, int mes)
        {
            return _reporteDatos.ObtenerReporteMensualPorProducto(anio, mes);
        }



    }
}
