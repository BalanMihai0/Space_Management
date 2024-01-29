using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary;
using SpaceLibrary;

namespace Individual_Sem2_Web.Pages
{
    [Authorize]
    public class DetailsSattelliteModel : PageModel
    {

        [BindProperty]
        public List<(SpaceObject, SpaceObject)> Collisions { get; set; }
        [BindProperty]
        public Satellite SelectedSatellite { get; set; }

        public IActionResult OnGet(string name)
        {
            SelectedSatellite = (Satellite)SpaceApp.Instance.SpaceManager.GetObjectByName(name);
            Collisions = SpaceApp.Instance.SpaceManager.GetCollisions();

            if (SelectedSatellite == null)
            {
                return NotFound();
            }
            List<(SpaceObject, SpaceObject)> itemsToRemove = new List<(SpaceObject, SpaceObject)>();

            foreach ((SpaceObject, SpaceObject) c in Collisions)
            {
                if (!(c.Item1.Equals(SelectedSatellite) || c.Item2.Equals(SelectedSatellite)))//collision does not contain the selected object
                {
                    itemsToRemove.Add(c);
                }
            }

            foreach ((SpaceObject, SpaceObject) c in itemsToRemove)
            {
                Collisions.Remove(c);
            }


            return Page();
        }
    }
}
