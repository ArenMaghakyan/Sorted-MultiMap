using System.Collections.Generic;
using System.Linq;

namespace Sorted_MultiMap
{
    public static class MultiMapExtensions
    {
        internal static SortedMultiMap<K,V> Union<K,V>(this SortedMultiMap<K,V> originalMap, SortedMultiMap<K, V> secondMap)
        {

            foreach (KeyValuePair<K, V> item in secondMap)
            {

                originalMap.Add(item.Key, item.Value);

            }
            return originalMap;
        }


        internal static SortedMultiMap<K, V> Intersect<K, V>(this SortedMultiMap<K, V> originalMap, SortedMultiMap<K, V> secondMap)
        {
            var newMap = new SortedMultiMap<K, V>();

            foreach (KeyValuePair<K, V> item in originalMap)
            {
                if (secondMap.HasKey(item.Key))
                {
                    var isCommonValue = secondMap.Get(item.Key).Contains(item.Value);

                    if (isCommonValue)
                    {
                        newMap.Add(item.Key, item.Value);
                    }

                } 

            }

            originalMap.Clear();

            foreach (KeyValuePair<K, V> item in newMap)
            {

                originalMap.Add(item.Key, item.Value);

            }

            return originalMap;
        }
    }

}