using System.Numerics;

namespace Models
{
    /// <summary>
    /// used for connecting shared library to frontend, displaying and taking inputs
    /// classes named '_Model' can be accessed in the frontend of the application
    /// operations are done using the ShareLibrary
    /// </summary>
    public class SpaceObject_Model
    {
        public string Name { get; set; }
        public double Mass { get; set; }
        public double Size { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Velocity { get; set; }
        public Vector3 Orientation { get; set; }

        public OrbitalData_Model OrbitalData { get; set; }

        public SpaceObject_Model() { }
    }
}