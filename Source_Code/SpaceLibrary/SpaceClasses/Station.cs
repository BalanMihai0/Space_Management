
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

public class Station : SpaceObject {

    private string model;
    private ResearchType researchType;
    private TelemetryData telemetryData;

    public Station(string model, ResearchType researchType,string name, double size, double mass, Vector3 position, Vector3 velocity, Vector3 orientation, OrbitType orbitType) : base(name, size, mass, position, velocity, orientation, orbitType)
    {
        //for new station, all telemetry good - default
        this.model = model;
        this.researchType = researchType;
        telemetryData = new TelemetryData();
    }
    public Station(string model, ResearchType researchType, string name, double size, 
        double mass, Vector3 position, Vector3 velocity, Vector3 orientation, 
        OrbitType orbitType, double temperature, double batteryLevel, double boardComputerHealth, double hullIntegrity) : base(name, size, mass, position, velocity, orientation, orbitType)
    {
        //for retrieving pre-existing station
        this.model = model;
        this.researchType = researchType;
        telemetryData = new TelemetryData(temperature, batteryLevel, hullIntegrity, boardComputerHealth);
    }

    public string Model { get => this.model; }
    public ResearchType ResearchType { get => this.researchType;}
    public TelemetryData TelemetryData { get => this.telemetryData; }

    public override string ToString()
    {
        return $"{base.Name}:{this.model} -- {this.GetType()}";
    }
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Station otherStation = (Station)obj;
        return this.Name == otherStation.Name && this.Position == otherStation.Position && this.Velocity == otherStation.Velocity;
    }
}