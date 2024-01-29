using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLibrary
{
    /// <summary>
    /// this class is used to generate the orbitalData of a SpaceObject subclass:
    /// this class assumes orbits to be circular
    /// the calculations will be done automatically upon creating the orbital data class
    /// (the convenience part of the app)
    /// </summary>
    public abstract class OrbitCalculator
    {
        private const double G = 6.67430e-11; // Gravitational constant ( m^3/kgs^2 )
        private const double M = 5.97237e24; // Mass of the Earth ( kg )
        private const double R = 6378.137; // Radius of Earth ( km )
        private const double RadiansToDegrees = 180/Math.PI; //for unit conversion

        private static double Magnitude(Vector3 v) // synonim: length
        {
            return Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
        }

        public static double CalculateSemiMajorAxis(Vector3 position, Vector3 velocity)
        {
            //the distance from Earth's Centre to the object in orbit
            return (Magnitude(position) + R);
        }

        public static double CalculateInclination(Vector3 normal)
        {
            // divide the vector by it's magnitude or length
            normal = Vector3.Normalize(normal); 
            // same as arccos(x)
            double i = Math.Acos(Vector3.Dot(normal, new Vector3(0, 1, 0)));
            return i;
        }

        public static double CalculateTrueAnomaly(Vector3 position)
        {
            // arctg(x), but returns the correct angle in all quadrants ( full range of angles)
            double trueAnomaly = Math.Atan2(position.Y, position.X);
            return trueAnomaly;
        }

        public static double CalculateLongitudeOfAscNode(Vector3 position1, Vector3 position2, double inclination)
        {
            Vector3 n = Vector3.Cross(new Vector3(0, 1, 0), position2 - position1);
            // divide the vector by it's magnitude or length
            n = Vector3.Normalize(n);
            // arctg(x), but returns the correct angle in all quadrants ( full range of angles)
            double O = Math.Atan2(n.Y, n.X);
            O = O - Math.PI / 2;
            if (O < 0)
            {
                O += 2 * Math.PI;
            }
            return O;
        }

        public static (double latitude, double longitude, double altitude, string name, string objectType) ConvertToGeographicalCoordinates(SpaceObject spaceObject)
        {
            Vector3 position = spaceObject.Position;
            Vector3 orientation = spaceObject.Orientation;
            Vector3 velocity = spaceObject.Velocity;

            double speed = velocity.Length();
            double radius = speed * speed / (2 * G * spaceObject.Mass); //vcp formula
            double altitude = radius - R;
            double latitude = Math.Asin(position.Z / position.Length()) * RadiansToDegrees;
            double longitude = Math.Atan2(position.Y, position.X) * RadiansToDegrees;

            // Geographical coordinates and altitude -- to be put in the map
            return (latitude, longitude, altitude, spaceObject.Name, spaceObject.GetType().ToString());
        }

        public static List<(SpaceObject, SpaceObject)> GetCollisions(List<SpaceObject> spaceObjects)
        {
            List<(SpaceObject, SpaceObject)> collisions = new List<(SpaceObject, SpaceObject)>();

            for (int i = 0; i < spaceObjects.Count - 1; i++)
            {
                for (int j = i + 1; j < spaceObjects.Count; j++)
                {
                    if (DoObjectsCollide(spaceObjects[i], spaceObjects[j]))
                    {
                        collisions.Add((spaceObjects[i], spaceObjects[j]));
                    }
                } 
            }

            return collisions;
        }

        private static bool DoObjectsCollide(SpaceObject obj1, SpaceObject obj2)
        {
            //check for same orbit type
            if (obj1.OrbitalData.OrbitType != obj2.OrbitalData.OrbitType)
            {
                return false;
            }

            //check distances
            double distance = Magnitude((obj1.Position - obj2.Position));
            if (distance > (obj1.Size + obj2.Size) * 2)
            {
                return false;
            }

            //check for the same time
            double timeToCollision = CalculateTimeToCollision(obj1, obj2);
            if (timeToCollision < 0)
            {
                return false;
            }

            return true;
        }

        private static double CalculateTimeToCollision(SpaceObject obj1, SpaceObject obj2)
        {
            double semiMajorAxis = obj1.OrbitalData.SemiMajorAxis;
            double trueAnomaly1 = obj1.OrbitalData.TrueAnomaly;
            double trueAnomaly2 = obj2.OrbitalData.TrueAnomaly;
            double angularVelocity1 = Math.Sqrt(G * obj1.Mass / Math.Pow(semiMajorAxis, 3));
            double angularVelocity2 = Math.Sqrt(G * obj2.Mass / Math.Pow(semiMajorAxis, 3));
            double timeToCollision = (trueAnomaly2 - trueAnomaly1) / (angularVelocity1 - angularVelocity2);
            return timeToCollision;
        }

        public static Vector3 GetNewPosition(Vector3 position1, Vector3 orientation1, Vector3 velocity1, int interval)
        {
            Vector3 newPosition = position1 + (velocity1 * interval);

            return newPosition;
        }

        public static double CalculateDistance(SpaceObject sp1, SpaceObject sp2)
        {
            return Math.Abs(Vector3.Distance(sp1.Position, sp2.Position));
        }
    }

}
