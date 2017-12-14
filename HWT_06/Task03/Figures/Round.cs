namespace Task03
{
    using System;

    public class Round : Figure
    {
        public Round()
        {
        }

        public Round(int x, int y, int r)
            : base(x, y)
        {
            this.Radius = r;
        }
        
        public int Radius { get; set; }

        public new double Length()
        {
            return 2 * this.Radius;
        }

        public new double Area()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        public new string Display()
        {
            return $"ROUND. Center: ({X}; {Y}), Radius: {Radius}, Circle length: {Length(): 0, ##}, Area: {Area(): 0, ##}";
        }
    }
}
