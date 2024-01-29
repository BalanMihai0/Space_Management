using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary;

namespace Individual_Sem2_Web.Pages
{
    [Authorize]
    public class DetailsDebrisModel : PageModel
    {

		[BindProperty]
		public Debris SelectedDebris { get; set; } //lazy renaming

		[BindProperty]
		public List<(SpaceObject,SpaceObject)> Collisions { get; set; }

		public IActionResult OnGet(string name)
		{
			SelectedDebris = (Debris)SpaceApp.Instance.SpaceManager.GetObjectByName(name);
			Collisions = SpaceApp.Instance.SpaceManager.GetCollisions();

			if (SelectedDebris == null)
			{
				return NotFound();
			}
            List<(SpaceObject, SpaceObject)> itemsToRemove = new List<(SpaceObject, SpaceObject)>();

            foreach ((SpaceObject, SpaceObject) c in Collisions)
            {
                if (!(c.Item1.Equals(SelectedDebris) || c.Item2.Equals(SelectedDebris)))//collision does not contain the selected object
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
