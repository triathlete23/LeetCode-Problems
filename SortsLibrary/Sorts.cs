using System;
using System.Collections.Generic;
using System.Linq;

namespace SortsLibrary
{
    public static class Sorts
    {
        public static int[] QuickSort(int[] ar)
        {
            ar.Shuffle();
            QuickSortRecursivePart(ar, 0, ar.Length - 1);
            return ar;
        }

        private static void QuickSortRecursivePart(int[] ar, int lo, int hi)
        {
            if (hi <= lo) return;
            var j = ar.Partition(lo, hi);
            QuickSortRecursivePart(ar, lo, j - 1);
            QuickSortRecursivePart(ar, j+1, hi);
        }

        private static int Partition(this int[] ar, int lo, int hi)
        {
            int i = lo, j = hi + 1;
            while (true)
            {
                //find item on left to swap
                while (ar[++i] < ar[lo])
                    if (i == hi) break;

                //find item on right to swap
                while (ar[lo] < ar[--j])
                    if (j == lo) break;
                
                //check if pointers cross
                if (i >= j) break;
                ar.Swap(i, j);
            }
            //swap with partitioning item
            ar.Swap(lo, j);
            //return index of item now known to be in place
            return j;
        }

        private static void Shuffle(this int[] ar)
        {
            var rand = new Random();
            ar = ar.OrderBy(x => rand.Next()).ToArray();
        }

        public static int[] HeapSort(int[] ar)
        {
            var n = ar.Length - 1;
            //build heap using bottom-up method
            for (var k = n / 2; k >= 0; k--)
            {
                ar.Sink(k, n);
            }
            //remove the maximum ones
            while (n > 0)
            {
                ar.Swap(0, n);
                ar.Sink(0, --n);
            }
            return ar;
        }

        private static void Sink(this int[] ar, int k, int n)
        {
            while (2 * k <= n)
            {
                var j = 2 * k;
                if (j < n && ar[j] < ar[j + 1]) j++;
                if (ar[k] >= ar[j]) break;
                ar.Swap(k, j);
                k = j;
            }
        }

        public static int[] BottomUpMergeSort(int[] ar)
        {
            var copy = new int[ar.Length];

            for (var sz = 1; sz < ar.Length; sz += sz)
            {
                for (var lo = 0; lo < ar.Length - sz; lo += 2*sz)
                {
                    Merge(ar, copy, lo, lo + sz - 1, Math.Min(lo + 2 * sz - 1, ar.Length - 1));
                }
            }

            return ar;
        }

        public static int[] MergeSort(int[] ar)
        {
            var copy = new int[ar.Length];
            MergeSortRecursivePart(ar, copy, 0, ar.Length - 1);

            return ar;
        }

        private static void MergeSortRecursivePart(int[] ar, 
            int[] copy, int lo, int hi)
        {
            if (hi <= lo) return;
            var mid = lo + (hi - lo) / 2;
            MergeSortRecursivePart(ar, copy, lo, mid);
            MergeSortRecursivePart(ar, copy, mid + 1, hi);
            Merge(ar, copy, lo, mid, hi);
        }

        private static void Merge(int[] ar, int[] copy, int lo, int mid, int hi)
        {
            for (var iter = 0; iter < ar.Length; iter++)
            {
                copy[iter] = ar[iter];
            }

            var i = lo;
            var j = mid + 1;
            for (var index = lo; index <= hi; index++)
            {
                if (i > mid)
                {
                    ar[index] = copy[j++];
                }
                else if (j > hi)
                {
                    ar[index] = copy[i++];
                }
                else if (copy[i] < copy[j])
                {
                    ar[index] = copy[i++];
                } else ar[index] = copy[j++];
            }
        }

        public static int[] ShellSort(int[] copy)
        {
            var ar = new int[copy.Length];
            for (var i = 0; i < copy.Length; i++)
            {
                ar[i] = copy[i];
            }

            var gaps = new[] {701, 301, 132, 57, 23, 10, 4, 1};
            foreach (var gap in gaps)
            {
                for (var i = gap; i < ar.Length; i++)
                {
                    var temp = ar[i];
                    int j;
                    for (j = i; j >= gap && ar[j - gap] > temp; j -= gap)
                    {
                        ar[j] = ar[j - gap];
                    }
                    ar[j] = temp;
                }
            }
            return ar;
        }

        //O(n^2) in average and worst cases
        //O(n) in best case
        public static int[] InsertionSort(int[] copy)
        {
            var ar = new int[copy.Length];
            for (var i = 0; i < copy.Length; i++)
            {
                ar[i] = copy[i];
            }

            for (var i = 1; i < ar.Length; i++)
            {
                var curr = i;
                for (var j = i - 1; j > -1; j--)
                {
                    if (ar[curr] >= ar[j]) continue;
                    ar.Swap(curr, j);
                    curr = j;
                }
            }
            
            return ar;
        }

        // O(n) = n^2 in all cases
        public static int[] SelectionSort(int[] copy)
        {
            var ar = new int[copy.Length];
            for (var i = 0; i < copy.Length; i++)
            {
                ar[i] = copy[i];
            }

            for (var i = 0; i < ar.Length - 1; i++)
            {
                for (var j = i + 1; j < ar.Length; j++)
                {
                    if (ar[i] <= ar[j]) continue;
                    ar.Swap(i, j);
                }
            }

            return ar;
        }

        private static void Swap(this int[] ar, int i, int j)
        {
            var temp = ar[i];
            ar[i] = ar[j];
            ar[j] = temp;
        }

        private static void Print(this IEnumerable<int> ar)
        {
            ar.ToList().ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
        }
    }
}
