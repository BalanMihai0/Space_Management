using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLibrary
{
    public interface ISpaceDataInterface
    {
        void AddSpaceObject(SpaceObject spaceObject);
        List<SpaceObject> GetAllSatellites();
        List<SpaceObject> GetAllStations();
        List<SpaceObject> GetAllDebris();

        void DeleteObject(SpaceObject spaceObject);

        void UpdateObject(string name,  SpaceObject spaceObject);

    }
}
