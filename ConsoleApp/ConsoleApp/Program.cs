using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StackM<string> stackM = new StackM<string>();
            stackM.Push("A");
            stackM.Push("B");
            stackM.Push("C");

            Console.WriteLine(stackM.Peek());
            stackM.Push("D");
            Console.WriteLine(stackM.Peek());

            stackM.Pop();
            stackM.Pop();
            stackM.Pop();
            Console.WriteLine(stackM.Peek());
        }
    }

    public class StackM<T>
    {
        private T[] items;
        private int count;
        private int initialCapacity = 10;
        public StackM()
        {
            items = new T[initialCapacity];
        }

        public int Count
        {
            get { return count; }
        }

        public bool IsEmpty
        {
            get { return count == 0; }
        }

        public void Push(T item)
        {
            if (count == items.Length)
                Resize(items.Length * 2);

            items[count++] = item;
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new Exception("Stack is empty");
            
            return items[--count];
        }

        public T Peek()
        {
            if(IsEmpty)
                throw new Exception("Stack is empty");

            return items[count - 1];
        }

        public void Resize(int newLength)
        {
            T[] newItems = new T[newLength];
            for (int i = 0; i < count; i++)
                newItems[i] = items[i];

            items = newItems;
        }
    }
}