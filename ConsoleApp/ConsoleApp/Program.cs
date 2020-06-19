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
            DoubleList<string> names = new DoubleList<string>();
            names.Add("Joe");
            names.AddFirst("Bob");
            names.Add("Smith");
            names.Add("Tony");
            names.ShowAll();

            names.Remove("Bob");
            names.ShowAll();
        }
    }

    public class DoubleList<T>
    {
        public DoubleNode<T> First { get; set; }
        public int Count { get; private set; }
        public bool IsEmpty { get { return Count == 0; } }
        private DoubleNode<T> Tail;

        public void AddFirst(T data)
        {
            DoubleNode<T> current = new DoubleNode<T>(data);
            if (First == null)
            {
                First = current;
                Tail = current;
            }
            else
            {
                DoubleNode<T> temp = First;
                First = current;
                temp.Previous = current;
                current.Next = temp;
            }
            Count++;
        }
        public void Add(T data)
        {
            DoubleNode<T> current = new DoubleNode<T>(data);
            if (First == null)
            {
                First = current;
            }
            else
            {
                Tail.Next = current;
                current.Previous = Tail;
            }
            Count++;
            Tail = current;
        }

        public void Remove(T data)
        {
            DoubleNode<T> current = new DoubleNode<T>(data);
            DoubleNode<T> currentSearchObject = First;
            while (currentSearchObject != null)
            {
                if (currentSearchObject.Data.Equals(data))
                {
                    if(currentSearchObject == Tail && currentSearchObject.Previous != null)
                    {
                        currentSearchObject.Previous.Next = null;
                        currentSearchObject = null;
                    }
                    if (currentSearchObject == First && currentSearchObject.Next != null)
                    {
                        First = currentSearchObject;
                        currentSearchObject.Previous = null;
                    }
                    else if(currentSearchObject == First)
                    {
                        First = null;
                    }
                }
                currentSearchObject = currentSearchObject.Next;
            }
        }

        public void Clear()
        {
            First = null;
            Tail = null;
            Count = 0;
        }

        public void ShowAll()
        {
            DoubleNode<T> current = First;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
            Console.WriteLine();
        }
    }

    public class DoubleNode<T>
    {
        public T Data { get; set; }
        public DoubleNode(T data)
        {
            Data = data;
        }
        public DoubleNode<T> Next { get; set; }
        public DoubleNode<T> Previous { get; set; }
    }

}