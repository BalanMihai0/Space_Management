using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLibrary.SpaceClasses
{
    internal class CommunicationCalculator
    {
        private WeightedGraph graph;

        public CommunicationCalculator(List<Satellite> initials)
        {
            graph = new WeightedGraph();
            foreach (Satellite s1 in initials)
            {
                if (s1.Objective.ToLower().Trim() == "communication"  || s1.Objective.ToLower().Trim() == "telecommunication" )
                {
                    foreach (Satellite s2 in initials)
                    {
                        if (s1 != s2 && (s2.Objective.ToLower().Trim() == "communication" || s2.Objective.ToLower().Trim() == "telecommunication"))
                        {
                            graph.AddEdge(s1, s2);
                        }
                    }
                }
            }
        }

        public List<Satellite> GetShortestPath(Satellite source, Satellite destination)
        {
            Dictionary<Satellite, double> distances = new Dictionary<Satellite, double>();
            Dictionary<Satellite, Satellite> previous = new Dictionary<Satellite, Satellite>();
            List<Satellite> unvisited = new List<Satellite>();

            // Initialize 
            foreach (Satellite satellite in graph.GetAllSatellites())
            {
                distances[satellite] = double.MaxValue;
                previous[satellite] = null;
                unvisited.Add(satellite);
            }

            distances[source] = 0;

            while (unvisited.Count > 0)
            {
                Satellite current = GetClosestSatellite(distances, unvisited);
                unvisited.Remove(current);

                if (current == destination)
                {
                    break;  // reached the destination =>  exit the loop
                }

                List<Edge> neighbors = graph.GetNeighbors(current);

                foreach (Edge edge in neighbors)
                {
                    double distance = distances[current] + edge.Weight;
                    if (distance < distances[edge.Destination])
                    {
                        distances[edge.Destination] = distance;
                        previous[edge.Destination] = current;
                    }
                }
            }

            //shortest path
            List<Satellite> path = new List<Satellite>();
            Satellite currentSatellite = destination;

            while (currentSatellite != null)
            {
                path.Add(currentSatellite);
                currentSatellite = previous[currentSatellite];
            }

            path.Reverse();

            return path;
        }

        private Satellite GetClosestSatellite(Dictionary<Satellite, double> distances, List<Satellite> unvisited)
        {
            Satellite closestSatellite = null;
            double minDistance = double.MaxValue;

            foreach (Satellite satellite in unvisited)
            {
                if (distances[satellite] < minDistance)
                {
                    closestSatellite = satellite;
                    minDistance = distances[satellite];
                }
            }

            return closestSatellite;
        }

    }
}
