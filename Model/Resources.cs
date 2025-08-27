namespace Model
{
    /// <summary>
    /// Represents a collection of various resources in the game.
    /// </summary>
    public struct Resources
    {
        // Basic resources
        public float Manpower;
        public float Credits;
        public float Ores;
        public float Foods;

        // Advanced resources
        public float Alloys;
        public float Fuel;

        // Rare resources
        public float RareMetals;
        public float Gases;
        public float Crystals;

        public Resources(
            float manpower = 0,
            float credits = 0,
            float ores = 0,
            float foods = 0,
            float alloys = 0,
            float fuel = 0,
            float rareMetals = 0,
            float gases = 0,
            float crystals = 0)
        {
            Manpower = manpower;
            Credits = credits;
            Ores = ores;
            Foods = foods;
            Alloys = alloys;
            Fuel = fuel;
            RareMetals = rareMetals;
            Gases = gases;
            Crystals = crystals;
        }

        public static Resources operator +(Resources a, Resources b)
        {
            return new Resources(
                a.Manpower + b.Manpower,
                a.Credits + b.Credits,
                a.Ores + b.Ores,
                a.Foods + b.Foods,
                a.Alloys + b.Alloys,
                a.Fuel + b.Fuel,
                a.RareMetals + b.RareMetals,
                a.Gases + b.Gases,
                a.Crystals + b.Crystals);
        }

        public static Resources operator -(Resources a, Resources b)
        {
            return new Resources(
                a.Manpower - b.Manpower,
                a.Credits - b.Credits,
                a.Ores - b.Ores,
                a.Foods - b.Foods,
                a.Alloys - b.Alloys,
                a.Fuel - b.Fuel,
                a.RareMetals - b.RareMetals,
                a.Gases - b.Gases,
                a.Crystals - b.Crystals);
        }

        public static Resources operator *(Resources a, float scalar)
        {
            return new Resources(
                a.Manpower * scalar,
                a.Credits * scalar,
                a.Ores * scalar,
                a.Foods * scalar,
                a.Alloys * scalar,
                a.Fuel * scalar,
                a.RareMetals * scalar,
                a.Gases * scalar,
                a.Crystals * scalar);
        }

        public void ApplyPercent(Resources percent)
        {
            Manpower    *= 1 + percent.Manpower;
            Credits     *= 1 + percent.Credits;
            Ores        *= 1 + percent.Ores;
            Foods       *= 1 + percent.Foods;
            Alloys      *= 1 + percent.Alloys;
            Fuel        *= 1 + percent.Fuel;
            RareMetals  *= 1 + percent.RareMetals;
            Gases       *= 1 + percent.Gases;
            Crystals    *= 1 + percent.Crystals;
        }

        public Resources GetWithPercent(Resources percent)
        {
            return new Resources
            {
                Manpower    = Manpower * (1 + percent.Manpower),
                Credits     = Credits * (1 + percent.Credits),
                Ores        = Ores * (1 + percent.Ores),
                Foods       = Foods * (1 + percent.Foods),
                Alloys      = Alloys * (1 + percent.Alloys),
                Fuel        = Fuel * (1 + percent.Fuel),
                RareMetals  = RareMetals * (1 + percent.RareMetals),
                Gases       = Gases * (1 + percent.Gases),
                Crystals    = Crystals * (1 + percent.Crystals)
            };
        }
    }
}
