using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.GraphTraversal
{
    public static class DepthFirstSearch
    {
        //public static IEnumerable<T> Explore<T>(T start, Func<T, IEnumerable<T>> getNeighbours, Func<T, bool> isEnd = null)
        //{
        //    var visited = new HashSet<T>();
        //    var toVisit = new Stack<T>();

        //    toVisit.Push(start);

        //    while (toVisit.Any())
        //    {
        //        var current = toVisit.Pop();

        //        visited.Add(current);

        //        yield return current;

        //        if (isEnd != null && isEnd(current))
        //            break;

        //        getNeighbours(current)
        //            .Where(n => !visited.Contains(n))
        //            .Reverse()
        //            .ToList()
        //            .ForEach(toVisit.Push);
        //    }

        //}

        public static IEnumerable<T> Explore<T>(T start, Func<T, IEnumerable<T>> getNeighbours,
            Func<T, bool> isEnd = null)
        {
            return dfs(start, getNeighbours, false, isEnd);
        }
    

    private static IEnumerable<T> dfs<T>(T start, Func<T, IEnumerable<T>> getNeighbours,bool pathOnly, Func<T, bool> isEnd = null)
        {
            var visitedFrom = new Dictionary<T,T>();
            var toVisit = new Stack<T>();

            toVisit.Push(start);

            visitedFrom.Add(start,default(T));

            while (toVisit.Any())
            {
                var current = toVisit.Pop();
                
                if(!pathOnly) yield return current;
                
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
                    else
                    {
                        yield break;
                    }
                }
                   
                
                var neighbours = getNeighbours(current)
                    .Where(n => !visitedFrom.ContainsKey(n))
                    .Reverse()
                    .ToList();
                foreach (var neighbour in neighbours)
                {
                    toVisit.Push(neighbour);
                    visitedFrom.Add(neighbour, current);
                }
            }

        }

        public static IEnumerable<T> FindPath<T>(T start, Func<T, IEnumerable<T>> getNeighbours, Func<T, bool> isEnd)
        {
            return dfs(start, getNeighbours, true, isEnd);
        }
    }
}
