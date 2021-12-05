namespace Day5
{
    public struct Line
    {
        public int X1;
        public int Y1;

        public int X2;
        public int Y2;

        public LineType LineType =>
            X1 == X2 ? LineType.Vertical :
            Y1 == Y2 ? LineType.Horizontal :
            LineType.Diagonal;

        public Line(int x1, int y1, int x2, int y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        
    }
}
