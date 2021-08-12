using lab_2_task_4.Factory;
using lab_2_task_4.Sorting;
using System;
using System.Collections.Generic;

namespace lab_2_task_4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose sort algorithm:");
            SortingFactory.Output();
            Console.Write("> ");
            int number = int.Parse(Console.ReadLine());

            /* processing numbers */
            List<int> listInt = Generator.GenerateInt();

            Console.Write("List of integer numbers:");
            foreach (int element in listInt)
            {
                Console.Write($" {element}");
            }
            Console.WriteLine();

            ISorting<int> sortingInt = SortingFactory.NewInstance<int>(number);
            sortingInt.Sort(listInt, (x, y) => y - x);

            Console.Write("Sorted integer numbers: ");
            foreach (int element in listInt)
            {
                Console.Write($" {element}");
            }
            Console.WriteLine();

            /* processing strings */
            List<string> listStr = Generator.GenerateString();

            Console.WriteLine("List of strings:");
            foreach (string element in listStr)
            {
                Console.WriteLine(element);
            }

            ISorting<string> sortingStr = SortingFactory.NewInstance<string>(number);
            sortingStr.Sort(listStr, (x, y) => x.Length - y.Length);

            Console.WriteLine("Sorted strings:");
            foreach (string element in listStr)
            {
                Console.WriteLine(element);
            }
        }
    }
}
