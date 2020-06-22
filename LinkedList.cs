using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    public class LinkedList<T>
    {
        protected class Node<T>
        {
            public T Value;
            public Node<T> Previous;

            public Node(T value)
            {
                this.Value = value;
            }
        }

        private Node<T> Head;
        private int Lenght;

        

        public LinkedList()
        {
            Lenght = 0;
        }

        public int GetLenght()
        {
            return Lenght;
        }
        public void Add(T elem)
        {
            Node<T> newNode = new Node<T>(elem);

            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                newNode.Previous = Head;
                Head = newNode;
            }

            Lenght++;
        }

        public void RemoveAt(int index)
        {
            Lenght--;

            Node<T> node = Head;
            for (int i = 0; i < Lenght - index - 1; i++)
            {
                node = node.Previous;
            }

            Node<T> node2 = node;

            node2 = node.Previous;
            node2 = node2.Previous;

            node.Previous = node2;
        }

        public void print()
        {
            Node<T> node = Head;
            List<T> list = new List<T>();
            for (int i = 0; i < Lenght; i++)
            {
                list.Add(node.Value);
                node = node.Previous;
            }

            list.Reverse();
            Console.WriteLine(String.Join(" ", list));
        }

        public void Swap(int index1, int index2)
        {
            T temp = this[index1];
            this[index1] = this[index2];
            this[index2] = temp;
        }

        public T this[int index]
        {
            get
            {
                if (index >= Lenght)
                {
                    throw new ArgumentException();
                }

                Node<T> node = Head;
                for (int i = 0; i < Lenght - index - 1; i++)
                {
                    node = node.Previous;
                }

                return node.Value;
            }
            set
            {
                if (index >= Lenght)
                {
                    throw new ArgumentException();
                }
                Node<T> node = Head;
                for (int i = 0; i < Lenght - index-1; i++)
                {
                    node = node.Previous;
                }

                node.Value = value;
            }
        }
    }
}