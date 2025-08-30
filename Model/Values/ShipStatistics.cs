namespace Model.Values
{
    /// <summary>
    /// Encapsulates various statistics related to a ship performance and characteristics.
    /// </summary>
    public struct ShipStatistics
    {
        #region General statistics

        /// <summary>
        /// Size of the ship. Determines categorization options and affects some other statistics.
        /// </summary>
        public float Size;

        /// <summary>
        /// Power of the ship.
        /// </summary>
        public float Power;

        /// <summary>
        /// Rank of the ship in normal space.
        /// </summary>
        public float Speed;

        /// <summary>
        /// Rank of the ship in hyper space. Determined by the hyperdrive installed.
        /// </summary>
        public ushort HyperSpeed;

        /// <summary>
        /// How much cargo (ground troops) the ship can carry. Primarily based on ship size.
        /// </summary>
        public float CargoCapacity;
        #endregion

        #region Defensive statistics
        /// <summary>
        /// Strength of the installed shields.
        /// </summary>
        public float Shield;

        /// <summary>
        /// Strength of the installed armor.
        /// </summary>
        public float Armor;

        /// <summary>
        /// Defense against missiles and torpedoes.
        /// </summary>
        public float PointDefense;

        /// <summary>
        /// Defense against aircraft.
        /// </summary>
        public float FlaK;
        #endregion
    }
}
