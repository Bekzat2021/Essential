using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Bread bread = new Bread { Weight = 80 };
            Butter butter = new Butter { Weight = 20 };

            Sandwich sandwich = bread + butter;

            Console.WriteLine(sandwich.Weight);
        }

        class Bread
        {
            public int Weight { get; set; }

            public static Sandwich operator +(Bread bread, Butter butter)
            {
                return new Sandwich { Weight = bread.Weight + butter.Weight };
            }
        }

        class Butter
        {
            public int Weight { get; set; }
        }

        class Sandwich
        {
            public int Weight { get; set; }
        }
    }
}
