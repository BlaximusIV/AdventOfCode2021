namespace Day5
{
    public struct Line
    {
        public (int X, int Y) Point1;
        public (int X, int Y) Point2;

        public LineType LineType =>
            Point1.X == Point2.X ? LineType.Vertical :
            Point1.Y == Point2.Y ? LineType.Horizontal :
            LineType.Diagonal;

        public (int X, int Y) LowPoint => Point1.Y < Point2.Y ? Point1 : Point2;
        public (int X, int Y) HighPoint => LowPoint == Point1 ? Point2 : Point1;

        public (int X, int Y) LeftPoint => Point1.X < Point2.X ? Point1 : Point2;
        public (int X, int Y) RightPoint => Point1 == LeftPoint ? Point2 : Point1;

        // Only accurate for Diagonal
        public bool IsInclined => LeftPoint.Y < RightPoint.Y;

        public Line(int x1, int y1, int x2, int y2)
        {
            Point1 = (x1, y1);
            Point2 = (x2, y2);
        }

    }
}
