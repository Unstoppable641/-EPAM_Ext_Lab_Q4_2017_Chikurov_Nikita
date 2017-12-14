namespace Task03
{
    using System;

    internal class Line : Figure
    {
        /// <param name = "x"> The X coordinate of the starting point </param>
        /// <param name = "y"> Coordinate At the starting point </param>
        /// <param name = "x1"> The X coordinate of the end point </param>
        /// <param name = "y1"> Coordinate End point </param>
        public Line()
        {
        }

        public Line(int x, int y, int x1, int y1)
                    : base(x, y)
        {
            this.X = x;
            this.Y = y;
            this.X1 = x1;
            this.Y1 = y1;
        }

        public int X1 { get; set; }

        public int Y1 { get; set; }

        public new double Length()
        {
            return Math.Sqrt(Math.Pow(this.X1 - this.X, 2) + Math.Pow(this.Y1 - this.Y, 2));
        }

        public new string Display()
        {
            return $"LINE. Start: ({X}; {Y}), End: ({X1}; {Y1}), Length: {Length(): 0, ##}";
        }
    }
}
