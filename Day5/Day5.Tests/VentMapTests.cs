using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Day5.Tests
{
    [TestClass]
    public class VentMapTests
    {
        private List<Line> TestLines = new List<Line>
        {
            new Line(0,9,5,9),
            new Line(8,0,0,8),
            new Line(9,4,3,4),
            new Line(2,2,2,1),
            new Line(7,0,7,4),
            new Line(6,4,2,0),
            new Line(0,9,2,9),
            new Line(3,4,1,4),
            new Line(0,0,8,8),
            new Line(5,5,8,2)
        };

        private const int TestMapSize = 10;

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var map = new VentMap(TestMapSize);

            // Act
            map.PlotLines(TestLines, isDebug: true);

            // Assert
            Assert.AreEqual(5, map.GetIntersectionCount());
        }
    }
}