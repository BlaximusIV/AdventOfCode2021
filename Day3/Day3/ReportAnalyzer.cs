namespace Day3
{
    public static class ReportAnalyzer
    {
        private const char One = '1';
        private const char Zero = '0';

        public static long FindPowerConsumption(List<string> binaryStrings)
        {
            var GammaBinaryString = GetMostCommonBinaryString(binaryStrings);
            var EpsilonBinaryString = GetFlippedBinaryString(GammaBinaryString);

            var gammaRate = Convert.ToInt32(GammaBinaryString, 2);
            var epsilonRate = Convert.ToInt32(EpsilonBinaryString, 2);

            return gammaRate * epsilonRate;
        }


        public static long FindLifeSupportRating(List<string> binaryStrings)
        {
            var OxygenGeneratorRating = FindRating(binaryStrings);
            var CO2ScrubberRating = FindRating(binaryStrings, index: 0, isInverted: true);

            var OxygenDecimal = Convert.ToInt32(OxygenGeneratorRating, 2);
            var CO2Decimal = Convert.ToInt32(CO2ScrubberRating, 2);

            return OxygenDecimal * CO2Decimal;
        }

        // It seems like there should be some wizardry that lets me skip the double loops
        // I've spent too much time on this though, and am going to move on with my life
        private static string GetMostCommonBinaryString(IEnumerable<string> binaryStrings)
        {
            var mostCommonString = string.Empty;
            for (int i = 0; i < binaryStrings.First().Length; i++)
                mostCommonString += GetMostCommonBit(binaryStrings, i);

            return mostCommonString;
        }

        private static char GetMostCommonBit(IEnumerable<string> binaryStrings, int index)
        {
            int OneCount = 0, ZeroCount = 0;
            foreach (var binaryString in binaryStrings)
                if (binaryString[index] == One)
                    OneCount++;
                else
                    ZeroCount++;

            if (OneCount == ZeroCount)
                return One;

            return OneCount > ZeroCount ? One : Zero;
        }

        private static string GetFlippedBinaryString(string binaryString)
        {
            var flippedString = string.Empty;

            foreach (char c in binaryString)
                flippedString += FlipBit(c);

            return flippedString;
        }

        private static char FlipBit(char bit) => bit == One ? Zero : One;

        private static string FindRating(IEnumerable<string> binaryStrings, int index = 0, bool isInverted = false)
        {
            if (binaryStrings.Count() == 1)
                return binaryStrings.Single();

            var seekingChar = GetMostCommonBit(binaryStrings, index);

            if (isInverted)
                seekingChar = FlipBit(seekingChar);

            var filteredStrings = binaryStrings.Where(s => s[index] == seekingChar);

            return FindRating(filteredStrings, index + 1, isInverted);
        }
    }
}
