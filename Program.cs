namespace Sorting_Algorithmss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * int[] array = [-11, 12, -42, 0, 1, 90, 68, 6, -9];
            Sort(array);
            Console.WriteLine(string.Join(" | ", array));
            */

            List<AbstractSort> algorithms = new()
             {
                new SelectionSort(),
                new InsertionSort(),
                new BubbleSort1(),
                new BubbleSort2(),
                new MergeSort(),
                new ShellSort(),
                new QuickSort(),
                new HeapSort()
             };

            //the average time complexity for the mentioned algorithms:

            //O(n2) : Selection sort, insertion sort, and bubble sort
            //O(n log(n)): Merge sort, Shell sort, quicksort, and heap sort


            for (int i = 0; i <= 100000; i += 10000)
            {
                Console.WriteLine($"\nRunning tests for Algorithms = {i}:");

                List<(Type Type, long Ms)> milliseconds = [];

                for (int j = 0; j < 5; j++)
                {
                    int[] array = GetRandomArray(i);
                    int[] input = new int[i];

                    foreach (AbstractSort algorithm in algorithms)
                    {
                        array.CopyTo(input, 0);
                        Stopwatch stopwatch = Stopwatch.StartNew();
                        algorithm.Sort(input);
                        stopwatch.Stop();
                        Type type = algorithm.GetType();
                        long ms = stopwatch.ElapsedMilliseconds;
                        milliseconds.Add((type, ms));
                    }
                }
                List<(Type, double)> results = milliseconds
                     .GroupBy(r => r.Type)
                     .Select(r => (r.Key, r.Average(t => t.Ms)))
                     .ToList();

                foreach ((Type type, double avg) in results)
                {
                    Console.WriteLine($"{type.Name}: {avg} ms");
                }
            }


                Console.ReadKey();
        }

        public static int[] GetRandomArray(long length)
        {
            Random random = new();
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(-100000, 100000);
            }
            return array;
        }

        ///Selection Sort
        //The worst and the average time complexity is O(n2)
        /*
          static void Sort(int[] a) 
       {
           for (int i = 0; i < a.Length - 1; i++)
           {
               int minIndex = i;
               int minValue = a[i];
               for (int j = i + 1; j < a.Length; j++)
               {
                   if (a[j] < minValue)
                   {
                       minIndex = j;
                       minValue = a[j];
                   }
               }
               (a[i], a[minIndex]) = (a[minIndex], a[i]);
           }
       }
        */


        ///Insertion Sort
        //The worst and average time complexity is O(n2)
        /*
        static void Sort(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int j = i;
                while(j > 0 && a[j] < a[j - 1])
                {
                    (a[j], a[j - 1]) = (a[j - 1], a[j]);
                    j--;
                }
            }
        }
        */


        ///Bubble Sort
        //The worst and average time complexity is O(n2)
        /*
        static void Sort(int[] a) // 72 steps
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
        */

        /*
        static void Sort(int[] a) // 56 steps
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
        */


        ///Merge Sort
        //The worst and average time complexity is O(nlog(n))
        /*
        public static void Sort(int[] a)
        {
            if(a.Length <= 1)
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

            while(i < left.Length && j < right.Length)
            {
                if(left[i] <= right[j])
                {
                    a[k] = left[i++];
                }
                else
                {
                    a[k] = right[j++];
                }
                    k++;    
            }

            while(i < left.Length)
            {
                a[k++] = left[i++];
            }

            while(j < right.Length)
            {
                a[k++] = right[j++];
            }
        }

        public static int[] GetSubarray(int[] a, int startIndex, int endIndex)
        {
            int[] result = new int[endIndex - startIndex + 1];
            Array.Copy(a, startIndex, result, 0, endIndex - startIndex + 1);
            return result;
        }
        */


        ///Shell sort
        // In the worst case, it is O(n2) -- average time complexity is about O(nlog(n)).
        /*
        public static void Sort(int[] a)
        {
            for (int h = a.Length / 2; h > 0; h /= 2)
            {
                for (int i = h; i < a.Length; i++)
                {
                    int j = i;
                    int ai = a[i];
                    while (j >= h && a[j - h] > ai)
                    {
                        a[j] = a[j - h];
                        j -= h;
                    }
                    a[j] = ai;
                }
            }
        }
        */

        ///Quick Sort
        // average time complexity is O(nlog(n)) -- worst time complexity is O(n2)
        /*
        public static void Sort(int[] a)
        {
            Sortpart(a, 0, a.Length - 1);
        }

        public static void Sortpart(int[] a, int lowerIndex, int upperIndex)
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
        */

        ///Heap sort
        //The time complexity is O(n log(n)).sorting large data collections.
        /*
        public static void Sort(int[] a)
        {
            for(int i = a.Length/2 - 1; i >= 0; i--)
            {
                Heapify(a, a.Length, i);
            }

            for(int i = a.Length - 1; i > 0; i--)
            {
                (a[0], a[i]) = (a[i], a[0]);
                Heapify(a, i, 0);
            }
        }

        public static void Heapify(int[] a, int n, int i)
        {
            int max = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            max = l < n && a[l] > a[max] ? l : max;
            max = r < n && a[r] > a[max] ? r : max;

            if(max != i)
            {
                (a[i], a[max]) = (a[max], a[i]);
                Heapify(a, n, max);
            }
        }
        */


    }
}
