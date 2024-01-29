using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLibrary.SpaceClasses
{
    public class Edge
    {
        public Satellite Destination { get; }
        public double Weight { get; }

        public Edge(Satellite destination, double weight)
        {
            Destination = destination;
            Weight = weight;
        }
    }
}
