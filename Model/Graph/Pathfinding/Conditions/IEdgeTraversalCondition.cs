namespace Model.Graph.Pathfinding.Conditions
{
    public interface IEdgeTraversalCondition<V, E> where E : IEdge<V> where V : IVertex<V>
    {
        public bool CanTraverseEdge(E edge);
    }
}
