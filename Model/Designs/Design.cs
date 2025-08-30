namespace Model.Designs
{
    /// <summary>
    /// <see cref="Design"/>s are created from <see cref="Designs.Blueprint"/>s. They represent a completed ship design ready for construction.
    /// </summary>
    public class Design : NamedObject
    {
        public Blueprint Blueprint { get; }
        public DesignPart[] Components { get; }
        public Design(string name, Blueprint original, DesignPart[] components) : base(name)
        {
            Components = [..components];
            Blueprint = original;
        }
    }
}
