var depthReadings = new List<int>();

// Change for appropriate path
const string inputPath = @"C:\repos\AdventOfCode2021\Day1\input.txt";
using (var sr = new StreamReader(inputPath))
    while (!sr.EndOfStream)
        depthReadings.Add(int.Parse(sr.ReadLine()));

int? cursor = null;
var depthIncreaseCount = 0;

foreach(var reading in depthReadings)
{
    if (reading > cursor)
        depthIncreaseCount++;

    cursor = reading;
}

Console.WriteLine($"{depthIncreaseCount} increasing readings");
