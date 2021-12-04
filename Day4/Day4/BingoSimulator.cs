using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class GameExtractor
    {
        private readonly List<string> pickedNumbers;

        private readonly List<BingoBoard> bingoBoards;

        public BingoSimulator(List<string> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                bool isBoard = false;
                if (i == 0)
                    pickedNumbers = input[i].Split(',').ToList();

                if ()
            }
        }

        public long FindWinningScore()
        {
            for (int i = 0; i < pickedNumbers.Count; i++)
                foreach(var board in bingoBoards)
                {
                    board.MarkBoard(pickedNumbers[i]);

                    // Small optimization, no use checking if we can't possibly have a winner yet
                    const int MinimumWinPickCount = 5;
                    if (i >= MinimumWinPickCount - 1 && board.IsWinningBoard())
                        return board.FindWinningScore(pickedNumbers[i]);
                }

            throw new Exception("No winner found with the given list of picked numbers");
        }

    }
}
