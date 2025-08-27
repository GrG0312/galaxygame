using System.Diagnostics.CodeAnalysis;

namespace Model
{
    /// <summary>
    /// Encapsulates statistics related to a turret. A turret can mount a weapon, can have multiple barrels, and can be grouped with other turrets of the same type.
    /// </summary>
    public struct TurretStatistics : IEquatable<TurretStatistics>
    {
        /// <summary>
        /// Turrets with the same characteristics can be grouped together to save on processing.
        /// </summary>
        public uint Amount;

        /// <summary>
        /// How many barrels the turret supports. Esentially a multiplier for the <b>InstalledWeapon</b>'s certain statistics.
        /// </summary>
        public uint Barrels;

        /// <summary>
        /// Resilience against critical hits, from 0 to 1. Multiplies enemy crit chance. A critical hit knocks out the turret until repaired.
        /// </summary>
        public float Resilience;

        /// <summary>
        /// What weapon is installed in the turret.
        /// </summary>
        public WeaponStatistics InstalledWeapon;

        public TurretStatistics(
            uint amount = 1,
            uint barrels = 1,
            float resilience = 0,
            WeaponStatistics installedWeapon = default)
        {
            Amount = amount;
            Barrels = barrels;
            Resilience = resilience;
            InstalledWeapon = installedWeapon;
        }

        public readonly bool Equals(TurretStatistics other)
        {
            return Amount == other.Amount &&
                   Barrels == other.Barrels &&
                   Resilience == other.Resilience &&
                   InstalledWeapon.Equals(other.InstalledWeapon);
        }

        public override readonly bool Equals(object? obj)
        {
            return obj is TurretStatistics ts && Equals(ts);
        }

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(Amount, Barrels, Resilience, InstalledWeapon.GetHashCode());
        }

        public static bool operator ==(TurretStatistics left, TurretStatistics right) => left.Equals(right);
        public static bool operator !=(TurretStatistics left, TurretStatistics right) => !left.Equals(right);
        public static TurretStatistics operator +(TurretStatistics left, TurretStatistics right)
        {
            if (left.InstalledWeapon != right.InstalledWeapon)
            {
                throw new GameException("Cannot group turrets together with different mounted weapons.");
            }
            return new TurretStatistics(left.Amount + right.Amount, left.Barrels, left.Resilience, left.InstalledWeapon);
        }
    }
}
