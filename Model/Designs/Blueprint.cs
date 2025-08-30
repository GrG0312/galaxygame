using Model.CodeComponents.DelegateComponents;

namespace Model.Designs
{
    /// <summary>
    /// <see cref="Blueprint"/>s are researched throughout the game. These will be the basis for creating new designs.
    /// </summary>
    public class Blueprint : DesignerCollection<Section>
    {
        public event EventHandler? Updated;
        public Blueprint(string name, Slot<Section>[] sectionSlots, Condition<Section>[] conditions) : base(name, sectionSlots, conditions) { }
    }
}
