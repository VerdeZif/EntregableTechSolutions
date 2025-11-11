using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Entidad.Models;
using Datos.Database;

namespace Datos.Repositorio
{
    public class VentaDatos
    {
        // Registrar una venta (usa el procedimiento almacenado sp_RegistrarVenta)
        public (int ventaId, string mensaje) RegistrarVenta(int userId, int clienteId, decimal total, List<DetalleVenta> detalles)
        {
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();

                using (var cmd = new SqlCommand("sp_RegistrarVenta", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros principales
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@ClienteId", clienteId);
                    cmd.Parameters.AddWithValue("@Total", total);

                    // Crear DataTable para el parámetro tipo TVP (TVP_DetalleVenta)
                    DataTable tvp = new DataTable();
                    tvp.Columns.Add("ProductoId", typeof(int));
                    tvp.Columns.Add("Cantidad", typeof(int));
                    tvp.Columns.Add("PrecioUnitario", typeof(decimal));

                    foreach (var d in detalles)
                    {
                        tvp.Rows.Add(d.ProductoId, d.Cantidad, d.PrecioUnitario);
                    }

                    var paramDetalle = cmd.Parameters.AddWithValue("@Detalle", tvp);
                    paramDetalle.SqlDbType = SqlDbType.Structured;
                    paramDetalle.TypeName = "TVP_DetalleVenta";

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            // Intentamos obtener VentaId
                            try
                            {
                                int ventaId = dr.GetInt32(dr.GetOrdinal("VentaId"));
                                return (ventaId, "Venta registrada correctamente");
                            }
                            catch
                            {
                                // Si no existe VentaId, revisamos ErrorMessage
                                try
                                {
                                    string error = dr.GetString(dr.GetOrdinal("ErrorMessage"));
                                    return (0, error);
                                }
                                catch
                                {
                                    return (0, "Error desconocido al registrar la venta");
                                }
                            }
                        }
                    }

                    return (0, "Error desconocido al registrar la venta");
                }
            }
        } // <- cierre del método RegistrarVenta

        // Listar ventas registradas
        public List<Venta> ListarVentas()
        {
            var lista = new List<Venta>();

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT 
                        v.VentaId, 
                        v.Fecha, 
                        v.Total,
                        v.ClienteId,
                        v.UserId,
                        c.Nombre AS ClienteNombre,
                        u.NombreCompleto AS UsuarioNombre
                    FROM Ventas v
                    INNER JOIN Clientes c ON v.ClienteId = c.ClienteId
                    INNER JOIN Usuarios u ON v.UserId = u.UserId
                    ORDER BY v.VentaId DESC", conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Venta
                            {
                                VentaId = Convert.ToInt32(dr["VentaId"]),
                                Fecha = Convert.ToDateTime(dr["Fecha"]),
                                Total = Convert.ToDecimal(dr["Total"]),
                                ClienteId = Convert.ToInt32(dr["ClienteId"]),
                                UserId = Convert.ToInt32(dr["UserId"]),
                                NombreCliente = dr["ClienteNombre"]?.ToString() ?? string.Empty,
                                NombreUsuario = dr["UsuarioNombre"]?.ToString() ?? string.Empty
                            });
                        }
                    }
                }
            }

            return lista;
        }

        // Listar detalle de una venta
        public List<DetalleVenta> ListarDetalle(int ventaId)
        {
            var lista = new List<DetalleVenta>();

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT 
                        d.DetalleId, 
                        d.ProductoId, 
                        p.Nombre AS ProductoNombre,
                        d.Cantidad, 
                        d.PrecioUnitario, 
                        (d.Cantidad * d.PrecioUnitario) AS Subtotal
                    FROM DetalleVenta d
                    INNER JOIN Productos p ON d.ProductoId = p.ProductoId
                    WHERE d.VentaId = @ventaId", conn))
                {
                    cmd.Parameters.AddWithValue("@ventaId", ventaId);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DetalleVenta
                            {
                                DetalleId = dr["DetalleId"] != DBNull.Value ? Convert.ToInt32(dr["DetalleId"]) : 0,
                                ProductoId = dr["ProductoId"] != DBNull.Value ? Convert.ToInt32(dr["ProductoId"]) : 0,
                                NombreProducto = dr["ProductoNombre"] != DBNull.Value ? dr["ProductoNombre"].ToString()! : string.Empty,
                                Cantidad = dr["Cantidad"] != DBNull.Value ? Convert.ToInt32(dr["Cantidad"]) : 0,
                                PrecioUnitario = dr["PrecioUnitario"] != DBNull.Value ? Convert.ToDecimal(dr["PrecioUnitario"]) : 0m
                            });
                        }
                    }
                }
            }

            return lista;
        }

        // Listar compras por cliente
        public List<dynamic> ListarComprasPorCliente(int clienteId)
        {
            var lista = new List<dynamic>();

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT v.VentaId, v.Fecha, v.Total
                    FROM Ventas v
                    WHERE v.ClienteId = @clienteId
                    ORDER BY v.Fecha DESC", conn))
                {
                    cmd.Parameters.Add("@clienteId", SqlDbType.Int).Value = clienteId;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new
                            {
                                VentaId = Convert.ToInt32(dr["VentaId"]),
                                Fecha = Convert.ToDateTime(dr["Fecha"]).ToString("dd/MM/yyyy HH:mm"),
                                Total = Convert.ToDecimal(dr["Total"])
                            });
                        }
                    }
                }
            }

            return lista;
        }
    }
}
