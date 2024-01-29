using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary;
using System.ComponentModel.DataAnnotations;

namespace Individual_Sem2_Web.Pages
{
    public class ForgotPasswordModel : PageModel
    {
        [BindProperty]
        [EmailAddress]
        public string Email { get;set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            try
            {
                User user = SpaceApp.Instance.UserManager.GetUserByEmail(Email);

                if (user == null)
                {
                    // User with the provided email address does not exist
                    TempData["ErrorMessage"] = "The entered email is not registered";
                    return RedirectToPage("ForgotPassword");
                }

                string newPassword = SpaceApp.Instance.UserManager.GenerateRandomPassword(9);

                //update the user's password
                User newUser = new Administrator(user.FirstName, user.Password, user.Email, user.LastName, user.Birthdate);

                //email first, catch exception before altering the db
                SpaceApp.Instance.UserManager.SendRecoveryEmail(user, newPassword);

                //transcribing the user and preparing for update
                //newUser.Password = newPassword;
                //if (user is Guest g)
                   // ((Guest)newUser).ProfilePictureURL = g.ProfilePictureURL;
               // SpaceApp.Instance.UserManager.UpdateUser(user.Email, newUser);

                

                return RedirectToPage("ForgotPasswordConfirmation");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Something went wrong, please try again later";
                return RedirectToPage("ForgotPassword");
            }
            
        }

    }
}
