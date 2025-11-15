namespace Entidad.Models
{
    // ==============================
    // MODELO DE CLIENTE
    // Representa la información de un cliente en el sistema
    // ==============================
    public class Cliente
    {
        // Identificador único del cliente en la base de datos
        public int ClienteId { get; set; }

        // Identificador del usuario asociado al cliente
        public int UserId { get; set; }

        // Nombre completo del cliente
        public string Nombre { get; set; } = string.Empty;

        // Correo electrónico del cliente
        public string Correo { get; set; } = string.Empty;

        // Número de teléfono del cliente
        public string Telefono { get; set; } = string.Empty;

        // Dirección física del cliente
        public string Direccion { get; set; } = string.Empty;

        // Foto de perfil o imagen asociada al cliente (opcional)
        public byte[]? Foto { get; set; }

        // ==============================
        // CAMPOS PARA CREAR EL USUARIO
        // ==============================

        // Nombre de usuario para el login (username)
        public string Username { get; set; } = string.Empty;

        // Contraseña hasheada para seguridad
        public string PasswordHash { get; set; } = string.Empty;
    }
}
