
var inputLines = new List<string>();

//inputLines.AddRange(new[]
//{
//    "2199943210",
//    "3987894921",
//    "9856789892",
//    "8767896789",
//    "9899965678"
//});

// Change for appropriate path
const string inputPath = @"C:\repos\AdventOfCode2021\Day9\input.txt";
using (var sr = new StreamReader(inputPath))
    while (!sr.EndOfStream)
        inputLines.Add(sr.ReadLine() ?? string.Empty);

var topography = new List<List<int>>();
for (int i = 0; i < inputLines.Count; i++)
{
    var line = new List<int>();
    for (int j = 0; j < inputLines[i].Length; j++)
        line.Add(int.Parse(inputLines[i][j].ToString()));

    topography.Add(line);
}

var riskLevelSum = 0;
for (int i = 0; i < topography.Count; i++)
{
    for (int j = 0; j < topography[i].Count; j++)
    {
        var current = topography[i][j];
        bool top = true;
        bool left = true;
        bool right = true;
        bool bottom = true;

        // Top
        if (i - 1 >= 0)
            top = topography[i - 1][j] > current;
        if (j - 1 >= 0)
            left = topography[i][j - 1] > current;
        if (i + 1 < topography.Count)
            bottom = topography[i + 1][j] > current;
        if (j + 1 < topography[i].Count)
            right = topography[i][j + 1] > current;

        // calculate and add risk level
        if (top && left && bottom && right)
            riskLevelSum += current + 1;
    }
}

Console.WriteLine($"Risk level: {riskLevelSum}");
