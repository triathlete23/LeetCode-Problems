using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ProblemsLibrary.Problems
{
    public static class ArrayProblems
    {
        public static int[] sortArrayFromAlgsPart2(this int[] a, int rightBound)
        {
            var length = a.Length;
            var count = new int[rightBound + 1];
            for (var i = 0; i < length; i++)
            {
                count[a[i] + 1]++;
            }

            for (var r = 0; r < rightBound; r++)
            {
                count[r + 1] += count[r];
            }

            var aux = new int[length];
            for (var i = 0; i < length; i++)
            {
                aux[count[a[i]]++] = a[i];
            }
            for (var i = 0; i < length; i++)
            {
                a[i] = aux[i];
            }

            return a;
        }

        public static List<int> oddNumbers(int l, int r)
        {
            var res = new List<int>();
            if (l > r) return res;
            if (l == r && l % 2 == 1)
            {
                res.Add(l);
                return res;
            };

            for (var i = l % 2 == 1 ? l : l + 1; i <= r; i += 2)
            {
                res.Add(i);
            }

            return res;
        }

        public static int hourglassSum(int[][] sum)
        {
            var n = sum.Length;
            var max = int.MinValue;

            for (var i = 1; i < n - 1; i++)
            {
                for (var j = 1; j < n - 1; j++)
                {
                    var curr = sum[i - 1][j - 1] + sum[i - 1][j] + sum[i - 1][j + 1] + sum[i][j] +
                            sum[i + 1][j - 1] + sum[i + 1][j] + sum[i + 1][j + 1];
                    if (curr > max) max = curr;
                }
            }
            return max;
        }

        public static int sockMerchant(int n, int[] ar)
        {
            var count = 0;
            var pairs = new List<int>();

            foreach (var el in ar)
            {
                if (pairs.Contains(el))
                {
                    count++;
                    pairs.Remove(el);
                }
                else pairs.Add(el);
            }

            return count;
        }

        public static int MaxRotateFunction(int[] A)
        {
            if (!A.Any()) return 0;

            var maxSum = 0;
            var allElemsSum = 0;
            for (var i = 0; i < A.Length; i++)
            {
                maxSum += A[i] * i;
                allElemsSum += A[i];
            }

            var prev = maxSum;
            for (var i = 1; i < A.Length; i++)
            {
                var sum = allElemsSum + prev - A.Length * A[A.Length - i];
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
                prev = sum;
            }

            return maxSum;
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            if (nums.Length < 2) return nums;

            var dict = new Dictionary<int, int>();
            // 2,7,11,15
            // target 9
            // i = 1
            // nums[i] = 7
            // [2] -> 0            
            // [7] -> 1
            for (var i = 0; i < nums.Length; i++)
            {                
                if (dict.ContainsKey(target - nums[i]))
                {
                    return new int[2] { dict[target - nums[i]], i };
                }
                dict[nums[i]] = i;
            }

            return nums;
        }

        public static void Merge(this int[] nums1, int m, int[] nums2, int n)
        {
            if (n == 0) return;

            if (m == 0)
            {
                for (var i = 0; i < n; i++)
                {
                    nums1[i] = nums2[i];
                }
                return;
            }

            var j = 0;
            for (var i = nums1.Length - 1; i >= 0; i--)
            {
                if (nums1[i] != 0 || j == nums2.Length) break;
                nums1[i] = nums2[j++];
            }

            for (var i = 0; i < nums1.Length - 1; i++)
            {
                for (j = 0; j < nums1.Length - i - 1; j++)
                {
                    if (nums1[j] > nums1[j + 1])
                    {
                        (nums1[j+1], nums1[j]) = (nums1[j], nums1[j+1]);
                    }
                }
            }
        }


    }
}
