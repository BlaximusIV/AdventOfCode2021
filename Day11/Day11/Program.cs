var inputLines = new List<string>();

// Testing Input
//inputLines.AddRange(new[]
//{
//    "5483143223",
//    "2745854711",
//    "5264556173",
//    "6141336146",
//    "6357385478",
//    "4167524645",
//    "2176841721",
//    "6882881134",
//    "4846848554",
//    "5283751526"
//});

// Change for appropriate path
const string inputPath = @"C:\repos\AdventOfCode2021\Day11\input.txt";
using (var sr = new StreamReader(inputPath))
    while (!sr.EndOfStream)
        inputLines.Add(sr.ReadLine() ?? string.Empty);

List<List<int>> Octopi = new List<List<int>>();
foreach (var line in inputLines)
{
    List<int> octupiRow = new List<int>();
    foreach (var octopus in line)
        octupiRow.Add(int.Parse(octopus.ToString()));

    Octopi.Add(octupiRow);
}

long flashCount = 0;
List<(int row, int col)> flashedOctupi = new List<(int row, int col)>();
const int iterationCount = 100;
for (int i = 0; i < iterationCount; i++)
{
    // Every row has the same count
    for (int j = 0; j < Octopi.Count; j++)
    {
        for (int k = 0; k < Octopi[j].Count; k++)
        {
            Octopi[j][k]++;
            if (Octopi[j][k] >= 10)
                flash(j, k);
        }
    }

    foreach ((int row, int col) in flashedOctupi)
        Octopi[row][col] = 0;

    flashCount += flashedOctupi.Count;
    flashedOctupi.Clear();
}

Console.WriteLine($"Flash count: {flashCount}");
Print();


#region Helper Methods
void flash(int row, int col)
{
    if (flashedOctupi.Contains((row, col)))
        return;

    flashedOctupi.Add((row, col));

    bool hasLeft = col - 1 >= 0;
    bool hasRight = col + 1 < Octopi[0].Count;
    bool hasTop = row - 1 >= 0;
    bool hasBottom = row + 1 < Octopi.Count;

    // Increment neighbors
    if (hasTop && hasLeft)
        IncrementOctopus(row - 1, col -1);
    if (hasTop)
        IncrementOctopus(row - 1, col);
    if (hasTop && hasRight)
        IncrementOctopus(row - 1, col + 1);
    if (hasLeft)
        IncrementOctopus(row, col - 1);
    if (hasRight)
        IncrementOctopus(row, col + 1);
    if (hasBottom && hasLeft)
        IncrementOctopus(row + 1, col - 1);
    if (hasBottom)
        IncrementOctopus(row + 1, col);
    if (hasBottom && hasRight)
        IncrementOctopus(row + 1, col + 1);
}

void IncrementOctopus(int row, int col) 
{
    Octopi[row][col]++;
    if (Octopi[row][col] >=10)
        flash(row, col);
}

void Print()
{
    foreach (var row in Octopi)
    {
        var line = string.Empty;
        foreach (var octopus in row)
            line += octopus;

        Console.WriteLine(line);
    }
}

#endregion