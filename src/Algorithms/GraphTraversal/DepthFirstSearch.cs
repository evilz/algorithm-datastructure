using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.GraphTraversal
{
    public static class DepthFirstSearch
    {
        public static IEnumerable<T> BrowseGraph<T>(T start, Func<T, IEnumerable<T>> getNeighbours)
        {
            var visited = new HashSet<T>();
            var stack = new Stack<T>();

            stack.Push(start);

            while (stack.Any())
            {
                var current = stack.Pop();

                if (!visited.Add(current)) { continue; }

                yield return current;

                var neighbours = getNeighbours(current)
                                    .Where(n => !visited.Contains(n));

                foreach (var neighbour in neighbours.Reverse())
                    stack.Push(neighbour);
            }

        }

        public static IEnumerable<T> FindPath<T>(T start, T end, Func<T, IEnumerable<T>> getNeighbours)
        {
            var visited = new HashSet<T>();
            var stack = new Stack<T>();
            var path = new Stack<T>();

            stack.Push(start);

            while (stack.Any())
            {
                var current = stack.Pop();
                path.Push(current);

                if (!visited.Add(current)) { continue; }

                if (current.Equals(end))
                    return path.Reverse();

                var neighbours = getNeighbours(current)
                                    .Where(n => !visited.Contains(n));

                if (!neighbours.Any())
                    path.Pop();

                foreach (var neighbour in neighbours.Reverse())
                    stack.Push(neighbour);
            }

            return Enumerable.Empty<T>();

        }
    }
}
