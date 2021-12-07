
var subPositions = new List<int>();

// Change as appropriate
const string inputPath = @"C:\repos\AdventOfCode2021\Day7\input.txt";
using (var sr = new StreamReader(inputPath))
    subPositions.AddRange(sr.ReadLine().Split(',').Select(s => int.Parse(s)));

var minimumTotalFuel = int.MaxValue;
for (int i = 0; i < subPositions.Max(); i++)
{
    var totalFuel = 0;
    foreach (var subPosition in subPositions)
        totalFuel += Math.Abs(subPosition - i);

    if (totalFuel < minimumTotalFuel)
        minimumTotalFuel = totalFuel;
}

Console.WriteLine($"Minimum Total Fuel: {minimumTotalFuel}");
