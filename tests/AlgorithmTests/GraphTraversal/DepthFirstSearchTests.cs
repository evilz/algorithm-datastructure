using Algorithms.GraphTraversal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AlgorithmTests.GraphTraversal
{
    class DepthFirstSearchTests
    {
        // TODO 
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

            Func<Point, char> getCell = (p) =>
             {
                 return maze.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Skip(1).ToArray()[p.Y][p.X];
             };

            Func<Point, IEnumerable<Point>> getNeighbours = (p) =>
             {
                 var allPoints = new Point[]
                 {
                    new Point(p.X, p.Y - 1), // top
                     new Point(p.X + 1, p.Y), // right
                     new Point(p.X, p.Y + 1), // bottom
                     new Point(p.X - 1, p.Y), // left
                 };

                 return allPoints.Where(x => getCell(x) != '%');

             };


            var result = DepthFirstSearch.BrowseGraph(start, getNeighbours);

            List<Point> path = new List<Point>();
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

        // TODO 
        [Test]
        public void Small_maze_FindPath_test()
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

            Func<Point, char> getCell = (p) =>
            {
                return maze.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Skip(1).ToArray()[p.Y][p.X];
            };

            Func<Point, IEnumerable<Point>> getNeighbours = (p) =>
            {
                var allPoints = new Point[]
                {
                    new Point(p.X, p.Y - 1), // top
                     new Point(p.X + 1, p.Y), // right
                     new Point(p.X, p.Y + 1), // bottom
                     new Point(p.X - 1, p.Y), // left
                };

                return allPoints.Where(x => getCell(x) != '%');

            };


            var result = DepthFirstSearch.FindPath(start,end, getNeighbours);

            for (int i = 0; i < result.Count() - 1; i++)
            {
                var TwoPoints = result.Skip(i).Take(2);
                var point1 = TwoPoints.First();
                var point2 = TwoPoints.Last();
                var distance = Math.Abs(point1.X - point2.X) + Math.Abs(point1.Y - point2.Y);
                Assert.That(distance, Is.EqualTo(1));
            }
        
            Assert.That(result.Last(), Is.EqualTo(end));
        }


    }
}
