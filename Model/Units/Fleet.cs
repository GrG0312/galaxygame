using Model.Leaders;

namespace Model.Units
{
    public class Fleet
    {
        public Commander? MainLeader;
        public Commander SecondaryLeader;
        public Nation Nation { get; }
        public List<IShipInstance> Ships { get; }

        public Fleet(Nation nation, Commander? main = null)
        {
            Nation = nation;
            Ships = new List<IShipInstance>();
            MainLeader = main;

        }
    }
}
