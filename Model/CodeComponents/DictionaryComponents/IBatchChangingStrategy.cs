namespace Model.CodeComponents.DictionaryComponents
{
    public interface IBatchChangingStrategy<TKey, TValue> where TKey : notnull
    {
        public event EventHandler<IReadOnlyCollection<TKey>>? BatchChangeCompleted;
        public void RegisterChange(TKey key, TValue value);
    }
}
