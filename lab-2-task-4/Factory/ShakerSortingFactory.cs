using lab_2_task_4.Sorting;

namespace lab_2_task_4.Factory
{
    public class ShakerSortingFactory : SortingFactory
    {
        public ShakerSortingFactory() : base("Shaker sort") {}

        protected override ISorting<T> NewInstance<T>()
        {
            return new ShakerSorting<T>();
        }
    }
}
