using Model.Interfaces;

namespace Model.Designs
{
    public enum DesignComponentType
    {
        Generator,
        Engine,
        Hyperdrive,
        Shield,
        Armor,
        Electrical,
        Special,
        Turret,
        Torpedo,
        Hangar,
        PointDefence,
        Super
    }

    #region Base classes
    public abstract class DesignComponent : NamedObject
    {
        protected DesignComponent(string name) : base(name) { }
    }

    public abstract class CostedComponent : DesignComponent, IHasCost
    {
        public int Cost { get; }
        protected CostedComponent(string name, int cost) : base(name)
        {
            Cost = cost;
        }
    }
    #endregion

    #region Ship default components
    public class GeneratorComponent : CostedComponent, IHasPower
    {
        public int Power { get; }
        public GeneratorComponent(string name, int cost, int powerOutput) : base(name, cost)
        {
            Power = powerOutput;
        }
    }

    public class GeneratorBoostComponent : DesignComponent
    {
        public GeneratorBoostComponent(string name) : base(name) { }
    }

    public class EngineComponent : CostedComponent, IHasSpeed
    {
        public int Speed { get; }
        public EngineComponent(string name, int cost, int speed) : base(name, cost)
        {
            Speed = speed;
        }
    }

    public class HyperdriveComponent : CostedComponent, IHasHyperSpeed
    {
        public int HyperSpeed { get; }
        public HyperdriveComponent(string name, int cost, int hspeed) : base(name, cost)
        {
            HyperSpeed = hspeed;
        }
    }

    public class ShieldComponent : CostedComponent, IHasShield
    {
        public int Shield { get; }
        public ShieldComponent(string name, int cost, int shield) : base(name, cost)
        {
            Shield = shield;
        }
    }

    public class ArmorComponent : CostedComponent, IHasArmor
    {
        public int Armor { get; }
        public ArmorComponent(string name, int cost, int armor) : base(name, cost)
        {
            Armor = armor;
        }
    }

    public class ElectricalComponent : CostedComponent
    {
        public ElectricalComponent(string name, int cost) : base(name, cost) { }
    }
    #endregion

}
