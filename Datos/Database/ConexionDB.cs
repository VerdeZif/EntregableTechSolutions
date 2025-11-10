using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Datos.Database
{
    public sealed class ConexionBD
    {
        private static ConexionBD? _instance;

        // Cambia el nombre de la base de datos aquí
        private readonly string _connectionString =
            "Data Source=DESKTOP-57CU3R8;Initial Catalog=TechSolutionsDB;Integrated Security=True;Trust Server Certificate=True;";

        private ConexionBD() { }

        public static ConexionBD Instance => _instance ??= new ConexionBD();

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
