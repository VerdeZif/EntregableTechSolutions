    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Security.Cryptography;


    namespace Negocio.Seguridad
    {
        public class PasswordHasher
        {
            // Generar hash SHA256
            public string HashPassword(string password)
            {
                using (SHA256 sha = SHA256.Create())
                {
                    byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                    return BitConverter.ToString(bytes).Replace("-", "").ToLower();
                }
            }

            // Verificar hash
            public bool VerifyPassword(string inputPassword, string hashedPassword)
            {
                string hashInput = HashPassword(inputPassword);
                return hashInput == hashedPassword;
            }
        }
        
    
    }
