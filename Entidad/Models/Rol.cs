namespace Entidad.Models
{
    // ==============================
    // MODELO DE ROL DE USUARIO
    // Representa los roles o perfiles que pueden tener los usuarios
    // Ejemplo: Administrador, Vendedor, Cliente, etc.
    // ==============================
    public class Rol
    {
        public int RoleId { get; set; }           // ID del rol en la base de datos
        public string Nombre { get; set; } = string.Empty;  // Nombre del rol (por ejemplo: "Administrador")
    }
}
