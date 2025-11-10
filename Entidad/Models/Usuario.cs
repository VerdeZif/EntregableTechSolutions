using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.Models
{
    public class Usuario
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;

        public byte[]? FotoPerfil { get; set; }
        public int RoleId { get; set; }

        // Relación con Rol
        public string? NombreRol { get; set; }
    }
}