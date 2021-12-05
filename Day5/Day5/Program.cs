
using Day5;
using System.Text.RegularExpressions;

var inputlines = new List<string>();

// Change for appropriate path
const string inputPath = @"C:\repos\AdventOfCode2021\Day5\input.txt";
using (var sr = new StreamReader(inputPath))
    while (!sr.EndOfStream)
        inputlines.Add(sr.ReadLine() ?? string.Empty);

const string X1 = nameof(X1), Y1 = nameof(Y1), X2 = nameof(X2), Y2 = nameof(Y2);
const string pattern = $@"(?<{X1}>\d*),(?<{Y1}>\d*)\s->\s(?<{X2}>\d*),(?<{Y2}>\d*)";

var lines = new List<Line>();
foreach (var line in inputlines)
{
    var plotLine = Regex.Matches(line, pattern).Single().Groups;

    lines.Add(new Line(
        int.Parse(plotLine[X1].Value),
        int.Parse(plotLine[Y1].Value),
        int.Parse(plotLine[X2].Value),
        int.Parse(plotLine[Y2].Value)));
}

// Looking at the input, we don't have any coordinates above 999
const int MapSize = 1000;
var map = new VentMap(MapSize);

map.PlotLines(lines, true);

Console.WriteLine($"{map.GetIntersectionCount()} ");