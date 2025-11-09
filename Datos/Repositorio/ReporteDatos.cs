using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Entidad.Models;
using Datos.Database;

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
                v.Total AS TotalVenta
            FROM DetalleVenta d
            INNER JOIN Productos p ON d.ProductoId = p.ProductoId
            INNER JOIN Ventas v ON d.VentaId = v.VentaId
            INNER JOIN Clientes c ON v.ClienteId = c.ClienteId
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
    }
}
