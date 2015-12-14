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
                 return maze.Split(new[] { Environment.NewLine },StringSplitOptions.None)[p.Y][p.X];
             };

            Func<Point, IEnumerable<Point>> getNeighbours = (p) =>
             {
                 var allPoints = new Point[] {
                new Point(p.X, p.Y - 1),
                 new Point(p.X + 1, p.Y),
                 new Point(p.X, p.Y + 1),
                 new Point(p.X - 1, p.Y),
             };

                 return allPoints.Where(x => getCell(x) != '%');
                 
             };


            var result = DepthFirstSearch.FindPath(start, end, getNeighbours);

            var expected = new[] { Point.Empty };
            Assert.That(result, Is.EquivalentTo(expected));
        }


    }
}
