using System;

namespace ConsoleApp5
{
    public class Task3
    {
        public static LinkedList<int> SwapValues(LinkedList<int> a, int n)
        {
            if (a.GetLenght() != 2 * n)
                throw new ArgumentException();

            for (int i = 0; i < n; i++)
            {
                if (a[i] < a[n + i])
                {
                    a.Swap(i, n + i);
                }
            }

            return a;
        }
    }
}