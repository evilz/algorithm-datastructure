using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Algorithms.GraphTraversal;
using DataStructure;
using Mono.Options;

namespace GraphTraversal.Visualizer
{
    class Program
    {
        

        public const string maze =
@"%%%%%%%%%%%%%%%%%%%%
%--------------%---%
%-%%-%%-%%-%%-%%-%-%
%--------S-------%-%
%%%%%%%%%%%%%%%%%%-%
%.-----------------%  
%%%%%%%%%%%%%%%%%%%%";

        private static Func<Point, char> GetCell(string maze)
        {
            return p => maze.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToArray()[p.Y][p.X];
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

        static void Main(string[] args)
        {
            var start = new Point(9, 3);
            var end = new Point(1, 5);

            var currentMaze = maze;

            Func<Point, char> getCell = GetCell(maze);
            Func<Point, IEnumerable<Point>> getNeighbours = GetNeighbours(getCell);


            var result = DepthFirstSearch.Explore(start, getNeighbours);

            var path = new List<Point>();
            foreach (var item in result)
            {

                path.Add(item);
                var lines = currentMaze.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
                var line = lines[item.Y].ToCharArray();
                line[item.X] = '*';
                lines[item.Y] = new string(line);
                currentMaze = string.Join(Environment.NewLine, lines);
                DisplayMaze(currentMaze, path, "Breadth First Search");
                
                Thread.Sleep(500);
                if (item == end) break;

            }
            Console.Read();
        }

        private static void DisplayMaze(string currentMaze,IEnumerable<Point> path,string algoName )
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(algoName);
            Console.ResetColor();
            Console.WriteLine($"Explored node count : {path.Count()}");
            Console.WriteLine();
            currentMaze.ToList().ForEach(Console.Write);
        }
    }
}