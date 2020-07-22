using System;
using System.Collections.Generic;

namespace Sorted_MultiMap
{
    class Program
    {
        static int Main(string[] args)
        {

            var mult = new SortedMultiMap<string, int>();

            mult.Add("a", 1);
            mult.Add("b", 2);
            mult.Add("b", 3);
            mult.Add("c", 4);


            return 0;
        }
    }
}
