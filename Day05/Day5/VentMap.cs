using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public struct VentMap
    {
        private int[][] _map;

        public VentMap(int size)
        {
            _map = new int[size][];
            for (int i = 0; i < size; i++)
                _map[i] = new int[size];
        }

        public void PlotLines(IEnumerable<Line> lines, bool includeDiagonal = false, bool isDebug = false)
        {
            foreach(var line in lines)
                PlotLine(line, includeDiagonal);

            if (isDebug)
                PrintMap();
        }

        private void PlotLine(Line line, bool includeDiagonal = false)
        {
            if (line.LineType == LineType.Horizontal) 
                for (int i = line.LeftPoint.X; i <= line.RightPoint.X; i++)
                    _map[line.LeftPoint.Y][i]++;
            else if (line.LineType == LineType.Vertical)
                for (int i = line.LowPoint.Y; i <= line.HighPoint.Y; i++)
                    _map[i][line.LeftPoint.X]++;
            else // is diagonal
            {
                if (includeDiagonal)
                {
                    var plotX = line.LeftPoint.X;
                    var plotY = line.LeftPoint.Y;

                    while (plotX != line.RightPoint.X + 1)
                    {
                        _map[plotY][plotX]++;

                        // Diagonals are only at 45 degrees
                        plotX++;
                        if (line.IsInclined)
                            plotY++;
                        else
                            plotY--;
                    }
                }
            }
        }

        public void PrintMap()
        {
            foreach (var plotLine in _map)
            {
                var line = string.Empty;
                foreach (var point in plotLine)
                    line += $"{point} ";

                Console.WriteLine(line);
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public int GetIntersectionCount()
        {
            var intersectCount = 0;
            foreach (var line in _map)
                intersectCount += line.Where(p => p > 1).Count();

            return intersectCount;
        }
    }
}
