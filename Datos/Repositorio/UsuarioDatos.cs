using Datos.Database;
using Entidad.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Datos.Repositorio
{
    public class UsuarioDatos
    {
        // =======================
        // LOGIN
        // =======================
        public Usuario? Login(string username, string password)
        {
            Usuario? user = null;
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(@"
                    SELECT u.UserId, u.Username, u.PasswordHash, u.NombreCompleto, u.FotoPerfil, 
                           u.RoleId, r.Nombre AS NombreRol
                    FROM Usuarios u
                    INNER JOIN Roles r ON u.RoleId = r.RoleId
                    WHERE u.Username = @username AND u.PasswordHash = @password", conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            user = new Usuario
                            {
                                UserId = Convert.ToInt32(dr["UserId"]),
                                Username = dr["Username"]?.ToString() ?? string.Empty,
                                PasswordHash = dr["PasswordHash"]?.ToString() ?? string.Empty,
                                NombreCompleto = dr["NombreCompleto"]?.ToString() ?? string.Empty,
                                FotoPerfil = dr["FotoPerfil"] as byte[],
                                RoleId = Convert.ToInt32(dr["RoleId"]),
                                NombreRol = dr["NombreRol"]?.ToString() ?? string.Empty
                            };
                        }
                    }
                }
            }
            return user;
        }

        // =======================
        // OBTENER POR USERNAME
        // =======================
        public Usuario? ObtenerPorUsername(string username)
        {
            Usuario? user = null;
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(@"
                    SELECT u.UserId, u.Username, u.PasswordHash, u.NombreCompleto, u.FotoPerfil, 
                           u.RoleId, r.Nombre AS NombreRol
                    FROM Usuarios u
                    INNER JOIN Roles r ON u.RoleId = r.RoleId
                    WHERE u.Username = @username", conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            user = new Usuario
                            {
                                UserId = Convert.ToInt32(dr["UserId"]),
                                Username = dr["Username"]?.ToString() ?? string.Empty,
                                PasswordHash = dr["PasswordHash"]?.ToString() ?? string.Empty,
                                NombreCompleto = dr["NombreCompleto"]?.ToString() ?? string.Empty,
                                FotoPerfil = dr["FotoPerfil"] as byte[],
                                RoleId = Convert.ToInt32(dr["RoleId"]),
                                NombreRol = dr["NombreRol"]?.ToString() ?? string.Empty
                            };
                        }
                    }
                }
            }
            return user;
        }

        // =======================
        // LISTAR USUARIOS
        // =======================
        public List<Usuario> Listar()
        {
            var lista = new List<Usuario>();
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(@"
                    SELECT u.UserId, u.Username, u.NombreCompleto, u.FotoPerfil, 
                           r.Nombre AS NombreRol, u.RoleId
                    FROM Usuarios u
                    INNER JOIN Roles r ON u.RoleId = r.RoleId", conn))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario
                            {
                                UserId = Convert.ToInt32(dr["UserId"]),
                                Username = dr["Username"]?.ToString() ?? string.Empty,
                                NombreCompleto = dr["NombreCompleto"]?.ToString() ?? string.Empty,
                                FotoPerfil = dr["FotoPerfil"] as byte[],
                                NombreRol = dr["NombreRol"]?.ToString() ?? string.Empty,
                                RoleId = Convert.ToInt32(dr["RoleId"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // =======================
        // REGISTRAR USUARIO
        // =======================
        public bool Registrar(Usuario usuario)
        {
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(@"
                    INSERT INTO Usuarios (Username, PasswordHash, NombreCompleto, RoleId, FotoPerfil)
                    VALUES (@username, @password, @nombre, @roleId, @foto)", conn))
                {
                    cmd.Parameters.AddWithValue("@username", usuario.Username);
                    cmd.Parameters.AddWithValue("@password", usuario.PasswordHash);
                    cmd.Parameters.AddWithValue("@nombre", usuario.NombreCompleto);
                    cmd.Parameters.AddWithValue("@roleId", usuario.RoleId);
                    var paramFoto = cmd.Parameters.Add("@foto", SqlDbType.VarBinary, -1);
                    paramFoto.Value = (object?)usuario.FotoPerfil ?? DBNull.Value;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // =======================
        // ACTUALIZAR USUARIO
        // =======================
        public bool Actualizar(Usuario usuario)
        {
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();

                string sql = @"
                    UPDATE Usuarios
                    SET Username = @username,
                        NombreCompleto = @nombreCompleto,
                        FotoPerfil = @fotoPerfil";

                // Solo actualiza la contraseña si viene con valor
                if (!string.IsNullOrWhiteSpace(usuario.PasswordHash))
                    sql += ", PasswordHash = @passwordHash";

                sql += " WHERE UserId = @userId";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", usuario.Username);
                    cmd.Parameters.AddWithValue("@nombreCompleto", usuario.NombreCompleto);
                    cmd.Parameters.AddWithValue("@userId", usuario.UserId);

                    var paramFoto = cmd.Parameters.Add("@fotoPerfil", SqlDbType.VarBinary, -1);
                    paramFoto.Value = (object?)usuario.FotoPerfil ?? DBNull.Value;

                    if (!string.IsNullOrWhiteSpace(usuario.PasswordHash))
                        cmd.Parameters.AddWithValue("@passwordHash", usuario.PasswordHash);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // =======================
        // ELIMINAR USUARIO
        // =======================
        public bool Eliminar(int userId)
        {
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand("DELETE FROM Usuarios WHERE UserId = @userId", conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // =======================
        // LISTAR ROLES
        // =======================
        public List<Rol> ListarRoles()
        {
            var roles = new List<Rol>();
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT RoleId, Nombre FROM Roles", conn))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            roles.Add(new Rol
                            {
                                RoleId = Convert.ToInt32(dr["RoleId"]),
                                Nombre = dr["Nombre"]?.ToString() ?? string.Empty
                            });
                        }
                    }
                }
            }
            return roles;
        }

        // =======================
        // OBTENER POR ID
        // =======================
        public Usuario? ObtenerPorId(int id)
        {
            Usuario? usuario = null;
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT u.UserId, u.Username, u.PasswordHash, u.NombreCompleto, u.FotoPerfil, 
                           u.RoleId, r.Nombre AS NombreRol
                    FROM Usuarios u
                    INNER JOIN Roles r ON u.RoleId = r.RoleId
                    WHERE u.UserId = @id", conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuario = new Usuario
                            {
                                UserId = Convert.ToInt32(dr["UserId"]),
                                Username = dr["Username"].ToString() ?? string.Empty,
                                PasswordHash = dr["PasswordHash"].ToString() ?? string.Empty,
                                NombreCompleto = dr["NombreCompleto"].ToString() ?? string.Empty,
                                FotoPerfil = dr["FotoPerfil"] as byte[],
                                RoleId = Convert.ToInt32(dr["RoleId"]),
                                NombreRol = dr["NombreRol"].ToString() ?? string.Empty
                            };
                        }
                    }
                }
            }
            return usuario;
        }
    }
}
