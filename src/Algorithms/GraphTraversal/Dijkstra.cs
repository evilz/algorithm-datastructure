using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        class PriorityQueue<TPriority, TItem> : IEnumerable<KeyValuePair<TPriority, TItem>>
        {
            readonly SortedDictionary<TPriority, Queue<TItem>> _subqueues;

            public PriorityQueue()
            {
                _subqueues = new SortedDictionary<TPriority, Queue<TItem>>(Comparer<TPriority>.Default);
            }
            
            public void Enqueue(TPriority priority, TItem item)
            {
                if (!_subqueues.ContainsKey(priority))
                {
                    _subqueues.Add(priority, new Queue<TItem>());
                }

                _subqueues[priority].Enqueue(item);
            }
            
            public KeyValuePair<TPriority, TItem> Dequeue()
            {
                if (_subqueues.Any())
                {
                    var first = _subqueues.First();
                    var nextItem = first.Value.Dequeue();
                    if (!first.Value.Any())
                    {
                        _subqueues.Remove(first.Key);
                    }
                    return new KeyValuePair<TPriority, TItem>(first.Key,nextItem);
                }
                else
                    throw new InvalidOperationException("The queue is empty");
            }

            public IEnumerator<KeyValuePair<TPriority,TItem>> GetEnumerator()
            {
                var q = _subqueues.SelectMany(pair => pair.Value.Select(item => new KeyValuePair<TPriority,TItem>(pair.Key,item)));
                return q.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable) _subqueues).GetEnumerator();
            }
        }

        public static IEnumerable<T> Explore<T>(T start, Func<T, IEnumerable<T>> getNeighbours,Func<T,T,int> getCost, Func<T, bool> isEnd = null)
        {
            return dijkstra(start, getNeighbours,getCost, false, isEnd);
        }

        private static IEnumerable<T> dijkstra<T>(T start, Func<T, IEnumerable<T>> getNeighbours, Func<T, T, int> getCost, bool pathOnly,
            Func<T, bool> isEnd = null)
        {
            var visitedFrom = new Dictionary<T, T>();
            var toVisit = new PriorityQueue<int,T>();
            toVisit.Enqueue(0,start);
            visitedFrom.Add(start, default(T));

            while (toVisit.Any())
            {
                var currentNode = toVisit.Dequeue();
                var current = currentNode.Value;
                var currentCost = currentNode.Key;


                if (!pathOnly)
                {
                    yield return current;
                }

                if (isEnd != null && isEnd(current))
                {
                    if (pathOnly)
                    {
                        var path = new Queue<T>();
                        
                        while (!current.Equals(start))
                        {
                            path.Enqueue(current);
                            current = visitedFrom[current];
                        }
                        path.Enqueue(current);
                        while (path.Any())
                        {
                            yield return path.Dequeue();
                        }

                    }
                    yield break;
                }

                var neighbours = getNeighbours(current)
                    .Where(n => !visitedFrom.ContainsKey(n))
                    .Reverse()
                    .ToList();
                foreach (var neighbour in neighbours)
                {
                    toVisit.Enqueue(currentCost + getCost(current,neighbour), neighbour); // <= add move cost here !
                    visitedFrom.Add(neighbour, current);
                }
            }

        }

        public static IEnumerable<T> FindPath<T>(T start, Func<T, IEnumerable<T>> getNeighbours, Func<T, T, int> getCost, Func<T, bool> isEnd = null)
        {
            return dijkstra(start, getNeighbours,getCost, true, isEnd);
        }
    }
}
