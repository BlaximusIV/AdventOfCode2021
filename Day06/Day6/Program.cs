
var fishAges = new List<int>();

// Change as appropriate
const string inputPath = @"C:\repos\AdventOfCode2021\Day6\input.txt";
using (var sr = new StreamReader(inputPath))
    fishAges.AddRange(sr.ReadLine().Split(',').Select(s => int.Parse(s)));


Dictionary<int, double> FishAtDays = new Dictionary<int, double>()
{
    { 0, 0 },
    { 1, 0 },
    { 2, 0 },
    { 3, 0 },
    { 4, 0 },
    { 5, 0 },
    { 6, 0 },
    { 7, 0 },
    { 8, 0 }
};

foreach (var age in fishAges)
    FishAtDays[age]++;

const int iterationCount = 256;
for (int i = 0; i < iterationCount; i++)
{
    double buffer = FishAtDays[0];

    for (int j = 0; j < FishAtDays.Count - 1; j++)
        FishAtDays[j] = FishAtDays[j + 1];

    FishAtDays[6] += buffer;
    FishAtDays[8] = buffer;
}

Console.WriteLine($"Total fish after {iterationCount} days: {FishAtDays.Values.Sum()}");
