using Model.CodeComponents.PlanetComponents;
using Model.Graph;

namespace Model.Map
{
    public class Hyperlane : IEdge<Planet>
    {
        #region Constants
        public const ushort MIN_RANK = 1;
        public const ushort MAX_RANK = 3;
        #endregion

        public Planet Vertex1 { get; }
        public Planet Vertex2 { get; }
        public ushort Rank { get; }

        public VisibilityComponent Visibility { get; private set; }

        public Hyperlane(Planet v1, Planet v2, ushort rank, HashSet<Nation>? visibility)
        {
            if (rank < MIN_RANK || rank > MAX_RANK)
            {
                throw new GameException($"Rank of hyperlane must be between {MIN_RANK} and {MAX_RANK}");
            }
            Vertex1 = v1;
            Vertex2 = v2;
            Rank = rank;
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
