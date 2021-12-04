using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class BingoBoard
    {

        private bool[][] board = new bool[5][];

        private readonly Dictionary<string, (int x, int y)> boardMap = new Dictionary<string, (int, int)>();

        public BingoBoard(string[] boardRows)
        {
            for (int i = 0; i < boardRows.Count(); i++)
            {
                var rowNumbers = boardRows[i].Split(' ');
                for (int j = 0; j < rowNumbers.Length; j++)
                    boardMap[rowNumbers[j]] = (i, j);
            }
        }

        public void MarkBoard(string number)
        {
            if (boardMap.ContainsKey(number))
                board[boardMap[number].x][boardMap[number].y] = true;
        }

        public bool IsWinningBoard()
        {
            // We know ahead of time that we will only have 5 X 5 boards,
            // so we can be more relaxed about indexes
            for (int i = 0;i < board.Length; i++)
                if (IsWinningRow(board[i]))
                    return true;

            for (int i = 0; i <= board.Length; i++)
                if (IsWinningColumn(i))
                    return true;

            return false;
        }

        public long FindWinningScore(string winningNumber)
        {
            var tally = 0;
            foreach (var key in boardMap.Keys)
            {
                // If the position has been chosen
                if (board[boardMap[key].x][boardMap[key].y])
                    continue;

                tally += int.Parse(key);
            }

            return tally * int.Parse(winningNumber);
        }

        private bool IsWinningRow(bool[] row) => row.All(position => position is true);

        private bool IsWinningColumn(int columnIndex)
        {
            var pickedCount = 0;
            foreach (var row in board)
                if (row[columnIndex])
                    pickedCount++;

            return pickedCount == board.Length;
        }

    }
}
