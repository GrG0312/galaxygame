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
        PointDefense,
        Super
    }

    #region Base classes
    public abstract class DesignPart : NamedObject
    {
        protected DesignPart(string name) : base(name) { }
    }
    #endregion
}
