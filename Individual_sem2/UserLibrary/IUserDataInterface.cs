using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLibrary
{
    public interface IUserDataInterface 
    {
        void AddUserToDatabase(User user);
        User CheckUserLogin(string email, string password);
        bool EmailAlreadyExists(string email);
        void UpdateUser(User oldUser, User newUser);
        User GetUserByEmail(string email); 
    }
}
