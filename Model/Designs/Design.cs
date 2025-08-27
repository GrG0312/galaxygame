namespace Model.Designs
{
    /// <summary>
    /// <see cref="Design"/>s are created from <see cref="Blueprint"/>s. They represent a completed ship design ready for construction.
    /// </summary>
    public class Design : NamedObject
    {
        private readonly Blueprint _originalBlueprint;
        public DesignPart[] Components { get; }
        public Design(string name, Blueprint original, DesignPart[] components) : base(name)
        {
            Components = [..components];
            _originalBlueprint = original;
        }
    }
}
