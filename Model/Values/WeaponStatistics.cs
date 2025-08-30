namespace Model.Values
{
    /// <summary>
    /// Encapsulates various statistics related to a weapon's performance and characteristics.
    /// </summary>
    public struct WeaponStatistics : IEquatable<WeaponStatistics>
    {
        /// <summary>
        /// Damage dealt on hit, before applying critical multipliers or splash reductions.
        /// </summary>
        public float Damage;

        /// <summary>
        /// Represents the range of a value, such as a distance or measurement.
        /// </summary>
        public float Range;

        /// <summary>
        /// Chance to hit the target, from 0 (always miss) to 1 (always hit).
        /// </summary>
        public float Accuracy;

        /// <summary>
        /// Weapons decrease the ship's excess power. A ship cannot operate if its power is below zero.
        /// </summary>
        public float PowerConsumption;

        /// <summary>
        /// Represents the speed of the projectile in distance units per time unit.
        /// </summary>
        public float ProjectileSpeed;

        /// <summary>
        /// Radius of effect for splash damage, 0 for no splash
        /// </summary>
        public float SplashRadius;

        /// <summary>
        /// Chance for a hit to be critical, from 0 (never critical) to 1 (always critical). Critical hits deal damage and disable modules.
        /// </summary>
        public float CriticalChance;

        public WeaponStatistics(
            float damage = 0,
            float rateOfFire = 0,
            float range = 0,
            float accuracy = 1,
            float powerConsumption = 0,
            float projectileSpeed = 0,
            float splashRadius = 0,
            float criticalChance = 0)
        {
            Damage = damage;
            Range = range;
            Accuracy = accuracy;
            PowerConsumption = powerConsumption;
            ProjectileSpeed = projectileSpeed;
            SplashRadius = splashRadius;
            CriticalChance = criticalChance;
        }

        public readonly bool Equals(WeaponStatistics other)
        {
            return Damage == other.Damage &&
                   Range == other.Range &&
                   Accuracy == other.Accuracy &&
                   ProjectileSpeed == other.ProjectileSpeed &&
                   SplashRadius == other.SplashRadius &&
                   CriticalChance == other.CriticalChance;
        }

        public readonly override bool Equals(object? obj)
        {
            return obj is WeaponStatistics ws && Equals(ws);
        }

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(Damage, Range, Accuracy, ProjectileSpeed, SplashRadius, CriticalChance);
        }

        public static bool operator ==(WeaponStatistics left, WeaponStatistics right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(WeaponStatistics left, WeaponStatistics right)
        {
            return !left.Equals(right);
        }
    }
}
