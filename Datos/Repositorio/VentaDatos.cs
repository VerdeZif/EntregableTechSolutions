using System.Data;
using Microsoft.Data.SqlClient;
using Entidad.Models;
using Datos.Database;

namespace Datos.Repositorio
{
    public class VentaDatos
    {
        // ==============================
        // REGISTRAR UNA VENTA
        // Usa el procedimiento almacenado sp_RegistrarVenta
        // ==============================
        public (int ventaId, string mensaje) RegistrarVenta(int userId, int clienteId, decimal total, List<DetalleVenta> detalles)
        {
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open(); // Abrir conexión a BD

                using (var cmd = new SqlCommand("sp_RegistrarVenta", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure; // Indicar que es SP

                    // Parámetros principales de la venta
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@ClienteId", clienteId);
                    cmd.Parameters.AddWithValue("@Total", total);

                    // Crear un DataTable para enviar los detalles como TVP
                    DataTable tvp = new DataTable();
                    tvp.Columns.Add("ProductoId", typeof(int));
                    tvp.Columns.Add("Cantidad", typeof(int));
                    tvp.Columns.Add("PrecioUnitario", typeof(decimal));

                    // Agregar cada detalle de venta al DataTable
                    foreach (var d in detalles)
                    {
                        tvp.Rows.Add(d.ProductoId, d.Cantidad, d.PrecioUnitario);
                    }

                    // Asignar DataTable como parámetro estructurado
                    var paramDetalle = cmd.Parameters.AddWithValue("@Detalle", tvp);
                    paramDetalle.SqlDbType = SqlDbType.Structured;
                    paramDetalle.TypeName = "TVP_DetalleVenta";

                    // Ejecutar SP y leer resultados
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            try
                            {
                                // Intentamos obtener VentaId generado
                                int ventaId = dr.GetInt32(dr.GetOrdinal("VentaId"));
                                return (ventaId, "Venta registrada correctamente");
                            }
                            catch
                            {
                                // Si no existe VentaId, intentamos obtener ErrorMessage
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

        // ==============================
        // LISTAR VENTAS REGISTRADAS
        // ==============================
        public List<Venta> ListarVentas()
        {
            var lista = new List<Venta>(); // Lista para almacenar resultados

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();

                // Consulta para obtener ventas con datos del cliente y usuario
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
                            // Mapear datos de cada venta al objeto Venta
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

            return lista; // Retorna todas las ventas
        }

        // ==============================
        // LISTAR DETALLE DE UNA VENTA
        // ==============================
        public List<DetalleVenta> ListarDetalle(int ventaId)
        {
            var lista = new List<DetalleVenta>(); // Lista para los detalles

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();

                // Consulta para obtener los detalles de la venta
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
                            // Mapear detalle de venta al objeto DetalleVenta
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

            return lista; // Retorna lista de detalles de la venta
        }

        // ==============================
        // LISTAR COMPRAS POR CLIENTE
        // ==============================
        public List<dynamic> ListarComprasPorCliente(int clienteId)
        {
            var lista = new List<dynamic>(); // Lista dinámica para mayor flexibilidad

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();

                // Consulta de todas las ventas de un cliente
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
                                Fecha = Convert.ToDateTime(dr["Fecha"]).ToString("dd/MM/yyyy HH:mm"), // Formato legible
                                Total = Convert.ToDecimal(dr["Total"])
                            });
                        }
                    }
                }
            }

            return lista; // Retorna compras filtradas por cliente
        }
    }
}