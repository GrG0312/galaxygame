using Model.Graph.Pathfinding.Conditions;

namespace Model.Graph.Pathfinding
{
    public interface IPathfinder<V, E> where V : IVertex<V> where E : IEdge<V>
    {
        public TravelPath<V, E>? FindFastestPath(
            V startLocation, 
            V targetLocation, 
            IEdgeTraversalCondition<V, E>[] edgeConditions, 
            IVertexTraversalCondition<V>[] vertexConditions);
    }
}
