using Datos.Database; // Conexión a BD y helpers
using Entidad.Models; // Modelo Cliente
using Microsoft.Data.SqlClient; // SQL Server
using System.Data; // Tipos ADO.NET

namespace Datos.Repositorio
{
    // Clase para operaciones CRUD de clientes en la base de datos
    public class ClienteDatos
    {
        // =============================
        // LISTAR TODOS LOS CLIENTES
        // =============================
        public List<Cliente> Listar()
        {
            var lista = new List<Cliente>();

            using (var conn = ConexionBD.Instance.GetConnection())// Obtener conexión
            {
                conn.Open();// Abrir conexión
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
                    using (SqlDataReader dr = cmd.ExecuteReader())// Leer resultados
                    {
                        while (dr.Read())// Recorrer cada registro
                        {
                            lista.Add(new Cliente // Mapear a objeto Cliente
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

            return lista; // Devolver lista de clientes
        }



        // =============================
        // OBTENER CLIENTE POR ID
        // =============================
        public Cliente? ObtenerPorId(int id)
        {
            Cliente? cliente = null;  // Declaración de variable que puede ser null si no se encuentra el cliente

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT ClienteId, Nombre, Correo, Telefono, Direccion, Foto, UserId AS UsuarioId
                    FROM Clientes
                    WHERE ClienteId = @id", conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id; // Parámetro ID

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read()) // Si se encuentra el cliente
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

            return cliente; // Devolver cliente o null
        }

        // =============================
        // REGISTRAR NUEVO CLIENTE
        // =============================
        public bool Registrar(Cliente cliente)
        {
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();

                using (var trans = conn.BeginTransaction()) // Iniciar transacción
                {
                    try
                    {
                        // Crear el usuario asociado al cliente
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

                        int nuevoUserId = Convert.ToInt32(cmdUsuario.ExecuteScalar()); // Insertar y obtener UserId

                        // Crear registro del cliente
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

                        cmdCliente.ExecuteNonQuery();// Insertar cliente

                        trans.Commit();// Confirmar transacción
                        return true;
                    }
                    catch
                    {
                        trans.Rollback(); // Revertir si falla
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
                        // Actualizar usuario
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

                        // Actualizar datos del cliente
                        var cmdCliente = new SqlCommand(@"
                        UPDATE Clientes
                            SET Nombre = @Nombre,
                                Correo = @Correo,
                                Telefono = @Telefono,
                                Direccion = @Direccion,
                                Foto = @Foto
                            WHERE ClienteId = @ClienteId;", conn, trans);// Confirmar cambios

                        cmdCliente.Parameters.AddWithValue("@ClienteId", cliente.ClienteId);
                        cmdCliente.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                        cmdCliente.Parameters.AddWithValue("@Correo", cliente.Correo ?? (object)DBNull.Value);
                        cmdCliente.Parameters.AddWithValue("@Telefono", cliente.Telefono ?? (object)DBNull.Value);
                        cmdCliente.Parameters.AddWithValue("@Direccion", cliente.Direccion ?? (object)DBNull.Value);

                        var paramFoto = cmdCliente.Parameters.Add("@Foto", SqlDbType.VarBinary, -1);
                        paramFoto.Value = (object?)cliente.Foto ?? DBNull.Value;

                        cmdCliente.ExecuteNonQuery();

                        trans.Commit(); // Confirmar cambios
                        return true;
                    }
                    catch
                    {
                        trans.Rollback(); // Revertir si falla
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
                        // Obtener el UserId del cliente
                        var cmdGetUserId = new SqlCommand(@"
                            SELECT UserId FROM Clientes WHERE ClienteId = @ClienteId;", conn, trans);
                        cmdGetUserId.Parameters.AddWithValue("@ClienteId", clienteId);

                        object result = cmdGetUserId.ExecuteScalar();
                        if (result == null)
                            throw new Exception("Cliente no encontrado.");

                        int userId = Convert.ToInt32(result);

                        // Eliminar cliente
                        var cmdDeleteCliente = new SqlCommand(@"
                            DELETE FROM Clientes WHERE ClienteId = @ClienteId;", conn, trans);
                        cmdDeleteCliente.Parameters.AddWithValue("@ClienteId", clienteId);
                        cmdDeleteCliente.ExecuteNonQuery();

                        // Eliminar usuario vinculado
                        var cmdDeleteUsuario = new SqlCommand(@"
                            DELETE FROM Usuarios WHERE UserId = @UserId;", conn, trans);
                        cmdDeleteUsuario.Parameters.AddWithValue("@UserId", userId);
                        cmdDeleteUsuario.ExecuteNonQuery();

                        trans.Commit();// Confirmar eliminación
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();// Revertir si falla
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
                        if (dr.Read())// Mapear a Cliente si existe 
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

            return cliente; // Devolver cliente o null
        }
    }
}
