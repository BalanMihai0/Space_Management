
using CustomExceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;

public class Guest : User 
{

    [Required]private string? profilePictureURL;

    public Guest():base() { } //used for model binding

    public Guest(string profilePicUrl, string firstName, string lastName, string email, string password, DateTime birthdate) : base(firstName, password, email, lastName,birthdate )
    {
        this.ProfilePictureURL = profilePicUrl;
    }



    public string ProfilePictureURL
    {
        get { return this.profilePictureURL; }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (IsPictureUrlValid(value))
                    this.profilePictureURL = value;
                else throw new InvalidURLException("Invalid Last Name");
            }
            else this.profilePictureURL = value;  
        }
    }

    public static bool IsPictureUrlValid(string url)
    {
        try
        {
            //checking request from browser
            using (var client = new WebClient())
            using (var stream = client.OpenRead(url))
            {
                return true;
            }
        }
        catch
        {
            return false;
        }
    }

}