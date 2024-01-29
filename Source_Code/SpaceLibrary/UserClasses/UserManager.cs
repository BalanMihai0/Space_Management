
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;
using UserLibrary;
using CustomExceptions;
using System.Runtime.CompilerServices;
using System.Dynamic;

public class UserManager 
{

    private readonly IUserDataInterface _userDataHandler;

    public UserManager(IUserDataInterface dataStorage)
    {
        _userDataHandler = dataStorage;
    }

    public User AuthenthicateUser(string email, string password) {
        //get the type of user
        return _userDataHandler.CheckUserLogin(email, password);
    }


    public void AddGuest(string firstName, string lastName, string password,string email,DateTime birthdate, string profilePicUrl ) 
    {
        if (!_userDataHandler.EmailAlreadyExists(email)) //optimize nr of requests for db
            _userDataHandler.AddUserToDatabase(new Guest(profilePicUrl, firstName, lastName, email, password, birthdate));
        else throw new InvalidEmailException("Email already exists");
    }
    public void AddEmployee(string firstName, string lastName, string password, string email, DateTime birthdate)
    {
        if (!_userDataHandler.EmailAlreadyExists(email)) //optimize nr of requests for db
            _userDataHandler.AddUserToDatabase(new Employee( firstName, password, email, lastName, birthdate));
        else throw new InvalidEmailException("Email already exists");
    }

    public void AddAdmin(string firstName, string lastName, string password, string email, DateTime birthdate)
    {
        if (!_userDataHandler.EmailAlreadyExists(email)) //optimize nr of requests for db
            _userDataHandler.AddUserToDatabase(new Administrator(firstName, password, email,lastName, birthdate));
        else throw new InvalidEmailException("Email already exists");
    }
    public string GenerateRandomPassword(int length)
    {
        const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+-=[]{}|;:,.<>?";

        var random = new Random();
        var password = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            password.Append(validChars[random.Next(validChars.Length)]);
        }

        return password.ToString();
    }
    public void RemoveUser(User user) 
    {
        _userDataHandler.DeleteUser(user);
    }
    public void UpdateUser(string email, User newUser)
    {
        _userDataHandler.UpdateUser(email, newUser);
    }
    public User GetUserByEmail(string email)
    {
        return _userDataHandler.GetUserByEmail(email);
    }

    public List<User> GetEmployees()
    {
        return _userDataHandler.GetAllEmployees();
    }
    public List<User> GetAdmins()
    {
        return _userDataHandler.GetAllAdministrators();
    }
    public List<User> GetGuests()
    {
        return _userDataHandler.GetAllGuests();
    }

    public List<User> GetAllUsers()
    {
        var a = _userDataHandler.GetAllAdministrators().ToList();
        var e = _userDataHandler.GetAllEmployees().ToList();
        var g = _userDataHandler.GetAllGuests().ToList();
        return a.Concat(e).Concat(g).ToList();
    }

    public void SendRecoveryEmail(User userLoggedIn, string newPassword)
    {
        EmailService emailService = new EmailService(userLoggedIn);
        emailService.SendRecoveryEmail(userLoggedIn.Email, newPassword); 
    }

}