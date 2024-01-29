
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
        if (!_userDataHandler.EmailAlreadyExists(email))
            _userDataHandler.AddUserToDatabase(new Guest(profilePicUrl, firstName, lastName, email, password, birthdate));
        else throw new InvalidEmailException("Email already exists");
    }
    public void AddEmployee(string firstName, string lastName, string password, string email, DateTime birthdate)
    {
        if (!_userDataHandler.EmailAlreadyExists(email))
            _userDataHandler.AddUserToDatabase(new Employee( firstName, password, email, lastName, birthdate));
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

    }
    public void UpdateUser(User toUpdate, User newUser)
    {

    }
    public User GetUserByEmail(string email)
    {
        return _userDataHandler.GetUserByEmail(email);
    }

    public void SendRecoveryEmail(User userLoggedIn, string newPassword)
    {
        EmailService emailService = new EmailService(userLoggedIn);
        emailService.SendRecoveryEmail(userLoggedIn.Email, newPassword); 
    }


   

}