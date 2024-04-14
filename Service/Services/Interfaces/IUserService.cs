using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IUserService
    {
        void RegisterUser(string username,string fullName,string email,string password);
        bool LoginUser(string username, string password);
    }
}
   