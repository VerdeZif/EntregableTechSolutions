namespace Entidad.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public byte[]? Foto { get; set; }

        // ✅ Relación con la tabla Usuarios
        public int UsuarioId { get; set; }
    }
}