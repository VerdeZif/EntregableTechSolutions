namespace Entidad.Models
{
    // ==============================
    // MODELO DE USUARIO
    // Representa un usuario del sistema con sus datos de acceso,
    // información personal y rol asociado.
    // ==============================
    public class Usuario
    {
        public int UserId { get; set; }                   // ID único del usuario en la base de datos
        public string Username { get; set; } = string.Empty; // Nombre de usuario para login
        public string PasswordHash { get; set; } = string.Empty; // Contraseña cifrada (hash)
        public string NombreCompleto { get; set; } = string.Empty; // Nombre completo del usuario
        public string Correo { get; set; } = string.Empty; // Correo electrónico del usuario
        public string Telefono { get; set; } = string.Empty; // Teléfono del usuario

        public byte[]? FotoPerfil { get; set; }           // Foto de perfil opcional del usuario
        public int RoleId { get; set; }                   // ID del rol asociado (FK a la tabla Roles)

        // Propiedad adicional para mostrar el nombre del rol directamente
        public string? NombreRol { get; set; }            // Nombre del rol asociado (ej. "Administrador")
    }
}
