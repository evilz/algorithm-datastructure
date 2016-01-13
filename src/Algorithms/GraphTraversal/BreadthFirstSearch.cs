using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.GraphTraversal
{
    public static class BreadthFirstSearch
    {
        public static IEnumerable<T> Explore<T>(T start, Func<T, IEnumerable<T>> getNeighbours, Func<T, bool> isEnd = null)
        {
            var visited = new HashSet<T>();
            var toVisit = new Queue<T>();
            toVisit.Enqueue(start);
            
            while (toVisit.Any())
            {
                var current = toVisit.Dequeue();
                visited.Add(current);

                yield return current;

                if(isEnd != null && isEnd(current)) { yield break; }

                getNeighbours(current)
                    .Where(n => !visited.Contains(n)).ToList()
                    .ForEach(n => toVisit.Enqueue(n));
            }

        }

        public static IEnumerable<T> FindPath<T>(T start, Func<T, IEnumerable<T>> getNeighbours, Func<T, bool> isEnd = null)
        {
            var visited = new Dictionary<T, T> { { start, default(T) } };
            var toVisit = new Queue<T>();
            toVisit.Enqueue(start);
            
            while (toVisit.Any())
            {
                var current = toVisit.Dequeue();
                
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
                    toVisit.Enqueue(next);
                    visited.Add(next, current);
                }
            }

            return Enumerable.Empty<T>();
        }

        //public static IEnumerable<T> FindPath<T>(T start, Func<T, IEnumerable<T>> getNeighbours, Func<T, bool> isEnd)
        //{
        //    var visited = new HashSet<T>();
        //    var toVisit = new Stack<T>();
        //    var path = new Stack<T>();

        //    toVisit.Push(start);

        //    while (toVisit.Any())
        //    {
        //        var current = toVisit.Pop();
        //        path.Push(current);

        //        visited.Add(current);

        //        if (isEnd(current))
        //            return path.Reverse();

        //        var neighbours = GetNotVisitiedNeighbours(getNeighbours, current, visited);

        //        if (!neighbours.Any())
        //        {
        //            if(!toVisit.Any()) { break; }

        //            var lastInPath = path.Peek();
        //            var lastInPathNeighbours = getNeighbours(lastInPath);
        //            var next = toVisit.Peek();
        //            while (!lastInPathNeighbours.Contains(next))
        //            {
        //                path.Pop();
        //                lastInPath = path.Peek();
        //                lastInPathNeighbours = getNeighbours(lastInPath);
        //            }

        //        }
        //        else
        //        {
        //            neighbours.ForEach(toVisit.Push);
        //        }
        //    }

        //    return Enumerable.Empty<T>();

        //}

        //private static List<T> GetNotVisitiedNeighbours<T>(Func<T, IEnumerable<T>> getNeighbours, T current, HashSet<T> visited)
        //{
        //    return getNeighbours(current)
        //        .Where(n => !visited.Contains(n))
        //        .Reverse()
        //        .ToList();
        //}
    }
}
