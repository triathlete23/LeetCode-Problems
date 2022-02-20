using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemsLibrary.Problems;
using ProblemsLibrary.Problems.Helpers;
using SortsLibrary;

namespace Tests
{
    [TestClass]
    public class ProblemsShould
    {
        private readonly int[] defaultArray = { 1, 3, 5, 7, 8 };

        private readonly int[] defaultArray1 = { 4, 3, 2, 6 };

        private readonly int[] defaultArrayToSort = { 9, 6, 1, 8, 3, 5, 7 };

        private readonly int[] sortedDefaultArray = { 1, 3, 5, 6, 7, 8, 9 };

        private readonly int[] defaultArray2 = { -2147483648, -2147483648 };

        private readonly int[] defaultArray3 = { 4, 15, 14, 3, 14, -8, 12, -9, 17, -1, 15, 1, 10, 19, -7, 15, 8, 7, -8, 11 };

        private readonly int[] randomArray = { 5, 4, 6, 3, 1, 9, 7, 8, 2 };

        private readonly int[] oneElementArray = { 4 };

        private readonly int[] twoElementsArray = { 7, 8 };

        private readonly string[] randomWords = { "abc", "deq", "mee", "aqq", "dkd", "ccc" };

        private readonly string[] randomWordsFromExample = { "abc", "cba", "xyx", "yxx", "yyx" };

        private readonly int?[] binaryTree1 = { 1, null, 0, 0, 1 };

        private readonly int?[] binaryTree2 = { 1, 0, 1, 0, 0, 0, 1 };

        private readonly int?[] binaryTree3 = { 1, 1, 0, 1, 1, 0, 1, 0 };

        private readonly int[][] matrix1 =
        {
            new[] {-9, -9, -9, 1, 1, 1},
            new[] {0, -9, 0, 4, 3, 2},
            new[] {-9, -9, -9, 1, 2, 3},
            new[] {0, 0, 8, 6, 6, 0},
            new[] {0, 0, 0, -2, 0, 0},
            new[] {0, 0, 1, 2, 4, 0}
        };

        private readonly int[][] points1 =
        {
            new []{ 0, 4 },
            new []{ 2, 6 },
            new []{ 1, 5 },
            new []{ 3, 7 },
            new []{ 4, 4 },
        };

        private readonly int[][] points2 =
        {
            new []{ 0, 10 },
            new []{ 10, 20 },
        };

        //[TestMethod]
        //public void ReturnSortedDefaultArray()
        //{
        //    var sorted = defaultArrayToSort.sortArrayFromAlgsPart2(defaultArrayToSort.Length - 3);
        //    var result = sorted.SequenceEqual(sortedDefaultArray);
        //    Assert.IsTrue(result);
        //}

        [TestMethod]
        [TestCategory("InsertIntoBST")]
        public void ReturnNewTreeWithANode1()
        {
            var initNode = new TreeNode
            {
                val = 2,
                left = new TreeNode
                {
                    left = new TreeNode(1),
                    right = new TreeNode(3)
                },
                right = new TreeNode(7)
            };

            var expNode = new TreeNode
            {
                val = 2,
                left = new TreeNode
                {
                    left = new TreeNode(1),
                    right = new TreeNode(3)
                },
                right = new TreeNode
                {
                    val = 7,
                    left = new TreeNode(5)
                }
            };

            var resNode = TreeProblems.InsertIntoBST(initNode, 5);
            Assert.AreEqual(expNode.right.left.val, resNode.right.left.val);
        }

        [TestMethod]
        [TestCategory("PowerSum")]
        public void ReturnThreeForNumberHundredAndPowTwo()
        {
            var res = OtherProblems.PowerSum(100, 2);
            Assert.AreEqual(3, res);
        }

        [TestMethod]
        [TestCategory("PowerSum")]
        public void ReturnOneForNumberTenAndPowTwo()
        {
            var res = OtherProblems.PowerSum(10, 2);
            Assert.AreEqual(1, res);
        }

        [TestMethod]
        [TestCategory("DistantPairs")]
        public void ReturnZeroForNextExample()
        {
            var res = OtherProblems.DistantPairs(points2, 1000);
            Assert.AreEqual(0, res);
        }

        [TestMethod]
        [TestCategory("DistantPairs")]
        public void ReturnTwoForNextExample()
        {
            var res = OtherProblems.DistantPairs(points1, 8);
            Assert.AreEqual(2, res);
        }

