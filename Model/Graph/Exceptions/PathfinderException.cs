namespace Model.Graph.Exceptions
{
    public class PathfinderException : GraphException
    {
        public PathfinderException() { }
        public PathfinderException(string message) : base(message) { }
    }
}
