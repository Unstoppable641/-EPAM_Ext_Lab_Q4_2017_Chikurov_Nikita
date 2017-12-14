namespace Task02
{
    using System;

    public class Round
    {
        /// <summary>
        /// Когда добавляю проверку на OutteR(с одной "t"),
        /// чтобы вводились только положительные числа,
        /// после компиляции прога выкидывает StackoverflowException ?!
        /// </summary>
        public Round()
        {
        }

        public Round(int x, int y, int r)
        {
            this.OutteR = r;
            this.X = x;
            this.Y = y;
        }

        public int OutteR { get; set; }

        protected internal int X { get; set; }

        protected internal int Y { get; set; }

        public double Area()
        {
            return Math.PI * this.OutteR * this.OutteR;
        }

        public double Length()
        {
            return 2 * Math.PI * this.OutteR;
        }

        public virtual string Display() //todo pn ToString лучше
        {
            return string.Format($"The circle with the center ({X}; {Y}) and the radius R = {OutteR} has the area = {Area(): 0. ##} and the perimeter = {Length():0.##}");
        }
    }
}
