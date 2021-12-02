using Day2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Day2Tests
{
    [TestClass]
    public class Day2UnitTests
    {
        [TestMethod]
        public void TestDistanceTravelled()
        {
            // Arrange
            var directions = new List<(string, int)>
            {
                ("forward", 5),
                ("down", 5),
                ("forward", 8),
                ("up", 3),
                ("down", 8),
                ("forward", 2)
            };

            // Act
            var distance = TravelSimulator.FindDistanceTravelled(directions);

            // Assert
            Assert.AreEqual(900, distance);
        }
    }
}
