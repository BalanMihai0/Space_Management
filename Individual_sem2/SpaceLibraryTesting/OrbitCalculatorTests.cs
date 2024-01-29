using NUnit.Framework;
using SpaceLibrary;
using System.Numerics;

[TestFixture]
public class OrbitCalculatorTests
{
    [Test]
    public void CalculateSemiMajorAxis_ReturnsExpectedValue()
    {
        var position = new Vector3(1000, 2000, 3000);
        var velocity = new Vector3(10, 20, 30);
        var expected = 8382.137; // calculated value
        var result = OrbitCalculator.CalculateSemiMajorAxis(position, velocity);

        Assert.That(result, Is.EqualTo(expected).Within(0.001));
    }

    [Test]
    public void CalculateInclination_ReturnsExpectedValue()
    {

        var normal = new Vector3(1, 2, 3);
        var expected = 1.2309594; // calculated value
        var result = OrbitCalculator.CalculateInclination(normal);


        Assert.That(result, Is.EqualTo(expected).Within(0.0000001));
    }

    [Test]
    public void CalculateTrueAnomaly_ReturnsExpectedValue()
    {
        var position = new Vector3(1000, 2000, 3000);
        var expected = 1.1071487177940904; // calculated value
        var result = OrbitCalculator.CalculateTrueAnomaly(position);


        Assert.That(result, Is.EqualTo(expected).Within(0.0000001));
    }

    [Test]
    public void CalculateLongitudeOfAscNode_ReturnsExpectedValue()
    {
        // Arrange
        var position1 = new Vector3(1000, 2000, 3000);
        var position2 = new Vector3(-1000, 2000, 3000);
        var inclination = 0.7853981633974483; // 45 degrees in radians
        var expected = 3.141592653589793; // pi radians
        var result = OrbitCalculator.CalculateLongitudeOfAscNode(position1, position2, inclination);

        Assert.That(result, Is.EqualTo(expected).Within(0.0000001));
    }

    [Test]
    public void ConvertToGeographicalCoordinates_ReturnsExpectedValues()
    {
        Satellite satellite = new Satellite(
            "SatelliteModel", "Observation", new Launch(), "Manufacturer",
            "SatelliteName", 100, 1000, new Vector3(10000, 0, 0), new Vector3(0, 5000, 0), new Vector3(0, 1, 0),
            OrbitType.LOWEARTH);

        var expected = (37.484450747329255, 63.43494882292201, 2976.107398155834); // calculated values

        var result = OrbitCalculator.ConvertToGeographicalCoordinates(satellite);

        Assert.That(result.latitude, Is.EqualTo(expected.Item1).Within(0.0000001));
        Assert.That(result.longitude, Is.EqualTo(expected.Item2).Within(0.0000001));
        Assert.That(result.altitude, Is.EqualTo(expected.Item3).Within(0.0000001));
    }
}
