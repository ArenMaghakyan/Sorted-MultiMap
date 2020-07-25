using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;


namespace Sorted_MultiMap
{
    class SortedMultiMap<K,V> : IEnumerable
    {
        private readonly Dictionary<K, List<V>> _myDictionary = new Dictionary<K, List<V>>();


        public IEnumerator GetEnumerator()
        {
            foreach (KeyValuePair<K, List<V>> keyValue in this._myDictionary)
            {
                if (keyValue.Key != null)
                {
                    yield return keyValue;
                }
            }
        }

         
        public void Add(K key, V value)
        {
            var hasKey = this._myDictionary.TryGetValue(key, out var valueList);

            if (hasKey)
            {
                valueList.Add(value);
                valueList.Sort();
                return;
            }

            var newList = new List<V> {value};
            this._myDictionary[key] = newList;

        }

   
        public List<V> Get(K key)
        {
            var hasKey = this._myDictionary.TryGetValue(key, out var valueList);

            if (hasKey)
            {
                return valueList;
            }

            throw new ArgumentException($"{key} key doesn't exist");
        }


        public bool Remove(K key, V value)
        { 
            var hasKey = this._myDictionary.TryGetValue(key, out var valueList);

            if (hasKey)
            {
                if (valueList.Remove(value))
                {
                    if (valueList.Count == 0)
                    {
                        return this._myDictionary.Remove(key);
                    }
                    else
                    {
                        valueList.Sort();
                    }
                }
                return true;
            }

            throw new ArgumentException($"{key} key doesn't exist");
        }


        public bool RemoveAll(K key)
        {
            var hasKey = this._myDictionary.TryGetValue(key, out var valueList);

            if (hasKey)
            {
                return this._myDictionary.Remove(key);
            }
            throw new ArgumentException($"{key} key doesn't exist");
        }

        public void Clear()
        {
            this._myDictionary.Clear();
        }

        public void RemoveDuplicateValues(K key)
        {
            this._myDictionary[key] = this._myDictionary[key].Distinct().ToList();
        }

        public bool HasKey(K key)
        {
            return this._myDictionary.ContainsKey(key);
        }

    }
}