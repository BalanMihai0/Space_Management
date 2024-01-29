using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLibrary.SpaceClasses
{
    class WeightedGraph
    {
        private Dictionary<Satellite, List<Edge>> adjacencyList;

        public WeightedGraph()
        {
            adjacencyList = new Dictionary<Satellite, List<Edge>>();
        }

        public void AddEdge(Satellite source, Satellite destination)
        {
            double weight = CalculateDistance(source, destination);
            Edge edge = new Edge(destination, weight);

            if (adjacencyList.ContainsKey(source))
            {
                adjacencyList[source].Add(edge);
            }
            else
            {
                adjacencyList[source] = new List<Edge> { edge };
            }
        }

        public List<Satellite> GetAllSatellites()
        {
            return adjacencyList.Keys.ToList();
        }

        public List<Edge> GetNeighbors(Satellite satellite)
        {
            if (adjacencyList.ContainsKey(satellite))
            {
                return adjacencyList[satellite];
            }

            return new List<Edge>();
        }

        private double CalculateDistance(Satellite source, Satellite destination)
        {
            return OrbitCalculator.CalculateDistance(source, destination);
        }
    }
}
