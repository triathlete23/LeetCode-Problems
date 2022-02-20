using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProblemsLibrary.Problems.Helpers;

namespace ProblemsLibrary.Problems
{
    public static class OtherProblems
    {
        public static int PowerSum(int X, int N)
        {
            return FindSum(X, N, 1);
        }

        private static int FindSum(int x, int n, int number)
        {
            var sqr = Convert.ToInt32(Math.Pow(number, n));
            if (sqr < x)
            {
                return FindSum(x, n, number + 1) +
                       FindSum(x - sqr, n, number + 1);
            }
            return sqr == x ? 1 : 0;
        }

        public static int DistantPairs(int[][] points, int c)
        {
            var max = 0;

            for (var i = 0; i < points.Length; i++)
            {
                for (var j = i + 1; j < points.Length - 1; j++)
                {
                    max = Math.Max(DistBetweenPoints(points[i], points[j], c), max);
                }
            }

            return max;
        }

        private static int DistBetweenPoints(int[] point1, int[] point2, int c)
        {
            var min = int.MaxValue;
            foreach (var a in point1)
            {
                foreach (var b in point2)
                {
                    if (a == b) return 0;
                    min = Math.Min(PointDist(new[] { a, b }, c), min);
                }
            }

            min = Math.Min(PointDist(point1, c), Math.Min(PointDist(point2, c), min));

            return min;
        }

        private static int PointDist(int[] point, int c)
        {
            if (point[0] == point[1]) return 0;
            var diff = Math.Abs(point[0] - point[1]);
            return Math.Min(diff, c - diff);
        }

        public static string Encode(int i)
        {
            var Base = Data.Alphabet.Length;
            if (i == 0) return Data.Alphabet[0].ToString();

            var s = string.Empty;

            while (i > 0)
            {
                s += Data.Alphabet[i % Base];
                i = i / Base;
            }

            return string.Join(string.Empty, s.Reverse());
        }

        public static int Decode(string s)
        {
            var Base = Data.Alphabet.Length;

            return s.Aggregate(0, (current, c) => current * Base + Data.Alphabet.IndexOf(c));
        }

        public static int NumJewelsInStones(string jewels, string stones)
        {
            var i = 0;
            //return stones.Replace(jewels, "").Length;
            var dict = jewels.ToDictionary(jewel => i++);

            var count = stones.Count(stone => dict.ContainsValue(stone));
            return count;
        }

        public static int BinarySearch(int[] array, int key)
        {
            int lo = 0, hi = array.Length - 1;
            while (lo <= hi)
            {
                var mid = lo + (hi - lo) / 2;
                var midValue = array[mid];
                if (midValue > key) hi = mid - 1;
                else if (midValue < key) lo = mid + 1;
                else return mid;
            }
            return -1;
        }

        public static string ToLowercase(string str)
        {
            return str.ToLower();
        }

        private static int calculateResultScore(int x, int y)
        {
            if (x > y) return 1;
            if (x < y) return -1;
            return 0;
        }

        public static List<int> CompareTriplets(List<int> a, List<int> b)
        {
            int aliceScore = 0, bobScore = 0;
            for (var i = 0; i < a.Count; i++)
            {
                if (calculateResultScore(a[i], b[i]) > 0)
                {
                    aliceScore += 1;
                }
                if (calculateResultScore(a[i], b[i]) < 0)
                {
                    bobScore += 1;
                }
            }

            return new List<int> { aliceScore, bobScore };
        }

        public static int StrStr(this string haystack, string needle)
        {
            if (haystack == null || needle == null) return -1;

            if (haystack.Equals(needle)) return 0;

            for (var i = 0; i < haystack.Length - needle.Length + 1; i++)
            {
                if (haystack.Substring(i, needle.Length).Equals(needle))
                {
                    return i;
                }
            }

            return -1;
        }

        public static int MaxSubArray(this int[] nums)
        {
            int max_so_far = int.MinValue,
                max_ending_here = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                max_ending_here += nums[i];

                if (max_so_far < max_ending_here)
                    max_so_far = max_ending_here;

                if (max_ending_here < 0)
                    max_ending_here = 0;
            }

            return max_so_far;
        }

