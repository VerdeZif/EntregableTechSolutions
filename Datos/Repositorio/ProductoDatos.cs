using Datos.Database; // Conexión a BD
using Entidad.Models; // Modelo Producto
using Microsoft.Data.SqlClient; // SQL Server
using System.Data; // Tipos ADO.NET

namespace Datos.Repositorio
{
    // Clase para operaciones CRUD de productos
    public class ProductoDatos
    {
        // =============================
        // LISTAR TODOS LOS PRODUCTOS
        // =============================
        public List<Producto> Listar()
        {
            var lista = new List<Producto>(); // Lista para guardar los productos

            using (var conn = ConexionBD.Instance.GetConnection()) // Obtener conexión
            {
                conn.Open(); // Abrir conexión
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Productos ORDER BY ProductoId DESC", conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader()) // Ejecutar consulta
                    {
                        while (dr.Read()) // Recorrer cada fila
                        {
                            lista.Add(new Producto // Mapear datos a objeto Producto y agregar a la lista
                            {
                                ProductoId = Convert.ToInt32(dr["ProductoId"]),
                                Nombre = dr["Nombre"].ToString()!,
                                Descripcion = dr["Descripcion"]?.ToString(),
                                Precio = Convert.ToDecimal(dr["Precio"]),
                                Stock = Convert.ToInt32(dr["Stock"]),
                                Imagen = dr["Imagen"] as byte[]
                            });
                        }
                    }
                }
            }

            return lista; // Devolver lista de productos
        }

        // =============================
        // OBTENER UN PRODUCTO POR ID
        // =============================
        public Producto? ObtenerPorId(int id)
        {
            Producto? producto = null; // Variable que puede ser null si no se encuentra

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Productos WHERE ProductoId = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id); // Parámetro ID

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read()) // Si se encuentra el producto
                        {
                            producto = new Producto // Mapear fila a objeto Producto
                            {
                                ProductoId = Convert.ToInt32(dr["ProductoId"]),
                                Nombre = dr["Nombre"].ToString()!,
                                Descripcion = dr["Descripcion"]?.ToString(),
                                Precio = Convert.ToDecimal(dr["Precio"]),
                                Stock = Convert.ToInt32(dr["Stock"]),
                                Imagen = dr["Imagen"] as byte[]
                            };
                        }
                    }
                }
            }

            return producto; // Devolver producto o null
        }

        // =============================
        // REGISTRAR NUEVO PRODUCTO
        // =============================
        public bool Registrar(Producto producto)
        {
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, Imagen)
                    VALUES (@nombre, @descripcion, @precio, @stock, @imagen)", conn))
                {
                    // Asignar parámetros de forma segura
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", (object?)producto.Descripcion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@stock", producto.Stock);
                    var paramImagen = cmd.Parameters.Add("@imagen", SqlDbType.VarBinary, -1);
                    paramImagen.Value = (object?)producto.Imagen ?? DBNull.Value;

                    return cmd.ExecuteNonQuery() > 0; // Ejecutar e indicar si se insertó
                }
            }
        }

        // =============================
        // ACTUALIZAR PRODUCTO
        // =============================
        public bool Actualizar(Producto producto)
        {
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"
                    UPDATE Productos
                    SET Nombre = @nombre,
                        Descripcion = @descripcion,
                        Precio = @precio,
                        Stock = @stock,
                        Imagen = @imagen
                    WHERE ProductoId = @id", conn))
                {
                    // Asignar parámetros de forma segura
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", (object?)producto.Descripcion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@stock", producto.Stock);
                    var paramImagen = cmd.Parameters.Add("@imagen", SqlDbType.VarBinary, -1);
                    paramImagen.Value = (object?)producto.Imagen ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@id", producto.ProductoId);

                    return cmd.ExecuteNonQuery() > 0; // Ejecutar e indicar si se actualizó
                }
            }
        }

        // =============================
        // ELIMINAR PRODUCTO
        // =============================
        public bool Eliminar(int id)
        {
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Productos WHERE ProductoId = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id); // Parámetro ID
                    return cmd.ExecuteNonQuery() > 0; // Ejecutar e indicar si se eliminó
                }
            }
        }
    }
}
