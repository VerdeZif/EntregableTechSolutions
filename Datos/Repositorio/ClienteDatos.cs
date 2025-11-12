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
            SELECT 
                c.ClienteId,
                c.UserId,
                u.Username,
                u.PasswordHash,
                c.Nombre,
                c.Correo,
                c.Telefono,
                c.Direccion,
                c.Foto
            FROM Clientes c
            INNER JOIN Usuarios u ON c.UserId = u.UserId
            WHERE u.RoleId = 3  -- Solo los usuarios con rol 'Cliente'
            ORDER BY c.ClienteId DESC", conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente
                            {
                                ClienteId = Convert.ToInt32(dr["ClienteId"]),
                                UserId = Convert.ToInt32(dr["UserId"]),
                                Username = dr["Username"].ToString()!,
                                PasswordHash = dr["PasswordHash"].ToString()!,
                                Nombre = dr["Nombre"].ToString()!,
                                Correo = dr["Correo"]?.ToString(),
                                Telefono = dr["Telefono"]?.ToString(),
                                Direccion = dr["Direccion"]?.ToString(),
                                Foto = dr["Foto"] == DBNull.Value ? null : (byte[])dr["Foto"]
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
                                UserId = Convert.ToInt32(dr["UsuarioId"])
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

                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1️⃣ Crear el usuario asociado al cliente (con foto)
                        var cmdUsuario = new SqlCommand(@"
                    INSERT INTO Usuarios (Username, PasswordHash, NombreCompleto, FotoPerfil, RoleId)
                    OUTPUT INSERTED.UserId
                    VALUES (@Username, @PasswordHash, @NombreCompleto, @FotoPerfil, @RoleId);", conn, trans);

                        cmdUsuario.Parameters.AddWithValue("@Username", cliente.Username);
                        cmdUsuario.Parameters.AddWithValue("@PasswordHash", cliente.PasswordHash);
                        cmdUsuario.Parameters.AddWithValue("@NombreCompleto", cliente.Nombre);
                        cmdUsuario.Parameters.AddWithValue("@RoleId", 3); // Rol "Cliente"

                        var paramFotoPerfil = cmdUsuario.Parameters.Add("@FotoPerfil", SqlDbType.VarBinary, -1);
                        paramFotoPerfil.Value = (object?)cliente.Foto ?? DBNull.Value;

                        int nuevoUserId = Convert.ToInt32(cmdUsuario.ExecuteScalar());

                        // 2️⃣ Crear el cliente vinculado al usuario recién creado
                        var cmdCliente = new SqlCommand(@"
                    INSERT INTO Clientes (UserId, Nombre, Correo, Telefono, Direccion, Foto)
                    VALUES (@UserId, @Nombre, @Correo, @Telefono, @Direccion, @Foto);", conn, trans);

                        cmdCliente.Parameters.AddWithValue("@UserId", nuevoUserId);
                        cmdCliente.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                        cmdCliente.Parameters.AddWithValue("@Correo", cliente.Correo ?? (object)DBNull.Value);
                        cmdCliente.Parameters.AddWithValue("@Telefono", cliente.Telefono ?? (object)DBNull.Value);
                        cmdCliente.Parameters.AddWithValue("@Direccion", cliente.Direccion ?? (object)DBNull.Value);

                        var paramFoto = cmdCliente.Parameters.Add("@Foto", SqlDbType.VarBinary, -1);
                        paramFoto.Value = (object?)cliente.Foto ?? DBNull.Value;

                        cmdCliente.ExecuteNonQuery();

                        // ✅ Confirmar ambas inserciones
                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        // ❌ Deshacer todo si algo falla
                        trans.Rollback();
                        throw;
                    }
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

                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1️⃣ Actualizar datos del usuario (incluyendo la foto)
                        var cmdUsuario = new SqlCommand(@"
                    UPDATE Usuarios
                    SET Username = @Username,
                        PasswordHash = @PasswordHash,
                        NombreCompleto = @NombreCompleto,
                        FotoPerfil = @FotoPerfil
                    WHERE UserId = @UserId;", conn, trans);

                        cmdUsuario.Parameters.AddWithValue("@UserId", cliente.UserId);
                        cmdUsuario.Parameters.AddWithValue("@Username", cliente.Username);
                        cmdUsuario.Parameters.AddWithValue("@PasswordHash", cliente.PasswordHash);
                        cmdUsuario.Parameters.AddWithValue("@NombreCompleto", cliente.Nombre);

                        var paramFotoPerfil = cmdUsuario.Parameters.Add("@FotoPerfil", SqlDbType.VarBinary, -1);
                        paramFotoPerfil.Value = (object?)cliente.Foto ?? DBNull.Value;

                        cmdUsuario.ExecuteNonQuery();

                        // 2️⃣ Actualizar datos del cliente
                        var cmdCliente = new SqlCommand(@"
                    UPDATE Clientes
                    SET Nombre = @Nombre,
                        Correo = @Correo,
                        Telefono = @Telefono,
                        Direccion = @Direccion,
                        Foto = @Foto
                    WHERE ClienteId = @ClienteId;", conn, trans);

                        cmdCliente.Parameters.AddWithValue("@ClienteId", cliente.ClienteId);
                        cmdCliente.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                        cmdCliente.Parameters.AddWithValue("@Correo", cliente.Correo ?? (object)DBNull.Value);
                        cmdCliente.Parameters.AddWithValue("@Telefono", cliente.Telefono ?? (object)DBNull.Value);
                        cmdCliente.Parameters.AddWithValue("@Direccion", cliente.Direccion ?? (object)DBNull.Value);

                        var paramFoto = cmdCliente.Parameters.Add("@Foto", SqlDbType.VarBinary, -1);
                        paramFoto.Value = (object?)cliente.Foto ?? DBNull.Value;

                        cmdCliente.ExecuteNonQuery();

                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        // =============================
        // ELIMINAR CLIENTE
        // =============================
        public bool Eliminar(int clienteId)
        {
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();

                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1️⃣ Obtener el UserId del cliente
                        var cmdGetUserId = new SqlCommand(@"
                            SELECT UserId FROM Clientes WHERE ClienteId = @ClienteId;", conn, trans);
                        cmdGetUserId.Parameters.AddWithValue("@ClienteId", clienteId);

                        object result = cmdGetUserId.ExecuteScalar();
                        if (result == null)
                            throw new Exception("Cliente no encontrado.");

                        int userId = Convert.ToInt32(result);

                        // 2️⃣ Eliminar cliente
                        var cmdDeleteCliente = new SqlCommand(@"
                            DELETE FROM Clientes WHERE ClienteId = @ClienteId;", conn, trans);
                        cmdDeleteCliente.Parameters.AddWithValue("@ClienteId", clienteId);
                        cmdDeleteCliente.ExecuteNonQuery();

                        // 3️⃣ Eliminar usuario vinculado
                        var cmdDeleteUsuario = new SqlCommand(@"
                            DELETE FROM Usuarios WHERE UserId = @UserId;", conn, trans);
                        cmdDeleteUsuario.Parameters.AddWithValue("@UserId", userId);
                        cmdDeleteUsuario.ExecuteNonQuery();

                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
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
                                UserId = Convert.ToInt32(dr["UsuarioId"])
                            };
                        }
                    }
                }
            }

            return cliente;
        }
    }
}
