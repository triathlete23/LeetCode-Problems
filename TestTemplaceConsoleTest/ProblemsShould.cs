using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTemplateConsoleApp;
using TestTemplateConsoleApp.Problems;
using TestTemplateConsoleApp.Problems.Helpers;
using static System.Console;

namespace TestTemplaceConsoleTest
{
    [TestClass]
    public class ProblemsShould
    {
        private readonly int[] defaultArray = { 1, 3, 5, 7, 8 };

        private readonly int[] randomArray = { 5, 4, 6, 3, 1, 9, 7, 8, 2 };

        private readonly int[] oneElementArray = { 4 };

        private readonly int[] twoElementsArray = { 7, 8 };

        private readonly string[] randomWords = {"abc", "deq", "mee", "aqq", "dkd", "ccc"};

        private readonly string[] randomWordsFromExample = {"abc", "cba", "xyx", "yxx", "yyx"};

        private readonly int?[] binaryTree1 = {1, null, 0, 0, 1};

        private readonly int?[] binaryTree2 = { 1, 0, 1, 0, 0, 0, 1 };

        private readonly int?[] binaryTree3 = { 1, 1, 0, 1, 1, 0, 1, 0 };


        [TestMethod]
        [TestCategory("PruneTree")]
        public void ReturnPruneTreeForExample2()
        {
            var tree = new TreeNode
            {
                val = 1,
                left = new TreeNode
                {
                    val = 0,
                    left = new TreeNode(0),
                    right = new TreeNode(0)
                },
                right = new TreeNode
                {
                    val = 1,
                    left = new TreeNode(0),
                    right = new TreeNode(1)
                }
            };

            var expectedTree = new TreeNode
            {
                val = 1,
                right = new TreeNode
                {
                    val = 1,
                    right = new TreeNode(1)
                }
            };

            var resTree = TreeProblems.PruneTree(tree);

            Assert.IsNull(resTree.left);
            Assert.AreEqual(expectedTree.right.right.val, resTree.right.right);
        }


        [TestMethod]
        [TestCategory("PruneTree")]
        public void ReturnPruneTreeForExample1()
        {
            var tree = new TreeNode
            {
                val = 1,
                right = new TreeNode
                {
                    val = 0,
                    left = new TreeNode(0),
                    right = new TreeNode(1)
                }
            };

            var expectedTree = new TreeNode
            {
                val = 1,
                right = new TreeNode
                {
                    val = 0,
                    right = new TreeNode(1)
                }
            };

            var resTree = TreeProblems.PruneTree(tree);

            Assert.IsNull(resTree.left);
            Assert.AreEqual(expectedTree.right.right.val, resTree.right.right.val);
        }

        [TestMethod]
        [TestCategory("FindAndReplacePattern")]
        public void ReturnAListWithTwoWordsForExample()
        {
            var expectedRes = new List<string> { "abc", "cba" };
            var res = StringProblems.FindAndReplacePattern(randomWordsFromExample, "abc").ToList();
            CollectionAssert.AreEqual(expectedRes, res);
        }

        [TestMethod]
        [TestCategory("FindAndReplacePattern")]
        public void ReturnAListWithTwoWords()
        {
            var expectedRes = new List<string> {"mee", "aqq"};
            var res = StringProblems.FindAndReplacePattern(randomWords, "abb").ToList();
            CollectionAssert.AreEqual(expectedRes, res);
        }

        [TestMethod]
        [TestCategory("MaxBinaryTree")]
        public void ReturnMaxBinaryTreeForRandomArray()
        {
            var res = TreeProblems.ConstructMaximumBinaryTree(randomArray);
            Assert.IsTrue(res.val == randomArray[5]);
            Assert.AreEqual(res.left.val, randomArray[2]);
            Assert.AreEqual(res.right.val, randomArray[randomArray.Length - 2]);
        }

        [TestMethod]
        [TestCategory("MaxBinaryTree")]
        public void ReturnMaxBinaryTreeForDefaultArray()
        {
            var res = TreeProblems.ConstructMaximumBinaryTree(defaultArray);
            Assert.IsTrue(res.val == defaultArray.Last());
        }

