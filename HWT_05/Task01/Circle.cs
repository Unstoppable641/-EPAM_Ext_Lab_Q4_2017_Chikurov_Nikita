namespace Task01
{
    using System;

    public class Circle
    {
        /// <summary>
        /// StyleCop говорит что нужно кинуть в проперти эту переменную,
        /// но она и так уже в свойстве находится, если же я меняю ей модификатор доступа
        /// на privat, мне запрещается использовать ее в другом классе, а на то что я поставил 
        /// модификатор protected он не реагирует.
        /// 
        /// еще StyleCop и ReSharper конфилктуют между собой снизу, где я пишу перед переменной
        /// "this." один говорит что так надо, другой что это useless.
        /// </summary>
        protected double radius;

        public double X { protected get; set; }

        public double Y { protected get; set; }

        public double Radius
        {
            protected get
            {
                return this.radius;
            }

            set
            {
                if (value > 0)
                {
                    this.radius = value;
                }
                else
                {
                    throw new ArgumentException("\n[Radius] must be greater than zero.\n");
                }
            }
        }

        public double GetLength()
        {
            return 2 * Math.PI * this.Radius;
        }
    }
}
