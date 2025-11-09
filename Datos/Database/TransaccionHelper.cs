using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace Datos.Database
{
    public class TransaccionHelper : IDisposable
    {
        public SqlConnection Conexion { get; private set; }
        public SqlTransaction Transaccion { get; private set; }

        public TransaccionHelper()
        {
            Conexion = ConexionBD.Instance.GetConnection(); // ← Cambio aquí
            Conexion.Open();
            Transaccion = Conexion.BeginTransaction();
        }

        public SqlCommand CrearComando(string query, CommandType tipo = CommandType.Text)
        {
            var cmd = new SqlCommand(query, Conexion, Transaccion)
            {
                CommandType = tipo
            };
            return cmd;
        }

        public void Confirmar()
        {
            Transaccion?.Commit();
            Cerrar();
        }

        public void Revertir()
        {
            Transaccion?.Rollback();
            Cerrar();
        }

        private void Cerrar()
        {
            if (Conexion != null && Conexion.State == ConnectionState.Open)
                Conexion.Close();
        }

        public void Dispose()
        {
            Cerrar();
        }
    }
}
