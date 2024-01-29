
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Administrator : User
{
    public Administrator() : base() { }
    public Administrator(string firstName, string password, string email, string lastName, DateTime birthdate) : base(firstName, password, email, lastName, birthdate)
    {
    }
    public Administrator(string firstName,  string email, string lastName, DateTime birthdate) : base(firstName, email, lastName, birthdate)
    {
    }
    public override string ToString()
    {
        return base.FirstName + ", " + base.LastName;
    }
}