using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.GraphTraversal
{
    public static class DepthFirstSearch
    {
        public static IEnumerable<T> FindPath<T>(T start,T end, Func<T,IEnumerable<T>> getNeighbours)
        {
            var visited = new HashSet<T>();
            var stack = new Stack<T>();

            stack.Push(start);

            while (stack.Any())
            {
                var current = stack.Pop();

                if (!visited.Add(current))
                    continue;

                yield return current;

                var neighbours = getNeighbours(current)
                                      .Where(n => !visited.Contains(n));

                foreach (var neighbour in neighbours)
                    stack.Push(neighbour);
            }
           
        }

    }
}
