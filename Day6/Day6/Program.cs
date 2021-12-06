
var fishAges = new List<int>();

// Change as appropriate
const string inputPath = @"C:\repos\AdventOfCode2021\Day6\input.txt";
using (var sr = new StreamReader(inputPath))
    fishAges.AddRange(sr.ReadLine().Split(',').Select(s => int.Parse(s)));

const int iterationCount = 80;
for (int i = 0; i < iterationCount; i++)
{
    var newFish = new List<int>();
    for (int j = 0; j < fishAges.Count; j++)
    {
        if (fishAges[j] == 0)
        {
            fishAges[j] = 6;
            newFish.Add(8);
        }
        else
        {
            fishAges[j]--;
        }
    }

    fishAges.AddRange(newFish);
}

Console.WriteLine($"Total fish after {iterationCount} days: {fishAges.Count}");
