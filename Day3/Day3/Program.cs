
var binaryStrings = new List<string>();

// Change for appropriate path
const string inputPath = @"C:\repos\AdventOfCode2021\Day3\input.txt";
using (var sr = new StreamReader(inputPath))
    while (!sr.EndOfStream)
        binaryStrings.Add(sr.ReadLine());

var gammaCounter = new int[12];
foreach(var line in binaryStrings)
{
    for(int i = 0; i < line.Length; i++)
        if(line[i] == '1')
            gammaCounter[i]++;
}

var gammaBinaryString = string.Empty;
var epsilonString = string.Empty;
for (int i = 0; i < gammaCounter.Length; i++)
    // We know the length of the list, so it's easy to tell if it is in the majority
    if (gammaCounter[i] > 500)
    {
        gammaBinaryString += "1";
        epsilonString += "0";
    }
    else
    {
        gammaBinaryString += "0";
        epsilonString += "1";
    }

var powerConsumption = Convert.ToInt32(gammaBinaryString, 2) * Convert.ToInt32(epsilonString, 2);

Console.WriteLine($"Power consumption: {powerConsumption} units");

