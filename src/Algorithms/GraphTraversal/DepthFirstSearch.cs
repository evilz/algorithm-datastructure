using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.GraphTraversal
{
    public static class DepthFirstSearch
    {
        public static IEnumerable<T> Explore<T>(T start, Func<T, IEnumerable<T>> getNeighbours, Func<T, bool> isEnd = null)
        {
            var visited = new HashSet<T>();
            var toVisit = new Stack<T>();

            toVisit.Push(start);

            while (toVisit.Any())
            {
                var current = toVisit.Pop();

                visited.Add(current);

                yield return current;

                if (isEnd != null && isEnd(current))
                    break;

                var neighbours = GetNotVisitiedNeighbours(getNeighbours, current, visited);

                neighbours.ForEach(toVisit.Push);
            }

        }
        
        public static IEnumerable<T> FindPath<T>(T start, Func<T, IEnumerable<T>> getNeighbours, Func<T, bool> isEnd)
        {
            var visited = new HashSet<T>();
            var toVisit = new Stack<T>();
            var path = new Stack<T>();

            toVisit.Push(start);

            while (toVisit.Any())
            {
                var current = toVisit.Pop();
                path.Push(current);

                visited.Add(current);

                if (isEnd(current))
                    return path.Reverse();

                var neighbours = GetNotVisitiedNeighbours(getNeighbours, current, visited);

                if (!neighbours.Any())
                {
                    if(!toVisit.Any()) { break; }

                    var lastInPath = path.Peek();
                    var lastInPathNeighbours = getNeighbours(lastInPath);
                    var next = toVisit.Peek();
                    while (!lastInPathNeighbours.Contains(next))
                    {
                        path.Pop();
                        lastInPath = path.Peek();
                        lastInPathNeighbours = getNeighbours(lastInPath);
                    }
 
                }
                else
                {
                    neighbours.ForEach(toVisit.Push);
                }
            }

            return Enumerable.Empty<T>();

        }

        private static List<T> GetNotVisitiedNeighbours<T>(Func<T, IEnumerable<T>> getNeighbours, T current, HashSet<T> visited)
        {
            return getNeighbours(current)
                .Where(n => !visited.Contains(n))
                .Reverse()
                .ToList();
        }
    }
}
