using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Day2.Tests
{
    [TestClass]
    public class TravelSimulatorTests
    {
        private List<(string, int)> testDirections = new List<(string, int)>
        {
            ("forward", 5),
            ("down", 5),
            ("forward", 8),
            ("up", 3),
            ("down", 8),
            ("forward", 2)
        };

        [TestMethod]
        public void TestDistanceTravelled()
        {
            // Act
            var distance = TravelSimulator.FindDistanceTravelled(testDirections);

            // Assert
            Assert.AreEqual(150, distance);
        }

        [TestMethod]
        public void TestDistanceTravelledByAim()
        {
            // Act
            var distance = TravelSimulator.FindDistanceTravelledByAim(testDirections);

            // Assert
            Assert.AreEqual(900, distance);
        }
    }
}
