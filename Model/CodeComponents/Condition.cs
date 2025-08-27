namespace Model.CodeComponents
{
    public class Condition<T> : NamedObject
    {
        public Predicate<T> Predicate { get; init; }

        public Condition(string name, Predicate<T> predicate) : base(name)
        {
            Predicate = predicate;
        }

        public static implicit operator Predicate<T>(Condition<T> condition)
        {
            return condition.Predicate;
        }
    }
}
