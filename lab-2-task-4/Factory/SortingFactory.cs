using lab_2_task_4.Sorting;
using System;
using System.Collections.Generic;

namespace lab_2_task_4.Factory
{
    public abstract class SortingFactory
    {
        private readonly string _name;

        public SortingFactory(string Name) => _name = Name;

        public string Name { get => _name; }

        protected abstract ISorting<T> NewInstance<T>();

        private static readonly List<SortingFactory> factories = new List<SortingFactory>(new SortingFactory[]
        {
            new BubbleSortingFactory(),
            new ShakerSortingFactory()
        });

        public static void Output()
        {
            int number = 1;
            foreach (SortingFactory factory in factories)
            {
                Console.WriteLine($"{number++, 2}) {factory.Name}");
            }
        }

        public static ISorting<T> NewInstance<T>(int number)
        {
            return factories[number - 1].NewInstance<T>();
        }
    }
}
