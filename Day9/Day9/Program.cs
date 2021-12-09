
var inputLines = new List<string>();

// Test Values
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

var mappedCoordinates = new List<(int X, int Y)>();
var basinsSizes = new List<int>();

for (int i = 0; i < topography.Count; i++)
{
    for (int j = 0; j < topography[i].Count; j++)
    {
        if (!mappedCoordinates.Contains((i, j)) && topography[i][j] != 9)
            basinsSizes.Add(GetBasin(i, j).Count);
    }
}

List<(int row,int col)> GetBasin(int row, int col)
{
    var basin = new List<(int row, int col)>();

    AddCoordinates(basin, row, col);
    mappedCoordinates.AddRange(basin);

    return basin;
}

void AddCoordinates(List<(int row, int col)> basin, int row, int col)
{
    basin.Add((row, col));

    // Right
    if (!basin.Contains((row, col + 1)) 
        && col + 1 < topography[0].Count 
        && topography[row][col + 1] != 9)
    {
        AddCoordinates(basin, row, col + 1);
    }
    // Top
    if (!basin.Contains((row - 1, col))
        && row - 1 >= 0
        && topography[row - 1][col] != 9)
    {
        AddCoordinates(basin, row - 1, col);
    }
    // Left
    if (!basin.Contains((row, col -1))
        && col - 1 >= 0
        && topography[row][col - 1] != 9)
    {
        AddCoordinates(basin, row, col - 1);
    }
    // Bottom
    if (!basin.Contains((row + 1, col))
        && row + 1 < topography.Count
        && topography[row + 1][col] != 9)
    {
        AddCoordinates(basin, row + 1, col);
    }
}

basinsSizes.Sort();
basinsSizes.Reverse();

Console.WriteLine($"Greatest basin product: {basinsSizes[0] * basinsSizes[1] * basinsSizes[2]}");
