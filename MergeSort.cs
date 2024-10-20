﻿namespace Sorting_Algorithmss.SortClasses
{
    public class MergeSort : AbstractSort
    {
        public override void Sort(int[] a)
        {
            if (a.Length <= 1)
            {
                return;
            }

            int m = a.Length / 2;
            int[] left = GetSubarray(a, 0, m - 1);
            int[] right = GetSubarray(a, m, a.Length - 1);

            Sort(left);
            Sort(right);

            int i = 0;
            int j = 0;
            int k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    a[k] = left[i++];
                }
                else
                {
                    a[k] = right[j++];
                }
                k++;
            }

            while (i < left.Length)
            {
                a[k++] = left[i++];
            }

            while (j < right.Length)
            {
                a[k++] = right[j++];
            }
        }

        private static int[] GetSubarray(int[] a, int startIndex, int endIndex)
        {
            int[] result = new int[endIndex - startIndex + 1];
            Array.Copy(a, startIndex, result, 0, endIndex - startIndex + 1);
            return result;
        }
    }
}
