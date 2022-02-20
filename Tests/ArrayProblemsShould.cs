using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemsLibrary.Problems;
using System.Linq;

namespace Tests
{
    [TestClass]
    public  class ArrayProblemsShould
    {
        [TestMethod]
        public void TwoNumbersTest1() 
        {
            var res = ArrayProblems.TwoSum(new int[4] { 2, 7, 11, 15 }, 9);
            Assert.AreEqual(0, res[0]);
            Assert.AreEqual(1, res[1]);
        }

        [TestMethod]
        public void TwoNumbersTest2()
        {
            var res = ArrayProblems.TwoSum(new int[3] { 3, 2, 4 }, 6);
            Assert.AreEqual(1, res[0]);
            Assert.AreEqual(2, res[1]);
        }

        [TestMethod]
        public void TwoNumbersTest3()
        {
            var res = ArrayProblems.TwoSum(new int[2] { 3, 3 }, 6);
            Assert.AreEqual(0, res[0]);
            Assert.AreEqual(1, res[1]);
        }

        [TestMethod]
        public void MergeTest1()
        {
            var nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
            var nums2 = new int[] { 2, 5, 6 };
            var res = new int[] { 1, 2, 2, 3, 5, 6 };
            nums1.Merge(6, nums2, 3);
            Assert.IsTrue(nums1.SequenceEqual(res));
        }

        [TestMethod]
        public void MergeTest2()
        {
            var nums1 = new int[] { 1 };
            var nums2 = new int[0];
            var res = new int[] { 1 };
            nums1.Merge(1, nums2, 0);
            Assert.IsTrue(nums1.SequenceEqual(res));
        }

        [TestMethod]
        public void MergeTest3()
        {
            var nums1 = new int[] {0};
            var nums2 = new int[] {1};
            var res = new int[] { 1 };
            nums1.Merge(0, nums2, 1);
            Assert.IsTrue(nums1.SequenceEqual(res));
        }

        [TestMethod]
        public void MergeTest4()
        {
            var nums1 = new int[] { 4, 0, 0, 0, 0, 0 };
            var nums2 = new int[] { 1, 2, 3, 5, 6 };
            var res = new int[] { 1, 2, 3, 4, 5, 6 };
            nums1.Merge(1, nums2, 5);
            Assert.IsTrue(nums1.SequenceEqual(res));
        }

        [TestMethod]
        public void MergeTest5()
        {
            var nums1 = new int[] { -1, -1, 0, 0, 0, 0 };
            var nums2 = new int[] { -1, 0 };
            var res = new int[] { -1, -1, -1, 0, 0, 0 };
            nums1.Merge(4, nums2, 2);
            Assert.IsTrue(nums1.SequenceEqual(res));
        }
    }
}
