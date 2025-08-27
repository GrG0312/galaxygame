namespace Model.CodeComponents
{
    public class ConditionComponent<T>
    {
        private readonly List<Condition<T>> _conditions;

        public ConditionComponent()
        {
            _conditions = new List<Condition<T>>();
        }

        public ConditionComponent(IEnumerable<Condition<T>> conditions)
        {
            _conditions = [.. conditions];
        }

        public void AddCondition(Condition<T> cond)
        {
            _conditions.Add(cond);
        }

        public void RemoveCondition(Condition<T> cond)
        {
            _conditions.Remove(cond);
        }

        public void RemoveCondition(string name)
        {
            _conditions.RemoveAll(c => c.Name == name);
        }

        public bool FulfillsAll(T obj)
        {
            foreach (Condition<T> condition in _conditions)
            {
                if (!condition.Predicate(obj))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
