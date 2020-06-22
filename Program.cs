using System;
using System.Collections.Generic;
using static ConsoleApp5.Task1;
using static ConsoleApp5.Task2;
using static ConsoleApp5.Task3;


namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            task1();
            task2();
            task3();
            task4();
        }

        public static void task1()
        {
            Console.WriteLine("Task1:");

            Console.WriteLine(CheckAnagram("hello", "elhol"));
            Console.WriteLine(CheckAnagram("world", "ldrow"));
            Console.WriteLine(CheckAnagram("anagram", "nasdfwr"));
        }

        public static void task2()
        {
            Console.WriteLine("Task2:");

            List<int> list = new List<int>() {9, 2, 5, 1, 3, 8, 4, 7, 6};
            list = MergeSort(list);
            Console.WriteLine(String.Join(" ", list));
        }

        public static void task3()
        {
            Console.WriteLine("Task3:");

            LinkedList<int> list = new LinkedList<int>();

            list.Add(10);
            list.Add(2);
            list.Add(3);
            list.Add(40);
            list.Add(12);
            list.Add(53);

            list.Add(88);
            list.Add(5);
            list.Add(243);
            list.Add(33);
            list.Add(55);
            list.Add(9);


            SwapValues(list, 6);

            list.print();
        }

        public static void task4()
        {
            List<Aeroflot> aeroflots = new List<Aeroflot>()
            {
                new Aeroflot("C", 22, new[] {1, 2, 3, 4, 5, 6, 7}),
                new Aeroflot("D", 12, new[] {1, 2, 3, 4, 5, 6, 7}),
                new Aeroflot("A", 7, new[] {1, 2, 3, 4, 5, 6, 7})
            };
            
            Aeroflot.Write("/Users/andriypyzh/RiderProjects/Exam/ConsoleApp5/file.txt", aeroflots);
            
            Task4 task = new Task4();
            task.show();
        }
    }
}