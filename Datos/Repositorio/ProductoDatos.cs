using Entidad.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Datos.Database;

namespace Datos.Repositorio
{
    public class ProductoDatos
    {
        // Listar todos los productos
        public List<Producto> Listar()
        {
            var lista = new List<Producto>();

            using (var conn = ConexionBD.Instance.GetConnection())

            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Productos ORDER BY ProductoId DESC", conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Producto
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

            return lista;
        }

        // Obtener un producto por ID
        public Producto? ObtenerPorId(int id)
        {
            Producto? producto = null;

            using (var conn = ConexionBD.Instance.GetConnection())

            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Productos WHERE ProductoId = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            producto = new Producto
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

            return producto;
        }

        // Registrar nuevo producto
        public bool Registrar(Producto producto)
        {
            using (var conn = ConexionBD.Instance.GetConnection())

            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, Imagen)
                    VALUES (@nombre, @descripcion, @precio, @stock, @imagen)", conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", (object?)producto.Descripcion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@imagen", (object?)producto.Imagen ?? DBNull.Value);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Actualizar producto
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
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", (object?)producto.Descripcion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@imagen", (object?)producto.Imagen ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", producto.ProductoId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Eliminar producto
        public bool Eliminar(int id)
        {
            using (var conn = ConexionBD.Instance.GetConnection())

            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Productos WHERE ProductoId = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
