using System;
using System.Collections.Generic;

namespace lab_2_task_4.Sorting
{
    public class ShakerSorting<T> : ISorting<T>
    {
        public void Sort(List<T> list, Comparison<T> comparison)
        {
            int leftBorder = 0, rightBorder = list.Count - 1, newBorder = rightBorder;
            do
            {
                for (var i = leftBorder; i < rightBorder; i++)
                {
                    if (comparison(list[i], list[i + 1]) > 0)
                    {
                        T tmp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = tmp;
                        newBorder = i;
                    }
                }
                rightBorder = newBorder;
                for (var i = rightBorder; i > leftBorder; i--)
                {
                    if (comparison(list[i], list[i - 1]) < 0)
                    {
                        T tmp = list[i];
                        list[i] = list[i - 1];
                        list[i - 1] = tmp;
                        newBorder = i;
                    }
                }
                leftBorder = newBorder;
            }
            while (leftBorder < rightBorder);
        }
    }
}
