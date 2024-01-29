using System.Numerics;

namespace Individual_Sem2_Web.DTOs
{
    public class DrawOrbitDTO
    {
        
        public Vector3 Position { get; set; }
        public double SemiMajorAxis { get; set; }
        public double Inclination { get; set; }
        public double LongitudeOfAscendingNode { get; set; }
        public double TrueAnomaly { get; set; }
        public string ObjectType { get; set; }

        public DrawOrbitDTO(Vector3 position, double semiMajorAxis, double inclination, double longitudeOfAscendingNode, double trueAnomaly, string objectType)
        {
            Position = position;
            SemiMajorAxis = semiMajorAxis;
            Inclination = inclination;
            LongitudeOfAscendingNode = longitudeOfAscendingNode;
            TrueAnomaly = trueAnomaly;
            ObjectType = objectType;
        }
    }
}
