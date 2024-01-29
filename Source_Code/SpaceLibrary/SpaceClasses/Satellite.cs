
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

public class Satellite : SpaceObject {

    private string model;
    private string objective;
    private string manufacturer;
    private Launch launchData;
    private TelemetryData? telemetryData; 

    public Satellite(string model, string objective, Launch launch, string manufacturer, 
        string name, double size, double mass, Vector3 position, Vector3 velocity, Vector3 orientation, 
        OrbitType orbitType) : base(name, size, mass, position, velocity, orientation, orbitType)
    {
        this.model = model;
        this.objective = objective;
        this.manufacturer = manufacturer;
        this.launchData = launch;
        telemetryData = new TelemetryData(); //starts with telemetry optimal
        //other fields in base constructor
    }

    public Satellite(string model, string objective, Launch launch, string manufacturer,
        string name, double size, double mass, Vector3 position, Vector3 velocity, Vector3 orientation,
        OrbitType orbitType,double battery, double temperature,double hullIntegrity, double boardComputerHealth) : base(name, size, mass, position, velocity, orientation, orbitType)
    {
        this.model = model;
        this.objective = objective;
        this.manufacturer = manufacturer;
        this.launchData = launch;
        telemetryData = new TelemetryData(temperature, battery, hullIntegrity, boardComputerHealth);
    }

    public string Model { get { return this.model; } }   
    public string Objective { get {  return this.objective; } }
    public string Manufacturer { get {  return this.manufacturer; } }
    public Launch LaunchData { get { return this.launchData; } }

    public TelemetryData TelemetryData { get => this.telemetryData; }

    public override string ToString()
    {
        return $"{base.Name}: {this.Model} -- {this.GetType()}";
    }
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Satellite otherSatellite = (Satellite)obj;
        return this.Name == otherSatellite.Name && this.Position == otherSatellite.Position && this.Velocity == otherSatellite.Velocity;
    }
}