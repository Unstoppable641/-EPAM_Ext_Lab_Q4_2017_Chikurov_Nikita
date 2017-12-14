namespace Task04
{
    using System;

    public class CreateMap : IMap
    {
        private int[,] bonuses;

        private int[,] barriers;

        public CreateMap()
        {
            /// Создание конструктора по дефолту как и в CreatePlayer
        }

        public int Height
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Width
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void SetBonuses()
        {
            /// заполнение массива с бонусами и размещение их на мапе
        }

        public void SetBarriers()
        {
            /// заполнение массива с барьерами и размещение их на мапе
        }

        public void Map(int w, int h)
        {
            /// создание карты 
            this.Width = w;
            this.Height = h;
            this.barriers = new int[w * h / 220, w * h / 220];
            this.bonuses = new int[w * h / 220, w * h / 220];
        }
    }
}
