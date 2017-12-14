namespace Task03
{
    using System;

    public abstract class Figure
    {
       public Figure()
        {
            var rand = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);//todo pn хардкод
            this.X = rand.Next(20) - 10;//todo pn хардкод
			this.Y = rand.Next(20) - 10;//todo pn хардкод
		}

        public Figure(int centerX, int centerY)
        {
            this.X = centerX;
            this.Y = centerY;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public double Length()//todo pn virtual?
		{
            return 0;
        }

        public string Display()//todo pn virtual?
		{
            return "The figure is not selected.";
        }

        public double Area()//todo pn virtual?
		{
            return 0;
        }
    }
}
