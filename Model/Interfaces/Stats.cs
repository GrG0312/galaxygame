namespace Model.Interfaces
{
    public interface IHasCost
    {
        public int Cost { get; }
    }
    public interface IHasPower
    {
        public int Power { get; }
    }
    public interface IHasHyperSpeed
    {
        public int HyperSpeed { get; }
    }
    public interface IHasSpeed
    {
        public int Speed { get; }
    }
    public interface IHasShield
    {
        public int Shield { get; }
    }
    public interface IHasArmor
    {
        public int Armor { get; }
    }
}
