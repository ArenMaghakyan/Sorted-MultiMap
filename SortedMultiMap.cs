using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Sorted_MultiMap
{
    class SortedMultiMap<K,V> : IEnumerable<KeyValuePair<K,V>>
    {
        private readonly Dictionary<K, List<V>> _myDictionary = new Dictionary<K, List<V>>();

        public void Add(K key, V value)
        {

            if (this._myDictionary.TryGetValue(key, out var valueList))
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

            if (this._myDictionary.TryGetValue(key, out var valueList))
            {
                return valueList;
            }

            throw new ArgumentException($"{key} key doesn't exist");
        }


        public bool Remove(K key, V value)
        {

            if (this._myDictionary.TryGetValue(key, out var valueList))
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
                        return true;
                    }
                }
                return false;
            }

            throw new ArgumentException($"{key} key doesn't exist");
        }


        public bool RemoveAll(K key)
        {

            if (this._myDictionary.TryGetValue(key, out var valueList))
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

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (KeyValuePair<K, List<V>> keyValue in this._myDictionary)
            {
                if (keyValue.Key != null)
                {
                    foreach (var v in keyValue.Value)
                    {
                        yield return new KeyValuePair<K, V>(keyValue.Key, v);
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}