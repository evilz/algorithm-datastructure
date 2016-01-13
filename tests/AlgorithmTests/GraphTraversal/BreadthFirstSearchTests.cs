using Algorithms.GraphTraversal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using DataStructure;


namespace AlgorithmTests.GraphTraversal
{
    public class BreadthFirstSearchTests
    {
        [Test]
        public void Small_maze_test()
        {
            var start = new Point(9, 3);
            var end = new Point(1, 5);

            var maze = @"
%%%%%%%%%%%%%%%%%%%%
%--------------%---%
%-%%-%%-%%-%%-%%-%-%
%--------P-------%-%
%%%%%%%%%%%%%%%%%%-%
%.-----------------%  
%%%%%%%%%%%%%%%%%%%%";

            Func<Point, char> getCell = GetCell(maze);
            Func<Point, IEnumerable<Point>> getNeighbours = GetNeighbours(getCell);


            var result = BreadthFirstSearch.Explore(start, getNeighbours);

            var path = new List<Point>();
            foreach (var item in result)
            {
                path.Add(item);
                if (item == end) break;
            }

            var expected = new[] {
                new Point(9,3),
                new Point(10,3),
                new Point(10,2),
                new Point(10,1),
                new Point(11,1),
                new Point(12,1),
                new Point(13,1),
                new Point(14,1),
                new Point(13,2),
                new Point(13,3),
                new Point(14,3),
                new Point(15,3),
                new Point(16,3),
                new Point(16,2),
                new Point(16,1),
                new Point(17,1),
                new Point(18,1),
                new Point(18,2),
                new Point(18,3),
                new Point(18,4),
                new Point(18,5),
                new Point(17,5),
                new Point(16,5),
                new Point(15,5),
                new Point(14,5),
                new Point(13,5),
                new Point(12,5),
                new Point(11,5),
                new Point(10,5),
                new Point(9,5),
                new Point(8,5),
                new Point(7,5),
                new Point(6,5),
                new Point(5,5),
                new Point(4,5),
                new Point(3,5),
                new Point(2,5),
                new Point(1,5),

            };
            Assert.That(path, Is.EquivalentTo(expected));
        }


//        [Test]
//        public void Small_maze_FindPath_test()
//        {
//            var start = new Point(9, 3);
//            var end = new Point(1, 5);

//            var maze = @"
//%%%%%%%%%%%%%%%%%%%%
//%--------------%---%
//%-%%-%%-%%-%%-%%-%-%
//%--------P-------%-%
//%%%%%%%%%%%%%%%%%%-%
//%.-----------------%  
//%%%%%%%%%%%%%%%%%%%%";

//            var getCell = GetCell(maze);
//            var getNeighbours = GetNeighbours(getCell);


//            var result = DepthFirstSearch.FindPath(start, getNeighbours,point => point == end ).ToArray();

//            for (var i = 0; i < result.Length - 1; i++)
//            {
//                var twoPoints = result.Skip(i).Take(2).ToArray();
//                var point1 = twoPoints[0];
//                var point2 = twoPoints[1];
//                var distance = Math.Abs(point1.X - point2.X) + Math.Abs(point1.Y - point2.Y);
//                Assert.That(distance, Is.EqualTo(1));
//            }
        
//            Assert.That(result.Last(), Is.EqualTo(end));
//        }

//        [Test]
//        public void Tiny_maze_FindPath_test()
//        {
//            var start = new Point(1, 3);
//            var end = new Point(7, 3);

//            const string maze = @"
//%%%%%%%%%
//%-------%
//%%%%-%%%%
//%P------%
//%%%%%%%%%";

//            Func<Point, char> getCell = p => maze.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Skip(1).ToArray()[p.Y][p.X];

//            Func<Point, IEnumerable<Point>> getNeighbours = p =>
//            {
//                var allPoints = new[]
//                {
//                    new Point(p.X, p.Y - 1), // top
//                     new Point(p.X + 1, p.Y), // right
//                     new Point(p.X, p.Y + 1), // bottom
//                     new Point(p.X - 1, p.Y), // left
//                };

//                return allPoints.Where(x => getCell(x) != '%');

//            };


//            var result = DepthFirstSearch.FindPath(start, getNeighbours, point => point == end).ToArray();

//            for (var i = 0; i < result.Length - 1; i++)
//            {
//                var twoPoints = result.Skip(i).Take(2).ToArray();
//                var point1 = twoPoints[0];
//                var point2 = twoPoints[1];
//                var distance = Math.Abs(point1.X - point2.X) + Math.Abs(point1.Y - point2.Y);
//                Assert.That(distance, Is.EqualTo(1));
//            }

//            Assert.That(result.Last(), Is.EqualTo(end));
//        }

//        [Test]
//        public void Explore_should_stop_on_specific_condition()
//        {
//            var start = new Point(1, 3);
//            var end = new Point(1, 1);
//            Func<Point,bool> endCondition = point => point == end;
           
//            const string maze = @"
//%%%%%%%%%
//%-------%
//%%%%-%%%%
//%P------%
//%%%%%%%%%";

//            var getCell = GetCell(maze);
//            var getNeighbours = GetNeighbours(getCell);

//            var result = DepthFirstSearch
//                .Explore(start, getNeighbours, endCondition)
//                .ToArray();

//            Assert.That(result.Count(), Is.EqualTo(12));
//            Assert.That(result.Last(),Is.EqualTo(end));
//        }

//        [Test]
//        public void FindPath_should_return_empty_enumerqble_when_no_path_found()
//        {
//            var start = new Point(1, 3);
//            var end = new Point(7, 1);

//            const string maze = @"
//%%%%%%%%%
//%-------%
//%%%%%%%%%
//%P------%
//%%%%%%%%%";

//            var getCell = GetCell(maze);
//            var getNeighbours = GetNeighbours(getCell);
            
//            var result = DepthFirstSearch.FindPath(start, getNeighbours, point => point == end);

//            Assert.That(result, Is.Empty);
//        }

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

        private static Func<Point, char> GetCell(string maze)
        {
            return p => maze.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Skip(1).ToArray()[p.Y][p.X];
        }
    }
}
