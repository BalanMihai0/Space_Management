using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary;

namespace Individual_Sem2_Web.Pages
{
    [Authorize]
    public class SatellitesModel : PageModel
    {
        public List<SpaceObject>? satellites { get; set; }
        public void OnGet()
        {
            satellites = SpaceApp.Instance.SpaceManager.GetAllSatellites();
        }
    }
}
