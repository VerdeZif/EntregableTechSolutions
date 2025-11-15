using Datos.Database; // Conexión a la base de datos (singleton)
using Entidad.Models; // Modelos: ReporteVenta, DetalleVenta
using Microsoft.Data.SqlClient; // Cliente SQL Server

namespace Datos.Repositorio
{
    public class ReporteVentaDatos
    {
        // ===============================
        // REPORTE DE VENTAS POR FECHA
        // ===============================
        public List<ReporteVenta> ObtenerVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            var lista = new List<ReporteVenta>(); // Lista donde se guardarán las ventas

            using (var conn = ConexionBD.Instance.GetConnection()) // Abrir conexión a la BD
            {
                conn.Open();
                string query = @"
                    SELECT 
                        v.VentaId,
                        v.Fecha,
                        c.Nombre AS Cliente,
                        u.NombreCompleto AS Usuario,
                        p.Nombre AS Producto,
                        d.Cantidad AS CantidadVendida,
                        (d.Cantidad * d.PrecioUnitario) AS Total,
                        v.Total AS TotalRecaudado
                    FROM Ventas v
                    INNER JOIN Clientes c ON v.ClienteId = c.ClienteId
                    INNER JOIN Usuarios u ON v.UserId = u.UserId
                    INNER JOIN DetalleVenta d ON v.VentaId = d.VentaId
                    INNER JOIN Productos p ON d.ProductoId = p.ProductoId
                    WHERE CAST(v.Fecha AS DATE) BETWEEN @fechaInicio AND @fechaFin
                    ORDER BY v.Fecha DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    // Asignar parámetros de fecha
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin);

                    using (var dr = cmd.ExecuteReader()) // Ejecuta consulta
                    {
                        while (dr.Read()) // Leer cada fila de resultados
                        {
                            // Mapear datos de la fila a objeto ReporteVenta
                            lista.Add(new ReporteVenta
                            {
                                VentaId = Convert.ToInt32(dr["VentaId"]),
                                Fecha = Convert.ToDateTime(dr["Fecha"]),
                                Cliente = dr["Cliente"]?.ToString() ?? string.Empty,
                                Usuario = dr["Usuario"]?.ToString() ?? string.Empty,
                                Producto = dr["Producto"]?.ToString() ?? string.Empty,
                                CantidadVendida = Convert.ToInt32(dr["CantidadVendida"]),
                                Total = Convert.ToDecimal(dr["Total"]),
                                TotalRecaudado = Convert.ToDecimal(dr["TotalRecaudado"])
                            });
                        }
                    }
                }
            }

            return lista; // Retorna todas las ventas dentro del rango de fechas
        }

        // ===============================
        // PRODUCTOS MÁS VENDIDOS
        // ===============================
        public List<ReporteVenta> ObtenerProductosMasVendidos(DateTime fechaInicio, DateTime fechaFin)
        {
            var lista = new List<ReporteVenta>(); // Lista donde se guardan los productos más vendidos

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        p.Nombre AS Producto,
                        SUM(d.Cantidad) AS TotalVendido,
                        SUM(d.Cantidad * d.PrecioUnitario) AS TotalRecaudado
                    FROM DetalleVenta d
                    INNER JOIN Ventas v ON d.VentaId = v.VentaId
                    INNER JOIN Productos p ON d.ProductoId = p.ProductoId
                    WHERE CAST(v.Fecha AS DATE) BETWEEN @fechaInicio AND @fechaFin
                    GROUP BY p.Nombre
                    ORDER BY TotalVendido DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    // Asignar parámetros de fechas
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read()) // Leer cada fila y mapear a ReporteVenta
                        {
                            lista.Add(new ReporteVenta
                            {
                                Producto = dr["Producto"]?.ToString() ?? string.Empty,
                                CantidadVendida = Convert.ToInt32(dr["TotalVendido"]),
                                TotalRecaudado = Convert.ToDecimal(dr["TotalRecaudado"])
                            });
                        }
                    }
                }
            }

            return lista; // Retorna los productos más vendidos en el rango de fechas
        }

        // ===============================
        // TOTAL DE VENTAS POR USUARIO
        // ===============================
        public List<ReporteVenta> ObtenerTotalVentasPorUsuario(DateTime fechaInicio, DateTime fechaFin)
        {
            var lista = new List<ReporteVenta>(); // Lista para acumular ventas por usuario

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        u.NombreCompleto AS Usuario,
                        COUNT(v.VentaId) AS TotalVentas,
                        SUM(v.Total) AS TotalRecaudado
                    FROM Ventas v
                    INNER JOIN Usuarios u ON v.UserId = u.UserId
                    WHERE CAST(v.Fecha AS DATE) BETWEEN @fechaInicio AND @fechaFin
                    GROUP BY u.NombreCompleto
                    ORDER BY TotalRecaudado DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read()) // Mapear cada usuario y su total de ventas
                        {
                            lista.Add(new ReporteVenta
                            {
                                Usuario = dr["Usuario"]?.ToString() ?? string.Empty,
                                TotalVentas = Convert.ToInt32(dr["TotalVentas"]),
                                TotalRecaudado = Convert.ToDecimal(dr["TotalRecaudado"])
                            });
                        }
                    }
                }
            }

            return lista; // Retorna la lista de usuarios con sus totales de ventas
        }

        // ===============================
        // DETALLE DE UNA VENTA
        // ===============================
        public List<DetalleVenta> ObtenerDetalleVenta(int ventaId)
        {
            var lista = new List<DetalleVenta>(); // Lista donde se guardan los productos de la venta

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(@"
                    SELECT 
                        d.DetalleId,
                        d.VentaId,
                        d.ProductoId,
                        p.Nombre AS ProductoNombre,
                        d.Cantidad,
                        d.PrecioUnitario,
                        v.Fecha AS FechaVenta,
                        c.Nombre AS ClienteNombre,
                        v.Total AS TotalVenta
                    FROM DetalleVenta d
                    INNER JOIN Productos p ON d.ProductoId = p.ProductoId
                    INNER JOIN Ventas v ON d.VentaId = v.VentaId
                    INNER JOIN Clientes c ON v.ClienteId = c.ClienteId
                    WHERE d.VentaId = @ventaId", conn))
                {
                    cmd.Parameters.AddWithValue("@ventaId", ventaId); // Asignar ID de venta

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read()) // Leer cada producto de la venta
                        {
                            lista.Add(new DetalleVenta
                            {
                                DetalleId = Convert.ToInt32(dr["DetalleId"]),
                                VentaId = Convert.ToInt32(dr["VentaId"]),
                                ProductoId = Convert.ToInt32(dr["ProductoId"]),
                                NombreProducto = dr["ProductoNombre"]?.ToString(),
                                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]),
                                FechaVenta = Convert.ToDateTime(dr["FechaVenta"]),
                                NombreCliente = dr["ClienteNombre"]?.ToString() ?? string.Empty,
                                TotalVenta = Convert.ToDecimal(dr["TotalVenta"])
                            });
                        }
                    }
                }
            }

            return lista; // Retorna todos los productos de la venta específica
        }
    }
}
