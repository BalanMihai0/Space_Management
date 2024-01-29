using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceLibrary;
using System.Numerics;

namespace SpaceLibraryTest
{
    [TestClass]
    public class OrbitCalculatorTests
    {
        [TestMethod]
        public void CalculateSemiMajorAxis_ReturnsExpectedValue()
        {
            var position = new Vector3(1000, 2000, 3000);
            var velocity = new Vector3(10, 20, 30);
            var expected = 10119.794386773941; 
            var result = OrbitCalculator.CalculateSemiMajorAxis(position, velocity);

            Assert.AreEqual(expected, result, 0.001);
        }

        [TestMethod]
        public void CalculateInclination_ReturnsExpectedValue()
        {
            var normal = new Vector3(1, 2, 3);
            var expected = 1.006853697281508; 
            var result = OrbitCalculator.CalculateInclination(normal);

            Assert.AreEqual(expected, result, 0.0000001);
        }

        [TestMethod]
        public void CalculateTrueAnomaly_ReturnsExpectedValue()
        {
            var position = new Vector3(1000, 2000, 3000);
            var expected = 1.1071487177940904; 
            var result = OrbitCalculator.CalculateTrueAnomaly(position);

            Assert.AreEqual(expected, result, 0.0000001);
        }

        [TestMethod]
        public void CalculateLongitudeOfAscNode_ReturnsExpectedValue()
        {
            // Arrange
            var position1 = new Vector3(1000, 2000, 3000);
            var position2 = new Vector3(-1000, 2000, 3000);
            var inclination = 0.7853981633974483; // 45 degrees in radians
            var expected = 4.712388980384469; // pi radians
            var result = OrbitCalculator.CalculateLongitudeOfAscNode(position1, position2, inclination);

            Assert.AreEqual(expected, result, 0.0000001);
        }

        [TestMethod]
        public void ConvertToGeographicalCoordinates_ReturnsExpectedValues()
        {
            Satellite satellite = new Satellite(
                "SatelliteModel", "Observation", new Launch(), "Manufacturer",
                "SatelliteName", 100, 1000, new Vector3(10000, 0, 0), new Vector3(0, 5000, 0), new Vector3(0, 1, 0),
                OrbitType.LOWEARTH);

            var expected = (0, 0, 187285558029670.62); 

            var result = OrbitCalculator.ConvertToGeographicalCoordinates(satellite);

            Assert.AreEqual(expected.Item1, result.latitude, 0.0000001);
            Assert.AreEqual(expected.Item2, result.longitude, 0.0000001);
            Assert.AreEqual(expected.Item3, result.altitude, 0.0000001);
        }
    }
}