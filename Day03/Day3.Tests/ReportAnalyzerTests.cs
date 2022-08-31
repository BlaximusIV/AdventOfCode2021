using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Day3.Tests
{
    [TestClass]
    public class ReportAnalyzerTests
    {
        private readonly List<string> TestStrings = new List<string>
        {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010"
        };

        [TestMethod]
        public void FindPowerConsumptionIsAccurate()
        {
            // Act
            var powerConsumption = ReportAnalyzer.FindPowerConsumption(TestStrings);

            // Assert
            Assert.AreEqual(198, powerConsumption);
        }

        [TestMethod]
        public void FindLifeSupportRatingIsAccurate()
        {
            // Act
            var lifeSupportRating = ReportAnalyzer.FindLifeSupportRating(TestStrings);

            // Assert
            Assert.AreEqual(230, lifeSupportRating);
        }
    }
}