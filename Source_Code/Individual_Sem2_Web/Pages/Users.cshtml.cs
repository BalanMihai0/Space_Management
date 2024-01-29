using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary;

namespace Individual_Sem2_Web.Pages
{
    [Authorize]
    public class UsersModel : PageModel
    {
        [BindProperty]
        public List<User> Users { get; set; }

        public void OnGet()
        {
            //load wanted users
            Users = SpaceApp.Instance.UserManager.GetAllUsers();

        }
    }
}
