using Domain.Models;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private Dictionary<string, User> registeredUsers = new Dictionary<string, User>();
        public User LoggedInUser { get; private set; }
        public bool LoginUser(string userName, string password)
        {
            if (registeredUsers.TryGetValue(userName, out User user) && user.Password == password)
            {
                LoggedInUser = user;
                Console.WriteLine("Login successful.");
                return true;
            }
            else
            {
                Console.WriteLine("Login failed. Incorrect username or password.");
                return false;
            }
        }

        public void RegisterUser(string username,string fullName,string email,string password)
        {
            if (registeredUsers.ContainsKey(username))
            {
                Console.WriteLine("This username is already taken. Please choose another one.");
            }
            else
            {
                registeredUsers.Add(new User(username,fullName,email,password));
                Console.WriteLine("Registration successful.");
            }
        }
    }
}
