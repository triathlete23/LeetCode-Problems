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
            Assert.AreEqual(2, OtherProblems.RemoveDuplicates(new int[] { 1, 1, 2 }));
        }

        [TestMethod]
        public void RemoveDuplicatesTest2()
        {
            Assert.AreEqual(5, OtherProblems.RemoveDuplicates(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }));
        }

        [TestMethod]
        public void RemoveElementTest1()
        {
            var arr = new int[] { 3, 2, 2, 3 };
            Assert.AreEqual(2, arr.RemoveElement(3));
            Assert.AreEqual(2, arr[0]);
            Assert.AreEqual(2, arr[1]);
        }

        [TestMethod]
        public void RemoveElementTest2()
        {
            var arr = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            var res = new int[] { 0, 1, 4, 0, 3 };
            Assert.AreEqual(5, arr.RemoveElement(2));
            Assert.IsTrue(arr.Contains(0));
            Assert.IsTrue(arr.Contains(1));
            Assert.IsTrue(arr.Contains(4));
            Assert.IsTrue(arr.Contains(3));
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
        public void DeleteDuplicatesTest1()
        {
            var listNode = new ListNode(1, new ListNode(1, new ListNode(2)));
            var res = new ListNode(1, new ListNode(2));
            Assert.AreEqual(res, listNode.DeleteDuplicates());
        }

        [TestMethod]
        public void DeleteDuplicatesTest2()
        {
            var listNode = new ListNode(1, new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(3, new ListNode(3))))));
            var res = new ListNode(1, new ListNode(2, new ListNode(3)));
            Assert.AreEqual(res, listNode.DeleteDuplicates());
        }

        [TestMethod]
        public void MergeTest1()
        {
            var nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
            var nums2 = new int[] { 2, 5, 6 };
            var res = new int[] { 1, 2, 2, 3, 5, 6 };
            nums1.Merge(3, nums2, 3);
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

        //[TestMethod]
        //public void MergeTest3()
        //{
        //    var nums1 = new int[0];
        //    var nums2 = new int[] { 1 };
        //    var res = new int[] { 1 };
        //    nums1.Merge(0, nums2, 1);
        //    Assert.IsTrue(nums1.SequenceEqual(res));
        //}

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

        //[TestMethod]
        //public void SortedArrayToBSTTest1()
        //{
        //    var nums = new int[] { -10, -3, 0, 5, 9 };
        //    var expected = new TreeNode(0, 
        //        new TreeNode(-10, null, new TreeNode(-3)),
        //        new TreeNode(5, null, new TreeNode(9)));
        //    var res = nums.SortedArrayToBST();
        //    Assert.AreEqual(expected, res);
        //}

        //[TestMethod]
        //public void SortedArrayToBSTTest2()
        //{
        //    var nums = new int[] { 1, 3 };
        //    var res = new TreeNode(1, null, new TreeNode(3));
        //    Assert.AreEqual(res, nums.SortedArrayToBST());
        //}

        //[TestMethod]
        //public void SortedArrayToBSTTest3()
        //{
        //    var nums = new int[] { 0, 1, 2, 3, 4, 5 };
        //    var res = new TreeNode(3, 
        //        new TreeNode(1, new TreeNode(2), new TreeNode(4)), 
        //        new TreeNode(5));
        //    Assert.AreEqual(res, nums.SortedArrayToBST());
        //}

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
        public void TrapTest1()
        {
            Assert.AreEqual(6, OtherProblems.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));
        }

        [TestMethod]
        public void TrapTest2()
        {
            Assert.AreEqual(9, OtherProblems.Trap(new int[] { 4, 2, 0, 3, 2, 5 }));
        }

        [TestMethod]
        public void PileOfStonesTest1()
        {
            Assert.AreEqual("Bob", OtherProblems.PileOfStones(new int[] { 1, 2, 3, 7 }));
        }

        [TestMethod]
        public void PileOfStonesTest2()
        {
            Assert.AreEqual("Alice", OtherProblems.PileOfStones(new int[] { 1, 2, 3, -9 }));
        }

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
    }
}
