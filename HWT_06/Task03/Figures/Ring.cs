namespace Task03.Figures
{
    using System;

    public class Ring : Figure
    {
        /// <param name = "x"> X coordinate of the center of the shape </param>
        /// <param name = "y"> Coordinate At the center of the shape </param>
        /// <param name = "r1"> External Ring Radius </param>
        /// <param name = "r2"> The inner radius of the ring </param>
           public Ring(int x, int y, int r1, int r2)
                    : base(x, y)
        {
            this.Radius1 = r1;
            this.Radius1 = r2;
        }

        public Ring()
        {
        }

        public int Radius1 { get; set; }

        public int Radius2 { get; set; }
        
        public new double Length()
        {
            return (2 * this.Radius1) + (2 * this.Radius2);
        }

        public new double Area()
        {
            return (((Math.PI * this.Radius1) * this.Radius1) - ((Math.PI * this.Radius2) * this.Radius2));
        }

        public new string Display()
        {
            return
                $"RING. Center: ({X}; {Y}), Radius outer: {Radius1}, Radius inner: {Radius2}, Length: {Length(): 0, ##}, Area: {Area(): 0, ##}";
        }
    }
}
