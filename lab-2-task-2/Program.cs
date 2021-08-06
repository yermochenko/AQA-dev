using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace lab_2_task_2
{
    class Program
    {
        static Queue<int> InputQueue()
        {
            Console.Write($"Enter queue size: ");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine($"Enter {size} integer numbers:");
            Queue<int> queue = new Queue<int>();
            for (var i = 0; i < size; i++)
            {
                int element = int.Parse(Console.ReadLine());
                queue.Enqueue(element);
            }
            return queue;
        }

        static T FindExtremum<T>(IEnumerable<T> sequence, Comparison<T> comparer)
        {
            IEnumerator<T> enumerator = sequence.GetEnumerator();
            if(enumerator.MoveNext())
            {
                T extremum = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    if (comparer(enumerator.Current, extremum) < 0)
                    {
                        extremum = enumerator.Current;
                    }
                }
                return extremum;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        static void Main(string[] args)
        {
            Queue<int> queue = InputQueue();
            Console.Write("Queue: ");
            foreach(int element in queue)
            {
                Console.Write($" {element}");
            }
            Console.WriteLine();
            int min = FindExtremum(queue, (x, y) => x - y);
            int max = FindExtremum(queue, (x, y) => y - x);
            Console.WriteLine($"min = {min}, max = {max}");
            bool needCalc = false;
            int sum = 0;
            foreach(int element in queue)
            {
                if(needCalc)
                {
                    sum += element;
                    if(element == min || element == max)
                    {
                        needCalc = false;
                    }
                }
                else
                {
                    if(element == min || element == max)
                    {
                        needCalc = true;
                        sum += element;
                    }
                }
            }
            Console.WriteLine($"sum of elements between min and max is {sum}");
        }
    }
}
