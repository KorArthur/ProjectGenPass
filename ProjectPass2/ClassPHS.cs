using System.Text;
using System.Security.Cryptography;

namespace ProjectPass2
{
    public class ClassPHS
    {
        
        //проверка на соответствие пароля
        public static Class Rezerv(int length_salt, int length_pass)
        {
            if (length_pass > 8) length_pass = 8;

            if (length_pass < 4) length_pass = 4;

            if (length_pass == 5 || length_pass== 7) length_pass++;

            string password = Generate(length_pass);

            string salt = CreateSalt(length_salt);

            string hash = GenerateHash(password, salt);

            Class Hash1 = new Class();
            Hash1.hash = hash;
            Hash1.salt = salt;
            Hash1.password = password;
            return Hash1;
        }

        // генератор соли
        private static string CreateSalt(int size)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[size];
            rng.GetBytes(salt);

            string A = "";
            for (int i = 0; i < salt.Length; i++)
            {
                A += salt[i].ToString();
            }
            return A.Substring(0, size);
        }

        // генератор пароля
        private static string pass = "0123456789";
        private static string Generate(int length)
        {
            
            Random Rdpass = new Random();
            string password = String.Empty;
            for (int i = 0; i < length; i++)
            {
                password += pass[Rdpass.Next(0, pass.Length)];
            }
            return password.ToString();
        }

        // генератор хеша
        private static string GenerateHash(string password, string salt)
        {

            byte[] bytes = Encoding.UTF8.GetBytes(password + salt);
            using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
            {
                byte[] hash = sha1.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
    }