        private static int CalculateSum(char a, char b, bool prev)
        {
            if (a == '0' && b == '0' && prev)
            {
                return 2;
            }

            if (a == '1' && b == '1' && prev)
            {
                return 4;
            }

            if (a == '1' && b == '1')
            {
                return 3;
            }

            if ((((a == '0' && b == '1') || (a == '1' && b == '0')) && prev) || (a == '0' && b == '0'))
            {
                return 0;
            }

            return 1;
        }

        private static bool checkHeight(TreeNode root, Height height)
        {
            if (root == null)
            {
                height.Value = 0;
                return true;
            }

            var leftHeighteight = new Height();
            var rightHeighteight = new Height();
            var l = checkHeight(root.left, leftHeighteight);
            var r = checkHeight(root.right, rightHeighteight);
            var leftHeight = leftHeighteight.Value;
            var rightHeight = rightHeighteight.Value;

            height.Value = (leftHeight > rightHeight ? leftHeight : rightHeight) + 1;

            return Math.Abs(rightHeight - leftHeight) <= 1 && l && r;
        }

        public static int Trap(int[] height)
        {
            if (height.Length == 0) return 0;

            var i = 0;
            var j = height.Length - 1;
            var leftMax = height[i];
            var rightMax = height[j];
            var res = 0;

            // [4,2,0,3,2,5]
            while (i <= j) // i: 6, j: 5, res: 9
            {
                if (leftMax <= rightMax) // lM: 5, rM: 5
                {
                    leftMax = Math.Max(leftMax, height[i]); // lm: 4, curr: 5
                    res += leftMax - height[i]; // 0
                    i++; // 6
                }
                else
                {
                    rightMax = Math.Max(rightMax, height[j]);
                    res += rightMax - height[j];
                    j--;
                }
            }
            return res;
        }

        private static int[] dp;
        public static string PileOfStones(int[] values)
        {
            if (values.Length == 0) return null;
            dp = new int[values.Length];
            for (var i = 0; i < dp.Length; i++)
            {
                dp[i] = int.MinValue;
            }

            var aliceScore = FindScore(values, 0);
            return aliceScore > 0 ? "Alice" : aliceScore < 0 ? "Bob" : "Tie";
        }

        private static int FindScore(int[] values, int i)
        {
            if (i == values.Length) return 0;
            if (dp[i] > int.MinValue)
            {
                return dp[i];
            }

            var sum = 0;
            for (var j = i; j < i + 3 && j < values.Length; j++)
            {
                sum += values[j];
                dp[i] = Math.Max(dp[i], sum - FindScore(values, j));
            }
            return dp[i];
        }

