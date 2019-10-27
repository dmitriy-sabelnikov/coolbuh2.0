using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using EnumType;
using DAL;

namespace BLL
{
    public class Password
    {
        private string _password { get; set; }
        PasswordRepository _repo = new PasswordRepository();

        private string GetHashPassword()
        {
            MD5 md5Hasher = MD5.Create();
            //вычисляем хеш-представление в байтах  
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(_password));

            StringBuilder stringHash = new StringBuilder();

            foreach (byte b in data)
            {
                stringHash.Append(b.ToString("x2").ToUpper());
            }

            return stringHash.ToString();
        }

        public Password(string password)
        {
            _password = password;
        }

        public bool VerifyPassword(EnumPassword type)
        {
            string originalPassword = _repo.GetPasswordById((int)type);
            if (originalPassword == string.Empty)
                return false;

            string verifyPassword = GetHashPassword();
            if (verifyPassword == string.Empty)
                return false;

            return originalPassword == verifyPassword;
        }
    }
}
