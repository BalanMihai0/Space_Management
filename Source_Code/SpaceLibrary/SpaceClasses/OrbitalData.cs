
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

public class OrbitalData {

    private double semiMajorAxis;
    private double inclination;
    private double longitudeOfAscendingNode;
    private double trueAnomaly;
    private OrbitType orbitType;

    public OrbitalData(double semiMajorAxis, double inclination, double longitudeOfAscendingNode, double trueAnomaly, OrbitType orbitType) 
    {
        this.semiMajorAxis = semiMajorAxis;
        this.inclination = inclination;
        this.longitudeOfAscendingNode = longitudeOfAscendingNode;
        this.trueAnomaly = trueAnomaly;
        this.orbitType = orbitType;
    }

    public double SemiMajorAxis { get { return this.semiMajorAxis; } }
    public double Inclination { get {  return this.inclination; } }
    public double LongitudeOfAscendingNode { get {  return this.longitudeOfAscendingNode; } }
    public double TrueAnomaly { get { return this.trueAnomaly; } }
    public OrbitType OrbitType { get { return this.orbitType;} }    

}