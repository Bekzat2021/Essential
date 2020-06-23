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
            CircularLinkedList<string> linkedList = new CircularLinkedList<string>();

            linkedList.Add("Bob");
            linkedList.Add("Tom");
            linkedList.Add("Sam");
            linkedList.Add("Joe");

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            linkedList.Remove("Joe");

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine(linkedList.Contains("Bob"));
        }
    }

    public class CircularLinkedList<T> : IEnumerable<T>
    {
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        Node<T> head;
        Node<T> tail;
        int count;

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            if(count == 0)
            {
                head = node;
                tail = node;
                tail.Next = head;
            }
            else
            {
                node.Next = head;
                tail.Next = node;
                tail = node;
            }
            count++;
        }

        public bool Remove(T data)
        {
            if (count == 0)
                return false;

            if(count == 1)
            {
                head = tail = null;
                return true;
            }
                

            Node<T> current = head;
            Node<T> previous = null;
            do
            {
                if (current.Data.Equals(data))
                {
                    previous.Next = current.Next;
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            } while (current != null);

            return false;
        }

        public bool Contains(T data)
        {
            Node<T> current = head;
            do
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            } while (current != head);
            return false;
        }

        public void Clear()
        {
            head = tail = null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            do
            {
                yield return current.Data;
                current = current.Next;
            } while (current != head);
        }
    }

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node(T data )
        {
            Data = data;
        }
    }
}