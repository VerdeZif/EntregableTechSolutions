using Datos.Database; // Conexión a la base de datos (Singleton)
using Entidad.Models; // Modelos: ReporteVenta, DetalleVenta, Cliente, Usuario
using Microsoft.Data.SqlClient; // SQL Server

namespace Datos.Repositorio
{
    // Clase para manejar todas las operaciones de reportes
    public class ReporteDatos
    {
        // =============================
        // VENTAS POR FECHA
        // =============================
        public List<ReporteVenta> ObtenerVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            var lista = new List<ReporteVenta>(); // Lista donde se guardarán las ventas obtenidas

            using (var conn = ConexionBD.Instance.GetConnection()) // Obtener conexión
            {
                conn.Open(); // Abrir conexión
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
                    // Asignamos valores a los parámetros de la consulta
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin);

                    using (var dr = cmd.ExecuteReader()) // Ejecutamos la consulta
                    {
                        while (dr.Read()) // Leer cada fila del resultado
                        {
                            // Mapear los datos de la fila a un objeto ReporteVenta
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

            return lista; // Devolver la lista completa de ventas
        }

        // =============================
        // PRODUCTOS MÁS VENDIDOS
        // =============================
        public List<ReporteVenta> ObtenerProductosMasVendidos(DateTime fechaInicio, DateTime fechaFin)
        {
            var lista = new List<ReporteVenta>(); // Lista donde se guardarán los productos y cantidades

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
                        while (dr.Read()) // Mapear cada fila a ReporteVenta
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

            return lista; // Devolver productos más vendidos
        }

        // =============================
        // TOTAL VENTAS POR USUARIO
        // =============================
        public List<ReporteVenta> ObtenerTotalVentasPorUsuario(DateTime fechaInicio, DateTime fechaFin)
        {
            var lista = new List<ReporteVenta>(); // Lista para acumular ventas por cada usuario

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
                                TotalVentas = dr["TotalVentas"] != DBNull.Value ? Convert.ToInt32(dr["TotalVentas"]) : 0,
                                TotalRecaudado = dr["TotalRecaudado"] != DBNull.Value ? Convert.ToDecimal(dr["TotalRecaudado"]) : 0m
                            });
                        }
                    }
                }
            }

            return lista; // Retorna la lista con ventas por usuario
        }

        // =============================
        // DETALLE DE UNA VENTA
        // =============================
        public List<DetalleVenta> ObtenerDetalleVenta(int ventaId)
        {
            var lista = new List<DetalleVenta>(); // Lista para almacenar el detalle de los productos de la venta

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
                    INNER JOIN Usuarios u ON v.UserId = u.UserId
                    WHERE d.VentaId = @ventaId", conn))
                {
                    cmd.Parameters.AddWithValue("@ventaId", ventaId);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read()) // Mapear cada detalle de producto a DetalleVenta
                        {
                            lista.Add(new DetalleVenta
                            {
                                DetalleId = Convert.ToInt32(dr["DetalleId"]),
                                VentaId = Convert.ToInt32(dr["VentaId"]),
                                ProductoId = Convert.ToInt32(dr["ProductoId"]),
                                NombreProducto = dr["ProductoNombre"]?.ToString(),
                                NombreUsuario = dr["NombreUsuario"]?.ToString(),
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

            return lista; // Devuelve todos los productos de la venta
        }

        // =============================
        // LISTAR CLIENTES PARA FILTROS
        // =============================
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
                    while (dr.Read()) // Mapear cada cliente a la lista
                    {
                        lista.Add(new Cliente
                        {
                            ClienteId = Convert.ToInt32(dr["ClienteId"]),
                            Nombre = dr["Nombre"]?.ToString() ?? string.Empty
                        });
                    }
                }
            }

            return lista; // Retorna la lista de clientes
        }

        // =============================
        // LISTAR VENDEDORES PARA FILTROS
        // =============================
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
                    while (dr.Read()) // Mapear cada vendedor a Usuario
                    {
                        lista.Add(new Usuario
                        {
                            UserId = Convert.ToInt32(dr["UserId"]),
                            NombreCompleto = dr["NombreCompleto"]?.ToString() ?? string.Empty
                        });
                    }
                }
            }

            return lista; // Retorna la lista de vendedores
        }

        // =============================
        // OBTENER VENTAS FILTRADAS POR VARIOS CRITERIOS
        // =============================
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
                    // Asignamos parámetros con posibilidad de ser nulos
                    cmd.Parameters.AddWithValue("@fechaInicio", (object)fechaInicio ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@fechaFin", (object)fechaFin ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@clienteId", (object)clienteId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@vendedorId", (object)vendedorId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@totalMin", (object)totalMin ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@totalMax", (object)totalMax ?? DBNull.Value);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read()) // Mapear cada venta filtrada
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

        // =============================
        // REPORTE MENSUAL POR VENDEDOR
        // =============================
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
                        while (dr.Read()) // Mapear ventas por vendedor
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

        // =============================
        // REPORTE MENSUAL POR CLIENTE
        // =============================
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
                        while (dr.Read()) // Mapear ventas por cliente
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

        // =============================
        // REPORTE MENSUAL POR PRODUCTO
        // =============================
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
                        while (dr.Read()) // Mapear ventas por producto
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
