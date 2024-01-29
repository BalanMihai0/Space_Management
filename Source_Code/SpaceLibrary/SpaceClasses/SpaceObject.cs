
using SpaceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

public abstract class SpaceObject {

    private string name;
    private double size;
    private double mass;
    private Vector3 position;
    private Vector3 velocity;
    private Vector3 orientation;
    private OrbitalData orbitalData;

    //used when first constructing objects
    public SpaceObject(string name, double size, double mass, Vector3 position, Vector3 velocity, Vector3 orientation, OrbitType orbitType)
    {
        this.name = name;
        this.size = size;
        this.mass = mass;
        this.position = position;
        this.velocity = velocity;
        this.orientation = orientation;
        orbitalData = new OrbitalData(
            OrbitCalculator.CalculateSemiMajorAxis(this.position, this.velocity),
            OrbitCalculator.CalculateInclination(position),
            OrbitCalculator.CalculateLongitudeOfAscNode(position, velocity, OrbitCalculator.CalculateInclination(position)),
            OrbitCalculator.CalculateTrueAnomaly(position),
            orbitType);

    }

    /// <summary>
    /// the properties have public getters, even though some may be unused.
    /// setters are protected so only subclasses can access them
    /// </summary>

    #region Properties
    public string Name{ get { return this.name; } protected set {this.name = value; } }
    public double Size { get { return this.size; } protected set { this.size = value; } }
    public double Mass { get { return this.mass; } protected set { this.mass = value; } }
    public Vector3 Position { get { return this.position; } protected set { this.position = value; } }
    public Vector3 Velocity { get { return this.velocity; } protected set { this.velocity = value; } }
    public Vector3 Orientation { get { return this.orientation; } protected set { this.orientation = value; } }
    public OrbitalData OrbitalData {  get { return this.orbitalData;} }
    #endregion
}