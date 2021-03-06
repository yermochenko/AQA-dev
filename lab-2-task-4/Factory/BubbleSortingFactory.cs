using lab_2_task_4.Sorting;

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
