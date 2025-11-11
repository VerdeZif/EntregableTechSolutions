using Datos.Repositorio;
using Entidad.Models;
using Negocio.Seguridad;

namespace Negocio.Servicios
{
    public class UsuarioNegocio
    {
        private readonly UsuarioDatos _usuarioDatos;
        private readonly PasswordHasher _passwordHasher;

        public UsuarioNegocio()
        {
            _usuarioDatos = new UsuarioDatos();
            _passwordHasher = new PasswordHasher();
        }

        // Validar login de usuario
        public Usuario? Login(string username, string password)
        {
            var usuario = _usuarioDatos.ObtenerPorUsername(username);
            if (usuario == null)
                return null;

            // Validar contraseña (hash)
            if (!_passwordHasher.VerifyPassword(password, usuario.PasswordHash))
                return null;

            return usuario;
        }

        // Listar todos los usuarios
        public List<Usuario> ListarUsuarios()
        {
            return _usuarioDatos.Listar();
        }

        // Registrar nuevo usuario
        public bool RegistrarUsuario(Usuario usuario, string passwordPlano)
        {
            usuario.PasswordHash = _passwordHasher.HashPassword(passwordPlano);
            return _usuarioDatos.Registrar(usuario);
        }

        // Listar roles
        public List<Rol> ListarRoles()
        {
            return _usuarioDatos.ListarRoles();
        }

        // Actualizar usuario
        public bool ActualizarUsuario(Usuario usuario)
        {
            return _usuarioDatos.Actualizar(usuario);
        }

        // Otra forma de Actualizar usuario
        public bool ActualizarUsuario(Usuario usuario, string? nuevaPassword)
        {
            if (!string.IsNullOrWhiteSpace(nuevaPassword))
            {
                usuario.PasswordHash = _passwordHasher.HashPassword(nuevaPassword);
            }

            return _usuarioDatos.Actualizar(usuario);
        }

        // Eliminar usuario
        public bool EliminarUsuario(int userId)
        {
            return _usuarioDatos.Eliminar(userId);
        }

        public Usuario? ObtenerPorId(int id)
        {
            return _usuarioDatos.ObtenerPorId(id);
        }

        // Generar hash desde la capa de negocio (útil para cambio de contraseña)
        public string GenerarHash(string passwordPlano)
        {
            return _passwordHasher.HashPassword(passwordPlano);
        }
    }
}
