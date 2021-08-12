using System;
using System.Collections.Generic;

namespace lab_2_task_4.Sorting
{
    public class BubbleSorting<T> : ISorting<T>
    {
        public void Sort(List<T> list, Comparison<T> comparison)
        {
            for (var i = list.Count - 1; i > 0; i--)
            {
                for (var j = 0; j < i; j++)
                {
                    if (comparison(list[j], list[j + 1]) > 0)
                    {
                        T tmp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = tmp;
                    }
                }
            }
        }
    }
}
