using Individual_Sem2_Web.DTOs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary;
using System.Security.Claims;
using UserLibrary;

namespace Individual_Sem2_Web.Pages
{
    [Authorize]
    public class ProfileModel : PageModel
    {

        [BindProperty]
        public EditUserDTO userDetails { get; set; }

        public ProfileModel()
        {
            userDetails = new EditUserDTO();
        }

        public void OnGet()
        {
            try
            {
                //load old user
                User oldUser = SpaceApp.Instance.UserManager.GetUserByEmail(User.FindFirst("Email").Value);
                if (oldUser != null)
                {
                    userDetails.FirstName = oldUser.FirstName;
                    userDetails.LastName = oldUser.LastName;
                    userDetails.Email = oldUser.Email;
                    userDetails.BirthDate = oldUser.Birthdate;
                    if (oldUser is Guest g)
                        userDetails.ProfilePictureUrl = g.ProfilePictureURL;
                }
            }
            catch(NullReferenceException ex) { Console.WriteLine(ex.Message); }
           
        }


        public IActionResult OnPostDeleteButton(IFormCollection data)
        {
            //perform db operation
            SpaceApp.Instance.UserManager.RemoveUser(SpaceApp.Instance.UserManager.GetUserByEmail(User.FindFirst("Email").Value));
            //log out the user
            Response.Headers.Add("X-Logout-Successful", "true");
            HttpContext.SignOutAsync(); 
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostSaveButton(IFormCollection data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User newUserDetails = null;
                    //check for type from cookie
                    if (User.FindFirst("TypeOfUser").Value == "Guest")
                    {
                        //load old user
                        Guest currentUser = (Guest)SpaceApp.Instance.UserManager.GetUserByEmail(User.FindFirst("Email").Value);

                        //info from form submission
                        newUserDetails = new Guest(userDetails.ProfilePictureUrl, userDetails.FirstName, userDetails.LastName, userDetails.Email, currentUser.Password, userDetails.BirthDate);
                        SpaceApp.Instance.UserManager.UpdateUser(currentUser.Email, newUserDetails);
                    }
                    else if (User.FindFirst("TypeOfUser").Value == "Employee")
                    {
                        //load old user
                        Employee currentUser = (Employee)SpaceApp.Instance.UserManager.GetUserByEmail(User.FindFirst("Email").Value);

                        //info from form submission
                        newUserDetails = new Employee(userDetails.FirstName, currentUser.Password, userDetails.Email, userDetails.LastName, userDetails.BirthDate);
                        SpaceApp.Instance.UserManager.UpdateUser(currentUser.Email, newUserDetails);
                    }
                    else if (User.FindFirst("TypeOfUser").Value == "Administrator")
                    {
                        //load old user
                        Administrator currentUser = (Administrator)SpaceApp.Instance.UserManager.GetUserByEmail(User.FindFirst("Email").Value);

                        //info from form submission
                        newUserDetails = new Administrator(userDetails.FirstName, currentUser.Password, userDetails.Email, userDetails.LastName, userDetails.BirthDate);
                        SpaceApp.Instance.UserManager.UpdateUser(currentUser.Email, newUserDetails);

                    }
                    //refresh the cookie
                    var claims = new List<Claim>
                    {
                        new Claim("Username", newUserDetails.FirstName + " " + newUserDetails.LastName),
                        new Claim("Email", newUserDetails.Email),
                        new Claim("TypeOfUser", newUserDetails.GetType().Name),
                        new Claim("IPAddress", HttpContext.Connection.RemoteIpAddress.ToString()),
                        new Claim("BirthDate", newUserDetails.Birthdate.ToString()),
                        new Claim("FirstName", newUserDetails.FirstName),
                        new Claim("LastName", newUserDetails.LastName)
                    };
                    if (newUserDetails is Guest g)
                        claims.Add(new Claim("ProfilePictureUrl", g.ProfilePictureURL));
                    var claimsidentiy = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddHours(2),
                        IsPersistent = false // RememberMe
                    };
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsidentiy), authProperties);
                    // Redirect to the index page
                    return RedirectToPage("/Index");
                }
                catch (NullReferenceException) { return Page(); }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }
    }

}
