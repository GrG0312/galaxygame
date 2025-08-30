using System.Numerics;

namespace Model.CodeComponents.DelegateComponents
{
    /// <summary>
    /// A type of <see cref="DelegateWrapperComponent{TDelegate, TParamObj}"/> that holds a delegate of type <see cref="Action{TParamObj}"/>.
    /// Used for implementing modifiers on an object of type <typeparamref name="TParamObj"/>.
    /// </summary>
    public abstract class Modifier<TParamObj> : DelegateWrapperComponent<Action<TParamObj>, TParamObj>
    {
        public Modifier(string name, Action<TParamObj> modification) : base(name, modification) { }
        public abstract void AddTo(Modifier<TParamObj> other);
    }

    public class SingleValueModifier<TParamObj> : Modifier<TParamObj>
    {
        public float Value;
        public SingleValueModifier(string name, Action<TParamObj> modification) : base(name, modification) { }
        public override void AddTo(Modifier<TParamObj> other)
        {
            if (other is not SingleValueModifier<TParamObj> svm)
            {
                throw new GameException("Incompatible modifier.");
            }
            svm.Value += this.Value;
        }
    }
}
