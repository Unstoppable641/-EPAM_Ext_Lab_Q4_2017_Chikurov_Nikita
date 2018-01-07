namespace Task01
{
    using System;

    public class Time : EventArgs
    {
        public static DateTime Timing => DateTime.Now;
    }
}
