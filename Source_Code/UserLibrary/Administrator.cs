
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Administrator : User
{
    public Administrator(string firstName, string password, string email, string lastName, DateTime birthdate) : base(firstName, password, email, lastName, birthdate)
    {
    }
}