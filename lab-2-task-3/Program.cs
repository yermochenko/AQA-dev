using System;
using System.Collections.Generic;

namespace lab_2_task_3
{
    class Program
    {
        static void OutputList(List<int> list)
        {
            Console.Write("List: ");
            foreach(int element in list)
            {
                Console.Write($" {element}");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.Write("Input amount of people: ");
            int n = int.Parse(Console.ReadLine());
            List<int> circle = new List<int>();
            for(int i = 1; i <= n; i++)
            {
                circle.Add(i);
            }
            OutputList(circle);
            int deletedIndex = 0;
            while(circle.Count > 1)
            {
                Console.WriteLine($"Cross out #{circle[deletedIndex]}");
                circle.RemoveAt(deletedIndex);
                OutputList(circle);
                deletedIndex++;
                if(deletedIndex >= circle.Count)
                {
                    deletedIndex = 0;
                }
            }
        }
    }
}
