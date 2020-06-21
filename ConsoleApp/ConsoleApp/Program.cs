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
            NodeStack<string> stack = new NodeStack<string>();
            stack.Push("Bob");
            stack.Push("Alice");
            stack.Push("Sam");
            stack.Push("Kate");

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            string head = stack.Peek();
            Console.WriteLine($"Верхушка стека: {head}\n");
            stack.Pop();

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class NodeStack<T> : IEnumerable<T>
    {
        Node<T> head;
        int count;

        public bool IsEmpty { 
            get { return count == 0; } 
        }

        public int Count {
            get { return count; }
        }

        public void Push(T item)
        {
            Node<T> node = new Node<T>(item);
            node.Next = head;
            head = node;
            count++;
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");
            Node<T> temp = head;
            head = head.Next;
            count--;
            return temp.Data;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");
            return head.Data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while(current != null)
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