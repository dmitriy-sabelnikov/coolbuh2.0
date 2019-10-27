using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PasswordRepository
    {
        private Dictionary<int, string> hasedPassword = new Dictionary<int, string>()
        {
            { 1, "21E415E4588CD027CA51D89B076A729E" }
        };

        public string GetPasswordById(int id)
        {
            if (!hasedPassword.ContainsKey(id))
                return string.Empty;

            return hasedPassword[id];
        }
    }
}
