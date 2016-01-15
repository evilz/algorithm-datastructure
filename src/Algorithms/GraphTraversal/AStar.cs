using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


// F = G + H
namespace Algorithms.GraphTraversal
{
    public class AStar
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
                    return new KeyValuePair<TPriority, TItem>(first.Key, nextItem);
                }
                else
                    throw new InvalidOperationException("The queue is empty");
            }

            public IEnumerator<KeyValuePair<TPriority, TItem>> GetEnumerator()
            {
                var q = _subqueues.SelectMany(pair => pair.Value.Select(item => new KeyValuePair<TPriority, TItem>(pair.Key, item)));
                return q.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)_subqueues).GetEnumerator();
            }
        }

        public static IEnumerable<T> Explore<T>(T start, Func<T, IEnumerable<T>> getNeighbours, Func<T, T, int> getCost, Func<T, int> heuristic, Func<T, bool> isEnd = null)
        {
            return astar(start, getNeighbours, getCost, heuristic, false, isEnd);
        }

        private static IEnumerable<T> astar<T>(T start, Func<T, IEnumerable<T>> getNeighbours, Func<T, T, int> getCost, Func<T, int> heuristic, bool pathOnly,
            Func<T, bool> isEnd = null)
        {
            var visitedFromAndCost = new Dictionary<T, Tuple<T, int>>();
            var toVisit = new PriorityQueue<int, T>();

            toVisit.Enqueue(0, start);
            visitedFromAndCost.Add(start, new Tuple<T, int>(default(T), 0));

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
                            current = visitedFromAndCost[current].Item1;
                        }
                        path.Enqueue(current);
                        while (path.Any())
                        {
                            yield return path.Dequeue();
                        }

                    }
                    yield break;
                }

                var neighboursWithCost = getNeighbours(current)
                    .Select(n => new { Neighbour = n, NewCost = visitedFromAndCost[current].Item2 + getCost(current, n) })
                    .Where(x =>
                        !visitedFromAndCost.ContainsKey(x.Neighbour)
                        || x.NewCost < visitedFromAndCost[x.Neighbour].Item2)
                    .ToList();

                foreach (var x in neighboursWithCost)
                {
                    var priority = x.NewCost + heuristic(x.Neighbour);
                    toVisit.Enqueue(priority, x.Neighbour);
                    visitedFromAndCost[x.Neighbour] = new Tuple<T, int>(current, x.NewCost);
                }
            }

        }

        public static IEnumerable<T> FindPath<T>(T start, Func<T, IEnumerable<T>> getNeighbours, Func<T, T, int> getCost, Func<T, int> heuristic, Func<T, bool> isEnd = null)
        {
            return astar(start, getNeighbours, getCost, heuristic, true, isEnd);
        }
    }
}
