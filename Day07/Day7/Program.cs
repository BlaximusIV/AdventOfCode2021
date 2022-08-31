
var subPositions = new List<int>();

// Change as appropriate
const string inputPath = @"C:\repos\AdventOfCode2021\Day7\input.txt";
using (var sr = new StreamReader(inputPath))
    subPositions.AddRange(sr.ReadLine().Split(',').Select(s => int.Parse(s)));

// Create fuel map to calculate once... It seems like there should be a fibonacci or bit manipulation something for this, but whatever
var fuelIncreaseByDistance = new List<int>();
var fuelMap = new Dictionary<int, long>();
for (int i = 0; i < subPositions.Max() + 1; i++)
{
    fuelIncreaseByDistance.Add(i);
    fuelMap[i] = fuelIncreaseByDistance.Sum();
}

var minimumTotalFuel = long.MaxValue;
for (int i = 0; i < subPositions.Max(); i++)
{
    long totalFuel = 0;
    foreach (var subPosition in subPositions)
        totalFuel += fuelMap[Math.Abs(subPosition - i)];

    if (totalFuel < minimumTotalFuel)
        minimumTotalFuel = totalFuel;
}

Console.WriteLine($"Minimum Total Fuel: {minimumTotalFuel}");
