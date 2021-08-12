using lab_2_task_4.Sorting;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2_task_4.Factory
{
    public class BubbleSortingFactory : SortingFactory
    {
        public BubbleSortingFactory() : base("Bubble sort") {}

        protected override ISorting<T> NewInstance<T>()
        {
            return new BubbleSorting<T>();
        }
    }
}
