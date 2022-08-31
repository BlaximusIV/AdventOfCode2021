using Day4;

var inputStrings = new List<string>();

// Change for appropriate path
const string inputPath = @"C:\repos\AdventOfCode2021\Day4\input.txt";
using (var sr = new StreamReader(inputPath))
    while (!sr.EndOfStream)
        inputStrings.Add(sr.ReadLine());

var simulator = new BingoSimulator(inputStrings);

var winningScore = simulator.FindWinningScore();
var finalWinningScore = simulator.FindLastWinningBoardScore();

Console.WriteLine($"Winning Score: {winningScore}");
Console.WriteLine($"Final Winning Score: {finalWinningScore}");

