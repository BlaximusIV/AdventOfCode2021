
using Day8;

var inputStrings = new List<string>();
// Test Values
//{
//    @"be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
//    @"edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
//    @"fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
//    @"fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
//    @"aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
//    @"fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
//    @"dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
//    @"bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
//    @"egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
//    @"gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce",
//};

// Change as appropriate
const string inputPath = @"C:\repos\AdventOfCode2021\Day8\input.txt";
using (var sr = new StreamReader(inputPath))
    while (!sr.EndOfStream)
        inputStrings.Add(sr.ReadLine() ?? String.Empty);

inputStrings = inputStrings.Where(x => !string.IsNullOrEmpty(x)).ToList();

var segmentReadings = new List<(List<string> inputs, List<string> outputs)>();
foreach (var input in inputStrings)
{
    var topSplit = input.Split(" | ");
    var inputs = topSplit[0].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
    var outputs = topSplit[1].Split(' ').Where((x) => !string.IsNullOrWhiteSpace(x)).ToList();
    segmentReadings.Add((inputs, outputs));
}

var total = 0;
foreach(var segment in segmentReadings)
{
    var subTotal = new SevenSegmentDisplay(segment.inputs, segment.outputs).Value;
    total += subTotal;
}

Console.WriteLine($"{total} readable segments");