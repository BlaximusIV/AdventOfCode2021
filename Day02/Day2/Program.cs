using Day2;

var pathDirections = new List<(string direction, int magnitude)>();

// Change for appropriate path
const string inputPath = @"C:\repos\AdventOfCode2021\Day2\input.txt";
using (var sr = new StreamReader(inputPath))
    while (!sr.EndOfStream)
        pathDirections.Add(parseDirection(sr.ReadLine()));

static (string, int) parseDirection(string direction)
{
    var directionDetails = direction.Split(' ');
    return (directionDetails[0], int.Parse(directionDetails[1]));
}

var distance = TravelSimulator.FindDistanceTravelledByAim(pathDirections);

Console.WriteLine($"Total Distance Travelled: {distance}");