using Entidad.Models;
using Negocio.Servicios;

namespace Negocio.Seguridad
{
    // ==============================
    // SERVICIO DE AUTENTICACIÓN
    // Encapsula la lógica de autenticación de usuarios,
    // utilizando los métodos de la capa de negocio (UsuarioNegocio)
    // ==============================
    public class AuthService
    {
        // Instancia de la clase de negocio para manejar usuarios
        private readonly UsuarioNegocio _usuarioNegocio;

        // Constructor: inicializa la instancia de UsuarioNegocio
        public AuthService()
        {
            _usuarioNegocio = new UsuarioNegocio();
        }

        // ==============================
        // MÉTODO DE LOGIN
        // Recibe el nombre de usuario y la contraseña, y devuelve
        // un objeto Usuario si las credenciales son correctas,
        // o null si son incorrectas.
        // ==============================
        public Usuario? Login(string username, string password)
        {
            // Delegamos la autenticación a la capa de negocio
            return _usuarioNegocio.Login(username, password);
        }
    }
}
