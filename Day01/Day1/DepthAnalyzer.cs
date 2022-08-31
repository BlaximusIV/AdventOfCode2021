namespace Day1
{
    public static class DepthAnalyzer
    {
        /// <summary>
        /// Find how many times depth increases for the given set of depth readings.
        /// Used in D1, Pt. 1 Solution.
        /// </summary>
        /// <param name="depthReadings"></param>
        /// <returns></returns>
        public static int FindDepthIncrease(List<int> depthReadings)
        {
            int? cursor = null;
            var depthIncreaseCount = 0;

            foreach (var reading in depthReadings)
            {
                if (reading > cursor)
                    depthIncreaseCount++;

                cursor = reading;
            }

            return depthIncreaseCount;
        }

        /// <summary>
        /// Use a windowed approach to give a more accurate picture of increasing depth.
        /// Used in D1 Pt. 2 Solution.
        /// </summary>
        /// <param name="depthReadings"></param>
        /// <returns></returns>
        public static int FindWindowedDepthIncrease(List<int> depthReadings)
        {
            var depthIncreaseCount = 0;

            // offset to take into account sliding window size
            const int windowSize = 3;
            for (int i = 0; i < depthReadings.Count - windowSize; i++)
            {
                var windowOneSum = depthReadings.GetRange(i, windowSize).Sum();
                var windowTwoSum = depthReadings.GetRange(i + 1, windowSize).Sum();

                if (windowTwoSum > windowOneSum)
                    depthIncreaseCount++;
            }

            return depthIncreaseCount;
        }
    }
}
