using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SpaceLibrary;
using System.Collections.Generic;
using System.Numerics;

namespace SpaceLibraryTest
{
    [TestClass]
    public class SpaceManagerTests
    {
        private SpaceManager spaceManager;
        private Mock<ISpaceDataInterface> mockSpaceDataInterface;

        [TestInitialize]
        public void Initialize()
        {
            mockSpaceDataInterface = new Mock<ISpaceDataInterface>();
            spaceManager = new SpaceManager(mockSpaceDataInterface.Object);
        }

        [TestMethod]
        public void AddObject_Should_AddSpaceObjectToDataHandler()
        {
            // Arrange
            Satellite testSatellite = new Satellite(
                 model: "TestModel",
                 objective: "TestObjective",
                 launch: new Launch(),
                 manufacturer: "TestManufacturer",
                 name: "TestSatellite",
                 size: 1.0,
                 mass: 100.0,
                 position: new Vector3(1000, 0, 0),
                 velocity: new Vector3(0, 10, 0),
                 orientation: new Vector3(0, 0, 0),
                 orbitType: OrbitType.GEOSTATIONARY
             );

            // Set up the mock to return a list of satellites
            List<SpaceObject> mockSatellites = new List<SpaceObject> { testSatellite };
            mockSpaceDataInterface.Setup(m => m.GetAllSatellites()).Returns(mockSatellites);

            // Act
            spaceManager.AddObject(testSatellite);

            // Assert
            List<SpaceObject> allObjects = spaceManager.GetAllSatellites();
            CollectionAssert.Contains(allObjects, testSatellite);
        }

        [TestMethod]
        public void GetOrbitTypes_Should_ReturnListOfOrbitTypes()
        {
            // Act
            List<OrbitType> orbitTypes = spaceManager.GetOrbitTypes();

            // Assert
            Assert.IsNotNull(orbitTypes);
            Assert.AreEqual(5, orbitTypes.Count); 
        }

        [TestMethod]
        public void GetResearchTypes_Should_ReturnListOfResearchTypes()
        {
            // Act
            List<ResearchType> researchTypes = spaceManager.GetResearchTypes();

            // Assert
            Assert.IsNotNull(researchTypes);
            Assert.AreEqual(6, researchTypes.Count); 
        }

        [TestMethod]
        public void GetAllSatellites_Should_ReturnListOfSatellites()
        {
            // Arrange
            Satellite testSatellite = new Satellite(
                 model: "TestModel",
                 objective: "TestObjective",
                 launch: new Launch(),
                 manufacturer: "TestManufacturer",
                 name: "TestSatellite",
                 size: 1.0,
                 mass: 100.0,
                 position: new Vector3(1000, 0, 0),
                 velocity: new Vector3(0, 10, 0),
                 orientation: new Vector3(0, 0, 0),
                 orbitType: OrbitType.GEOSTATIONARY
             );
            Satellite testSatellite2 = new Satellite(
                 model: "TestModel2",
                 objective: "TestObjective",
                 launch: new Launch(),
                 manufacturer: "TestManufacturer",
                 name: "TestSatellite",
                 size: 1.0,
                 mass: 100.0,
                 position: new Vector3(1000, 0, 0),
                 velocity: new Vector3(0, 10, 0),
                 orientation: new Vector3(0, 0, 0),
                 orbitType: OrbitType.GEOSTATIONARY
             );
            var mockSatellites = new List<SpaceObject> { testSatellite, testSatellite };
            mockSpaceDataInterface.Setup(m => m.GetAllSatellites()).Returns(mockSatellites);

            // Act
            var satellites = spaceManager.GetAllSatellites();

            // Assert
            Assert.IsNotNull(satellites);
            Assert.AreEqual(2, satellites.Count);
        }

        [TestMethod]
        public void GetAllStations_Should_ReturnListOfStations()
        {
            // Arrange
            var mockStations = new List<SpaceObject>();
            Station testStation = new Station("a", ResearchType.MICROGRAVITY, "test", 10, 10, new Vector3(1, 1, 1), new Vector3(1, 1, 1), new Vector3(1, 1, 1), OrbitType.LOWEARTH);
            mockStations.Add(testStation);
            mockStations.Add(testStation);
            mockSpaceDataInterface.Setup(m => m.GetAllStations()).Returns(mockStations);

            // Act
            var stations = spaceManager.GetAllStations();

            // Assert
            Assert.IsNotNull(stations);
            Assert.AreEqual(2, stations.Count);
        }

