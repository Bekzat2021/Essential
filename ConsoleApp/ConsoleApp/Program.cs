using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int length = numbers.Length;
            int middle = length / 2;
            int temp;

            for (int i = 0; i < middle; i++)
            {
                temp = numbers[i];
                numbers[i] = numbers[length - i - 1];
                numbers[length - i - 1] = temp;
            }

            foreach (var item in numbers)
            {
                Console.Write(item + " ");
            }
        }
    }
}
