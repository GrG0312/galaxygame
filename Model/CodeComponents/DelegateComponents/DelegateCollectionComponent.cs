namespace Model.CodeComponents.DelegateComponents
{
    /// <summary>
    /// A class dedicated for storing a collection of delegate wrapper objects.
    /// </summary>
    /// <typeparam name="TWrapper">What type of wrapper are stored in <see cref="_delegates"/> list.</typeparam>
    /// <typeparam name="TDelegate">The type of delegate that is used in the <typeparamref name="TWrapper"/> object.</typeparam>
    /// <typeparam name="TParamObj">The type of object accepted by the delegate wrapper as parameter.</typeparam>
    public abstract class DelegateCollectionComponent<TWrapper, TDelegate, TParamObj> 
        where TWrapper : DelegateWrapperComponent<TDelegate, TParamObj> 
        where TDelegate : Delegate
    {
        protected readonly List<TWrapper> _delegates;
        public IReadOnlyCollection<TWrapper> Delegates => _delegates;

        protected DelegateCollectionComponent()
        {
            _delegates = new List<TWrapper>();
        }
        public DelegateCollectionComponent(IEnumerable<TWrapper> delegates)
        {
            _delegates = [.. delegates];
        }

        public virtual void Add(TWrapper deleg)
        {
            _delegates.Add(deleg);
        }
        public virtual void Remove(TWrapper deleg)
        {
            _delegates.Remove(deleg);
        }
        public virtual void Remove(string name)
        {
            _delegates.RemoveAll(c => c.Name == name);
        }
    }


    /// <summary>
    /// An expanded version of <see cref="DelegateCollectionComponent{TWrapper, TDelegate, TParamObj}"/> dedicated for storing <see cref="Condition{TParamObject}"/> objects.
    /// </summary>
    /// <typeparam name="TParamObj">The type of object accepted by the delegate wrapper as parameter.</typeparam>
    public class ConditionComponent<TParamObj> : DelegateCollectionComponent<Condition<TParamObj>, Predicate<TParamObj>, TParamObj>
    {
        public ConditionComponent() : base() { }
        public ConditionComponent(IEnumerable<Condition<TParamObj>> conditions) : base(conditions) { }
        public bool FulfillsAll(TParamObj obj, out string whyNot)
        {
            whyNot = string.Empty;
            foreach (Condition<TParamObj> condition in _delegates)
            {
                if (!condition.Delegate(obj))
                {
                    whyNot = condition.Name;
                    return false;
                }
            }
            return true;
        }

        public bool FulfillsAny(TParamObj obj)
        {
            foreach (Condition<TParamObj> condition in _delegates)
            {
                if (condition.Delegate(obj))
                {
                    return true;
                }
            }
            return false;
        }
    }


    /// <summary>
    /// An expanded version of <see cref="DelegateCollectionComponent{TWrapper, TDelegate, TParamObj}"/> dedicated for storing <see cref="Modifier{TParamObject}"/> objects.
    /// </summary>
    /// <typeparam name="TParamObj">The type of object accepted by the delegate wrapper as parameter.</typeparam>
    public class ModifierComponent<TParamObj> : DelegateCollectionComponent<Modifier<TParamObj>, Action<TParamObj>, TParamObj>
    {
        public ModifierComponent() : base() { }
        public ModifierComponent(IEnumerable<Modifier<TParamObj>> modifiers) : base(modifiers) { }
        public void ApplyAll(TParamObj obj)
        {
            foreach (Modifier<TParamObj> modifier in _delegates)
            {
                modifier.Delegate(obj);
            }
        }
    }
}
