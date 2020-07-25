using System;
using System.Collections.Generic;
using System.Threading.Channels;

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

                multi2.Add("x", 2);
                multi2.Add("x", 3);
                multi2.Add("a", 8);

                multi.Intersect(multi2);
                //multi.Union(mult2);

                foreach (KeyValuePair<string, List<int>> item in multi)
                {
                    foreach (var i in multi.Get(item.Key))
                    {
                        Console.WriteLine($"{item.Key}-{i}", item.Key, i);
                    }
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
