using Divinus.Domain.Entities.Base;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Domain.Entities
{
    public class User : EntityBase
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public User(string email , string password)
        {
            Email = email;
            Password = password;
            CreatedAt = DateTime.Now;

            new AddNotifications<User>(this)
                .IfNotEmail(x => x.Email, "e-mail inválido")
                .IfNullOrInvalidLength(x => x.Password, 6, 12, "A senha deve ter no mínimo entre 6 a 12 caracteres");

            if(IsValid())
            {
                Password = ConvertToMD5(Password); 
            }
        }

        public string ConvertToMD5(string passWord)
        {
            if (string.IsNullOrEmpty(passWord)) return "";
            var password = (passWord += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }


        protected User()
        {

        }
    }
}
