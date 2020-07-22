using System;
using System.Collections.Generic;

namespace Sorted_MultiMap
{
    class SortedMultiMap<K,V>
    {
        private readonly Dictionary<K, List<V>> _myDictionary = new Dictionary<K, List<V>>();

        public void Add(K key, V value)
        {
            var hasKey = this._myDictionary.TryGetValue(key, out var list);

            if (hasKey)
            {
                list.Add(value);
                return;
            }

            var newList = new List<V> {value};
            this._myDictionary[key] = newList;

        }


        public void Get(K key)
        {
            
        }

        public bool Remove(K key, V value)
        { 
            var hasKey = this._myDictionary.TryGetValue(key, out var valueList);

            if (hasKey)
            {
                valueList.Remove(value);
                return true;
            }

            return false;
        }

        public bool RemoveAll(K key)
        {
            return this._myDictionary.Remove(key);
        }
    }
}