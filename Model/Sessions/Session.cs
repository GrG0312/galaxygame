using Model.Graph;
using Model.Map;

namespace Model.Sessions
{
    public class Session
    {
        public Random RandomGenerator { get; private set; }
        public WeightedGraph<Planet, Hyperlane> Map { get; private set; }
        public Dictionary<string, Nation> Nations { get; private set; }
        public Session(int randomSeed, Dictionary<string, Nation> nations, Dictionary<Planet, List<Hyperlane>> map)
        {
            RandomGenerator = new Random(randomSeed);
            Nations = new Dictionary<string, Nation>(nations);
            Map = new WeightedGraph<Planet, Hyperlane>(map);
        }
    }
}
