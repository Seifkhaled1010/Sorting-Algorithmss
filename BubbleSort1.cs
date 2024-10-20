﻿namespace Sorting_Algorithmss.SortClasses
{
    public class BubbleSort1 : AbstractSort
    {
        public override void Sort(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                bool isAnyChange = false;
                for (int j = 0; j < a.Length - 1; j++)
                {
                    if (a[j] < a[j + 1])
                    {
                        isAnyChange = true;
                        (a[j], a[j + 1]) = (a[j + 1], a[j]);
                    }
                }
                if (!isAnyChange)
                    break;
            }
        }
    }
}
