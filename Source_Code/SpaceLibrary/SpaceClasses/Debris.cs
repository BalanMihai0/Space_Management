
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

public class Debris : SpaceObject {

    private double dangerRadius;
    private double v1;
    private string text;
    private double v2;
    private double v3;
    private Vector3 vector31;
    private Vector3 vector32;
    private Vector3 vector33;
    private object selectedItem;

    public Debris( double dangerRadius, string name, double size, double mass, Vector3 position, Vector3 velocity, Vector3 orientation, OrbitType orbitType) : base(name, size, mass, position, velocity, orientation, orbitType)
    {
        this.dangerRadius = dangerRadius;
    }

    public double DangerRadius { get => this.dangerRadius; }

    public override string ToString()
    {
        return $"{base.Name}: Danger Radius: {this.DangerRadius} -- {this.GetType()}";
    }
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Debris otherDebris = (Debris)obj;
        return this.Name == otherDebris.Name && this.Position == otherDebris.Position && this.Velocity == otherDebris.Velocity;
    }
}