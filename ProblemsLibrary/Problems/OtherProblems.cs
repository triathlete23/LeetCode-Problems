using System;
using System.Collections.Generic;
using System.Linq;
using ProblemsLibrary.Problems.Helpers;

namespace ProblemsLibrary.Problems
{
    public static class OtherProblems
    {
        public static void Test()
        {
            var list = new List<int>(2);
            list.Add(1);
            list.Add(1);
            list.Add(1);
        }

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

        public static bool IsPalindrome(this int x)
        {
            if (x < 0 || (x > 9 && x % 10 == 0))
            {
                return false;
            }

            int revert = 0;
            while (x > revert)
            {
                revert = revert * 10 + x % 10;
                x /= 10;
            }

            return x == revert || x == revert / 10;
        }

        public static int RomanToInt(this string s)
        {
            var alph = new Dictionary<char, int>
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

            var comb = new Dictionary<string, int>
            {
                { "IV", 4 },
                { "IX", 9 },
                { "XL", 40 },
                { "XC", 90 },
                { "CD", 400 },
                { "CM", 900 }
            };

            var res = 0;
            var prev = 0;
            for (var i = 0; i < s.Length; i++)
            {
                var curr = alph[s[i]];
                if (prev != 0 && curr > prev)
                {
                    var combValue = comb[String.Concat(s[i - 1], s[i])];
                    res += combValue;
                    res -= prev;
                }
                else
                {
                    res += curr;
                }
                prev = curr;
            }

            return res;
        }

        public static string LongestCommonPrefix(this string[] strs)
        {
            if (strs.Length == 0) return string.Empty;

            var prefix = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                var j = 0;
                while (j < Math.Min(prefix.Length, strs[i].Length) && prefix[j] == strs[i][j])
                {
                    j++;
                }
                prefix = prefix.Substring(0, j);
            }

            return prefix;
        }

        public static bool IsValid(this string s)
        {
            if (s == "") return true;
            if (s.Length % 2 == 1) return false;

            var stack = new Stack<char>();

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(')');
                    continue;
                }

                if (s[i] == '[')
                {
                    stack.Push(']');
                    continue;
                }

                if (s[i] == '{')
                {
                    stack.Push('}');
                    continue;
                }

