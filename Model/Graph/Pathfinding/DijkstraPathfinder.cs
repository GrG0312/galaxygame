using Model.Graph.Exceptions;
using Model.Graph.Pathfinding.Conditions;

namespace Model.Graph.Pathfinding
{
    public class DijkstraPathfinder<VertexType, EdgeType> : IPathfinder<VertexType, EdgeType>
        where VertexType : IVertex<VertexType>
        where EdgeType : IEdge<VertexType>
    {
        private WeightedGraph<VertexType, EdgeType> mapGraph;

        public DijkstraPathfinder(WeightedGraph<VertexType, EdgeType> weightedGraph)
        {
            mapGraph = weightedGraph;
        }

        public TravelPath<VertexType, EdgeType>? FindFastestPath(
            VertexType startLocation, 
            VertexType targetLocation, 
            IEdgeTraversalCondition<VertexType, EdgeType>[] edgeConditions, 
            IVertexTraversalCondition<VertexType>[] vertexConditions)
        {
            if (!mapGraph.ContainsVertex(startLocation, targetLocation))
            {
                throw new PathfinderException("Vertices are missing from graph, unable to plan route!");
            }

            Dictionary<VertexType, EdgeType> previousRoutes = new Dictionary<VertexType, EdgeType>();
            Dictionary<VertexType, int> distances = new Dictionary<VertexType, int>();
            PriorityQueue<VertexType, int> toBeChecked = new PriorityQueue<VertexType, int>();

            // Initialize distances
            foreach (VertexType vertex in mapGraph.AdjacencyList.Keys)
            {
                int initialDistance = vertex.Equals(startLocation) ? 0 : int.MaxValue;
                distances[vertex] = initialDistance;
                toBeChecked.Enqueue(vertex, initialDistance);
            }

            while (toBeChecked.Count > 0)
            {
                // Check the next vertex in PR Queue
                VertexType currentVertex = toBeChecked.Dequeue();
                if (currentVertex.Equals(targetLocation))
                {
                    break;
                }

                if (!vertexConditions.All(condition => condition.CanTraverseVertex(currentVertex)))
                {
                    continue;
                }

                foreach (EdgeType currentEdge in mapGraph.AdjacencyList[currentVertex])
                {
                    if (!edgeConditions.All(condition => condition.CanTraverseEdge(currentEdge)))
                    {
                        continue;
                    }

                    VertexType neighbor = currentEdge.GetOtherEnd(currentVertex);
                    int newDistance = distances[currentVertex] + currentEdge.Speed;

                    if (newDistance < distances[neighbor])
                    {
                        distances[neighbor] = newDistance;
                        previousRoutes[neighbor] = currentEdge;
                        toBeChecked.Enqueue(neighbor, newDistance);
                    }
                }
            }

            return ReconstructPath(previousRoutes, targetLocation);
        }

        private TravelPath<VertexType, EdgeType>? ReconstructPath(Dictionary<VertexType, EdgeType> previousRoutes, VertexType targetLocation)
        {
            List<EdgeType> path = new List<EdgeType>();
            if (!previousRoutes.ContainsKey(targetLocation)) return null;

            VertexType currentPlanet = targetLocation;
            while (previousRoutes.ContainsKey(currentPlanet))
            {
                EdgeType prev = previousRoutes[currentPlanet];
                path.Add(prev);
                currentPlanet = prev.GetOtherEnd(currentPlanet);
            }
            path.Add(previousRoutes[currentPlanet]);
            path.Reverse();
            return new TravelPath<VertexType, EdgeType>(path);
        }
    }
}
