using System.Collections;

namespace Model.CodeComponents.DictionaryComponents
{
    public class DictionaryComponent<TKey, TValue> :
        IEnumerable<KeyValuePair<TKey, TValue>> 
        where TKey : notnull
    {
        protected readonly Dictionary<TKey, TValue> _values;
        protected IBatchChangingStrategy<TKey, TValue>? _batchChangingStrategy;

        public event EventHandler<IReadOnlyCollection<TKey>>? ValuesChanged;

        public TValue this[TKey key, bool shouldNotify = true]
        {
            get
            {
                return _values[key];
            }
            set
            {
                _values[key] = value;
                if (_batchChangingStrategy != null)
                {
                    _batchChangingStrategy.RegisterChange(key, value);
                    return;
                }
                else if (shouldNotify)
                {
                    ValuesChanged?.Invoke(this, [key]);
                }
            }
        }

        public DictionaryComponent()
        {
            _values = new Dictionary<TKey, TValue>();
        }

        public DictionaryComponent(Dictionary<TKey, TValue> initialValues)
        {
            _values = new Dictionary<TKey, TValue>(initialValues);
        }

        public void UseBatchChangingStrategy(IBatchChangingStrategy<TKey, TValue> strategy)
        {
            if (_batchChangingStrategy != null)
            {
                throw new GameException($"{nameof(_batchChangingStrategy)} is already in use, unable to make change.");
            }
            _batchChangingStrategy = strategy;
            strategy.BatchChangeCompleted += OnBatchChangeCompleted;
        }

        private void OnBatchChangeCompleted(object? sender, IReadOnlyCollection<TKey> changedKeys)
        {
            _batchChangingStrategy!.BatchChangeCompleted -= OnBatchChangeCompleted;
            _batchChangingStrategy = null;
            ValuesChanged?.Invoke(this, changedKeys);
        }

        #region Interface Methods
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
