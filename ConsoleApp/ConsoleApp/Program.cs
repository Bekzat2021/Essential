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
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Kate");
            queue.Enqueue("Sam");
            queue.Enqueue("Alice");
            queue.Enqueue("Tom");

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine();
            string firsItem = queue.Dequeue();
            Console.WriteLine($"Извлеченный элемент: {firsItem}");
            Console.WriteLine();

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Queue<T> : IEnumerable<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        int count;
        public bool IsEmpty { get { return count == 0; } }

        public void Enqueue(T data)
        {
            Node<T> item = new Node<T>(data);
            Node<T> tempItem = Tail;
            Tail = item;
            if (count == 0)
                Head = Tail;
            else
                tempItem.Next = Tail;
            count++;
        }

        public T Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            Node<T> tempNode = Head;
            Head = Head.Next;
            count--;
            return tempNode.Data;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return Head.Data;
        }

        public bool Contains(T data)
        {
            Node<T> current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return Head.Data;
            }
        }

        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return Tail.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }

    public class Node<T>
    {
        public Node(T data)
        {
            Data = data; 
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
}