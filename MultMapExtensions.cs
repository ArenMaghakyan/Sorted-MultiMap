using System.Collections.Generic;
using System.Linq;

namespace Sorted_MultiMap
{
    public static class MultiMapExtensions
    {
        internal static SortedMultiMap<K,V> Union<K,V>(this SortedMultiMap<K,V> originalMap, SortedMultiMap<K, V> secondMap)
        {

            foreach (KeyValuePair<K, List<V>> item in secondMap)
            {

                var hasKey = originalMap.HasKey(item.Key);

                foreach (var values in secondMap.Get(item.Key))
                {
                    originalMap.Add(item.Key, values);
                }

                if (hasKey)
                {
                    originalMap.RemoveDuplicateValues(item.Key);
                }

            }
            return originalMap;
        }


        internal static SortedMultiMap<K, V> Intersect<K, V>(this SortedMultiMap<K, V> originalMap, SortedMultiMap<K, V> secondMap)
        {
            var newMap = new SortedMultiMap<K, V>();

            foreach (KeyValuePair<K, List<V>> item in originalMap)
            {
                if (secondMap.HasKey(item.Key))
                {
                    var commonValuesList = item.Value.Intersect(secondMap.Get(item.Key)).ToList();
                    foreach (var values in commonValuesList)
                    {
                        newMap.Add(item.Key, values);
                    }

                } 

            }

            originalMap.Clear();

            foreach (KeyValuePair<K, List<V>> item in newMap)
            {

                foreach (var values in newMap.Get(item.Key))
                {
                    originalMap.Add(item.Key, values);
                }

            }

            return originalMap;
        }
    }

}