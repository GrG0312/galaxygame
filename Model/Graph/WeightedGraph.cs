using Model.Graph.Exceptions;

namespace Model.Graph
{
    public class WeightedGraph<VertexType, EdgeType>
        where VertexType : IVertex<VertexType>
        where EdgeType : IEdge<VertexType>
    {
        protected Dictionary<VertexType, List<EdgeType>> adjacencyList;
        public IReadOnlyDictionary<VertexType, IReadOnlyList<EdgeType>> AdjacencyList => (IReadOnlyDictionary<VertexType, IReadOnlyList<EdgeType>>)adjacencyList;

        #region Constructors
        public WeightedGraph()
        {
            adjacencyList = new Dictionary<VertexType, List<EdgeType>>();
        }

        public WeightedGraph(Dictionary<VertexType, List<EdgeType>> adjacencyList)
        {
            this.adjacencyList = new Dictionary<VertexType, List<EdgeType>>(adjacencyList);
            VerifyGraph();
        }
        #endregion

        #region Add operations
        public void AddVertex(VertexType vertex)
        {
            if (!ContainsVertex(vertex))
            {
                adjacencyList[vertex] = new List<EdgeType>();
            }
        }

        public void AddEdge(EdgeType edge)
        {
            if (!ContainsVertex(edge.Vertex1, edge.Vertex2))
            {
                throw new GraphException("An endpoint vertex doesn't exist in the graph when adding new edge.");
            }
            adjacencyList[edge.Vertex1].Add(edge);
            adjacencyList[edge.Vertex2].Add(edge);
        }
        #endregion

        #region Contains operations
        public bool ContainsVertex(params VertexType[] vertices)
        {
            return vertices.All(vertex => adjacencyList.ContainsKey(vertex));
        }
        #endregion

        #region Remove operations
        public void RemoveVertex(VertexType vertex, bool forceRemove = false)
        {
            if (adjacencyList[vertex].Count == 0)
            {
                adjacencyList.Remove(vertex);
            } else
            {
                if (forceRemove)
                {
                    ForceRemoveEdgesWithVertex(vertex);
                }
                else throw new GraphException("Vertex still has connections. Remove connections before removing the vertex itself.");
            }
        }
        private void ForceRemoveEdgesWithVertex(VertexType vertex)
        {
            foreach (EdgeType edge in adjacencyList[vertex])
            {
                VertexType other = edge.GetOtherEnd(vertex);
                adjacencyList[other].Remove(edge);
            }
        }

        public void RemoveEdge(EdgeType edge)
        {
            adjacencyList[edge.Vertex1].Remove(edge);
            adjacencyList[edge.Vertex2].Remove(edge);
        }

        public void RemoveEdgesBetween(VertexType vertex1, VertexType vertex2)
        {
            List<EdgeType> edges = adjacencyList[vertex1].Where(edge => edge.GetOtherEnd(vertex1).Equals(vertex2)).ToList();
            foreach (EdgeType edge in edges)
            {
                adjacencyList[vertex1].Remove(edge);
                adjacencyList[vertex2].Remove(edge);
            }
        }
        #endregion

        #region Private
        private void VerifyGraph()
        {
            foreach (List<EdgeType> edgeList in adjacencyList.Values)
            {
                foreach (EdgeType edge in edgeList)
                {
                    if (!adjacencyList.ContainsKey(edge.Vertex1) || !adjacencyList.ContainsKey(edge.Vertex2))
                    {
                        throw new GraphException($"End-vertex of edge is not contained in the graph.");
                    }
                }
            }
        }
        #endregion
    }
}
