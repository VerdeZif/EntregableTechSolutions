using Entidad.Models;
using Negocio.Servicios;

namespace Negocio.Seguridad
{
    public class AuthService
    {
        private readonly UsuarioNegocio _usuarioNegocio;

        public AuthService()
        {
            _usuarioNegocio = new UsuarioNegocio();
        }

        public Usuario? Login(string username, string password)
        {
            // Llama al método Login de UsuarioNegocio
            return _usuarioNegocio.Login(username, password);
        }
    }
}

