using lab_2_task_4.Sorting;

namespace lab_2_task_4.Factory
{
    public class InsertionSortingFactory : SortingFactory
    {
        public InsertionSortingFactory() : base("Insertion sort") {}

        protected override ISorting<T> NewInstance<T>()
        {
            return new InsertionSorting<T>();
        }
    }
}
