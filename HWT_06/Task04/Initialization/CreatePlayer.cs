namespace Task04
{
    using System;

    public class CreatePlayer : IUnit
    {
        /// <summary>
        /// создание конструктора по дефолту, с указанием парамметров - Nick, MoveSpeed и т.п.
        /// </summary>
        public CreatePlayer(string nick)
        {
            this.Nickname = nick;
            /// и т.д.
        }

        /// <summary>
        /// реализация интерфейса
        /// автоматически сгенерированная решарпером
        /// </summary>
        public int Damage
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

        public int Dex
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

        public int Hp
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

        public int Int
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

        public int Mana
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

        public int MoveSpeed
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

        public string Nickname
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

        public int PosX
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

        public int PosY
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

        public int Str
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

        public CreateMap Map
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public void TakeBonus()
        {
            /// реализация подбора бонуса
        }

        public void Move(string way)
        {
            /// реализация перемещения с учетом всех (!) коллизий
        }
    }
}
