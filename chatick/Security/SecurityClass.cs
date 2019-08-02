using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace chatick.Security
{
    class SecurityClass
    {
        public string[] password_MD5Hash(string pass) // 1- возвращаемый параметр - соль, 2 - хешированная строка
        {//метод преобразует пароль в хеш-строку и генерирует соль
            using (MD5 md5Hash = MD5.Create()) //MD5(MD5(password)+salt)
            {
                string[] str = new string[2];
                string Salt = generate_salt();
                str[0]= Salt;
                str[1] = GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, pass) + Salt);
                return str;
            }
        }
        public string password_MD5Hash_open(string pass,string salt) // 1- возвращаемый параметр - хешированная строка
        {//метод считывает хеш-строку пароля и соль из базы данных
            using (MD5 md5Hash = MD5.Create()) //MD5(MD5(password)+salt)
            {
                string password = GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, pass) + salt);
                return password;
            }
        }
        string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        private string generate_salt()
        {
            Random rand = new Random();
            string salt = "";
            for(int i = 0; i < 6; i++)
            {
                salt += (char)rand.Next(33, 126);
            }
            return salt;
        }
    }
}
