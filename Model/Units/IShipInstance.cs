using Model.Designs;
using Model.Values;

namespace Model.Units
{
    public interface IShipInstance
    {
        public ShipStatistics InstanceStats { get; }
        public Design Design { get; }
        public Nation Nation { get; }
    }
}
