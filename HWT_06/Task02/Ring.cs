namespace Task02
{
    using System;

    public class Ring : Round
    {
        public Ring()
        {
        }

        public Ring(int x, int y, int r1, int r2)
            : base(x, y, r1)
        {
            this.InneR = r2;
        }

        public int InneR { get; set; }

        public new double Area()
        {
            return (Math.PI * this.OutteR * this.OutteR) - (Math.PI * this.InneR * this.InneR);
        }

        public double Perimeter()
        {
			//todo pn спокойнее-спокойнее) на замечания о скобках тоже можно забить (но не во всех случаях)
            //// С**А КАК ЖЕ ГОРИТ УЖЕ. ПОЧЕМУ ОН ГОВОРИТ СНАЧАЛА ЧТО НУЖНО ПОСТАВИТЬ ПРИОРИТЕТ СКОБКАМИ, А ПОТОМ ГОВОРИТ ЧТО У ВАС ЕСТЬ БЕСПОЛЕЗНЫЕ СКОБКИ
            return ((2 * (Math.PI * this.OutteR)) + ((2 * Math.PI) * this.InneR));
        }

        public override string Display()
        {
            return
                $"The ring with the center (\n{X}; {Y}), the outer radius R = {OutteR} and the inner radius R2 = {InneR}, \n has the area = {Area(): 0. ##} and the perimeter = {Perimeter(): 0. ##} ";
        }
    }
}