        [TestMethod]
        [TestCategory("OddNumbers")]
        public void ReturnOddNumbersForRange3()
        {
            var res = ArrayProblems.oddNumbers(2, 8);
            Assert.AreEqual(3, res.Count);
        }

        [TestMethod]
        [TestCategory("OddNumbers")]
        public void ReturnOddNumbersForRange2()
        {
            var res = ArrayProblems.oddNumbers(3, 7);
            Assert.AreEqual(3, res.Count);
        }

        [TestMethod]
        [TestCategory("OddNumbers")]
        public void ReturnOddNumbersForRange1()
        {
            var res = ArrayProblems.oddNumbers(4, 3);
            Assert.AreEqual(0, res.Count);
        }

        [TestMethod]
        [TestCategory("OddNumbers")]
        public void ReturnOddNumbersForRange()
        {
            var res = ArrayProblems.oddNumbers(4, 5);
            Assert.AreEqual(1, res.Count);
        }

        [TestMethod]
        [TestCategory("HourglassSum")]
        public void ReturnMaxForMatrix1()
        {
            var res = ArrayProblems.hourglassSum(matrix1);
            Assert.AreEqual(28, res);
        }

        [TestMethod]
        [TestCategory("RotateFunction")]
        public void ReturnMaxForDefaultArray3()
        {
            var res = ArrayProblems.MaxRotateFunction(defaultArray3);
            Assert.AreEqual(1511, res);
        }

        [TestMethod]
        [TestCategory("RotateFunction")]
        public void ReturnMaxForDefaultArray2()
        {
            var res = ArrayProblems.MaxRotateFunction(defaultArray2);
            Assert.AreEqual(-2147483648, res);
        }

