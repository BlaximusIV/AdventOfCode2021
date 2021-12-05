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

        public void PlotLines(IEnumerable<Line> lines, bool isDebug = false)
        {
            foreach(var line in lines)
                PlotLine(line);

            if (isDebug)
                PrintMap();
        }

        private void PlotLine(Line line)
        {
            if (line.LineType == LineType.Horizontal)
            {
                var start = line.X1 < line.X2 ? line.X1 : line.X2;
                var end = start == line.X1 ? line.X2 : line.X1;
                
                for (int i = start; i <= end; i++)
                    _map[line.Y1][i]++;

            }
            else if (line.LineType == LineType.Vertical)
            {
                var start = line.Y1 < line.Y2 ? line.Y1 : line.Y2;
                var end = start == line.Y1 ? line.Y2 : line.Y1;

                for (int i = start; i <= end; i++)
                    _map[i][line.X1]++;
            }

            // Not currently mapping diagonal lines
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
