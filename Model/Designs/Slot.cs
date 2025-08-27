using Model.CodeComponents;

namespace Model.Designs
{
    public class Slot<T> : NamedObject
    {
        private ConditionComponent<T> _conditions;
        public Slot(string name, Condition<T>[] conditions) : base(name)
        {
            this._conditions = new ConditionComponent<T>(conditions);
        }

        public void Fill(T obj)
        {
            if (!_conditions.FulfillsAll(obj))
            {
                throw new GameException();
            }
        }
    }

    public class ModuleSlot : NamedObject
    {
        public ModuleSlot(string name) : base(name)
        {

        }
    }

    public class PartSlot : NamedObject
    {
        public PartSlot(string name) : base(name)
        {
        }
    }
}
