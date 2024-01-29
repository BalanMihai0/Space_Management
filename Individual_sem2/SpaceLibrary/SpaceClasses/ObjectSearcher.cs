using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLibrary.SpaceClasses
{
    /// <summary>
    /// returns results: full matches, partial matches; takes into account typos( e.g. query larger than the name)
    /// </summary>
    public abstract class ObjectSearcher
    {
        public static List<SpaceObject> GetSearchResults(string query, List<SpaceObject> allSpaceObjects)
        {
            List<SpaceObject> searchResults = new List<SpaceObject>();

            foreach (SpaceObject obj in allSpaceObjects)
            {
                if (obj.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
                {
                    searchResults.Add(obj);
                }
                else if (obj.GetType() == typeof(Satellite))
                {
                    Satellite sat = (Satellite)obj;
                    if (sat.Objective.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                        sat.Manufacturer.Contains(query, StringComparison.OrdinalIgnoreCase))
                    {
                        searchResults.Add(sat);
                    }
                }
                else if (obj.GetType() == typeof(Station))
                {
                    Station st = (Station)obj;
                    if (st.Model.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                        st.ResearchType.ToString().Contains(query, StringComparison.OrdinalIgnoreCase))
                    {
                        searchResults.Add(st);
                    }
                }
            }
            return searchResults;
        }
    }
}
