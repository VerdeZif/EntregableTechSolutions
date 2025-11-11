using Datos.Database;
using Entidad.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Datos.Repositorio
{
    public class ClienteDatos
    {
        // =============================
        // LISTAR TODOS LOS CLIENTES
        // =============================
        public List<Cliente> Listar()
        {
            var lista = new List<Cliente>();

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT ClienteId, Nombre, Correo, Telefono, Direccion, Foto, UserId AS UsuarioId
                    FROM Clientes
                    ORDER BY ClienteId DESC", conn))
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
                                Foto = dr["Foto"] as byte[],
                                UsuarioId = Convert.ToInt32(dr["UsuarioId"])
                            });
                        }
                    }
                }
            }

            return lista;
        }

        // =============================
        // OBTENER CLIENTE POR ID
        // =============================
        public Cliente? ObtenerPorId(int id)
        {
            Cliente? cliente = null;

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT ClienteId, Nombre, Correo, Telefono, Direccion, Foto, UserId AS UsuarioId
                    FROM Clientes
                    WHERE ClienteId = @id", conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

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
                                Foto = dr["Foto"] as byte[],
                                UsuarioId = Convert.ToInt32(dr["UsuarioId"])
                            };
                        }
                    }
                }
            }

            return cliente;
        }

        // =============================
        // REGISTRAR NUEVO CLIENTE
        // =============================
        public bool Registrar(Cliente cliente)
        {
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Clientes (Nombre, Correo, Telefono, Direccion, Foto, UserId)
                    VALUES (@nombre, @correo, @telefono, @direccion, @foto, @usuarioId)", conn))
                {
                    cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 100).Value = cliente.Nombre;
                    cmd.Parameters.Add("@correo", SqlDbType.NVarChar, 100).Value = (object?)cliente.Correo ?? DBNull.Value;
                    cmd.Parameters.Add("@telefono", SqlDbType.NVarChar, 20).Value = (object?)cliente.Telefono ?? DBNull.Value;
                    cmd.Parameters.Add("@direccion", SqlDbType.NVarChar, 200).Value = (object?)cliente.Direccion ?? DBNull.Value;

                    var parametroFoto = new SqlParameter("@foto", SqlDbType.VarBinary, -1);
                    parametroFoto.Value = (object?)cliente.Foto ?? DBNull.Value;
                    cmd.Parameters.Add(parametroFoto);

                    cmd.Parameters.Add("@usuarioId", SqlDbType.Int).Value = cliente.UsuarioId;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // =============================
        // ACTUALIZAR CLIENTE
        // =============================
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
                        Foto = @foto,
                        UserId = @usuarioId
                    WHERE ClienteId = @id", conn))
                {
                    cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 100).Value = cliente.Nombre;
                    cmd.Parameters.Add("@correo", SqlDbType.NVarChar, 100).Value = (object?)cliente.Correo ?? DBNull.Value;
                    cmd.Parameters.Add("@telefono", SqlDbType.NVarChar, 20).Value = (object?)cliente.Telefono ?? DBNull.Value;
                    cmd.Parameters.Add("@direccion", SqlDbType.NVarChar, 200).Value = (object?)cliente.Direccion ?? DBNull.Value;

                    var parametroFoto = new SqlParameter("@foto", SqlDbType.VarBinary, -1);
                    parametroFoto.Value = (object?)cliente.Foto ?? DBNull.Value;
                    cmd.Parameters.Add(parametroFoto);

                    cmd.Parameters.Add("@usuarioId", SqlDbType.Int).Value = cliente.UsuarioId;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = cliente.ClienteId;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // =============================
        // ELIMINAR CLIENTE
        // =============================
        public bool Eliminar(int id)
        {
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Clientes WHERE ClienteId = @id", conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // =============================
        // OBTENER CLIENTE POR USERNAME
        // =============================
        public Cliente? ObtenerNombrePorUsuario(string username)
        {
            Cliente? cliente = null;

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT c.ClienteId, c.Nombre, c.Correo, c.Telefono, c.Direccion, c.Foto, c.UserId AS UsuarioId
                    FROM Clientes c
                    INNER JOIN Usuarios u ON c.UserId = u.UserId
                    WHERE u.Username = @username", conn))
                {
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;

                    using (var dr = cmd.ExecuteReader())
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
                                Foto = dr["Foto"] as byte[],
                                UsuarioId = Convert.ToInt32(dr["UsuarioId"])
                            };
                        }
                    }
                }
            }

            return cliente;
        }
    }
}
