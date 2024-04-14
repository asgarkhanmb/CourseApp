using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User:BaseEntity
    {
        public User(string username, string fullName, string email, string password)
        {
            UserName = username;
            FullName = fullName;
            Email = email;
            Password = password;
        }

        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
