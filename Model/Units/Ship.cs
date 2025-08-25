using Model.Designs;

namespace Model.Units
{
    public class Ship
    {
        public Design Design { get; }

        public Ship(Design design)
        {
            Design = design;
        }
    }
}
