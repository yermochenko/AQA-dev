using System;
using System.Collections.Generic;

namespace lab_2_task_4.Sorting
{
    public interface ISorting<T>
    {
        void Sort(List<T> list, Comparison<T> comparison);
    }
}
