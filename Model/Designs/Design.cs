namespace Model.Designs
{
    public class Design : NamedObject
    {
        public Module[] ModuleSlots { get; }
        public Design(string name, ushort modules) : base(name)
        {
            ModuleSlots = new Module[modules];
        }
    }
}
