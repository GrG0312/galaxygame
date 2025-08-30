using Model.CodeComponents.DelegateComponents;

namespace Model.Designs
{
    public class Section : DesignerCollection<DesignPart>
    {
        public Section(string name, Slot<DesignPart>[] partSlots, Condition<DesignPart>[] conditions) : base(name, partSlots, conditions) { }
    }
}
