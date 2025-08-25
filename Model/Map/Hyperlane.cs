using Model.CodeComponents;
using Model.Graph;

namespace Model.Map
{
    public class Hyperlane : IEdge<Planet>
    {
        #region Local constants
        private static int MAX_SPEED => GameDefines.HYPERLANE_MAX_SPEED;
        private static int MIN_SPEED => GameDefines.HYPERLANE_MIN_SPEED;
        #endregion

        public Planet Vertex1 { get; }
        public Planet Vertex2 { get; }
        public int Speed { get; }

        public VisibilityComponent Visibility { get; private set; }

        public Hyperlane(Planet v1, Planet v2, int speed, HashSet<Nation>? visibility)
        {
            if (speed < MIN_SPEED || speed > MAX_SPEED)
            {
                throw new GameException($"Thrust must be between {MIN_SPEED} and {MAX_SPEED}");
            }
            Vertex1 = v1;
            Vertex2 = v2;
            Speed = speed;
            Visibility = new VisibilityComponent(visibility);
        }

        public Planet GetOtherEnd(Planet v)
        {
            if (Vertex1 == v)
            {
                return Vertex2;
            }
            else if (Vertex2 == v)
            {
                return Vertex1;
            }
            else
            {
                throw new GameException();
            }
        }
    }
}
