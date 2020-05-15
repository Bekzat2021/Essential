using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Second s = new Second { Seconds = 115 };

            Hour h = s;

            Console.WriteLine(h.Hours);
            Console.WriteLine(h.Minutes);
            Console.WriteLine(h.Seconds);
        }
    }

    class Second
    {
        public int Seconds { get; set; }
    }

    class Minute
    {
        public int Seconds { get; set; }
        public int Minutes { get; set; }

        public static implicit operator Minute(Second s)
        {
            int min = s.Seconds / 60;
            int sec = s.Seconds % 60;
            return new Minute { Minutes = min, Seconds = sec };
        }

        public static implicit operator Second(Minute m)
        {
            return new Second { Seconds = (m.Minutes * 60) + (m.Seconds) };
        }
    }

    class Hour
    {
        public int Seconds { get; set; }
        public int Minutes { get; set; }
        public int Hours { get; set; }

        public static implicit operator Hour(Second s)
        {
            int hours = s.Seconds / 3600;
            int minutes = (s.Seconds % 3600) / 60;
            int seconds = (s.Seconds % 3600) % 60;
            return new Hour { Seconds = seconds, Hours = hours, Minutes = minutes };
        }
    }
}
