namespace Sorting_Algorithmss.SortClasses
{
    public class BubbleSort2 : AbstractSort
    {
        public override void Sort(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        (a[j], a[j + 1]) = (a[j + 1], a[j]);
                    }
                }
            }
        }
    }
}
