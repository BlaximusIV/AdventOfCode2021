using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class BingoSimulator
    {
        private readonly List<string> pickedNumbers = new List<string>();
        private readonly List<BingoBoard> bingoBoards = new List<BingoBoard>();

        public BingoSimulator(List<string> input)
        {
            int boardId = 1;
            List<string> boardRows = new List<string>();
            for (int i = 0; i < input.Count; i++)
            {
                if (i == 0)
                {
                    pickedNumbers = input[i].Split(',').ToList();
                    continue;
                }

                var blankRow = string.IsNullOrWhiteSpace(input[i]);
                if (!blankRow)
                    boardRows.Add(input[i]);

                if(boardRows.Count == 5)
                {
                    bingoBoards.Add(new BingoBoard(boardRows, boardId));
                    boardRows.Clear();
                    boardId++;
                }
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
