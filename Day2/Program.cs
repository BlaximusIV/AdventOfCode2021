
#region Ingest Data

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

#endregion

#region Simulate Travel

// The only directions given
const string up = nameof(up);
const string down = nameof(down);
const string forward = nameof(forward);

var range = 0;
var depth = 0;

foreach (var step in pathDirections)
{
    if (step.direction == up)
        depth -= step.magnitude;

    else if (step.direction == down)
        depth += step.magnitude;

    else 
        range += step.magnitude;
}

#endregion

Console.WriteLine($"Final Depth: {depth} Final Horizontal Range: {range} Total Distance Travelled: {depth * range}");