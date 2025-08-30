using Model.Values;

namespace Model.Designs
{
    public enum DesignPartSize
    {
        Small,
        Medium,
        Large,
        Extra,
    }
    //public enum PartType
    //{
    //    Generator,
    //    Engine,
    //    Hyperdrive,
    //    Shield,
    //    Armor,
    //    Electrical,
    //    Special,
    //    Turret,
    //    Torpedo,
    //    Hangar,
    //    PointDefense,
    //    Super
    //}

    public abstract class DesignPart : NamedObject
    {
        public DesignPartSize Size { get; protected set; }
        protected DesignPart(string name, DesignPartSize size) : base(name)
        {
            Size = size;
        }
    }

    public abstract class StatPart<TStat> : DesignPart
    {
        public TStat Stats { get; protected set; }
        protected StatPart(string name, DesignPartSize size, TStat stats) : base(name, size)
        {
            Stats = stats;
        }
    }

    public class WeaponPart : StatPart<WeaponStatistics>
    {
        public WeaponPart(string name, DesignPartSize size, WeaponStatistics stats) : base(name, size, stats) { }
    }

    public class ShipPart : StatPart<ShipStatistics>
    {
        public ShipPart(string name, DesignPartSize size, ShipStatistics stats) : base(name, size, stats) { }
    }
}