        [TestMethod]
        public void GetAllDebris_Should_ReturnListOfDebris()
        {
            // Arrange
            var mockDebris = new List<SpaceObject>();
            Debris testDebris = new Debris(100, "A", 1000, 10, new Vector3(1,1,1), new Vector3(1,1,1),new Vector3(1,1,1), OrbitType.LOWEARTH);
            mockDebris.Add(testDebris);
            mockDebris.Add(testDebris);
            mockSpaceDataInterface.Setup(m => m.GetAllDebris()).Returns(mockDebris);

            // Act
            var debris = spaceManager.GetAllDebris();

            // Assert
            Assert.IsNotNull(debris);
            Assert.AreEqual(2, debris.Count);
        }

        [TestMethod]
        public void GetAllCommunications_Should_ReturnListOfCommunications()
        {
            // Arrange
            var mockSatellites = new List<SpaceObject>();
            Satellite testSatellite = new Satellite(
                 model: "TestModel",
                 objective: "Communication",
                 launch: new Launch(),
                 manufacturer: "TestManufacturer",
                 name: "TestSatellite",
                 size: 1.0,
                 mass: 100.0,
                 position: new Vector3(1000, 0, 0),
                 velocity: new Vector3(0, 10, 0),
                 orientation: new Vector3(0, 0, 0),
                 orbitType: OrbitType.GEOSTATIONARY
             );
            mockSatellites.Add(testSatellite);
            mockSatellites.Add(testSatellite);
            mockSpaceDataInterface.Setup(m => m.GetAllSatellites()).Returns(mockSatellites);

            // Act
            var communications = spaceManager.GetAllCommunications();

            // Assert
            Assert.IsNotNull(communications);
            Assert.AreEqual(2, communications.Count);
        }

        [TestMethod]
        public void SortObjectsAlphabetically_ShouldReturnSortedList()
        {
            // Arrange
            var spaceObjects = new List<SpaceObject>
        {
                new Satellite(
                 model: "TestModel",
                 objective: "TestObjective",
                 launch: new Launch(),
                 manufacturer: "TestManufacturer",
                 name: "ATestSatellite",
                 size: 1.0,
                 mass: 100.0,
                 position: new Vector3(1000, 0, 0),
                 velocity: new Vector3(0, 10, 0),
                 orientation: new Vector3(0, 0, 0),
                 orbitType: OrbitType.GEOSTATIONARY
             ),
            new Satellite(
                 model: "TestModel",
                 objective: "TestObjective",
                 launch: new Launch(),
                 manufacturer: "TestManufacturer",
                 name: "BTestSatellite",
                 size: 1.0,
                 mass: 100.0,
                 position: new Vector3(1000, 0, 0),
                 velocity: new Vector3(0, 10, 0),
                 orientation: new Vector3(0, 0, 0),
                 orbitType: OrbitType.GEOSTATIONARY
             )
        };

            // Act
            var sortedList = spaceManager.SortObjectsAlphabetically(spaceObjects);

            // Assert
            var expectedList = spaceObjects.OrderBy(s => s.Name).ToList();
            CollectionAssert.AreEqual(expectedList, sortedList);
        }

        [TestMethod]
        public void SearchSpaceObjects_ShouldReturnPartialMatch()
        {
            // Arrange
            string query = "AAA";
            var spaceObjects = new List<SpaceObject>
    {
        new Satellite(
            model: "TestModel",
            objective: "TestObjective",
            launch: new Launch(),
            manufacturer: "TestMnufcturer",
            name: "ATestSatellite",
            size: 1.0,
            mass: 100.0,
            position: new Vector3(1000, 0, 0),
            velocity: new Vector3(0, 10, 0),
            orientation: new Vector3(0, 0, 0),
            orbitType: OrbitType.GEOSTATIONARY
        ),
        new Satellite(
            model: "TestModel",
            objective: "TestObjective",
            launch: new Launch(),
            manufacturer: "TestMnufcturer",
            name: "BTestSatellite",
            size: 1.0,
            mass: 100.0,
            position: new Vector3(1000, 0, 0),
            velocity: new Vector3(0, 10, 0),
            orientation: new Vector3(0, 0, 0),
            orbitType: OrbitType.GEOSTATIONARY
        )
    };

            var mockSpaceDataInterface = new Mock<ISpaceDataInterface>();
            mockSpaceDataInterface.Setup(m => m.GetAllSatellites()).Returns(spaceObjects);

            // Act
            spaceManager.AddObject(spaceObjects[0]);
            spaceManager.AddObject(spaceObjects[1]);
            var searchResults = spaceManager.SearchSpaceObjects(query);

            // Assert
            Assert.AreEqual(0, searchResults.Count());
        }



    }
}
