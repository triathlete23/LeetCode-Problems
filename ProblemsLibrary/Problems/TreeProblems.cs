using ProblemsLibrary.Problems.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProblemsLibrary.Problems
{
    public static class TreeProblems
    {
        public static TreeNode InsertIntoBST(TreeNode root, int val)
        {
            return insertNode(root, val);
        }

        private static TreeNode insertNode(TreeNode node, int val)
        {
            if (node == null) return new TreeNode(val);

            if (node.val > val)
            {
                node.left = insertNode(node.left, val);
            }
            else
            {
                node.right = insertNode(node.right, val);
            }

            return node;
        }

        public static TreeNode PruneTree(TreeNode node)
        {
            return CheckOnOneValue(node);
        }

        private static TreeNode CheckOnOneValue(TreeNode node)
        {
            if (node.left != null)
            {
                node.left = CheckOnOneValue(node.left);
            }

            if (node.right != null)
            {
                node.right = CheckOnOneValue(node.right);
            }

            return node.val == 0 && node.left == null && node.right == null ? null : node;
        }

        public static TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            return CreateNode(nums, 0, nums.Length);
        }

        private static TreeNode CreateNode(this int[] nums, int startIndex, int finishIndex)
        {
            if (startIndex == finishIndex) return null;

            var currentMaxIndex = nums.FindMax(startIndex, finishIndex);

            var node = new TreeNode(nums[currentMaxIndex])
            {
                left = nums.CreateNode(startIndex, currentMaxIndex),
                right = nums.CreateNode(currentMaxIndex + 1, finishIndex)
            };
            return node;
        }

        private static int FindMax(this int[] nums, int startIndex, int finishIndex)
        {
            var maxIndex = startIndex;

            for (var i = startIndex + 1; i < finishIndex; i++)
            {
                if (nums[maxIndex] >= nums[i]) continue;
                maxIndex = i;
            }

            return maxIndex;
        }

        public static IList<int> InorderTraversal(this TreeNode root)
        {
            var res = new List<int>();
            if (root == null) return res;

            root.left.Inorder(res);
            res.Add(root.val);
            root.right.Inorder(res);
            return res;
        }

        private static void Inorder(this TreeNode root, IList<int> list)
        {
            if (root == null) return;

            root.left.Inorder(list);
            list.Add(root.val);
            root.right.Inorder(list);
        }

        public static bool IsSameTree(this TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null && q != null) return false;
            if (p != null && q == null) return false;

            if (p.val != q.val) return false;

            var left = p.left.IsSameTree(q.left);
            var right = p.right.IsSameTree(q.right);
            return left && right;
        }

        public static bool IsSymmetric(this TreeNode root)
        {
            if (root == null) return true;
            if (root.left == null && root.right == null) return true;
            if ((root.left == null && root.right != null) || (root.left != null && root.right == null)) return false;

            return root.left.IsMirror(root.right);
        }

        private static bool IsMirror(this TreeNode leftTree, TreeNode rightTree)
        {
            if ((leftTree == null && rightTree != null) || (leftTree != null && rightTree == null)) return false;
            if (leftTree == null && rightTree == null) return true;
            if (leftTree.val != rightTree.val) return false;

            return leftTree.left.IsMirror(rightTree.right) && leftTree.right.IsMirror(rightTree.left);
        }

        public static int MaxDepth(this TreeNode root)
        {
            if (root == null) return 0;

            return Math.Max(MaxDepthLocal(root.left, 1), MaxDepthLocal(root.right, 1));
        }

        private static int MaxDepthLocal(TreeNode node, int depth)
        {
            if (node == null) return depth;
            depth++;
            var left = MaxDepthLocal(node.left, depth);
            var right = MaxDepthLocal(node.right, depth);
            return Math.Max(left, right);
        }

        public static TreeNode SortedArrayToBST(this int[] nums)
        {
            if (nums == null || nums.Length == 0) return null;
            return BuildBST(nums, 0, nums.Length - 1);
        }

        private static TreeNode BuildBST(int[] nums, int start, int end)
        {
            if (start > end) return null;

            int mid = (start + end) / 2;
            return new TreeNode(nums[mid], BuildBST(nums, start, mid - 1), BuildBST(nums, mid + 1, end));
        }

        public static bool IsBalanced(this TreeNode root)
        {
            if (root == null || (root.right == null && root.left == null)) return true;
            if (Math.Abs(GetTreeHeight(root.left) - GetTreeHeight(root.right)) > 1) return false;
            return IsBalanced(root.left) && IsBalanced(root.right);
        }

        private static int GetTreeHeight(TreeNode root)
        {
            if (root == null) return 1;
            return Math.Max(GetTreeHeight(root.left), GetTreeHeight(root.right)) + 1;
        }

        public static int MinDepth(this TreeNode root)
        {
            if (root == null) return 0;
            var l = root.left.MinDepth();
            var r = root.right.MinDepth();
            if (l == 0) return r + 1;
            if (r == 0) return l + 1;
            return Math.Min(l, r) + 1;
        }

        public static bool HasPathSum(this TreeNode root, int targetSum)
        {
            if (root == null) return false;

            if (targetSum == root.val && root.left == null && root.right == null) return true;

            var left = root.left.HasPathSum(targetSum - root.val);
            if (left) return true;

            var right = root.right.HasPathSum(targetSum - root.val);
            if (right) return true;

            return false;
        }
    }
}
