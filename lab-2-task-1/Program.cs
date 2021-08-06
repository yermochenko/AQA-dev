using System;
using System.Collections.Generic;

namespace lab_2_task_1
{
    class Program
    {
        static HashSet<int> InputSet(string name)
        {
            Console.Write($"Enter {name} set size: ");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine($"Enter {size} integer numbers ({name} set):");
            HashSet<int> set = new HashSet<int>();
            for (var i = 0; i < size; i++)
            {
                int element = int.Parse(Console.ReadLine());
                set.Add(element);
            }
            return set;
        }

        static void OutputSet(HashSet<int> set)
        {
            foreach (int element in set)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            HashSet<int> set1 = InputSet("first");
            HashSet<int> set2 = InputSet("second");
            HashSet<int> resultSet = new HashSet<int>(set1);
            resultSet.IntersectWith(set2);
            Console.Write("First set is: ");
            OutputSet(set1);
            Console.Write("Second set is: ");
            OutputSet(set2);
            Console.Write("Result set is: ");
            OutputSet(resultSet);
        }
    }
}
