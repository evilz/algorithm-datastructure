using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.GraphTraversal
{
    public static class BreadthFirstSearch
    {
        public static IEnumerable<T> Explore<T>(T start, Func<T, IEnumerable<T>> getNeighbours, Func<T, bool> isEnd = null)
        {
            return Bfs(start, getNeighbours, false, isEnd);
        }

        private static IEnumerable<T> Bfs<T>(T start, Func<T, IEnumerable<T>> getNeighbours, bool pathOnly,
            Func<T, bool> isEnd = null)
        {
            var visitedFrom = new Dictionary<T, T>();
            var toVisit = new Queue<T>();
            toVisit.Enqueue(start);
            visitedFrom.Add(start, default(T));

            while (toVisit.Any())
            {
                var current = toVisit.Dequeue();


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
                    toVisit.Enqueue(neighbour);
                    visitedFrom.Add(neighbour, current);
                }
            }

        }

        public static IEnumerable<T> FindPath<T>(T start, Func<T, IEnumerable<T>> getNeighbours, Func<T, bool> isEnd = null)
        {
            return Bfs(start, getNeighbours, true, isEnd);
        }
    }
}
