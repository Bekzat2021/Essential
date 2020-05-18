using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            TArray<int> array = new TArray<int> (arr);

            array.Show();
            array.Add(9);
            array.Show();

            Console.WriteLine($"Array length {array.GetLength()}");

            array.Add(158);
            array.Add(222);
            array.Show();

            Console.WriteLine($"10 element: {array[9]}");
            array[9] = 10;

            Console.WriteLine($"Array length {array.GetLength()}");
            array[10] = 11;
            array.Show();
            Console.WriteLine($"10 element: {array[9]}");

            Console.WriteLine("Deleting 2 and 4 element");
            array.DeleteAtIndex(1);
            array.DeleteAtIndex(2);
            array.Show();

            Console.WriteLine($"Array length {array.GetLength()}");

            Console.WriteLine("Deleting last element");
            array.DeleteAtIndex(8);
            array.Show();

            Console.WriteLine($"Array length {array.GetLength()}");
        }
    }

    class TArray<T>
    {
        T[] array;
        public TArray(params T[] values)
        {
            array = values;
        }

        public T this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }

        public void DeleteAtIndex(int index)
        {
            T[] temp = new T[array.Length - 1];
            for (int i = 0; i < array.Length; i++)
            {
                if (i != index)
                    temp[i] = array[i];
                else
                {
                    for (int j = i; j < temp.Length; j++)
                    {
                        temp[j] = array[j + 1];
                    }
                    break;
                }
            }
            array = temp;
        }

        public int GetLength()
        {
            return array.Length;
        }

        public void Add(T val)
        {
            T[] temp = new T[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }
            temp[array.Length] = val;
            array = temp;
        }

        public void Delete()
        {

        }

        public void Show()
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
