using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Negocio.Seguridad;

namespace GeneradorHash
{
    class Program
    {
        static void Main(string[] args)
        {
            var hasher = new PasswordHasher();
            string hash = hasher.HashPassword("123"); // contraseña que quieras
            Console.WriteLine("Hash SHA256: " + hash);
            Console.ReadLine(); // mantiene la ventana abierta
        }
    }
}
