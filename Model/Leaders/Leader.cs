namespace Model.Leaders
{
    public class Leader : NamedObject
    {
        public ushort Level { get; protected set; }
        public float Experience { get; protected set; }
        protected Leader(string name, ushort level = 1, float experience = 0) : base(name)
        {
            Level = level;
            Experience = experience;
        }
    }

    public class Commander : Leader
    {
        public uint ShipLimit { get; protected set; }

        public Commander(string name, ushort level = 1, float experience = 0, uint shipLimit = 3) : base(name, level, experience)
        {
            ShipLimit = shipLimit;
        }
    }
}
