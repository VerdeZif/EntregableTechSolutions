using Datos.Database;
using Entidad.Models;
using Microsoft.Data.SqlClient;

namespace Datos.Repositorio
{
    public class ReporteDatos
    {
        // Ventas por fecha
        public List<ReporteVenta> ObtenerVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            var lista = new List<ReporteVenta>();

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        v.VentaId,
                        v.Fecha,
                        c.Nombre AS Cliente,
                        u.NombreCompleto AS Usuario,
                        v.Total
                    FROM Ventas v
                    INNER JOIN Clientes c ON v.ClienteId = c.ClienteId
                    INNER JOIN Usuarios u ON v.UserId = u.UserId
                    WHERE CAST(v.Fecha AS DATE) BETWEEN @fechaInicio AND @fechaFin
                    ORDER BY v.Fecha DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteVenta
                            {
                                VentaId = dr["VentaId"] != DBNull.Value ? Convert.ToInt32(dr["VentaId"]) : 0,
                                Fecha = dr["Fecha"] != DBNull.Value ? Convert.ToDateTime(dr["Fecha"]) : DateTime.MinValue,
                                Cliente = dr["Cliente"]?.ToString() ?? string.Empty,
                                Usuario = dr["Usuario"]?.ToString() ?? string.Empty,
                                Total = dr["Total"] != DBNull.Value ? Convert.ToDecimal(dr["Total"]) : 0m
                            });
                        }
                    }
                }
            }

            return lista;
        }

        // Productos más vendidos
        public List<ReporteVenta> ObtenerProductosMasVendidos(DateTime fechaInicio, DateTime fechaFin)
        {
            var lista = new List<ReporteVenta>();

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
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteVenta
                            {
                                Producto = dr["Producto"]?.ToString() ?? string.Empty,
                                CantidadVendida = dr["TotalVendido"] != DBNull.Value ? Convert.ToInt32(dr["TotalVendido"]) : 0,
                                TotalRecaudado = dr["TotalRecaudado"] != DBNull.Value ? Convert.ToDecimal(dr["TotalRecaudado"]) : 0m
                            });
                        }
                    }
                }
            }

            return lista;
        }

        // Total ventas por usuario
        public List<ReporteVenta> ObtenerTotalVentasPorUsuario(DateTime fechaInicio, DateTime fechaFin)
        {
            var lista = new List<ReporteVenta>();

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
                        while (dr.Read())
                        {
                            lista.Add(new ReporteVenta
                            {
                                Usuario = dr["Usuario"]?.ToString() ?? string.Empty,
                                TotalVentas = dr["TotalVentas"] != DBNull.Value ? Convert.ToInt32(dr["TotalVentas"]) : 0,
                                TotalRecaudado = dr["TotalRecaudado"] != DBNull.Value ? Convert.ToDecimal(dr["TotalRecaudado"]) : 0m
                            });
                        }
                    }
                }
            }

            return lista;
        }
        public List<DetalleVenta> ObtenerDetalleVenta(int ventaId)
        {
            var lista = new List<DetalleVenta>();

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
                v.Total AS TotalVenta,
                u.NombreCompleto AS NombreUsuario
            FROM DetalleVenta d
            INNER JOIN Productos p ON d.ProductoId = p.ProductoId
            INNER JOIN Ventas v ON d.VentaId = v.VentaId
            INNER JOIN Clientes c ON v.ClienteId = c.ClienteId
            INNER JOIN Usuarios u ON v.UserId = u.UserId   -- ✅ unión con la tabla de usuarios
            WHERE d.VentaId = @ventaId", conn))
                {
                    cmd.Parameters.AddWithValue("@ventaId", ventaId);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DetalleVenta
                            {
                                DetalleId = Convert.ToInt32(dr["DetalleId"]),
                                VentaId = Convert.ToInt32(dr["VentaId"]),
                                ProductoId = Convert.ToInt32(dr["ProductoId"]),
                                NombreProducto = dr["ProductoNombre"]?.ToString(),
                                NombreUsuario = dr["NombreUsuario"]?.ToString(),  // ✅ ahora sí existe
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

            return lista;
        }

        // 🔹 Listar clientes para filtros de reportes
        public List<Cliente> ObtenerClientes()
        {
            var lista = new List<Cliente>();

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                string query = "SELECT ClienteId, Nombre FROM Clientes ORDER BY Nombre";

                using (var cmd = new SqlCommand(query, conn))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Cliente
                        {
                            ClienteId = Convert.ToInt32(dr["ClienteId"]),
                            Nombre = dr["Nombre"]?.ToString() ?? string.Empty
                        });
                    }
                }
            }

            return lista;
        }

        // 🔹 Listar vendedores para filtros de reportes
        public List<Usuario> ObtenerVendedores()
        {
            var lista = new List<Usuario>();

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();

                
                string query = @"
            SELECT u.UserId, u.NombreCompleto 
            FROM Usuarios u
            INNER JOIN Roles r ON u.RoleId = r.RoleId
            WHERE r.Nombre = 'Vendedor'
            ORDER BY u.NombreCompleto";

                using (var cmd = new SqlCommand(query, conn))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Usuario
                        {
                            UserId = Convert.ToInt32(dr["UserId"]),
                            NombreCompleto = dr["NombreCompleto"]?.ToString() ?? string.Empty
                        });
                    }
                }
            }

            return lista;
        }


        // 🔹 Obtener ventas filtradas por fecha, cliente y vendedor
        // 🔹 Obtener ventas filtradas por fecha, cliente y vendedor
        public List<ReporteVenta> ObtenerVentasFiltradas(
            DateTime? fechaInicio,
            DateTime? fechaFin,
            int? clienteId = null,
            int? vendedorId = null,
            decimal? totalMin = null,
            decimal? totalMax = null)
        {
            var lista = new List<ReporteVenta>();

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT 
                v.VentaId, 
                v.Fecha, 
                c.Nombre AS Cliente, 
                u.NombreCompleto AS Vendedor, 
                v.Total
            FROM Ventas v
            INNER JOIN Clientes c ON v.ClienteId = c.ClienteId
            INNER JOIN Usuarios u ON v.UserId = u.UserId
            WHERE 
                (@fechaInicio IS NULL OR v.Fecha >= @fechaInicio)
                AND (@fechaFin IS NULL OR v.Fecha <= @fechaFin)
                AND (@clienteId IS NULL OR v.ClienteId = @clienteId)
                AND (@vendedorId IS NULL OR v.UserId = @vendedorId)
                AND (@totalMin IS NULL OR v.Total >= @totalMin)
                AND (@totalMax IS NULL OR v.Total <= @totalMax)
            ORDER BY v.Fecha DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    // 🔧 Aquí está el cambio importante:
                    cmd.Parameters.AddWithValue("@fechaInicio", (object)fechaInicio ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@fechaFin", (object)fechaFin ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@clienteId", (object)clienteId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@vendedorId", (object)vendedorId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@totalMin", (object)totalMin ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@totalMax", (object)totalMax ?? DBNull.Value);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteVenta
                            {
                                VentaId = dr["VentaId"] != DBNull.Value ? Convert.ToInt32(dr["VentaId"]) : 0,
                                Fecha = dr["Fecha"] != DBNull.Value ? Convert.ToDateTime(dr["Fecha"]) : DateTime.MinValue,
                                Cliente = dr["Cliente"]?.ToString() ?? string.Empty,
                                Usuario = dr["Vendedor"]?.ToString() ?? string.Empty,
                                Total = dr["Total"] != DBNull.Value ? Convert.ToDecimal(dr["Total"]) : 0m
                            });
                        }
                    }
                }
            }

            return lista;
        }

        // 🔹 Reporte mensual por vendedor
        public List<ReporteVenta> ObtenerReporteMensualPorVendedor(int anio, int mes)
        {
            var lista = new List<ReporteVenta>();
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT 
                u.NombreCompleto AS Vendedor,
                COUNT(v.VentaId) AS TotalVentas,
                SUM(v.Total) AS TotalRecaudado
            FROM Ventas v
            INNER JOIN Usuarios u ON v.UserId = u.UserId
            WHERE YEAR(v.Fecha) = @anio AND MONTH(v.Fecha) = @mes
            GROUP BY u.NombreCompleto
            ORDER BY TotalRecaudado DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@anio", anio);
                    cmd.Parameters.AddWithValue("@mes", mes);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteVenta
                            {
                                Usuario = dr["Vendedor"]?.ToString() ?? "",
                                TotalVentas = Convert.ToInt32(dr["TotalVentas"]),
                                TotalRecaudado = Convert.ToDecimal(dr["TotalRecaudado"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // 🔹 Reporte mensual por cliente
        public List<ReporteVenta> ObtenerReporteMensualPorCliente(int anio, int mes)
        {
            var lista = new List<ReporteVenta>();
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT 
                c.Nombre AS Cliente,
                COUNT(v.VentaId) AS TotalVentas,
                SUM(v.Total) AS TotalRecaudado
            FROM Ventas v
            INNER JOIN Clientes c ON v.ClienteId = c.ClienteId
            WHERE YEAR(v.Fecha) = @anio AND MONTH(v.Fecha) = @mes
            GROUP BY c.Nombre
            ORDER BY TotalRecaudado DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@anio", anio);
                    cmd.Parameters.AddWithValue("@mes", mes);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteVenta
                            {
                                Cliente = dr["Cliente"]?.ToString() ?? "",
                                TotalVentas = Convert.ToInt32(dr["TotalVentas"]),
                                TotalRecaudado = Convert.ToDecimal(dr["TotalRecaudado"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // 🔹 Reporte mensual por producto
        public List<ReporteVenta> ObtenerReporteMensualPorProducto(int anio, int mes)
        {
            var lista = new List<ReporteVenta>();
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
            WHERE YEAR(v.Fecha) = @anio AND MONTH(v.Fecha) = @mes
            GROUP BY p.Nombre
            ORDER BY TotalVendido DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@anio", anio);
                    cmd.Parameters.AddWithValue("@mes", mes);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteVenta
                            {
                                Producto = dr["Producto"]?.ToString() ?? "",
                                CantidadVendida = Convert.ToInt32(dr["TotalVendido"]),
                                TotalRecaudado = Convert.ToDecimal(dr["TotalRecaudado"])
                            });
                        }
                    }
                }
            }
            return lista;
        }




    }
}
