namespace Model.Interfaces
{
    public interface IHasModifier<T>
    {
        public Action<T> Modifier { get; }
    }
}
