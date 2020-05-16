using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dollar d = new Dollar { Sum = 556 };
            Console.WriteLine($"$ {d.Sum}");

            Euro e = (Euro)d;
            Console.WriteLine($"€ {e.Sum}");
        }
    }

    class Dollar
    {
        public decimal Sum { get; set; }
    }

    struct DollarPrice
    {
        public static decimal Euro { get; private set; } = 1.08197M;
    }

    class Euro
    {
        public decimal Sum { get; set; }

        public static implicit operator Dollar(Euro e)
        {
            return new Dollar { Sum = e.Sum * DollarPrice.Euro };
        }

        public static explicit operator Euro(Dollar d)
        {
            return new Euro { Sum = d.Sum / DollarPrice.Euro };
        }
    }
}
