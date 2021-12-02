using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Day1.Tests
{
    [TestClass]
    public class DepthAnalyzerTests
    {
        private readonly List<int> _testDepths = new List<int>()
        {
            199,
            200,
            208,
            210,
            200,
            207,
            240,
            269,
            260,
            263
        };

        [TestMethod]
        public void DepthIncreaseIsAccurate()
        {
            // Act
            var depthIncreaseCount = DepthAnalyzer.FindDepthIncrease(_testDepths);
            
            // Assert
            Assert.AreEqual(7, depthIncreaseCount);
        }

        [TestMethod]
        public void WindowedDepthIncreaseIsAccurate()
        {
            // Act
            var depthIncreaseCount = DepthAnalyzer.FindWindowedDepthIncrease(_testDepths);

            // Assert
            Assert.AreEqual(5, depthIncreaseCount);
        }
    }
}