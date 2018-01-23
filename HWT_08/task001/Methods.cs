namespace Task001
{
    using static System.String;

    public static class Methods
    {
        public delegate void Comparing(ref string first, ref string second);

        public static void Sort(string[] strings, Comparing del)
        {
            if (strings == null || del == null)
            {
                return;
            }

            for (var i = 0; i < strings.Length - 1; i++)//todo pn давай не пузырьковой сортировкой, а более оптимальной
            {
                for (var j = i + 1; j < strings.Length; j++)
                {
                    Compare(ref strings[i], ref strings[j]);
                }
            }
        }

        public static void Compare(ref string first, ref string second)
        {
            if (first.Length == second.Length)
            {
                if (CompareOrdinal(first, second) < 0)
                {
                    Swap(ref first, ref second);
                }
            }

            if (first.Length < second.Length)
            {
                Swap(ref first, ref second);
            }
        }

        private static void Swap(ref string first, ref string second)
        {
            var swap = first;
            first = second;
            second = swap;
        }
    }
}
