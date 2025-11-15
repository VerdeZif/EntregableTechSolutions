using Datos.Repositorio;
using Entidad.Models;
using Negocio.Seguridad;

namespace Negocio.Servicios
{
    // ==============================
    // CAPA DE NEGOCIO PARA USUARIOS
    // Gestiona toda la lógica de negocio relacionada con los usuarios:
    // login, registro, actualización, eliminación y roles.
    // ==============================
    public class UsuarioNegocio
    {
        // Instancia para acceder a la capa de datos de usuarios
        private readonly UsuarioDatos _usuarioDatos;

        // Instancia para manejo de hash de contraseñas
        private readonly PasswordHasher _passwordHasher;

        // Constructor: inicializa las dependencias
        public UsuarioNegocio()
        {
            _usuarioDatos = new UsuarioDatos();
            _passwordHasher = new PasswordHasher();
        }

        // ==============================
        // LOGIN DE USUARIO
        // Valida credenciales y retorna el objeto Usuario si son correctas
        // ==============================
        public Usuario? Login(string username, string password)
        {
            // Obtener usuario por username
            var usuario = _usuarioDatos.ObtenerPorUsername(username);
            if (usuario == null)
                return null;

            // Validar contraseña usando hash
            if (!_passwordHasher.VerifyPassword(password, usuario.PasswordHash))
                return null;

            return usuario;
        }

        // ==============================
        // LISTAR USUARIOS
        // Devuelve todos los usuarios registrados
        // ==============================
        public List<Usuario> ListarUsuarios()
        {
            return _usuarioDatos.Listar();
        }

        // ==============================
        // REGISTRAR NUEVO USUARIO
        // Recibe usuario y contraseña en texto plano,
        // genera hash de la contraseña y lo guarda
        // ==============================
        public bool RegistrarUsuario(Usuario usuario, string passwordPlano)
        {
            usuario.PasswordHash = _passwordHasher.HashPassword(passwordPlano);
            return _usuarioDatos.Registrar(usuario);
        }

        // ==============================
        // LISTAR ROLES
        // Devuelve todos los roles disponibles en el sistema
        // ==============================
        public List<Rol> ListarRoles()
        {
            return _usuarioDatos.ListarRoles();
        }

        // ==============================
        // ACTUALIZAR USUARIO
        // Actualiza información básica del usuario (sin cambiar contraseña)
        // ==============================
        public bool ActualizarUsuario(Usuario usuario)
        {
            return _usuarioDatos.Actualizar(usuario);
        }

        // ==============================
        // ACTUALIZAR USUARIO CON NUEVA CONTRASEÑA
        // Si se recibe nueva contraseña, se genera hash antes de actualizar
        // ==============================
        public bool ActualizarUsuario(Usuario usuario, string? nuevaPassword)
        {
            if (!string.IsNullOrWhiteSpace(nuevaPassword))
            {
                usuario.PasswordHash = _passwordHasher.HashPassword(nuevaPassword);
            }

            return _usuarioDatos.Actualizar(usuario);
        }

        // ==============================
        // ELIMINAR USUARIO
        // Elimina un usuario según su ID
        // ==============================
        public bool EliminarUsuario(int userId)
        {
            return _usuarioDatos.Eliminar(userId);
        }

        // ==============================
        // OBTENER USUARIO POR ID
        // ==============================
        public Usuario? ObtenerPorId(int id)
        {
            return _usuarioDatos.ObtenerPorId(id);
        }

        // ==============================
        // GENERAR HASH DE CONTRASEÑA
        // Método útil para cambios de contraseña o validaciones externas
        // ==============================
        public string GenerarHash(string passwordPlano)
        {
            return _passwordHasher.HashPassword(passwordPlano);
        }
    }
}
