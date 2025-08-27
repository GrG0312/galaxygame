namespace Model.CodeComponents.DictionaryComponents
{
    public class FixedBatchChanging<TKey, TValue> : IBatchChangingStrategy<TKey, TValue> where TKey : notnull
    {
        private TKey[] _changes;
        private int _currentIndex = 0;

        public event EventHandler<IReadOnlyCollection<TKey>>? BatchChangeCompleted;

        public FixedBatchChanging(int amount)
        {
            _changes = new TKey[amount];
        }

        public void RegisterChange(TKey key, TValue value)
        {
            if (_currentIndex >= _changes.Length)
            {
                throw new GameException("Cannot register more changes than the fixed amount.");
            }
            _changes[_currentIndex] = key;
            _currentIndex++;
            if (_currentIndex == _changes.Length)
            {
                BatchChangeCompleted?.Invoke(this, _changes);
            }
        }

        public void ResetBatchChanges(int newAmount)
        {
            _changes = new TKey[newAmount];
            _currentIndex = 0;
        }
    }
}
