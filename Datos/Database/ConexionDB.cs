using Microsoft.Data.SqlClient; // Librería para SQL Server

namespace Datos.Database
{
    // Clase singleton para gestionar la conexión a la base de datos
    public sealed class ConexionBD
    {
        private static ConexionBD? _instance; // Instancia única de la clase

        // Cambia el nombre de la base de datos aquí
        private readonly string _connectionString =
            "Data Source=localhost;Initial Catalog=TechSolutionsDB;Integrated Security=True;Trust Server Certificate=True;";

        private ConexionBD() { }// Constructor privado para evitar instancias externas


        public static ConexionBD Instance => _instance ??= new ConexionBD();// Obtiene la instancia única

        public SqlConnection GetConnection()// Obtiene la instancia única
        {
            return new SqlConnection(_connectionString);// Devuelve una nueva conexión SQL
        }
    }
}
