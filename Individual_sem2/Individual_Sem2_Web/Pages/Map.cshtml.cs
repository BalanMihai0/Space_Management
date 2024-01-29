using Individual_Sem2_Web.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary;
using System.Text.Json;

namespace Individual_Sem2_Web.Pages
{
    [Authorize]
    public class MapModel : PageModel
    {
        [BindProperty]
        public List<CoordinateSystem>? spaceObjectsGeo {get; set; }

        [BindProperty]
        public List<DrawOrbitDTO> spaceObjectsRaw { get; set; }
        public void OnGet()
        {
            List<SpaceObject> spaceObjectsInit = SpaceApp.Instance.SpaceManager.GetAllObjects();
            spaceObjectsGeo = new List<CoordinateSystem>();
            spaceObjectsRaw = new List<DrawOrbitDTO>();
            //convert to geo coorinates
            foreach (SpaceObject spaceObject in spaceObjectsInit)
            {
                spaceObjectsGeo.Add(SpaceApp.Instance.SpaceManager.ConvertToGeographicCoordinates(spaceObject));
                //move all data to orbit drawing
                spaceObjectsRaw.Add(new DrawOrbitDTO(spaceObject.Position, spaceObject.OrbitalData.SemiMajorAxis, 
                    spaceObject.OrbitalData.Inclination, spaceObject.OrbitalData.LongitudeOfAscendingNode, spaceObject.OrbitalData.TrueAnomaly,
                    spaceObject.GetType().Name));
            }
            
        }
    }

    public record struct CoordinateSystem(double Latitude, double Longitude, double Altitude, string name, string objectType)
    {
        public static implicit operator (double Latitude, double Longitude, double Altitude, string name, string objectType)(CoordinateSystem value)
        {
            return (value.Latitude, value.Longitude, value.Altitude, value.name, value.objectType);
        }

        public static implicit operator CoordinateSystem((double Latitude, double Longitude, double Altitude, string name, string objectType) value)
        {
            return new CoordinateSystem(value.Latitude, value.Longitude, value.Altitude, value.name, value.objectType);
        }
    }

    /* 
     const spaceObjectsRaw = @Html.Raw(Json.Serialize(Model.spaceObjectsRaw, new JsonSerializerSettings
        {
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        ContractResolver = new DefaultContractResolver
        {
        NamingStrategy = new CamelCaseNamingStrategy()
        }
        }));
     */
}
