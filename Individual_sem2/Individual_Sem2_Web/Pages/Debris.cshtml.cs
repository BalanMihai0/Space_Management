using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary;

namespace Individual_Sem2_Web.Pages
{
    [Authorize]
    public class DebrisModel : PageModel
    {
		public List<SpaceObject>? debrisList { get; set; }
		public void OnGet()
        {
			debrisList = SpaceApp.Instance.SpaceManager.GetAllDebris();
		}
    }
}
