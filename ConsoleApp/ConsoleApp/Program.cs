using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            People people = new People(3);
            people[0] = new Person { Name = "Tom", Age = 20 };
            people[1] = new Person { Name = "Bob", Age = 21 };
            people[2] = new Person { Name = "Sam", Age = 22 };

            people.ShowAllPersons();

            Console.WriteLine(people[1].Name);
            Console.WriteLine(people["Smith"].Name);
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class People
    {
        private Person[] data;
        public People(int size)
        {
            data = new Person[size];
        }

        public void ShowAllPersons()
        {
            foreach (var person in data)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }

        public Person this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }

        public Person this[string name]
        {
            get
            {
                Person p = new Person();
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i]?.Name == name)
                    {
                        data[i].Name += " - founded";
                        return data[i];
                    }
                }
                p.Name += "Not founded";
                return p;
            }
        }
    }

    class Matrix 
    {
        private int[,] numbers = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        
        public int this[int i, int j]
        {
            get
            {
                return numbers[i, j];
            }
            set
            {
                numbers[i, j] = value;
            }
        }

        public void GetAllLength()
        {
            Console.WriteLine(numbers.GetLength(0));
            Console.WriteLine(numbers.GetLength(1));
        }

        public void ShowArray()
        {
            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    Console.Write(numbers[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
