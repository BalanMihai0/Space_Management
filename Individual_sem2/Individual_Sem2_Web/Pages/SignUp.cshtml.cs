using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserLibrary;
using DataLibrary;
using SpaceLibrary;
using SharedLibrary;
using System.Runtime.CompilerServices;
using Individual_Sem2_Web.DTOs;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Individual_Sem2_Web.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly ILogger<SignUpModel> _logger;
        [BindProperty]
        public CreateGuestDTO guestToRegister { get; set; }

        public SignUpModel(ILogger<SignUpModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            try
            {
                if (!ModelState.IsValid) { return Page(); }
                else
                {
                    SpaceApp.Instance.UserManager.AddGuest(guestToRegister.FirstName, guestToRegister.LastName, guestToRegister.Password, guestToRegister.Email, guestToRegister.Birthdate, guestToRegister.ProfilePictureURL);
                    TempData.Remove("WarningMessage"); //if exists
                    return RedirectToPage("Login");
                }
            }
            catch(Exception ex)
            { 
                TempData["WarningMessage"] = ex.Message;
                TempData.Keep("WarningMessage");
                return Page();
            }
        }

    }
}
