using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] letters = new char[10];
            
            for (int i = 0; i < letters.Length; i++)
            {
                Console.Write($" {i + 1} - letter: ");
                letters[i] = Convert.ToChar(Console.ReadLine());
            }

            char temp;
            for (int i = 0; i < letters.Length; i++)
            {
                for (int j = i + 1; j < letters.Length; j++)
                {
                    if ((char)letters[i] > (char)letters[j])
                    {
                        temp = letters[i];
                        letters[i] = letters[j];
                        letters[j] = temp;
                    }
                }
            }

            foreach (var item in letters)
            {
                Console.Write(item + " ");
            }
        }
    }
}
