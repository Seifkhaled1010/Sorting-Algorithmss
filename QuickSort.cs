namespace Sorting_Algorithmss.SortClasses
{
    public class QuickSort : AbstractSort
    {
        public override void Sort(int[] a)
        {
            Sortpart(a, 0, a.Length - 1);
        }

        private static void Sortpart(int[] a, int lowerIndex, int upperIndex)
        {
            if (lowerIndex >= upperIndex)
            {
                return;
            }

            int pivot = a[upperIndex];
            int j = lowerIndex - 1;

            for (int i = lowerIndex; i < upperIndex; i++)
            {
                if (a[i] < pivot)
                {
                    j++;
                    (a[j], a[i]) = (a[i], a[j]);
                }
            }

            int p = j + 1;
            (a[p], a[upperIndex]) = (a[upperIndex], a[p]);

            Sortpart(a, lowerIndex, p - 1);
            Sortpart(a, p + 1, upperIndex);
        }
    }
}
