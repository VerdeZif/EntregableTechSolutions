using Datos.Database;
using Entidad.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;


namespace Datos.Repositorio
{
    public class UsuarioDatos
    {
        // Login (opcional, ya lo tienes)
        public Usuario? Login(string username, string password)
        {
            Usuario? user = null;
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(@"
                    SELECT u.UserId, u.Username, u.PasswordHash, u.NombreCompleto, u.FotoPerfil, u.RoleId, r.Nombre
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
                                NombreRol = dr["Nombre"]?.ToString() ?? string.Empty
                            };
                        }
                    }
                }
            }
            return user;
        }

        // Obtener usuario por username
        public Usuario? ObtenerPorUsername(string username)
        {
            Usuario? user = null;
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(@"
                    SELECT u.UserId, u.Username, u.PasswordHash, u.NombreCompleto, u.FotoPerfil, u.RoleId, r.Nombre
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
                                NombreRol = dr["Nombre"]?.ToString() ?? string.Empty
                            };
                        }
                    }
                }
            }
            return user;
        }

        // Listar todos los usuarios
        public List<Usuario> Listar()
        {
            var lista = new List<Usuario>();
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(@"
                    SELECT u.UserId, u.Username, u.NombreCompleto, u.FotoPerfil, r.Nombre, u.RoleId
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
                                NombreRol = dr["Nombre"]?.ToString() ?? string.Empty,
                                RoleId = Convert.ToInt32(dr["RoleId"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // Registrar usuario
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
                    var paramFoto = cmd.Parameters.Add("@foto", System.Data.SqlDbType.VarBinary, -1);
                    paramFoto.Value = (object?)usuario.FotoPerfil ?? DBNull.Value;
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Actualizar usuario
        public bool Actualizar(Usuario usuario)
        {
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();

                // Construir SQL dinámicamente
                string sql = @"
                UPDATE Usuarios
                SET Username = @username,
                    NombreCompleto = @nombre,
                    RoleId = @roleId,
                    FotoPerfil = @foto";

                if (!string.IsNullOrWhiteSpace(usuario.PasswordHash))
                {
                    sql += ", PasswordHash = @passwordHash";
                }

                sql += " WHERE UserId = @userId";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", usuario.Username);
                    cmd.Parameters.AddWithValue("@nombre", usuario.NombreCompleto);
                    cmd.Parameters.AddWithValue("@roleId", usuario.RoleId);

                    var paramFoto = cmd.Parameters.Add("@foto", System.Data.SqlDbType.VarBinary, -1);
                    paramFoto.Value = (object?)usuario.FotoPerfil ?? DBNull.Value;

                    cmd.Parameters.AddWithValue("@userId", usuario.UserId);

                    if (!string.IsNullOrWhiteSpace(usuario.PasswordHash))
                        cmd.Parameters.AddWithValue("@passwordHash", usuario.PasswordHash);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


        // Eliminar usuario
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

        // Listar roles
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

        public Usuario? ObtenerPorId(int id)
        {
            Usuario? usuario = null;

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE UserId = @id", conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuario = new Usuario
                            {
                                UserId = Convert.ToInt32(dr["UserId"]),
                                Username = dr["Username"].ToString()!,
                                NombreCompleto = dr["NombreCompleto"].ToString()!,
                                FotoPerfil = dr["FotoPerfil"] as byte[],
                                RoleId = Convert.ToInt32(dr["RoleId"])
                            };
                        }
                    }
                }
            }

            return usuario;
        }

    }
}

