namespace Entidad.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public int UserId { get; set; }  // ← Antes era UsuarioId

        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public byte[]? Foto { get; set; }

        // Campos para crear el usuario
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}
