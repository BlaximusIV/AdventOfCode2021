﻿using Day3;

var binaryStrings = new List<string>();

// Change for appropriate path
const string inputPath = @"C:\repos\AdventOfCode2021\Day3\input.txt";
using (var sr = new StreamReader(inputPath))
    while (!sr.EndOfStream)
        binaryStrings.Add(sr.ReadLine());

var powerConsumption = ReportAnalyzer.FindPowerConsumption(binaryStrings);
var lifeSupportRating = ReportAnalyzer.FindLifeSupportRating(binaryStrings);

Console.WriteLine($"Power consumption: {powerConsumption}");
Console.WriteLine($"Life support rating: {lifeSupportRating}");

