namespace Task01
{
    using System.Collections.Generic;
    using System.Linq;

    public static class MySumArray
    {
        public static int Sum(this IEnumerable<int> param)
        {
            return Enumerable.Sum(param);
        }
    }
}