                if ((!stack.Any() && (s[i] == ')' || s[i] == ']' || s[i] == '}')) || s[i] != stack.Pop()) return false;
            }

            return stack.Count() == 0;
        }

        public static ListNode MergeTwoLists(this ListNode list1, ListNode list2)
        {
            if (list1 == null && list2 == null) return null;
            if (list1 == null) return list2;
            if (list2 == null) return list1;

            ListNode head; ListNode temp;
            if (list1.val < list2.val)
            {
                head = temp = new ListNode(list1.val);
                list1 = list1.next;
            }
            else
            {
                head = temp = new ListNode(list2.val);
                list2 = list2.next;
            }

            while (list1 != null && list2 != null)
            {
                if (list1.val > list2.val)
                {
                    temp.next = new ListNode(list2.val);
                    list2 = list2.next;
                }
                else
                {
                    temp.next = new ListNode(list1.val);
                    list1 = list1.next;
                }
                temp = temp.next;
            }

            while (list1 != null)
            {
                temp.next = new ListNode(list1.val);
                list1 = list1.next;
                temp = temp.next;
            }

            while (list2 != null)
            {
                temp.next = new ListNode(list2.val);
                list2 = list2.next;
                temp = temp.next;
            }

            return head;
        }

        public static int RemoveDuplicates(int[] nums)
        {
            var k = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (i < nums.Length - 1 && nums[i] == nums[i + 1])
                {
                    continue;
                }

                nums[k] = nums[i];
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

        public static int SearchInsert(this int[] nums, int target)
        {
            var ans = -1;
            var l = 0;
            var r = nums.Length - 1;
            while (r >= l)
            {
                var mid = l + (r - l) / 2;

                if (nums[mid] == target) return mid;

                if (target < nums[mid])
                {
                    r = mid - 1;
                    ans = mid;
                }
                else
                {
                    ans = mid + 1;
                    l = mid + 1;
                }
            }

            return ans;
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

        public static int LengthOfLastWord(this string s)
        {
            if (s == null)
            {
                return 0;
            }

            var k = 0;
            for (var i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ')
                {
                    if (k > 0)
                    {
                        return k;
                    }

                    continue;
                }

                k++;
            }

            return k;
        }

        public static int[] PlusOne(this int[] digits)
        {
            var last = digits.Length - 1;
            if (digits[last] < 9)
            {
                digits[last]++;
                return digits;
            }

            if (digits.Length == 1)
            {
                return new int[] { 1, 0 };
            }

            digits[last] = 0;
            for (var i = last - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }

                digits[i] = 0;
            }

            var res = new int[digits.Length + 1];
            res[0] = 1;
            for (var i = 1; i < res.Length; i++)
            {
                res[i] = digits[i - 1];
            }
            return res;
        }

        public static string AddBinary(string a, string b)
        {
            var stack = new Stack<char>();
            var i = a.Length - 1;
            var j = b.Length - 1;
            var prev = false;
            while (i > -1 && j > -1)
            {
                var res = CalculateSum(a[i], b[j], prev);
                if (res == 0)
                {
                    stack.Push('0');
                }
                else if (res == 1)
                {
                    stack.Push('1');
                }
                else if (res == 2)
                {
                    stack.Push('1');
                    prev = false;
                }
                else if (res == 3)
                {
                    stack.Push('0');
                    prev = true;
                }
                else
                {
                    stack.Push('1');
                    prev = true;
                }

                i--;
                j--;
            }

            while (i >= 0)
            {
                var res = CalculateSum(a[i], '0', prev);
                if (res == 0)
                {
                    stack.Push('0');
                }
                else if (res == 1)
                {
                    stack.Push('1');
                }
                else if (res == 2)
                {
                    stack.Push('1');
                    prev = false;
                }
                else
                {
                    stack.Push('0');
                    prev = true;
                }
                i--;
            }

            while (j >= 0)
            {
                var res = CalculateSum('0', b[j], prev);
                if (res == 0)
                {
                    stack.Push('0');
                }
                else if (res == 1)
                {
                    stack.Push('1');
                }
                else if (res == 2)
                {
                    stack.Push('1');
                    prev = false;
                }
                else if (res == 3)
                {
                    stack.Push('1');
                    prev = true;
                }
                else
                {
                    stack.Push('0');
                    prev = true;
                }
                j--;
            }

            if (prev)
            {
                stack.Push('1');
            }

            return new string(stack.ToArray());
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

        public static int MySqrt(int x)
        {
            if (x == 0) return 0;

            double init = x;
            double y = 1;

            double e = 0.0001;
            while (init - y > e)
            {
                init = (init + y) / 2;
                y = x / init;
            }

            return (int)init;
        }

        public static int ClimbStairs(int n)
        {
            if (n == 1) return 1;

            var ways = new int[n + 1];
            ways[0] = 1;
            ways[1] = 1;

            for (var i = 2; i < ways.Length; i++)
            {
                ways[i] = ways[i - 1] + ways[i - 2];
            }

            return ways[n];
        }

        public static ListNode DeleteDuplicates(this ListNode head)
        {
            if (head == null) return null;
            if (head.next == null) return head;

            var curr = head;
            while (curr != null && curr.next != null)
            {
                if (curr.val == curr.next.val)
                {
                    curr.next = curr.next.next;
                    continue;
                }

                curr = curr.next;
            }

            return head;
        }

        public static void Merge(this int[] nums1, int m, int[] nums2, int n)
        {
            if (n == 0) return;

            if (m == 0 && n > 0)
            {
                nums1 = new int[n];
                for (var l = 0; l < n; l++)
                {
                    nums1[l] = nums2[l];
                }
                return;
            }

            var i = m - 1;
            var j = n - 1;
            for (var k = nums1.Length - 1; k >= 0; k--)
            {
                if (i < 0 || j < 0)
                {
                    break;
                }

                if (nums1[i] > nums2[j])
                {
                    nums1[k] = nums1[i];
                    i--;
                }
                else
                {
                    nums1[k] = nums2[j];
                    j--;
                }
            }
        }

        public static IList<int> InorderTraversal(this TreeNode root)
        {
            var res = new List<int>();
            if (root == null) return res;

            res = InOrder(res, root);

            return res;
        }

        private static List<int> InOrder(List<int> order, TreeNode node)
        {
            if (node == null) return order;

            order = InOrder(order, node.left);
            order.Add(node.val);
            order = InOrder(order, node.right);

            return order;
        }

        public static bool IsSameTree(this TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;

            if (p == null || q == null) return false;

            if (p.val != q.val) return false;

            return p.right.IsSameTree(q.right) && p.left.IsSameTree(q.left);
        }

        public static bool IsSymmetric(this TreeNode root)
        {
            if (root == null) return true;

            return IsMirror(root, root);
        }

        private static bool IsMirror(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) return true;

            if (left == null || right == null) return false;

            if (left.val != right.val) return false;

            return IsMirror(left.left, right.right) && IsMirror(left.right, right.left);
        }

        public static int MaxDepth(this TreeNode root)
        {
            if (root == null) return 0;

            var depth = 1;

            if (root.left == null && root.right == null) return depth;

            var leftDepth = 0;
            if (root.left != null) leftDepth = root.left.MaxDepth();

            var rightDepth = 0;
            if (root.right != null) rightDepth = root.right.MaxDepth();

            depth += leftDepth > rightDepth ? leftDepth : rightDepth;
            return depth;
        }

        public static TreeNode SortedArrayToBST(this int[] nums)
        {
            if (nums == null || nums.Length == 0) return null;

            if (nums.Length == 1) return new TreeNode(nums[0]);

            return ConstructTreeNode(nums, 0, nums.Length - 1);
        }

        private static TreeNode ConstructTreeNode(int[] nums, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;
            var node = new TreeNode(nums[mid])
            {
                left = ConstructTreeNode(nums, start, mid - 1),

                right = ConstructTreeNode(nums, mid + 1, end)
            };

            return node;
        }

        public static bool IsBalanced(this TreeNode root)
        {
            return checkHeight(root, new Height());
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

        public static int MinDepth(this TreeNode root)
        {
            if (root == null) return 0;

            if (root.left == null && root.right == null) return 1;

            if (root.left == null || root.right == null) return Math.Max(MinDepth(root.left), MinDepth(root.right)) + 1;

            return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
        }

        public static bool HasPathSum(this TreeNode root, int targetSum)
        {
            if (root == null) return false;

            targetSum -= root.val;
            if (root.left == null && root.right == null) return targetSum == 0;

            return root.left.HasPathSum(targetSum) || root.right.HasPathSum(targetSum);
        }

        public static IList<IList<int>> Generate(int numRows)
        {
            var list = new List<IList<int>>();
            for (var i = 0; i < numRows; i++)
            {
                var curr = new int[i + 1];
                if (curr.Length > 1)
                {
                    curr[0] = list[i - 1][0];
                    curr[curr.Length - 1] = list[i - 1][list[i - 1].Count - 1];
                    for (var j = 1; j < curr.Length - 1; j++)
                    {
                        curr[j] = list[i - 1][j - 1] + list[i - 1][j];
                    }
                }
                else
                {
                    curr[0] = 1;
                }

                list.Add(curr);
            }
            return list;
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

        public static int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length < 2) return 0;

            var min = prices[0];
            var max = int.MinValue;

            for (var i = 0; i < prices.Length; i++)
            {
                int diff = prices[i] - min;
                if (diff > max) max = diff;
                if (prices[i] < min) min = prices[i];
            }

            return max;
        }

        public static bool ContainsDuplicate(int[] nums)
        {
            var hashSet = new HashSet<int>();
            for (var i = 0;i < nums.Length; i++)
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

            for (var j=nums.Length - 2; j >= 0; j--)
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
                if (nums[mid-1] > nums[mid]) // mid-1: 1, mid: 2
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
    }    
}
