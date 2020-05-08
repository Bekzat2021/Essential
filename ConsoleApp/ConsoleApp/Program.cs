using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter num 1: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter num 2: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            string answer = (num1 == num2) ? $"{num1} = {num2} " : (num1 > num2) ? $"{num1} > {num2}" : $"{num1} < {num2}";
            Console.WriteLine(answer);
        }

    }
}
