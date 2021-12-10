
var inputlines = new List<string>();

// Test Lines
//inputlines.AddRange(new string[]
//{
//    "[({(<(())[]>[[{[]{<()<>>",
//    "[(()[<>])]({[<{<<[]>>(",
//    "{([(<{}[<>[]}>{[]{[(<()>",
//    "(((({<>}<{<{<>}{[]{[]{}",
//    "[[<[([]))<([[{}[[()]]]",
//    "[{[{({}]{}}([{[{{{}}([]",
//    "{<[[]]>}<{[{[{[]{()[[[]",
//    "[<(<(<(<{}))><([]([]()",
//    "<{([([[(<>()){}]>(<<{{",
//    "<{([{{}}[<[[[<>{}]]]>[]]"
//});

// Change for appropriate path
const string inputPath = @"C:\repos\AdventOfCode2021\Day10\input.txt";
using (var sr = new StreamReader(inputPath))
    while (!sr.EndOfStream)
        inputlines.Add(sr.ReadLine() ?? string.Empty);

var completionScores = new List<long>();
for (int i = 0; i < inputlines.Count; i++)
{
    var charStack = new Stack<char>();
    var charIndex = 0;
    var isLineCorrect = true;
    while (isLineCorrect && charIndex < inputlines[i].Count())
    {
        var c = inputlines[i][charIndex];

        if (IsClosingChar(c))
        {
            if (!charStack.Any() || c != GetPartner(charStack.Pop()))
                isLineCorrect = false;
        }
        else
            charStack.Push(c);

        if (charIndex < inputlines[i].Count() && isLineCorrect)
            charIndex++;
    }

    if (isLineCorrect) // We know it's incomplete then
    {
        long score = 0;
        while (charStack.Any())
        {
            score *= 5;
            score += GetCharScore(GetPartner(charStack.Pop()));
        }

        completionScores.Add(score);
    }
}

completionScores.Sort();
var medianIndex = (completionScores.Count / 2);
var medianScore = completionScores[medianIndex];

Console.Write($"Median bugbash score: {medianScore}");

bool IsClosingChar(char ch) => new[] { ')', ']', '>', '}' }.Contains(ch);

char GetPartner(char ch)
{
    var partner = 
          ch == '(' ? ')'
        : ch == ')' ? '('
        : ch == ']' ? '['
        : ch == '[' ? ']'
        : ch == '{' ? '}'
        : ch == '}' ? '{'
        : ch == '<' ? '>'
        : '<';

    return partner;
}

int GetCharScore(char ch) =>
    ch == ')' ? 1
    : ch == ']' ? 2
    : ch == '}' ? 3
    : 4;

