using Model.Graph;
using Model.Map;

namespace Model.Sessions
{
    public class Session
    {
        public WeightedGraph<Planet, Hyperlane> Map { get; private set; }
        public Dictionary<string, Nation> Nations { get; private set; }

        public Session()
        {
            Map = new WeightedGraph<Planet, Hyperlane>();
            Nations = new Dictionary<string, Nation>();
        }
        public Session(Dictionary<string, Nation> nations, Dictionary<Planet, List<Hyperlane>> map)
        {
            Nations = new Dictionary<string, Nation>(nations);
            Map = new WeightedGraph<Planet, Hyperlane>(map);
        }
    }
}
