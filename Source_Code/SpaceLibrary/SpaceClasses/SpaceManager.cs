
using NUnit.Framework.Constraints;
using SpaceLibrary;
using SpaceLibrary.SpaceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace SpaceLibrary
{
    public class SpaceManager
    {

        private readonly ISpaceDataInterface _spaceDataHandler;
        private const int timeInterval = 5000; //one second bewteen updates

        public SpaceManager(ISpaceDataInterface dataStorage)
        {
            _spaceDataHandler = dataStorage;
        }
        
        public void AddObject(SpaceObject spaceObject)
        {
            _spaceDataHandler.AddSpaceObject(spaceObject);
        }
        public List<OrbitType> GetOrbitTypes()
        {
            List<OrbitType> orbitTypes = new List<OrbitType>();
            foreach (OrbitType type in Enum.GetValues(typeof(OrbitType)))
            {
                orbitTypes.Add(type);
            }
            return orbitTypes;
        }


        public List<ResearchType> GetResearchTypes()
        {
            List<ResearchType> types = new List<ResearchType>();
            foreach (ResearchType type in Enum.GetValues(typeof(ResearchType)))
            {
                types.Add(type);
            }
            return types;
        }

        public List<(SpaceObject, SpaceObject)> GetCollisions()
        {
            return OrbitCalculator.GetCollisions(GetAllObjects());
        }
        public List<SpaceObject> GetAllSatellites()
        {
            return _spaceDataHandler.GetAllSatellites();
        }
        public List<SpaceObject> GetAllStations()
        {
            return _spaceDataHandler.GetAllStations();
        }
        public List<SpaceObject> GetAllDebris()
        {
            return _spaceDataHandler.GetAllDebris();
        }

        public List<SpaceObject> GetAllObjects()
        {
            var satellites = _spaceDataHandler.GetAllSatellites()?.ToList() ?? new List<SpaceObject>();
            var stations = _spaceDataHandler.GetAllStations()?.ToList() ?? new List<SpaceObject>();
            var debris = _spaceDataHandler.GetAllDebris()?.ToList() ?? new List<SpaceObject>();
            return satellites.Concat(stations).Concat(debris).ToList();
        }

        public List<SpaceObject> GetAllCommunications()
            //returns satellites with communication objective
        {
            List<SpaceObject> temp = _spaceDataHandler.GetAllSatellites();
            List<SpaceObject> temp1 = new List<SpaceObject>();
            foreach (Satellite s in temp)
            {
                if(s.Objective.ToLower().Trim() == "communication" || s.Objective.ToLower().Trim() == "telecommunication")
                {
                    temp1.Add(s);
                }
            }
            return temp1;
        }

        public void DeleteObject(SpaceObject sp)
        {
            _spaceDataHandler.DeleteObject(sp);
        }

        public List<SpaceObject> SortObjectsAlphabetically(List<SpaceObject> initialList)
        {
            return initialList.OrderBy(s => s.Name).ToList(); //complexity O(n*log(n)), fastest consistent sorting in C#
        }

        public List<Satellite> SortSatellitesByLaunchDate(List<Satellite> satellites, bool OldToNew)
        {
            if (OldToNew)
            {
                return satellites.OrderBy(s => s.LaunchData.LaunchDate).ToList();
            }
            else
            {
                return satellites.OrderByDescending(s => s.LaunchData.LaunchDate).ToList();
            }
        }

        public List<SpaceObject> SearchSpaceObjects(string query)
        {
            
            return ObjectSearcher.GetSearchResults(query, this.GetAllObjects());
        }

        public List<Satellite> GetCommunicationPath(Satellite s1, Satellite s2)
        {
            List<SpaceObject> spaceObjects = GetAllCommunications();
            List<Satellite> satellites = spaceObjects.OfType<Satellite>().ToList();
            CommunicationCalculator comm = new CommunicationCalculator(satellites);
            return comm.GetShortestPath(s1, s2); 
        }

        public (double latitude, double longitude, double altitude, string name, string objectType) ConvertToGeographicCoordinates(SpaceObject sp)
        {
            return OrbitCalculator.ConvertToGeographicalCoordinates(sp);
        }
        
        // functions to display, search, filter, update

        public void EditObject(string name, SpaceObject sp)
        {
            _spaceDataHandler.UpdateObject(name, sp);
        }

        public SpaceObject GetObjectByName(string name)
        {
            List<SpaceObject> temp = SearchSpaceObjects(name);
            foreach (SpaceObject sp in temp)
            {
                if(sp.Name == name) //don't get a match for something else than name
                {
                    return sp;
                }
            }
            return null; //nothing found. should never get here
        }

        //time simulations: 

        public async void StartTimeFlow()
        {
            while (true)
            {
                //update event
                UpdateSpaceObjects();
                UpdateEvent?.Invoke(this, EventArgs.Empty);
                //waiting
                await Task.Delay(timeInterval);
            }
        }

        private void UpdateSpaceObjects()
        {
            List<SpaceObject> spaceObjects = this.GetAllObjects();
            foreach (SpaceObject spaceObject in spaceObjects)
            {
                Vector3 newPosition = OrbitCalculator.GetNewPosition(spaceObject.Position, spaceObject.Orientation, spaceObject.Velocity, timeInterval);
                if (spaceObject is Satellite s)
                { 
                    Satellite newSatellite = new Satellite(
                       s.Model,s.Objective,s.LaunchData,s.Manufacturer,s.Name, s.Size,s.Mass,newPosition,s.Velocity, s.Orientation,s.OrbitalData.OrbitType, s.TelemetryData.BatteryLevel,s.TelemetryData.Temperature,s.TelemetryData.HullIntegrity, s.TelemetryData.BoardComputerHealth);
                    EditObject(s.Name, newSatellite);
                }
                else if(spaceObject is Station st)
                {
                    Station newStation = new Station(
                        st.Model, st.ResearchType, st.Name, st.Size, st.Mass, newPosition, st.Velocity, st.Orientation, st.OrbitalData.OrbitType, st.TelemetryData.Temperature, st.TelemetryData.BatteryLevel, st.TelemetryData.BoardComputerHealth, st.TelemetryData.HullIntegrity);
                    EditObject(st.Name, newStation);
                }
                else if(spaceObject is Debris d)
                {
                    Debris newDebris = new Debris(
                        d.DangerRadius, d.Name, d.Size, d.Mass, newPosition, d.Velocity, d.Orientation, d.OrbitalData.OrbitType);
                    EditObject(d.Name, newDebris);
                }
            }
        }

        public event EventHandler UpdateEvent;

    }
}
