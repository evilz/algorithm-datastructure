using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Algorithms.GraphTraversal;
using DataStructure;

namespace GraphTraversal.Visualizer
{
    class Program
    {
        private const string MAZE =
@"%%%%%%%%%%%%%%%%%%%%
%--------------%---%
%-%%-%%-%%-%%-%%-%-%
%--------S-------%-%
%%%%%%%%%%%%%%%%%%-%
%.-----------------%  
%%%%%%%%%%%%%%%%%%%%";

        private static Func<Point, char> GetCell(string grid)
        {
            return p => grid.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToArray()[p.Y][p.X];
        }

        private static Func<Point, IEnumerable<Point>> GetNeighbours(Func<Point, char> getCell)
        {
            return p =>
            {
                var allPoints = new[]
                {
                    new Point(p.X, p.Y - 1), // top
                    new Point(p.X + 1, p.Y), // right
                    new Point(p.X, p.Y + 1), // bottom
                    new Point(p.X - 1, p.Y), // left
                };

                return allPoints.Where(x => getCell(x) != '%');
            };
        }

        static void Main()
        {
            var start = new Point(9, 3);
            var end = new Point(1, 5);
            var currentMaze = MAZE;
            Func<Point, char> getCell = GetCell(MAZE);
            Func<Point, IEnumerable<Point>> getNeighbours = GetNeighbours(getCell);
            Func<Point, Point, int> getCost = (from, to) => (to.X + to.Y)%2 == 0 ? 1 : 3;  
            var millisecondsTimeout = 300;

            var algorithms = new Dictionary<int, Tuple<string, Func<IEnumerable<Point>>, Func<IEnumerable<Point>>>> 
            {
                {1, "Depth First Search", () =>  DepthFirstSearch.Explore(start, getNeighbours),()=>DepthFirstSearch.FindPath(start,getNeighbours,p => p.Equals(end) ) },
                {2, "Breadth First Search", () =>  BreadthFirstSearch.Explore(start, getNeighbours) ,()=>BreadthFirstSearch.FindPath(start,getNeighbours,p => p.Equals(end) )},
                {3, "Dijkstra", () =>  Dijkstra.Explore(start, getNeighbours,getCost ) ,()=>Dijkstra.FindPath(start,getNeighbours,getCost,p => p.Equals(end) )}
            };

            Console.WriteLine("Choose traversal algorithm :");
            
            foreach (var algorithm in algorithms)
            {
                Console.WriteLine($"\t{algorithm.Key} - {algorithm.Value.Item1}");
            }

            int choice = 0;
            while (choice == 0)
            {
                int.TryParse(Console.ReadLine(), out choice);
            }

            var result = algorithms[choice].Item2();
            var path = algorithms[choice].Item3().ToList();

            var visited = new List<Point>();
            
            foreach (var item in result)
            {

                visited.Add(item);
                var lines = currentMaze.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
                var line = lines[item.Y].ToCharArray();
                line[item.X] = '*';
                lines[item.Y] = new string(line);
                currentMaze = string.Join(Environment.NewLine, lines);
                DisplayMaze(currentMaze, visited.Count,0,algorithms[choice].Item1);
                
                Thread.Sleep(millisecondsTimeout);
                if (item == end) break;

            }
            
            foreach (var item in path)
            {
                var lines = currentMaze.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                var line = lines[item.Y].ToCharArray();
                line[item.X] = '+';
                lines[item.Y] = new string(line);
                currentMaze = string.Join(Environment.NewLine, lines);
            }
            DisplayMaze(currentMaze, visited.Count(),path.Count(), algorithms[choice].Item1);
            
            Console.Read();
        }

        private static void DisplayMaze(string currentMaze,int visitedCount,int pathCount,string algoName )
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(algoName);
            Console.ResetColor();
            Console.WriteLine($"Explored node count : {visitedCount}");
            Console.WriteLine($"Path length : {pathCount}");
            Console.WriteLine();
            foreach (var c in currentMaze.ToList())
            {
                if(c == '*')
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                if(c == '+')
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(c);
                Console.ResetColor();
            }
            
        }
    }
}