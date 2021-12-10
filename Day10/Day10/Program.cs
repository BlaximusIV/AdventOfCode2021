
var inputlines = new List<string>();

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

long bugCatchSum = 0;
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

    if (!isLineCorrect)
    {
        var offendingChar = inputlines[i][charIndex];
        bugCatchSum += GetCharScore(offendingChar);
    }
}

Console.Write($"Bugbash score: {bugCatchSum}");


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

int GetCharScore(char ch)
{
    if (ch == ')')
        return 3;
    else if (ch == '>')
        return 25137;
    else if (ch == ']')
        return 57;
    else
        return 1197;
}
