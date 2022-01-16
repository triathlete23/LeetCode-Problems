using ProblemsLibrary.Problems.Helpers;

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
    }
}
