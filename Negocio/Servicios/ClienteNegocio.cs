using Datos.Repositorio;
using Entidad.Models;

namespace Negocio.Servicios
{
    public class ClienteNegocio
    {
        private readonly ClienteDatos _clienteDatos;

        public ClienteNegocio()
        {
            _clienteDatos = new ClienteDatos();
        }

        // Listar todos los clientes
        public List<Cliente> ListarClientes()
        {
            return _clienteDatos.Listar();
        }

        // Obtener cliente por ID
        public Cliente? ObtenerPorId(int id)
        {
            return _clienteDatos.ObtenerPorId(id);
        }

        public Cliente? ObtenerClientePorId(int id)
        {
            return ObtenerPorId(id);
        }

        // Registrar cliente
        public bool RegistrarCliente(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                throw new ArgumentException("El nombre del cliente es obligatorio.");

            if (string.IsNullOrWhiteSpace(cliente.Username))
                throw new ArgumentException("El nombre de usuario es obligatorio.");

            if (string.IsNullOrWhiteSpace(cliente.PasswordHash))
                throw new ArgumentException("La contraseña es obligatoria.");

            return _clienteDatos.Registrar(cliente);
        }

        // Actualizar cliente
        public bool ActualizarCliente(Cliente cliente)
        {
            if (cliente.ClienteId <= 0)
                throw new ArgumentException("ID de cliente no válido.");

            return _clienteDatos.Actualizar(cliente);
        }

        // Eliminar cliente
        public bool EliminarCliente(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID de cliente no válido.");

            return _clienteDatos.Eliminar(id);
        }
    }
}