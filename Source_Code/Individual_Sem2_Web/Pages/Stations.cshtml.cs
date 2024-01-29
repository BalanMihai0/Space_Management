using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary;

namespace Individual_Sem2_Web.Pages

{
	[Authorize]
	public class StationsModel : PageModel
    {
		public List<SpaceObject>? stations { get; set; }

		public void OnGet()
        {
			stations = SpaceApp.Instance.SpaceManager.GetAllStations();
		}
    }
}
