using System;
using System.Collections.Generic;

namespace Sorted_MultiMap
{
    class Program
    {
        static int Main(string[] args)
        {

            var multi = new SortedMultiMap<string, int>();
            var multi2 = new SortedMultiMap<string, int>();


            try
            {
                multi.Add("a", 1);
                multi.Add("x", 2);
                multi.Add("x", 4);
                multi.Add("x", 6);
                multi.Add("x", 7);

                multi2.Add("x", 2);
                multi2.Add("x", 3);
                multi2.Add("a", 8);

                multi.Intersect(multi2);
                //multi.Union(multi2);

                foreach (KeyValuePair<string, int> item in multi)
                {
                    Console.WriteLine($"{item.Key}-{item.Value}", item.Key, item.Value);
                }

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            return 0;
        }
    }
}
