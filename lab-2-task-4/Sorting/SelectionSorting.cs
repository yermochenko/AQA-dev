using System;
using System.Collections.Generic;

namespace lab_2_task_4.Sorting
{
    public class SelectionSorting<T> : ISorting<T>
    {
        public void Sort(List<T> list, Comparison<T> comparison)
        {
            for(var i = 0; i < list.Count - 1; i++)
            {
                for(var j = i + 1; j < list.Count; j++)
                {
                    if(comparison(list[i], list[j]) > 0)
                    {
                        T tmp = list[i];
                        list[i] = list[j];
                        list[j] = tmp;
                    }
                }
            }
        }
    }
}
