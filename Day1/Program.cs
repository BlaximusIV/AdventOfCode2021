var depthReadings = new List<int>();

// Change for appropriate path
const string inputPath = @"C:\repos\AdventOfCode2021\Day1\input.txt";
using (var sr = new StreamReader(inputPath))
    while (!sr.EndOfStream)
        depthReadings.Add(int.Parse(sr.ReadLine()));

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

Console.WriteLine($"{depthIncreaseCount} increasing readings");
