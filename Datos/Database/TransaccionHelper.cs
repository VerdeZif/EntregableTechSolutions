using Microsoft.Data.SqlClient;// Librería para SQL Server
using System.Data;// Librería para tipos de datos ADO.NET

namespace Datos.Database
{
    // Clase para manejar transacciones SQL con commit y rollback
    public class TransaccionHelper : IDisposable
    {
        public SqlConnection Conexion { get; private set; }// Conexión a la base de datos
        public SqlTransaction Transaccion { get; private set; }// Transacción activa

        public TransaccionHelper()
        {
            Conexion = ConexionBD.Instance.GetConnection(); // Obtiene la conexión desde el singleton
            Conexion.Open();// Abre la conexión
            Transaccion = Conexion.BeginTransaction();// Inicia la transacción
        }

        public SqlCommand CrearComando(string query, CommandType tipo = CommandType.Text)// Crea un comando asociado a la conexión y transacción
        {
            var cmd = new SqlCommand(query, Conexion, Transaccion)// Crea un comando asociado a la conexión y transacción
            {
                CommandType = tipo// Tipo de comando (Text, StoredProcedure, etc.)
            };
            return cmd;// Devuelve el comando listo para ejecutar
        }

        public void Confirmar()
        {
            Transaccion?.Commit();// Confirma la transacción
            Cerrar();// Cierra la conexión
        }

        public void Revertir()
        {
            Transaccion?.Rollback();// Revierte la transacción
            Cerrar();// Cierra la conexión
        }

        private void Cerrar()
        {
            if (Conexion != null && Conexion.State == ConnectionState.Open)
                Conexion.Close();// Cierra la conexión si está abierta
        }

        public void Dispose()
        {
            Cerrar();// Permite usar "using" para liberar recursos
        }
    }
}
