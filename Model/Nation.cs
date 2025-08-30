using Model.Leaders;
using Model.Units;

namespace Model
{
    public class Nation : NamedObject
    {
        public string Adjective { get; protected set; }
        public readonly List<Fleet> Fleets;
        public readonly List<Leader> Leaders;

        public Nation(string name, string adjective) : base(name)
        {
            Adjective = adjective;
            Fleets = new List<Fleet>();
            Leaders = new List<Leader>();
        }
    }
}