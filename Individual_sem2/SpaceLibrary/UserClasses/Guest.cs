
using CustomExceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

public class Guest : User
{

    [Required]private string? profilePictureURL;

    public Guest():base() { } //used for model binding

    public Guest(string profilePicUrl, string firstName, string lastName, string email, string password, DateTime birthdate) : base(firstName, password, email, lastName,birthdate )
    {
        this.ProfilePictureURL = profilePicUrl;
    }
    public Guest(string profilePicUrl, string firstName, string lastName, string email,  DateTime birthdate) : base(firstName,  email, lastName, birthdate)
    {
        this.ProfilePictureURL = profilePicUrl;
    }


    public string ProfilePictureURL
    {
        get { return this.profilePictureURL; }
        protected set
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (IsPictureUrlValid(value))
                    this.profilePictureURL = value;
                else throw new InvalidURLException("Invalid Url");
            }
            else this.profilePictureURL = value;  
        }
    }

    public static bool IsPictureUrlValid(string url)
    {
        try
        {
            // Check if the URL matches the expected format
            var regex = new Regex(@"^(http|https)://.*\.(jpg|jpeg|png|gif|bmp)$", RegexOptions.IgnoreCase);
            if (!regex.IsMatch(url))
            {
                return false;
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public override string ToString()
    {
        return base.FirstName + ", " + base.LastName;
    }

}