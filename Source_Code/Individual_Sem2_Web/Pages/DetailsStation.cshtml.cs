using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary;

namespace Individual_Sem2_Web.Pages
{
    [Authorize]
    public class DetailsStationModel : PageModel
    {

        [BindProperty]
        public List<(SpaceObject, SpaceObject)> Collisions { get; set; }
        [BindProperty]
		public Station SelectedStation { get; set; } 

		public IActionResult OnGet(string name)
		{
			SelectedStation = (Station)SpaceApp.Instance.SpaceManager.GetObjectByName(name);
            Collisions = SpaceApp.Instance.SpaceManager.GetCollisions();

            if (SelectedStation == null)
			{
				return NotFound();
			}
            //remove objects that do not contain Station
            List<(SpaceObject, SpaceObject)> itemsToRemove = new List<(SpaceObject, SpaceObject)>();

            foreach ((SpaceObject, SpaceObject) c in Collisions)
            {
                if (!(c.Item1.Equals(SelectedStation) || c.Item2.Equals(SelectedStation)))//collision does not contain the selected object
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
