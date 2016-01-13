using System;
using System.Collections.Generic;

namespace GraphTraversal.Visualizer
{
    public static class TupleListExtensions
    {
        public static void Add<T1, T2>(this IList<Tuple<T1, T2>> list,
            T1 item1, T2 item2)
        {
            list.Add(Tuple.Create(item1, item2));
        }

        public static void Add<T,T1, T2>(this IDictionary<T,Tuple<T1, T2>> dictionary,
          T key,T1 item1, T2 item2)
        {
            dictionary.Add(key,Tuple.Create(item1, item2));
        }

        public static void Add<T, T1, T2,T3>(this IDictionary<T, Tuple<T1, T2,T3>> dictionary,
         T key, T1 item1, T2 item2, T3 item3)
        {
            dictionary.Add(key, Tuple.Create(item1, item2,item3));
        }

        public static void Add<T1, T2, T3>(this IList<Tuple<T1, T2, T3>> list,
            T1 item1, T2 item2, T3 item3)
        {
            list.Add(Tuple.Create(item1, item2, item3));
        }

        // and so on...
    }
}