using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemsLibrary.Problems;
using ProblemsLibrary.Problems.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class TreeProblemsShould
    {
        [TestMethod]
        public void InorderTraversalTest1()
        {
            var res = new List<int> { 1, 3, 2 };
            var tree = new TreeNode(1, null, new TreeNode(2, new TreeNode(3)));
            Assert.IsTrue(res.SequenceEqual(tree.InorderTraversal()));
        }

        [TestMethod]
        public void InorderTraversalTest2()
        {
            var res = new List<int>();
            TreeNode tree = null;
            Assert.IsTrue(res.SequenceEqual(tree.InorderTraversal()));
        }

        [TestMethod]
        public void InorderTraversalTest3()
        {
            var res = new List<int> { 1 };
            var tree = new TreeNode(1);
            Assert.IsTrue(res.SequenceEqual(tree.InorderTraversal()));
        }

        [TestMethod]
        public void IsSameTreeTest1()
        {
            var first = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            var second = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            Assert.IsTrue(first.IsSameTree(second));
        }

        [TestMethod]
        public void IsSameTreeTest2()
        {
            var first = new TreeNode(1, new TreeNode(2));
            var second = new TreeNode(1, null, new TreeNode(3));
            Assert.IsFalse(first.IsSameTree(second));
        }

        [TestMethod]
        public void IsSameTreeTest3()
        {
            var first = new TreeNode(1, new TreeNode(2), new TreeNode(1));
            var second = new TreeNode(1, new TreeNode(1), new TreeNode(2));
            Assert.IsFalse(first.IsSameTree(second));
        }

        [TestMethod]
        public void IsSameTreeTest4()
        {
            var first = new TreeNode(1, new TreeNode(1));
            var second = new TreeNode(1, null, new TreeNode(1));
            Assert.IsFalse(first.IsSameTree(second));
        }

        [TestMethod]
        public void IsSymmetricTest1()
        {
            var root = new TreeNode(1,
                new TreeNode(2, new TreeNode(3), new TreeNode(4)),
                new TreeNode(2, new TreeNode(4), new TreeNode(3)));

            Assert.IsTrue(root.IsSymmetric());
        }

        [TestMethod]
        public void IsSymmetricTest2()
        {
            var root = new TreeNode(1,
                new TreeNode(2, null, new TreeNode(3)),
                new TreeNode(2, null, new TreeNode(3)));

            Assert.IsFalse(root.IsSymmetric());
        }

        [TestMethod]
        public void IsSymmetricTest3()
        {
            TreeNode root = null;
            Assert.IsTrue(root.IsSymmetric());
        }

        [TestMethod]
        public void IsSymmetricTest4()
        {
            TreeNode root = new TreeNode(1);
            Assert.IsTrue(root.IsSymmetric());
        }

        [TestMethod]
        public void MaxDepthTest1()
        {
            var root = new TreeNode(3,
                new TreeNode(9),
                new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            Assert.AreEqual(3, root.MaxDepth());
        }

        [TestMethod]
        public void MaxDepthTest2()
        {
            var root = new TreeNode(1, null, new TreeNode(2));
            Assert.AreEqual(2, root.MaxDepth());
        }

        [TestMethod]
        public void MaxDepthTest3()
        {
            var root = new TreeNode(1);
            Assert.AreEqual(1, root.MaxDepth());
        }

        [TestMethod]
        public void MaxDepthTest4()
        {
            var root = new TreeNode();
            Assert.AreEqual(1, root.MaxDepth());
        }

        [TestMethod]
        public void SortedArrayToBSTTest1()
        {
            var nums = new int[] { -10, -3, 0, 5, 9 };
            var expected = new TreeNode(0,
                new TreeNode(-10, null, new TreeNode(-3)),
                new TreeNode(5, null, new TreeNode(9)));
            Assert.AreEqual(expected, nums.SortedArrayToBST());
        }

        [TestMethod]
        public void SortedArrayToBSTTest2()
        {
            var nums = new int[] { 1, 3 };
            var res = new TreeNode(1, null, new TreeNode(3));
            Assert.AreEqual(res, nums.SortedArrayToBST());
        }

        [TestMethod]
        public void SortedArrayToBSTTest3()
        {
            var nums = new int[] { 0, 1, 2, 3, 4, 5 };
            var res = new TreeNode(3,
                new TreeNode(1, new TreeNode(2), new TreeNode(4)),
                new TreeNode(5));
            Assert.AreEqual(res, nums.SortedArrayToBST());
        }

        [TestMethod]
        public void IsBalancedTest1()
        {
            var tree = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            Assert.IsTrue(tree.IsBalanced());
        }

        [TestMethod]
        public void IsBalancedTest2()
        {
            var tree = new TreeNode(1,
                new TreeNode(2, new TreeNode(3, new TreeNode(4), new TreeNode(4)), new TreeNode(3)),
                new TreeNode(2));
            Assert.IsFalse(tree.IsBalanced());
        }

        [TestMethod]
        public void IsBalancedTest3()
        {
            TreeNode tree = null;
            Assert.IsTrue(tree.IsBalanced());
        }

        [TestMethod]
        public void IsBalancedTest4()
        {
            var tree = new TreeNode(1,
                new TreeNode(2, new TreeNode(3, new TreeNode(4))),
                new TreeNode(2, null, new TreeNode(3, null, new TreeNode(4))));
            Assert.IsFalse(tree.IsBalanced());
        }

        [TestMethod]
        public void IsBalancedTest5()
        {
            var tree = new TreeNode(1, 
                new TreeNode(2, new TreeNode(4, new TreeNode(8)), new TreeNode(5)),
                new TreeNode(3, new TreeNode(6)));
            Assert.IsTrue(tree.IsBalanced());
        }

        [TestMethod]
        public void MinDepthTest1()
        {
            var tree = new TreeNode(3,
                new TreeNode(9),
                new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            Assert.AreEqual(2, tree.MinDepth());
        }

        [TestMethod]
        public void MinDepthTest2()
        {
            var tree = new TreeNode(2,
                null,
                new TreeNode(3,
                    null, new TreeNode(4,
                    null, new TreeNode(5,
                    null, new TreeNode(6)))));
            Assert.AreEqual(5, tree.MinDepth());
        }

        [TestMethod]
        public void MinDepthTest3()
        {
            var tree = new TreeNode(1, new TreeNode(2));
            Assert.AreEqual(2, tree.MinDepth());
        }

        [TestMethod]
        public void HasPathSumTest1()
        {
            var tree = new TreeNode(5,
                new TreeNode(4, new TreeNode(11, new TreeNode(7), new TreeNode(2)),
                new TreeNode(8, new TreeNode(13), new TreeNode(4, null, new TreeNode(1)))));

            Assert.IsTrue(tree.HasPathSum(22));
        }

        [TestMethod]
        public void HasPathSumTest2()
        {
            var tree = new TreeNode(1, new TreeNode(2), new TreeNode(3));

            Assert.IsFalse(tree.HasPathSum(5));
        }

        [TestMethod]
        public void HasPathSumTest3()
        {
            Assert.IsFalse(((TreeNode)null).HasPathSum(0));
        }

        [TestMethod]
        public void HasPathSumTest4()
        {
            var tree = new TreeNode(-2, null, new TreeNode(-3));

            Assert.IsTrue(tree.HasPathSum(-5));
        }

        [TestMethod]
        public void HasPathSumTest5()
        {
            var tree = new TreeNode(8,
                new TreeNode(9),
                new TreeNode(-6, new TreeNode(5), new TreeNode(9)));

            Assert.IsTrue(tree.HasPathSum(7));
        }

        [TestMethod]
        public void HasPathSumTest6()
        {
            var tree = new TreeNode(1,
                new TreeNode(2));

            Assert.IsFalse(tree.HasPathSum(1));
        }
    }
}