using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* NOTE
- The SortedDictionary<TKey, TValue> generic class is a binary search tree with O(log n) retrieval,
where n is the number of elements in the dictionary. In this, it is similar to the 
SortedList<TKey, TValue> generic class. The two classes have similar object models, and both have
O(log n) retrieval. Where the two classes differ is in memory use and speed of insertion and removal:

- SortedList<TKey, TValue> uses less memory than SortedDictionary<TKey, TValue>.

-SortedDictionary<TKey, TValue> has faster insertion and removal operations for unsorted data,
O(log n) as opposed to O(n) for  SortedList<TKey, TValue>.

If the list is populated all at once from sorted data, SortedList<TKey,  TValue> is faster than
SortedDictionary<TKey, TValue>.
*/

namespace Algorithms.GraphTraversal
{
    public class Dijkstra
    {
        public static IEnumerable<T> Explore<T>(T start, Func<T, IEnumerable<T>> getNeighbours, Func<T, bool> isEnd = null)
        {
            var visited = new Dictionary<T, T> { { start, default(T) } };
            var toVisit = new SortedDictionary<int,T>();
            toVisit.Add(0,start);

            while (toVisit.Any())
            {
                var currentNode = toVisit.First();
                var current = currentNode.Value;
                var currentCost = currentNode.Key;

                if (isEnd != null && isEnd(current))
                {
                    var path = new List<T>();
                    while (!current.Equals(start))
                    {
                        path.Add(current);
                        current = visited[current];
                    }
                    path.Add(current);
                    path.Reverse();
                    return path;
                }

                foreach (var next in getNeighbours(current)
                    .Where(n => !visited.ContainsKey(n)))
                {
                    toVisit.Add(currentCost++, next); // todo change cost !!! And func ? Func<T,T,int>
                    visited.Add(next, current);
                }
            }

            return Enumerable.Empty<T>();
        } 
    }
}
