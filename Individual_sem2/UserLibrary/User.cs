
using CustomExceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

public abstract class User {


    [Required] private string firstName;
    [Required] private string password;
    [Required][EmailAddress] private string email;
    [Required] private string lastName;
    [Required] private DateTime birthdate;

    public User() { } //used for model binding

    public User(string firstName, string password, string email, string lastName, DateTime birthdate)
    {
        this.FirstName = firstName;
        this.Password = password;
        this.Email = email;
        this.LastName = lastName;
        this.Birthdate = birthdate;
    }

    #region properties + validation
    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (IsValidName(value))
                this.firstName = value;
            else throw new InvalidFirstNameException("Invalid First Name");
        }
    }
    public string Password { 
        get { return this.password; }
        set 
        {
            if (!IsPasswordWeak(value))
                this.password = value;
            else throw new WeakPasswordException("Too weak");
        }
    }
    public string Email { 
        get { return this.email; }
        set
        {
            if (IsEmailValid(value))
                this.email = value;
            else throw new InvalidEmailException("Invalid Email address");
        }
    }
    public string LastName  {
        get { return this.lastName; }
        set
        {
            if (IsValidName(value))
                this.lastName = value;
            else throw new InvalidLastNameException("Invalid Last Name");
        }
    }
    public DateTime Birthdate
    {
        get { return this.birthdate; }
        set
        {
            if (IsBirthDateValid(value))
                this.birthdate = value;
            else throw new InvalidBirthDateException("Invalid Birth Date");
        }
    }
    #endregion

    private bool IsValidName(string firstName)
    {
        if (string.IsNullOrEmpty(firstName))
        {
            return false;
        }

        foreach (char c in firstName)
        {
            if (!char.IsLetter(c) && c != '-')
            {
                return false;
            }
        }

        if (!char.IsLetter(firstName[0]) || !char.IsLetter(firstName[firstName.Length - 1]))
        {
            return false;
        }

        if (firstName.Length > 50)
        {
            return false;
        }
        return true;
    }

    private bool IsPasswordWeak(string password)
    {
        /// <summary>
        /// passowrd must be 8 characters or longer
        /// password must contain letters and numbers
        /// </summary>
        if (password.Length < 8)
        {
            return true;
        }
        if (!password.Any(char.IsLower))
        {
            return true;
        }
        if (!password.Any(char.IsDigit))
        {
            return true;
        }
        return false;
    }

    private static bool IsEmailValid(string email)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        bool isValidEmail = Regex.IsMatch(email, pattern);

        if (!isValidEmail)
        {
            //email is not in correct format
            return false;
        }
        return true;
    }

    private static bool IsBirthDateValid(DateTime date)
    {
        if (date > DateTime.Now.Date)
        {
            return false;
        }
        return true;
    }

}