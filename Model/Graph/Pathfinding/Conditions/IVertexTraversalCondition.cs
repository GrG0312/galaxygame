namespace Model.Graph.Pathfinding.Conditions
{
    public interface IVertexTraversalCondition<V> : IVertex<V>
    {
        public bool CanTraverseVertex(V vertex);
    }
}
