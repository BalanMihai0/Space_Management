using DataLibrary;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary;
using System.Security.Claims;
using MaxMind.GeoIP2;

namespace Individual_Sem2_Web.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string EmailToCheck { get; set; }
        [BindProperty]
        public string PasswordToCheck { get; set; }

        [BindProperty]
        public bool RememberMe { get; set; }    

        public bool DoCredentialsMatch { get; set; }

        private readonly ILogger<LoginModel> _logger;
        public LoginModel(ILogger<LoginModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {

        }


        public IActionResult OnPost()
        {   
            User? tempUser = SpaceApp.Instance.UserManager.AuthenthicateUser(EmailToCheck, PasswordToCheck);
            if (tempUser != null)
            {
                var claims = new List<Claim>
                {
                    new Claim("Username", tempUser.FirstName + " " + tempUser.LastName),
                    new Claim("Email", tempUser.Email),
                    new Claim("TypeOfUser", tempUser.GetType().Name),
                    new Claim("IPAddress", HttpContext.Connection.RemoteIpAddress.ToString()),
                    new Claim("BirthDate", tempUser.Birthdate.ToString()),
                    new Claim("FirstName", tempUser.FirstName),
                    new Claim("LastName", tempUser.LastName)
                };
                if(tempUser is Guest g)
                    claims.Add(new Claim("ProfilePictureUrl", g.ProfilePictureURL));

                var claimsidentiy = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddHours(2),
                    IsPersistent = false // RememberMe
				};
				HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsidentiy), authProperties);
                return RedirectToPage("/Index");
            }
            else
            {
                //login failed
                TempData["ErrorMessage"] = "Credentials did not match";
                return RedirectToPage("/Login");
            }
        }
    }
}