        [TestMethod]
        [TestCategory("RotateFunction")]
        public void ReturnMaxForDefaultArray1()
        {
            var res = ArrayProblems.MaxRotateFunction(defaultArray1);
            Assert.AreEqual(26, res);
        }

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
            Assert.AreEqual(expectedTree.right.right.val, resTree.right.right.val);
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
            var expectedRes = new List<string> { "mee", "aqq" };
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
            var aliceScores = new List<int> { 10, 11, 12 };
            var bobScores = new List<int> { 12, 10, 13 };
            var expected = new List<int> { 1, 2 };

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
        public void ReturnIndexOfRandomElementInSortedArray()
        {
            var array = Data.GenerateRandomArray(10000);
            var sortedArray = Sorts.ShellSort(array);
            var elementToFind = array[new Random().Next(sortedArray.Length)];
            var result = OtherProblems.BinarySearch(sortedArray, elementToFind);
            Assert.AreNotEqual(-1, result);
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

        [TestMethod]
        public void IsPalindromeTest1()
        {
            var x = 121;
            Assert.IsTrue(x.IsPalindrome());
        }

        [TestMethod]
        public void IsPalindromeTest2()
        {
            var x = -121;
            Assert.IsFalse(x.IsPalindrome());
        }

        [TestMethod]
        public void IsPalindromeTest3()
        {
            var x = 10;
            Assert.IsFalse(x.IsPalindrome());
        }

        [TestMethod]
        public void IsPalindromeTest4()
        {
            var x = 1881;
            Assert.IsTrue(x.IsPalindrome());
        }

        [TestMethod]
        public void IsPalindromeTest5()
        {
            var x = 11;
            Assert.IsTrue(x.IsPalindrome());
        }

        [TestMethod]
        public void IsPalindromeTest6()
        {
            var x = 100;
            Assert.IsFalse(x.IsPalindrome());
        }

        [TestMethod]
        public void IsPalindromeTest7()
        {
            var x = 0;
            Assert.IsTrue(x.IsPalindrome());
        }

        [TestMethod]
        public void IsPalindromeTest8()
        {
            var x = 123;
            Assert.IsFalse(x.IsPalindrome());
        }

        [TestMethod]
        public void IsPalindromeTest9()
        {
            var x = 88888;
            Assert.IsTrue(x.IsPalindrome());
        }
        
        [TestMethod]
        public void IsPalindromeTest10()
        {
            var x = 1000021;
            Assert.IsFalse(x.IsPalindrome());
        }

        [TestMethod]
        public void RomanToIntTest1()
        {
            var s = "III";
            Assert.AreEqual(3, s.RomanToInt());
        }

        [TestMethod]
        public void RomanToIntTest11()
        {
            var s = "XII";
            Assert.AreEqual(12, s.RomanToInt());
        }

        [TestMethod]
        public void RomanToIntTest2()
        {
            var s = "LVIII";
            Assert.AreEqual(58, s.RomanToInt());
        }

        [TestMethod]
        public void RomanToIntTest21()
        {
            var s = "XXVII";
            Assert.AreEqual(27, s.RomanToInt());
        }

        [TestMethod]
        public void RomanToIntTest3()
        {
            var s = "MCMXCIV";
            Assert.AreEqual(1994, s.RomanToInt());
        }

        [TestMethod]
        public void LongestCommonPrefix1()
        {
            var arr = new string[] { "flower", "flow", "flight" };
            Assert.AreEqual("fl", arr.LongestCommonPrefix());
        }

        [TestMethod]
        public void LongestCommonPrefix2()
        {
            var arr = new string[] { "dog", "racecar", "car" };
            Assert.AreEqual("", arr.LongestCommonPrefix());
        }

        [TestMethod]
        public void LongestCommonPrefix3()
        {
            var arr = new string[] { "ab", "a" };
            Assert.AreEqual("a", arr.LongestCommonPrefix());
        }

        [TestMethod]
        public void LongestCommonPrefix4()
        {
            var arr = new string[] { "a", "b" };
            Assert.AreEqual("", arr.LongestCommonPrefix());
        }

        [TestMethod]
        public void LongestCommonPrefix5()
        {
            var arr = new string[] { "cir", "car" };
            Assert.AreEqual("c", arr.LongestCommonPrefix());
        }

        [TestMethod]
        public void IsValidTest1()
        {
            var s = "()";
            Assert.AreEqual(true, s.IsValid());
        }

        [TestMethod]
        public void IsValidTest2()
        {
            var s = "()[]{}";
            Assert.AreEqual(true, s.IsValid());
        }

        [TestMethod]
        public void IsValidTest3()
        {
            var s = "(]";
            Assert.AreEqual(false, s.IsValid());
        }

        [TestMethod]
        public void IsValidTest4()
        {
            var s = "{[]}";
            Assert.AreEqual(true, s.IsValid());
        }

        [TestMethod]
        public void IsValidTest5()
        {
            var s = "((";
            Assert.AreEqual(false, s.IsValid());
        }

        [TestMethod]
        public void IsValidTest6()
        {
            var s = "){";
            Assert.AreEqual(false, s.IsValid());
        }
        
        [TestMethod]
        public void IsValidTest7()
        {
            var s = "(])";
            Assert.AreEqual(false, s.IsValid());
        }
        
        [TestMethod]
        public void IsValidTest8()
        {
            var s = "[])";
            Assert.AreEqual(false, s.IsValid());
        }

        [TestMethod]
        public void MergeTwoListsTest1()
        {
            var list1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            var list2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            
            var res = new ListNode(1, 
                    new ListNode(1, 
                    new ListNode(2, 
                    new ListNode(3, 
                    new ListNode(4, 
                    new ListNode(4))))));

            Assert.AreEqual(res, list1.MergeTwoLists(list2));
        }

        [TestMethod]
        public void MergeTwoListsTest2()
        {
            ListNode l1 = null;
            ListNode l2 = null;
            Assert.IsNull(l1.MergeTwoLists(l2));
        }

        [TestMethod]
        public void MergeTwoListsTest3()
        {
            ListNode l1 = null;
            ListNode l2 = new ListNode();
            Assert.AreEqual(new ListNode(), l1.MergeTwoLists(l2));
        }

        [TestMethod]
        public void RemoveDuplicatesTest1()
        {
            var arr = new int[] { 1, 1, 2 };
            Assert.AreEqual(2, arr.RemoveDuplicates());
            CollectionAssert.AreEqual(new int[] { 1, 2, 2 }, arr);
        }

        [TestMethod]
        public void RemoveDuplicatesTest2()
        {
            var arr = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            Assert.AreEqual(5, arr.RemoveDuplicates());
            CollectionAssert.AreEqual(new int[] { 0, 1, 2, 3, 4 }, arr.Take(5).ToArray());
        }

        [TestMethod]
        public void RemoveElementTest1()
        {
            var arr = new int[] { 3, 2, 2, 3 };
            Assert.AreEqual(2, arr.RemoveElement(3));
            CollectionAssert.AreEqual(new int[] { 2, 2 }, arr.Take(2).ToArray());
        }

        [TestMethod]
        public void RemoveElementTest2()
        {
            var arr = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            var res = new int[] { 0, 1, 3, 0, 4 };
            Assert.AreEqual(5, arr.RemoveElement(2));
            CollectionAssert.AreEquivalent(res, arr.Take(5).ToArray());
        }

        [TestMethod]
        public void RemoveElementTest3()
        {
            var arr = new int[] { 1 };
            Assert.AreEqual(1, arr.RemoveElement(1));
            CollectionAssert.AreEqual(new int[] { }, arr);
        }

        [TestMethod]
        public void StrStrTest1()
        {
            Assert.AreEqual(2, "hello".StrStr("ll"));
        }

        [TestMethod]
        public void StrStrTest2()
        {
            Assert.AreEqual(-1, "aaaaa".StrStr("bba"));
        }

        [TestMethod]
        public void StrStrTest3()
        {
            Assert.AreEqual(0, "".StrStr(""));
        }

        [TestMethod]
        public void StrStrTest4()
        {
            Assert.AreEqual(-1, "mississippi".StrStr("issipi"));
        }

        [TestMethod]
        public void StrStrTest5()
        {
            Assert.AreEqual(4, "mississippi".StrStr("issip"));
        }

        [TestMethod]
        public void SearchInsertTest1()
        {
            var arr = new int[] { 1, 3, 5, 6 };
            Assert.AreEqual(2, arr.SearchInsert(5));
        }

        [TestMethod]
        public void SearchInsertTest2()
        {
            var arr = new int[] { 1, 3, 5, 6 };
            Assert.AreEqual(1, arr.SearchInsert(2));
        }
        
        [TestMethod]
        public void SearchInsertTest3()
        {
            var arr = new int[] { 1, 3, 5, 6 };
            Assert.AreEqual(4, arr.SearchInsert(7));
        }

        [TestMethod]
        public void SearchInsertTest4()
        {
            var arr = new int[] { 1, 3, 5, 6 };
            Assert.AreEqual(0, arr.SearchInsert(0));
        }

        [TestMethod]
        public void SearchInsertTest5()
        {
            var arr = new int[] { 1, 3 };
            Assert.AreEqual(0, arr.SearchInsert(0));
        }

        [TestMethod]
        public void SearchInsertTest6()
        {
            var arr = new int[] { 3, 5, 7, 9, 10 };
            Assert.AreEqual(3, arr.SearchInsert(8));
        }

        [TestMethod]
        public void MaxSubArrayTest1()
        {
            var arr = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

            Assert.AreEqual(6, arr.MaxSubArray());
        }

        [TestMethod]
        public void MaxSubArrayTest2()
        {
            var arr = new int[] { 1 };

            Assert.AreEqual(1, arr.MaxSubArray());
        }

        [TestMethod]
        public void MaxSubArrayTest3()
        {
            var arr = new int[] { 5, 4, -1, 7, 8 };

            Assert.AreEqual(23, arr.MaxSubArray());
        }

        [TestMethod]
        public void MaxSubArrayTest4()
        {
            var arr = new int[] { -2, 1 };

            Assert.AreEqual(1, arr.MaxSubArray());
        }

        [TestMethod]
        public void MaxSubArrayTest5()
        {
            var arr = new int[] { -1, -2 };

            Assert.AreEqual(-1, arr.MaxSubArray());
        }

        [TestMethod]
        public void LengthOfLastWordTest1()
        {
            Assert.AreEqual(5, "Hello World".LengthOfLastWord());
        }

        [TestMethod]
        public void LengthOfLastWordTest2()
        {
            Assert.AreEqual(4, "   fly me   to   the moon  ".LengthOfLastWord());
        }

        [TestMethod]
        public void LengthOfLastWordTest3()
        {
            Assert.AreEqual(6, "luffy is still joyboy".LengthOfLastWord());
        }

        [TestMethod]
        public void PlusOneTest1()
        {
            var arr = new int[] { 1, 2, 3 };
            var res = arr.PlusOne();
            Assert.AreEqual(1, res[0]);
            Assert.AreEqual(2, res[1]);
            Assert.AreEqual(4, res[2]);
        }

        [TestMethod]
        public void PlusOneTest2()
        {
            var arr = new int[] { 4,3,2,1 };
            var res = arr.PlusOne();
            Assert.AreEqual(4, res[0]);
            Assert.AreEqual(3, res[1]);
            Assert.AreEqual(2, res[2]);
            Assert.AreEqual(2, res[3]);
        }

        [TestMethod]
        public void PlusOneTest3()
        {
            var arr = new int[] { 9 };
            var res = arr.PlusOne();
            Assert.AreEqual(1, res[0]);
            Assert.AreEqual(0, res[1]);
        }

        [TestMethod]
        public void PlusOneTest4()
        {
            var arr = new int[] { 9, 9 };
            var res = arr.PlusOne();
            Assert.AreEqual(3, res.Length);
            Assert.AreEqual(1, res[0]);
            Assert.AreEqual(0, res[1]);
            Assert.AreEqual(0, res[2]);
        }

        [TestMethod]
        public void PlusOneTest5()
        {
            var arr = new int[] { 9, 8, 9 };
            var res = arr.PlusOne();
            Assert.AreEqual(9, res[0]);
            Assert.AreEqual(9, res[1]);
            Assert.AreEqual(0, res[2]);
        }


        [TestMethod]
        public void AddBinaryTest1()
        {
            Assert.AreEqual("100", OtherProblems.AddBinary("11", "1"));
        }

        [TestMethod]
        public void AddBinaryTest2()
        {
            Assert.AreEqual("10101", OtherProblems.AddBinary("1010", "1011"));
        }

        [TestMethod]
        public void AddBinaryTest3()
        {
            Assert.AreEqual("0", OtherProblems.AddBinary("0", "0"));
        }

        [TestMethod]
        public void AddBinaryTest4()
        {
            Assert.AreEqual("1000", OtherProblems.AddBinary("1", "111"));
        }
        
        [TestMethod]
        public void AddBinaryTest5()
        {
            Assert.AreEqual("11110", OtherProblems.AddBinary("1111", "1111"));
        }

        [TestMethod]
        public void MySqrtTest1()
        {
            Assert.AreEqual(2, OtherProblems.MySqrt(4));
        }

        [TestMethod]
        public void MySqrtTest2()
        {
            Assert.AreEqual(2, OtherProblems.MySqrt(8));
        }

        [TestMethod]
        public void MySqrtTest3()
        {
            Assert.AreEqual(3, OtherProblems.MySqrt(10));
        }

        [TestMethod]
        public void MySqrtTest4()
        {
            Assert.AreEqual(1, OtherProblems.MySqrt(1));
        }
        
        [TestMethod]
        public void MySqrtTest5()
        {
            Assert.AreEqual(46339, OtherProblems.MySqrt(2147395599));
        }

        [TestMethod]
        public void MySqrtTest6()
        {
            Assert.AreEqual(46340, OtherProblems.MySqrt(2147483647));
        }

        [TestMethod]
        public void ClimbStairsTest1()
        {
            Assert.AreEqual(2, OtherProblems.ClimbStairs(2));
        }

        [TestMethod]
        public void ClimbStairsTest2()
        {
            Assert.AreEqual(3, OtherProblems.ClimbStairs(3));
        }

        [TestMethod]
        public void ClimbStairsTest3()
        {
            Assert.AreEqual(8, OtherProblems.ClimbStairs(5));
        }   
        
        [TestMethod]
        public void GenerateTest1()
        {
            var result = new List<IList<int>>
            {
                new List<int>{1},
                new List<int>{1,1},
                new List<int>{1,2,1},
                new List<int>{1,3,3,1},
                new List<int>{1,4,6,4,1}
            };

            Assert.ReferenceEquals(result, OtherProblems.Generate(5));
        }

        [TestMethod]
        public void GenerateTest2()
        {
            var result = new List<IList<int>>
            {
                new List<int> { 1 }
            };

            Assert.ReferenceEquals(result, OtherProblems.Generate(1));
        }

        [TestMethod]
        public void GetRowTest1()
        {
            var result = new List<int> { 1, 3, 3, 1 };
            Assert.ReferenceEquals(result, OtherProblems.GetRow(3));
        }

        [TestMethod]
        public void GetRowTest2()
        {
            var result = new List<int> { 1 };
            Assert.ReferenceEquals(result, OtherProblems.GetRow(0));
        }

        [TestMethod]
        public void GetRowTest3()
        {
            var result = new List<int> { 1, 1 };
            Assert.ReferenceEquals(result, OtherProblems.GetRow(1));
        }

        [TestMethod]
        public void TrapTest1()
        {
            Assert.AreEqual(6, OtherProblems.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));
        }

