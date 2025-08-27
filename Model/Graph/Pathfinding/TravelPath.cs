namespace Model.Graph.Pathfinding
{
    public class TravelPath<VertexType, EdgeType> where VertexType : IVertex<VertexType> where EdgeType : IEdge<VertexType>
    {
        public List<EdgeType> EdgesToTravel;
        public int TotalCost { get; }

        public TravelPath(List<EdgeType> edges)
        {
            EdgesToTravel = new List<EdgeType>(edges);
            TotalCost = EdgesToTravel.Sum(edge => edge.Rank);
        }
    }
}
