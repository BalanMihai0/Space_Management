using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLibrary
{
    public class Employee : User
    {
        public Employee():base() { }
        public Employee(string firstName, string password, string email, string lastName, DateTime birthdate) : base(firstName, password, email, lastName, birthdate)
        {
        }
        public override string ToString()
        {
            return base.FirstName + ", " + base.LastName;
        }
    }
}
