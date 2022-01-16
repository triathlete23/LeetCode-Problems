namespace ProblemsLibrary.Problems.Helpers
{
    public static class Helper
    {
        public static TreeNode ConstructBinaryTreeFromArray(int[] ar)
        {
            var node = new TreeNode(ar[0]);
            return CreateNode(ar, node, 0, ar.Length);
        }

        private static TreeNode CreateNode(int[] ar, TreeNode root, int i, int count)
        {
            if (i < count)
            {
                var tempRoot = new TreeNode(ar[i]);
                root = tempRoot;

                tempRoot.left = CreateNode(ar, tempRoot.left, 2 * i + 1, count);
                tempRoot.right = CreateNode(ar, tempRoot.right, 2 * i + 2, count);
            }
            return root;
        }
    }
}
