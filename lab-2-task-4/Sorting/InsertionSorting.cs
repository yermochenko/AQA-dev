using System;
using System.Collections.Generic;

namespace lab_2_task_4.Sorting
{
    public class InsertionSorting<T> : ISorting<T>
    {
        public void Sort(List<T> list, Comparison<T> comparison)
        {
            for (var i = 1; i < list.Count; i++)
            {
                var element = list[i];
                var j = i - 1;
                while (j >= 0 && comparison(element, list[j]) < 0)
                {
                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = element;
            }
        }
    }
}
