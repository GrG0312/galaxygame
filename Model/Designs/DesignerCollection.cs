using Model.CodeComponents.DelegateComponents;

namespace Model.Designs
{
    public abstract class DesignerCollection<TObj> : NamedObject
    {
        protected readonly Slot<TObj>[] slots;
        private readonly ConditionComponent<TObj> slotConditions;

        #region Public Properties
        public IReadOnlyCollection<Slot<TObj>> Slots => slots;
        public IReadOnlyCollection<Condition<TObj>> SlotConditions => slotConditions.Delegates;
        #endregion

        public DesignerCollection(string name, Slot<TObj>[] sectionSlots, Condition<TObj>[] conditions) : base(name)
        {
            slots = [..sectionSlots];
            this.slotConditions = new ConditionComponent<TObj>(conditions);
        }
    }
}
