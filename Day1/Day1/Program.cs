using Day1;

var depthReadings = new List<int>();

// Change for appropriate path
const string inputPath = @"C:\repos\AdventOfCode2021\Day1\input.txt";
using (var sr = new StreamReader(inputPath))
    while (!sr.EndOfStream)
        depthReadings.Add(int.Parse(sr.ReadLine()));

var depthIncreaseCount = DepthAnalyzer.FindWindowedDepthIncrease(depthReadings);

Console.WriteLine($"{depthIncreaseCount} increasing readings");