        [TestMethod]
        public void TrapTest2()
        {
            Assert.AreEqual(9, OtherProblems.Trap(new int[] { 4, 2, 0, 3, 2, 5 }));
        }

        //[TestMethod]
        //public void PileOfStonesTest1()
        //{
        //    Assert.AreEqual("Bob", OtherProblems.PileOfStones(new int[] { 1, 2, 3, 7 }));
        //}

        //[TestMethod]
        //public void PileOfStonesTest2()
        //{
        //    Assert.AreEqual("Alice", OtherProblems.PileOfStones(new int[] { 1, 2, 3, -9 }));
        //}

        [TestMethod]
        public void MaxProfitTest()
        {
            Assert.AreEqual(5, OtherProblems.MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 }));
        }

        [TestMethod]
        public void MaxProfitTest1()
        {
            Assert.AreEqual(0, OtherProblems.MaxProfit(new int[] { 7, 6, 4, 3, 1 }));
        }

        [TestMethod]
        public void MaxProfitTest2()
        {
            Assert.AreEqual(0, OtherProblems.MaxProfit(new int[] { 7, 6 }));
            Assert.AreEqual(0, OtherProblems.MaxProfit(new int[] { 6, 6 }));
        }

        [TestMethod]
        public void MaxProfitTest3()
        {
            Assert.AreEqual(3, OtherProblems.MaxProfit(new int[] { 1,4,2 }));
        }

        [TestMethod]
        public void MaxProfitTest4()
        {
            Assert.AreEqual(4, OtherProblems.MaxProfit(new int[] { 3, 2, 6, 5, 0, 3 }));
        }

        [TestMethod]
        public void ContainsDuplicateTest1()
        {
            Assert.IsTrue(OtherProblems.ContainsDuplicate(new int[] { 1, 2, 3, 1 }));
        }

        [TestMethod]
        public void ContainsDuplicateTest2()
        {
            Assert.IsFalse(OtherProblems.ContainsDuplicate(new int[] { 1, 2, 3, 4 }));
        }

        [TestMethod]
        public void ContainsDuplicateTest3()
        {
            Assert.IsTrue(OtherProblems.ContainsDuplicate(new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }));
        }

        [TestMethod]
        public void ProductExceptSelfTest1()
        {
            Assert.IsTrue(new int[] { 24, 12, 8, 6 }.SequenceEqual(OtherProblems.ProductExceptSelf(new int[] { 1, 2, 3, 4 })));
        }

        [TestMethod]
        public void ProductExceptSelfTest2()
        {
            Assert.IsTrue(new int[] { 0, 0, 9, 0, 0 }.SequenceEqual(OtherProblems.ProductExceptSelf(new int[] { -1, 1, 0, -3, 3 })));
        }

        [TestMethod]
        public void MaxProduct1()
        {
            Assert.AreEqual(6, OtherProblems.MaxProduct(new int[] { 2, 3, -2, 4 }));
        }

        [TestMethod]
        public void MaxProduct2()
        {
            Assert.AreEqual(0, OtherProblems.MaxProduct(new int[] { -2, 0, -1 }));
        }

        [TestMethod]
        public void MaxProduct3()
        {
            Assert.AreEqual(2, OtherProblems.MaxProduct(new int[] { 0, 2 }));
        }

        [TestMethod]
        public void MaxProduct4()
        {
            Assert.AreEqual(24, OtherProblems.MaxProduct(new int[] { -2, 3, -4 }));
        }
        
        [TestMethod]
        public void MaxProduct5()
        {
            Assert.AreEqual(1, OtherProblems.MaxProduct(new int[] { -3, 0, 1, -2 }));
        }

        [TestMethod]
        public void MaxProduct6()
        {
            Assert.AreEqual(24, OtherProblems.MaxProduct(new int[] { 2, -5, -2, -4, 3 }));
        }

        [TestMethod]
        public void FindMinTest1()
        {
            Assert.AreEqual(1, OtherProblems.FindMin(new int[] { 3, 4, 5, 1, 2 }));
        }

        [TestMethod]
        public void FindMinTest2()
        {
            Assert.AreEqual(0, OtherProblems.FindMin(new int[] { 4, 5, 6, 7, 0, 1, 2 }));
        }

        [TestMethod]
        public void FindMinTest3()
        {
            Assert.AreEqual(11, OtherProblems.FindMin(new int[] { 11, 13, 15, 17 }));
        }

        [TestMethod]
        public void FindMinTest4()
        {
            Assert.AreEqual(0, OtherProblems.FindMin(new int[] { 1, 2, 3, 4, 5, 6, 7, 0 }));
        }

        [TestMethod]
        public void FindMinTest5()
        {
            Assert.AreEqual(0, OtherProblems.FindMin(new int[] { 2, 3, 4, 5, 6, 7, 0, 1 }));
        }

        [TestMethod]
        public void FindMinTest6()
        {
            Assert.AreEqual(1, OtherProblems.FindMin(new int[] { 5, 1, 2, 3, 4 }));
        }

        [TestMethod]
        public void SearchTest1()
        {
            Assert.AreEqual(4, OtherProblems.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0)); // -
        }

        [TestMethod]
        public void SearchTest2()
        {
            Assert.AreEqual(-1, OtherProblems.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3)); // right
        }

        [TestMethod]
        public void SearchTest3()
        {
            Assert.AreEqual(-1, OtherProblems.Search(new int[] { 1 }, 0));
        }

        [TestMethod]
        public void SearchTest4()
        {
            Assert.AreEqual(1, OtherProblems.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 5)); // right, left
        }

        [TestMethod]
        public void SearchTest5()
        {
            Assert.AreEqual(4, OtherProblems.Search(new int[] { 4, 5, 6, 7, 8, 1, 2, 3 }, 8)); // right, left, mid
        }

        [TestMethod]
        public void ThreeSumTest()
        {
            var expectedResult = new List<IList<int>>
            {
                new int[]{ -1, -1, 2 },
                new int[]{ -1, 0, 1 }
            };
            var res = OtherProblems.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
            Assert.IsTrue(expectedResult.All(arr => res.Any(el => el.Count == arr.Count && el.All(x => arr.Contains(x)))));
        }

        [TestMethod]
        public void ThreeSumTest1()
        {
            Assert.IsFalse(OtherProblems.ThreeSum(new int[0]).Any());
        }

        [TestMethod]
        public void ThreeSumTest2()
        {
            Assert.IsFalse(OtherProblems.ThreeSum(new int[] { 0 }).Any());
        }

        [TestMethod]
        public void ThreeSumTest3()
        {
            var expectedResult = new List<IList<int>>
            {
                new int[]{ 0,0,0 }
            };
            var res = OtherProblems.ThreeSum(new int[] { 0, 0, 0 });
            Assert.IsTrue(expectedResult.All(arr => res.Any(el => el.Count == arr.Count && el.All(x => arr.Contains(x)))));
        }

        [TestMethod]
        public void MaxAreaTest()
        {
            Assert.AreEqual(49, OtherProblems.MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }));
        }

        [TestMethod]
        public void MaxAreaTest1()
        {
            Assert.AreEqual(1, OtherProblems.MaxArea(new int[] { 1, 1 }));
        }

        [TestMethod]
        public void MaxAreaTest2()
        {
            Assert.AreEqual(4, OtherProblems.MaxArea(new int[] { 1, 2, 4, 3 }));
        }

        [TestMethod]
        public void MaxAreaTest3()
        {
            Assert.AreEqual(17, OtherProblems.MaxArea(new int[] { 2, 3, 4, 5, 18, 17, 6 }));
        }

        [TestMethod]
        public void MaxAreaTest4()
        {
            Assert.AreEqual(2, OtherProblems.MaxArea(new int[] { 1,2,1 }));
        }

        [TestMethod]
        public void MaxAreaTest5()
        {
            Assert.AreEqual(16, OtherProblems.MaxArea(new int[] { 4, 3, 2, 1, 4 }));
        }

        [TestMethod]
        public void MaxAreaTest6()
        {
            Assert.AreEqual(49, OtherProblems.MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }));
        }

        [TestMethod]
        public void GetSumTest()
        {
            Assert.AreEqual(3, OtherProblems.GetSum(1, 2));
        }

        [TestMethod]
        public void GetSumTest1()
        {
            Assert.AreEqual(5, OtherProblems.GetSum(2, 3));
        }
    }
}
