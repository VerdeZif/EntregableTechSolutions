using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return _usuarioNegocio.Login(username, password);
        }
    }
}
