using lab_2_task_4.Sorting;

namespace lab_2_task_4.Factory
{
    public class SelectionSortingFactory : SortingFactory
    {
        public SelectionSortingFactory() : base("Selection sort") {}

        protected override ISorting<T> NewInstance<T>()
        {
            return new SelectionSorting<T>();
        }
    }
}
