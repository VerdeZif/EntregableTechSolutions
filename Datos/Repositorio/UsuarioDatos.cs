using Entidad.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using Datos.Database;

namespace Datos.Repositorio
{
    public class UsuarioDatos
    {
        // Método para validar un usuario (login)
        public Usuario? Login(string username, string password)
        {
            Usuario? user = null;

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT 
                        u.UserId,
                        u.Username,
                        u.PasswordHash,
                        u.NombreCompleto,
                        u.FotoPerfil,
                        u.RoleId,
                        r.Nombre
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
                                NombreRol = dr["Nombre"]?.ToString() ?? string.Empty // <-- aquí se asigna correctamente
                            };
                        }
                    }
                }
            }

            return user;
        }
        // Obtener usuario por username (sin validar contraseña)
        public Usuario? ObtenerPorUsername(string username)
        {
            Usuario? user = null;

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"
            SELECT 
                u.UserId,
                u.Username,
                u.PasswordHash,
                u.NombreCompleto,
                u.FotoPerfil,
                u.RoleId,
                r.Nombre
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

        // Método para listar todos los usuarios
        public List<Usuario> Listar()
        {
            var lista = new List<Usuario>();

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT 
                        u.UserId,
                        u.Username,
                        u.NombreCompleto,
                        u.FotoPerfil,
                        r.Nombre
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
                                NombreRol = dr["Nombre"]?.ToString() ?? string.Empty // <-- también aquí
                            });
                        }
                    }
                }
            }

            return lista;
        }

        // Método para registrar un nuevo usuario
        public bool Registrar(Usuario usuario)
        {
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Usuarios (Username, PasswordHash, NombreCompleto, RoleId, FotoPerfil)
                    VALUES (@username, @password, @nombre, @roleId, @foto)", conn))
                {
                    cmd.Parameters.AddWithValue("@username", usuario.Username);
                    cmd.Parameters.AddWithValue("@password", usuario.PasswordHash);
                    cmd.Parameters.AddWithValue("@nombre", usuario.NombreCompleto);
                    cmd.Parameters.AddWithValue("@roleId", usuario.RoleId);
                    cmd.Parameters.AddWithValue("@foto", (object?)usuario.FotoPerfil ?? DBNull.Value);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
