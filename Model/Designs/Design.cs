namespace Model.Designs
{
    public class Design
    {
        public string Name { get; }
        public Module[] ModuleSlots { get; }
        public Design(string name, ushort modules)
        {
            Name = name;
            ModuleSlots = new Module[modules];
        }
    }
}
