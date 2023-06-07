using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.Generic
{
    internal abstract class BaseRepository<TKey,TValue,TConfig> : IRepository
    {
        private Dictionary<TKey, TValue> _items;
        public IReadOnlyDictionary<TKey, TValue> Items => _items;


        public BaseRepository(IEnumerable<TConfig> configs) => _items = CreateItems(configs);

        private Dictionary<TKey, TValue> CreateItems(IEnumerable<TConfig> configs)
        {
            _items = new Dictionary<TKey, TValue>();
            foreach(var config in configs)
            {
                _items[GetKey(config)] = CreateItem(config);
            }
            return _items;
        }

        protected abstract TValue CreateItem(TConfig config);

        protected abstract TKey GetKey(TConfig config);

        public void Dispose() => _items?.Clear();
    }
}