        public static bool ContainsDuplicate(int[] nums)
        {
            var hashSet = new HashSet<int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (hashSet.Contains(nums[i]))
                {
                    return true;
                }
                hashSet.Add(nums[i]);
            }
            return false;
        }

        public static int[] ProductExceptSelf(int[] nums)
        {
            var left = new int[nums.Length];
            left[0] = 1;

            var right = new int[nums.Length];
            right[right.Length - 1] = 1;

            var res = new int[nums.Length];

            for (var i = 1; i < nums.Length; i++)
            {
                left[i] = nums[i - 1] * left[i - 1];
            }

            for (var j = nums.Length - 2; j >= 0; j--)
            {
                right[j] = nums[j + 1] * right[j + 1];
            }

            for (var i = 0; i < nums.Length; i++)
            {
                res[i] = left[i] * right[i];
            }

            return res;
        }

        public static int MaxProduct(int[] nums)
        {
            if (nums.Length == 1) return nums[0];

            var res = nums[0];
            var max = res;
            var min = res;
            for (var i = 1; i < nums.Length; i++)
            {
                var a = max * nums[i];
                var b = min * nums[i];
                max = Math.Max(Math.Max(a, b), nums[i]);
                min = Math.Min(Math.Min(a, b), nums[i]);
                res = Math.Max(res, max);
            }
            return res;
        }

        public static int FindMinSimple(int[] nums) // O(n)
        {
            if (nums.Length == 1) return nums[0];

            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] < nums[i]) continue;
                else return nums[i];
            }

            return nums.First();
        }

        public static int FindMin(int[] nums) // O(log n)
        {
            if (nums.Length == 1) return nums[0];

            if (nums.First() < nums.Last()) return nums[0];

            var left = 0;
            var right = nums.Length - 1;
            while (left < right) // left: 0, right: 4
            {
                var mid = (left + right) / 2; // mid: 2
                if (nums[mid - 1] > nums[mid]) // mid-1: 1, mid: 2
                {
                    return nums[mid];
                }

                if (nums[mid + 1] < nums[mid]) // mid: 2, mid+1: 3
                {
                    return nums[mid + 1];
                }

                if (nums[mid] > nums[left]) // mid: 2, left: 5
                {
                    left = mid;
                }
                else
                {
                    right = mid;
                }
            }

            return nums[0];
        }

        public static int Search(int[] nums, int target) // 4, 5, 6, 7, 0, 1, 2  target: 0
        {
            if (nums.Length == 1)
            {
                return nums[0] == target ? 0 : -1;
            }

            var left = 0;
            var right = nums.Length - 1;
            while (left < right) // left: 0, right: 6
            {
                var mid = (left + right) / 2; // mid: 3
                if (nums[mid] == target)
                {
                    return mid;
                }
                if (nums[left] == target)
                {
                    return left;
                }
                if (nums[right] == target)
                {
                    return right;
                }

                if (nums[left] <= nums[mid])
                {
                    if (target > nums[left] && target < nums[mid])
                    {
                        right = mid - 1;
                        continue;
                    }
                    left = mid + 1;
                    continue;
                }

                if (target > nums[mid] && target < nums[right])
                {
                    left = mid + 1;
                    continue;
                }

                right = mid - 1;
            }

            return -1;
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums.Length < 2) return new List<int>[0];
            Array.Sort(nums);

            // -4, -1, -1, 0, 1, 2
            var res = new List<IList<int>>();
            for (var i = 0; i < nums.Length - 2; i++)//looking for triplets, exclude last 2 numbers
            {
                // i, low, _, _, _, high
                // -4, -1, -1, 0, 1, 2

                //i: 3
                //nums[i]: 0

                if (i > 0 && nums[i] == nums[i - 1]) continue;

                var low = i + 1; //4, nums[low]: 1
                var high = nums.Length - 1; // 5, nums[high]: 2
                var sum = -nums[i]; //1

                while (low < high) //1<5
                {
                    if (nums[low] + nums[high] == sum)  //1 == 1
                    {
                        // [[-1, -1, 2]]
                        res.Add(new int[] { nums[i], nums[low], nums[high] });
                        while (low < high && nums[low] == nums[low + 1]) low++;
                        while (low < high && nums[high - 1] == nums[high]) high--;
                        low++;
                        high--;
                    }
                    else if (nums[low] + nums[high] > sum)
                    {
                        high--;
                    }
                    else
                    {
                        low++;
                    }
                }
            }

            return res;
        }

        public static int MaxArea(int[] height)
        {
            if (height.Length == 2) return height.Min();

            // 0, 1, 2, 3, 4, 5, 6, 7, 8
            // 1, 8, 6, 2, 5, 4, 8, 3, 7            
            var left = 0; //left: 0, value: 1
            var right = height.Length - 1; // right: 8, value: 7            
            var max = int.MinValue;
            while (left < right)
            {
                var smaller = Math.Min(height[left], height[right]);

                max = Math.Max(max, smaller * (right - left));

                if (height[left] < height[right]) left++;
                else right--;
            }

            return max;
        }

        public static int GetSum(int a, int b)
        {
            while (b != 0)
            {
                int temp = (a & b) << 1;
                a ^= b;
                b = temp;
            }
            return a;
        }

        public static bool IsPalindrome(this int x)
        {
            int revert = 0;
            for (var i = x; i > 0; i /= 10)
            {
                revert = revert * 10 + i % 10;
            }

            return x == revert;
        }

        public static int RomanToInt(this string s)
        {
            if (s == null) return 0;

            var dict = new Dictionary<char, int>
            {
                {'I', 1 },
                {'V', 5 },
                {'X', 10 },
                {'L', 50 },
                {'C', 100 },
                {'D', 500 },
                {'M', 1000 },
            };

            if (s.Length == 1) return dict[s[0]];
            // IV IX XL CM
            // 4 9 40 900
            var res = dict[s[s.Length - 1]];
            char prev = s[s.Length - 1];
            for (var i = s.Length - 2; i >= 0; i--)
            {
                // MCMXCIV
                if (dict[s[i]] < dict[prev])
                {
                    res -= dict[s[i]];
                }
                else
                {
                    res += dict[s[i]];
                }

                prev = s[i];
            }
            return res;
        }

        public static string LongestCommonPrefix(this string[] strs)
        {
            if (strs.Length == 1) return strs[0];
            if (strs.Contains("")) return "";

            var sb = new StringBuilder(strs[0]);
            for (var i = 1; i < strs.Length; i++)
            {
                var temp = new StringBuilder();
                var j = 0;
                while (j < Math.Min(sb.Length, strs[i].Length) && sb[j] == strs[i][j])
                {
                    temp.Append(sb[j++]);
                }
                sb.Clear();
                sb.Append(temp.ToString());
            }
            return sb.ToString();
        }

        public static bool IsValid(this string s)
        {
            // ( ) { } [ ]
            if (s.Length == 1 ||
                s[0] == ')' ||
                s[0] == '}' ||
                s[0] == ']' ||
                s[s.Length - 1] == '(' ||
                s[s.Length - 1] == '{' ||
                s[s.Length - 1] == '[')
                return false;

            var stack = new Stack<char>();
            foreach (var c in s)
            {
                if (c == '(' || c == '{' || c == '[') stack.Push(c);

                if (stack.Count == 0 ||
                    (c == ')' && stack.Peek() != '(') ||
                    (c == '}' && stack.Peek() != '{') ||
                    (c == ']' && stack.Peek() != '['))
                    return false;

                if ((c == ')' && stack.Peek() == '(') ||
                    (c == '}' && stack.Peek() == '{') ||
                    (c == ']' && stack.Peek() == '['))
                {
                    stack.Pop();
                    continue;
                }
            }

            return stack.Count == 0;
        }

        public static ListNode MergeTwoLists(this ListNode list1, ListNode list2)
        {
            if (list1 == null) return list2;
            if (list2 == null) return list1;

            var arr = new List<int>();
            while (list1?.val > int.MinValue && list2?.val > int.MinValue)
            {
                if (list1.val > list2.val)
                {
                    arr.Add(list2.val);
                    list2 = list2.next;
                }
                else
                {
                    arr.Add(list1.val);
                    list1 = list1.next;
                }
            }

            while (list1?.val > int.MinValue)
            {
                arr.Add(list1.val);
                list1 = list1.next;
            }

            while (list2?.val > int.MinValue)
            {
                arr.Add(list2.val);
                list2 = list2.next;
            }

            var res = new ListNode(arr[arr.Count - 1]);
            for (var i = arr.Count - 2; i >= 0; i--)
            {
                res = new ListNode(arr[i], res);
            }

            return res;
        }

        public static int RemoveDuplicates(this int[] nums)
        {
            if (nums.Length == 1) return 1;

            // 0 0 1 1 1 2 2 3 3 4
            // prev_i = 2
            // nums[prev_i] = 1
            // i = 3
            // nums[i] = 1
            var k = 1;
            var prev_i = 0;
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[prev_i]) continue;

                if (i - prev_i > 1)
                {
                    nums[++prev_i] = nums[i];
                }
                else
                {
                    prev_i = i;
                }

                k++;
            }
            return k;
        }

        public static int RemoveElement(this int[] nums, int val)
        {
            var k = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                {
                    continue;
                }

                nums[k] = nums[i];
                k++;
            }

            return k;
        }

        public static int SearchInsert(this int[] nums, int target)
        {
            // 1,3,5,6
            // 7

            return Search(nums, target, 0, nums.Length - 1);
        }

        private static int Search(this int[] nums, int x, int low, int high)
        {
            if (low > high) return low;

            var mid = (low + high) / 2;
            if (x == nums[mid]) return mid;

            if (x > nums[mid]) return nums.Search(x, mid + 1, high);
            return nums.Search(x, low, mid - 1);
        }

        public static int LengthOfLastWord(this string s)
        {
            var _s = s.Split();
            for (var i = _s.Length - 1; i > 0; i--)
            {
                if (!string.IsNullOrEmpty(_s[i]))
                    return _s[i].Length;
            }
            return _s[0].Length;
        }

        public static int[] PlusOne(this int[] digits)
        {
            var toExtend = false;
            for (var i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] == 9 && (toExtend || i == digits.Length - 1))
                {
                    digits[i] = 0;
                    toExtend = true;
                    continue;
                }

                if (toExtend)
                {
                    digits[i]++;
                    return digits;
                }

                if (i == digits.Length - 1)
                {
                    digits[digits.Length - 1]++;
                    return digits;
                }
            }
            var newDigits = new int[digits.Length + 1];
            newDigits[0] = 1;
            return newDigits;
        }

        public static string AddBinary(string a, string b)
        {
            if (a == "0") return b;
            if (b == "0") return a;

            var next = false;
            var res = new StringBuilder(a.Length > b.Length ? a : b);
            var add = new StringBuilder(a.Length > b.Length ? b : a);
            var diff = res.Length - add.Length;
            for (var i = res.Length - 1; i >= 0; i--)
            {
                // 1 1 1 1
                // 1 1 1 1
                //       |
                // false
                if (i - diff < 0)
                {
                    if (res[i] == '1' && next)
                    {
                        res[i] = '0';
                        continue;
                    }
                    if (res[i] == '0' && next)
                    {
                        res[i] = '1';
                        next = false;
                    }
                    break;
                }

                if (res[i] == '1' && add[i - diff] == '1')
                {
                    if (next)
                    {
                        res[i] = '1';
                        continue;
                    }
                    res[i] = '0';
                    next = true;
                    continue;
                }

                if (res[i] == '1' || add[i - diff] == '1')
                {
                    if (next)
                    {
                        res[i] = '0';
                        continue;
                    }
                    res[i] = '1';
                    continue;
                }

                if (next)
                {
                    res[i] = '1';
                    next = false;
                }
            }
            if (next)
            {
                var sb = new StringBuilder();
                sb.Append('1');
                sb.Append(res.ToString());
                return sb.ToString();
            }
            return res.ToString();
        }

        public static int MySqrt(int x)
        {
            if (x < 2) return x;

            var low = 0;
            var high = x;
            while (low <= high)
            {
                int temp = (high + low) / 2;
                if ((long)temp * temp > x) high = temp - 1;
                else low = temp + 1;
            }
            return high;
        }

        public static int ClimbStairs(int n)
        {
            if (n == 1) return n;

            var ways = new int[n + 1];
            ways[0] = 1;
            ways[1] = 1;
            for (var i = 2; i < ways.Length; i++)
            {
                ways[i] = ways[i - 1] + ways[i - 2];
            }

            return ways[n];
        }

        public static IList<IList<int>> Generate(int numRows)
        {
            var res = new List<IList<int>>();
            for (var i = 0; i < numRows; i++)
            {
                var cur = new List<int>();
                for (var j = 0; j < i; j++)
                {
                    if (j == 0 || j == i - 1) cur.Add(1);
                    else cur.Add(res[i - 2][j - 1] + res[i - 2][j]);
                }
                if (cur.Any()) res.Add(cur);
            }
            return res;
        }

        public static IList<int> GetRow(int rowIndex)
        {
            var res = new List<IList<int>>();
            for (var i = 0; i < rowIndex+2; i++)
            {
                var cur = new List<int>();
                for (var j = 0; j < i; j++)
                {
                    if (j == 0 || j == i - 1) cur.Add(1);
                    else cur.Add(res[i - 2][j - 1] + res[i - 2][j]);
                }
                if (cur.Any()) res.Add(cur);
            }
            return res.Last();
        }

        public static int MaxProfit(int[] prices)
        {
            if (prices.Length == 2) return prices[1] - prices[0] > 0 ? prices[1] - prices[0] : 0;
            var low = prices[0];
            var diff = 0;
            for (var i = 1; i < prices.Length; i++)
            {
                if (prices[i] - low > diff)
                {
                    diff = prices[i] - low;
                }
                else if (prices[i] < low)
                {
                    low = prices[i];
                }
            }
            return diff > 0 ? diff : 0;
        }
    }
}
