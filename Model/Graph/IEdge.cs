using Model.Graph.Exceptions;

namespace Model.Graph
{
    public interface IEdge<V> where V : IVertex<V>, IEquatable<V>
    {
        public V Vertex1 { get; }
        public V Vertex2 { get; }
        public int Speed { get; }
        public V GetOtherEnd(V other)
        {
            if (Vertex1.Equals(other))
            {
                return Vertex2;
            }
            else if (Vertex2.Equals(other))
            {
                return Vertex1;
            }
            else
            {
                throw new GraphException();
            }
        }
    }
}
