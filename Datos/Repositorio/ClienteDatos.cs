using Entidad.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Datos.Database;

namespace Datos.Repositorio
{
    public class ClienteDatos
    {
        // Listar todos los clientes
        public List<Cliente> Listar()
        {
            var lista = new List<Cliente>();

            using (var conn = ConexionBD.Instance.GetConnection())

            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Clientes ORDER BY ClienteId DESC", conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente
                            {
                                ClienteId = Convert.ToInt32(dr["ClienteId"]),
                                Nombre = dr["Nombre"].ToString()!,
                                Correo = dr["Correo"]?.ToString(),
                                Telefono = dr["Telefono"]?.ToString(),
                                Direccion = dr["Direccion"]?.ToString(),
                                Foto = dr["Foto"] as byte[]
                            });
                        }
                    }
                }
            }

            return lista;
        }

        // Obtener un cliente por su ID
        public Cliente? ObtenerPorId(int id)
        {
            Cliente? cliente = null;

            using (var conn = ConexionBD.Instance.GetConnection())

            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Clientes WHERE ClienteId = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            cliente = new Cliente
                            {
                                ClienteId = Convert.ToInt32(dr["ClienteId"]),
                                Nombre = dr["Nombre"].ToString()!,
                                Correo = dr["Correo"]?.ToString(),
                                Telefono = dr["Telefono"]?.ToString(),
                                Direccion = dr["Direccion"]?.ToString(),
                                Foto = dr["Foto"] as byte[]
                            };
                        }
                    }
                }
            }

            return cliente;
        }

        // Registrar nuevo cliente
        public bool Registrar(Cliente cliente)
        {
            using (var conn = ConexionBD.Instance.GetConnection())

            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Clientes (Nombre, Correo, Telefono, Direccion, Foto)
                    VALUES (@nombre, @correo, @telefono, @direccion, @foto)", conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@correo", (object?)cliente.Correo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@telefono", (object?)cliente.Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@direccion", (object?)cliente.Direccion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@foto", (object?)cliente.Foto ?? DBNull.Value);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Actualizar cliente
        public bool Actualizar(Cliente cliente)
        {
            using (var conn = ConexionBD.Instance.GetConnection())

            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"
                    UPDATE Clientes
                    SET Nombre = @nombre,
                        Correo = @correo,
                        Telefono = @telefono,
                        Direccion = @direccion,
                        Foto = @foto
                    WHERE ClienteId = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@correo", (object?)cliente.Correo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@telefono", (object?)cliente.Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@direccion", (object?)cliente.Direccion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@foto", (object?)cliente.Foto ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", cliente.ClienteId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Eliminar cliente
        public bool Eliminar(int id)
        {
            using (var conn = ConexionBD.Instance.GetConnection())

            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Clientes WHERE ClienteId = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