        [TestMethod]
        [TestCategory("MaxBinaryTree")]
        public void ReturnMaxBinaryTreeWithTwoElement()
        {
            var res = TreeProblems.ConstructMaximumBinaryTree(twoElementsArray);
            Assert.IsTrue(res.val == twoElementsArray[1]);
            Assert.IsNull(res.right);
        }

        [TestMethod]
        [TestCategory("MaxBinaryTree")]
        public void ReturnMaxBinaryTreeWithOneElement()
        {
            var res = TreeProblems.ConstructMaximumBinaryTree(oneElementArray);
            Assert.IsTrue(res.val == oneElementArray.First());
            Assert.IsNull(res.left);
            Assert.IsNull(res.right);
        }

        [TestMethod]
        [TestCategory("SocksMerchant")]
        public void ReturnPairsCount()
        {
            var ar = new[] { 1, 1, 3, 1, 2, 1, 3, 3, 3, 3 };

            var res = ArrayProblems.sockMerchant(10, ar);
            Assert.AreEqual(4, res);
        }

        [TestMethod]
        [TestCategory("HammingDistance")]
        public void ReturnDiffInBitsFor40and94()
        {
            var result = StringProblems.HammingDistance(120, 94);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        [TestCategory("HammingDistance")]
        public void ReturnDiffInBitsFor3and1()
        {
            var result = StringProblems.HammingDistance(3, 1);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        [TestCategory("HammingDistance")]
        public void ReturnDiffInBitsFor10and13()
        {
            var result = StringProblems.HammingDistance(10, 13);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        [TestCategory("HammingDistance")]
        public void ReturnDiffInBitsFor1and4()
        {
            var result = StringProblems.HammingDistance(1, 4);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        [TestCategory("MorseCode")]
        public void ReturnNumberOfTransformation()
        {
            var words = new[] { "gin", "zen", "gig", "msg" };

            Assert.AreEqual(2, StringProblems.UniqueMorseRepresentations(words));
        }

        [TestMethod]
        [TestCategory("BobAndAliceScore")]
        public void ReturnAliceAndBobScores1()
        {
            var aliceScores = new List<int> {10, 11, 12};
            var bobScores = new List<int> {12, 10, 13};
            var expected = new List<int> {1, 2};

            var result = OtherProblems.CompareTriplets(aliceScores, bobScores);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("BobAndAliceScore")]
        public void ReturnAliceAndBobScores2()
        {
            var aliceScores = new List<int> { 13, 11, 12 };
            var bobScores = new List<int> { 12, 10, 13 };
            var expected = new List<int> { 2, 1 };
            
            var result = OtherProblems.CompareTriplets(aliceScores, bobScores);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("BobAndAliceScore")]
        public void ReturnAliceAndBobScores3()
        {
            var aliceScores = new List<int> { 12, 10, 13 };
            var bobScores = new List<int> { 12, 10, 13 };
            var expected = new List<int> { 0, 0 };

            var result = OtherProblems.CompareTriplets(aliceScores, bobScores);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("BinarySearch")]
        public void ReturnMinusOneIfElementIsNotInArray()
        {
            var result = OtherProblems.BinarySearch(defaultArray, 4);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        [TestCategory("BinarySearch")]
        public void ReturnMinusOneIfElementIsNotInTwoElementsArray()
        {
            var result = OtherProblems.BinarySearch(defaultArray, 4);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        [TestCategory("BinarySearch")]
        public void ReturnMinusOneIfArrayIsEmpty()
        {
            var result = OtherProblems.BinarySearch(new int[] { }, 4);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        [TestCategory("BinarySearch")]
        public void ReturnZeroIfElementIsOnTheIFirstPosition()
        {
            var result = OtherProblems.BinarySearch(defaultArray, 1);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("BinarySearch")]
        public void ReturnLastELementIndexIfElementIsOnTheILastPosition()
        {
            var result = OtherProblems.BinarySearch(defaultArray, 8);
            Assert.AreEqual(defaultArray.Length - 1, result);
        }

        [TestMethod]
        [TestCategory("BinarySearch")]
        public void FindElementInOneElementArray()
        {
            var result = OtherProblems.BinarySearch(oneElementArray, 4);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("BinarySearch")]
        public void FindElementInTwoElementArray()
        {
            var result = OtherProblems.BinarySearch(twoElementsArray, 7);
            Assert.AreEqual(0, result);
        }
    }
}
