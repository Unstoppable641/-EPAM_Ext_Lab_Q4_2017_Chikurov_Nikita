namespace Task02
{
    using System;

    public class FieldsForWords
    {
        public string Word { get; private set; }

        public int Amout { get; private set; }

        public void IncAmout()
        {
            this.Amout++;
        }

        public class WordAndAmound : FieldsForWords
        {
            public WordAndAmound(string word)
            {
                this.Word = word;
                this.Amout = 1;
            }
        }
    }
}
