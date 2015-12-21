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
            var stack = new Stack<T>();

            stack.Push(start);

            while (stack.Any())
            {
                var current = stack.Pop();
                
                if (!visited.Add(current)) { continue; }

                yield return current;

                if (isEnd != null && isEnd(current))
                    break;

                var neighbours = getNeighbours(current)
                                .Where(n => !visited.Contains(n));

                foreach (var neighbour in neighbours.Reverse())
                    stack.Push(neighbour);
            }

        }

        public static IEnumerable<T> FindPath<T>(T start, Func<T, IEnumerable<T>> getNeighbours, Func<T, bool> isEnd)
        {
            var visited = new HashSet<T>();
            var stack = new Stack<T>();
            var path = new Stack<T>();

            stack.Push(start);

            while (stack.Any())
            {
                var current = stack.Pop();
                path.Push(current);

                visited.Add(current);

                if (isEnd(current))
                    return path.Reverse();

                var neighbours = getNeighbours(current)
                                    .Where(n => !visited.Contains(n))
                                    .ToArray();

                if (!neighbours.Any())
                {
                    if(!stack.Any()) { break; }

                    var lastInPath = path.Peek();
                    var lastInPathNeighbours = getNeighbours(lastInPath);
                    var next = stack.Peek();
                    while (!lastInPathNeighbours.Contains(next))
                    {
                        path.Pop();
                        lastInPath = path.Peek();
                        lastInPathNeighbours = getNeighbours(lastInPath);
                    }
 
                }
    

                foreach (var neighbour in neighbours.Reverse())
                    stack.Push(neighbour);
            }

            return Enumerable.Empty<T>();

        }
    }
}
