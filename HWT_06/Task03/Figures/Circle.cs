namespace Task03
{
    using System;

    public class Circle : Figure
    {
        public Circle()
        {
        }

        public Circle(int x, int y, int r)
            : base(x, y)
        {
            this.Radius = r;
        }

        public int Radius { get; }

        public new double Length()
        {
            return 2 * this.Radius;
        }

        public new string Display()
        {
            return $"CIRCLE. Center: ({X}; {Y}), Radius: {Radius}, Circumference: {Length(): 0, ##}";
        }
    }
}
