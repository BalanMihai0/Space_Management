using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Individual_Sem2_Web.Pages
{
    public class SignOutModel : PageModel
    {
        public IActionResult OnGet()
        {
            Response.Headers.Add("X-Logout-Successful", "true");
            HttpContext.SignOutAsync();
            return RedirectToPage("/Index");
        }
    }
}
