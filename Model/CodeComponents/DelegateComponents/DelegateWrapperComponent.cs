namespace Model.CodeComponents.DelegateComponents
{
    /// <summary>
    /// A delegate wrapper class that holds a single delegate of type <typeparamref name="TDelegate"/> that accept a parameter of type <typeparamref name="TParamObj"/>.
    /// </summary>
    public abstract class DelegateWrapperComponent<TDelegate, TParamObj> : NamedObject where TDelegate : Delegate
    {
        public TDelegate Delegate { get; }

        public DelegateWrapperComponent(string name, TDelegate del) : base(name)
        {
            Delegate = del;
        }

        public static implicit operator TDelegate(DelegateWrapperComponent<TDelegate, TParamObj> component)
        {
            return component.Delegate;
        }
    }

    /// <summary>
    /// A type of <see cref="DelegateWrapperComponent{TDelegate, TParamObj}"/> that holds a delegate of type <see cref="Predicate{TParamObj}"/>.
    /// Used for implementing slotConditions on an object of type <typeparamref name="TParamObj"/>.
    /// </summary>
    /// <typeparam name="TParamObj"></typeparam>
    public class Condition<TParamObj> : DelegateWrapperComponent<Predicate<TParamObj>, TParamObj>
    {
        public Condition(string name, Predicate<TParamObj> predicate) : base(name, predicate) { }
    }
}
