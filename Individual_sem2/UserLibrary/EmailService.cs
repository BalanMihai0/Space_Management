using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace UserLibrary
{
    /// <summary>
    /// this class is used for the 'forgot password' feature of the web application
    /// not fully implemented yet
    /// </summary>
    public class EmailService
    {
        private User userLoggedIn;

        public EmailService(User userLoggedIn)
        {
            this.userLoggedIn = userLoggedIn;
        }
        public void SendRecoveryEmail(string email, string newPassword)
        {
            //IUserDataInterface userDataStorage = new UserDataHandeler();
            //UserManager um = new UserManager(userDataStorage); //used for generating a new password

            var client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("username", "password"),
                EnableSsl = true,
            };
            client.Credentials = new System.Net.NetworkCredential("username", "password");
            client.EnableSsl = true;

            //new mail message
            MailMessage message = new MailMessage();
            message.From = new MailAddress("501909@student.fontys.nl");
            message.To.Add(new MailAddress("bms.balan@gmail.com")); //hardcoded: no users registered with actual emails
            message.Subject = "Password Recovery";
            message.Body = $"Your new password is {newPassword}. You can reset this password in your profile.";

            client.Send(message);
        }

    }
}
