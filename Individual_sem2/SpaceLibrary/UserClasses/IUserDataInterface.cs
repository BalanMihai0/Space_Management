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
        void UpdateUser(string email, User newUser);
        User GetUserByEmail(string email); 
        List<User> GetAllEmployees();
        List<User> GetAllGuests();
        List<User> GetAllAdministrators();
        void DeleteUser(User user);
    }
}
