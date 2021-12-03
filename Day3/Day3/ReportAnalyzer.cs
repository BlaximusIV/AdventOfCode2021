namespace Day3
{
    public static class ReportAnalyzer
    {
        public static long FindPowerConsumption(List<string> binaryStrings)
        {
            var binaryCounter = GetBinaryPositionCounts(binaryStrings);
            (string GammaBinaryString, string EpsilonBinaryString) = GetMostLeastCommonBinaryString(binaryCounter, binaryStrings.Count);

            var gammaRate = Convert.ToInt32(GammaBinaryString, 2);
            var epsilonRate = Convert.ToInt32(EpsilonBinaryString, 2);

            return gammaRate * epsilonRate;
        }


        public static long FindLifeSupportRating(List<string> binaryStrings)
        {
            var binaryCounter = GetBinaryPositionCounts(binaryStrings);
            (string OxygenGeneratorRatingLocator, string CO2ScrubberRatingLocator) = GetMostLeastCommonBinaryString(binaryCounter, binaryStrings.Count);

            var OxygenGeneratorRating = FindRatingBinary(binaryStrings, 0, OxygenGeneratorRatingLocator, '1');
            var CO2ScrubberRating = FindRatingBinary(binaryStrings, 0, CO2ScrubberRatingLocator, '0');

            var OxygenDecimal = Convert.ToInt32(OxygenGeneratorRating, 2);
            var CO2Decimal = Convert.ToInt32(CO2ScrubberRating, 2);

            return OxygenDecimal * CO2Decimal;
        }

        #region Private Methods

        private static int[] GetBinaryPositionCounts(List<string> binaryStrings)
        {
            var binaryCounter = new int[binaryStrings[0].Length];
            foreach (var line in binaryStrings)
            {
                for (int i = 0; i < line.Length; i++)
                    if (line[i] == '1')
                        binaryCounter[i]++;
            }

            return binaryCounter;
        }

        // retrieve the strings representing the most common and least common bits for each position
        private static (string MostCommon, string LeastCommon) GetMostLeastCommonBinaryString(int[] binaryCounts, int listLength)
        {
            var mostCommonString = string.Empty;
            var leastCommonString = string.Empty;
            for (int i = 0; i < binaryCounts.Length; i++)
                // We know the length of the list, so it's easy to tell if it is in the majority
                if (binaryCounts[i] >= listLength / 2)
                {
                    mostCommonString += "1";
                    leastCommonString += "0";
                }
                else
                {
                    mostCommonString += "0";
                    leastCommonString += "1";
                }

            return (mostCommonString, leastCommonString);
        }

        private static string FindRatingBinary(List<string> binaryStrings, int index, string ratingLocator, char tieBreakerValue)
        {
            if (binaryStrings.Count == 1)
                return binaryStrings.Single();

            if (binaryStrings.Count < 1 || index >= binaryStrings[0].Length)
                throw new ArgumentException("Invalid data, cannot continue search.");

            var seekingValue = ratingLocator[index];
            if (binaryStrings.Count % 2 == 0)
            {
                var OneCount = binaryStrings.Count(s => s[index] == '1');
                if (OneCount == binaryStrings.Count / 2)
                    seekingValue = tieBreakerValue;
            }

            var filteredList = binaryStrings.Where(s => s[index] == seekingValue).ToList();

            return FindRatingBinary(filteredList, index + 1, ratingLocator, tieBreakerValue);
        }

        #endregion
    }
}
