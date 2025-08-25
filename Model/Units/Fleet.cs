namespace Model.Units
{
    public class Fleet
    {
        protected List<Ship> ships;
        public IReadOnlyList<Ship> Ships => ships.AsReadOnly();

        public Fleet()
        {
            ships = new List<Ship>();
        }
        public void AddShip(Ship ship)
        {
            ships.Add(ship);
        }
    }
}
