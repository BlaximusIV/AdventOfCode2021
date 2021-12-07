
var subPositions = new List<int>();

// Change as appropriate
const string inputPath = @"C:\repos\AdventOfCode2021\Day7\input.txt";
using (var sr = new StreamReader(inputPath))
    subPositions.AddRange(sr.ReadLine().Split(',').Select(s => int.Parse(s)));

// Create fuel map to calculate once... It seems like there should be a fibonacci or bit manipulation something for this, but whatever
var fuelMap = new List<int>();
for (int i = 0; i < subPositions.Max(); i++)
    fuelMap.Add(i);

var minimumTotalFuel = int.MaxValue;
for (int i = 0; i < subPositions.Max(); i++)
{
    var totalFuel = 0;
    foreach (var subPosition in subPositions)
        totalFuel += fuelMap.Where(d => d <= Math.Abs(subPosition - i)).Sum();

    if (totalFuel < minimumTotalFuel)
        minimumTotalFuel = totalFuel;
}

Console.WriteLine($"Minimum Total Fuel: {minimumTotalFuel}");
