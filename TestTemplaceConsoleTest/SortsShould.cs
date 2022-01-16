using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTemplateConsoleApp;

namespace TestTemplaceConsoleTest
{
    [TestClass]
    public class SortsShould
    {
        private readonly int[] defaultArray = { 9, 6, 1, 8, 3, 5, 7 };

        private readonly int[] sortedDefaultArray = {1, 3, 5, 6, 7, 8, 9};

        private readonly int[] arrayWithDoubles = {2, 4, 2, 3, 1, 8, 4};

        private readonly int[] sortedArrayWithDoubles = {1, 2, 2, 3, 4, 4, 8};

        private readonly int[] oneElementArray = { 4 };

        private readonly int[] twoElementsArray = { 7, 8 };

        private readonly int[] sortedTwoElementsArray = { 7, 8 };

        [TestMethod]
        [TestCategory("HeapSort")]
        public void ReturnSortedDefaultArrayByHeapSort()
        {
            var result = Sorts.HeapSort(defaultArray);
            var actual = sortedDefaultArray.SequenceEqual(result);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("HeapSort")]
        public void ReturnSortedDoublesArrayByHeapSort()
        {
            var result = Sorts.HeapSort(arrayWithDoubles);
            var actual = sortedArrayWithDoubles.SequenceEqual(result);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("HeapSort")]
        public void ReturnSortedTwoElementArrayByHeapSort()
        {
            var result = Sorts.HeapSort(twoElementsArray);
            var actual = sortedTwoElementsArray.SequenceEqual(result);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("HeapSort")]
        public void ReturnSortedOneElementArrayByHeapSort()
        {
            var result = Sorts.HeapSort(oneElementArray);
            var actual = result.SequenceEqual(oneElementArray);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("BottomUpMergeSort")]
        public void ReturnSortedDefaultArrayByBottomUpMergeSort()
        {
            var result = Sorts.BottomUpMergeSort(defaultArray);
            var actual = sortedDefaultArray.SequenceEqual(result);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("BottomUpMergeSort")]
        public void ReturnSortedDoublesArrayByBottomUpMergeSort()
        {
            var result = Sorts.BottomUpMergeSort(arrayWithDoubles);
            var actual = sortedArrayWithDoubles.SequenceEqual(result);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("BottomUpMergeSort")]
        public void ReturnSortedTwoElementArrayByBottomUpMergeSort()
        {
            var result = Sorts.BottomUpMergeSort(twoElementsArray);
            var actual = sortedTwoElementsArray.SequenceEqual(result);
            Assert.IsTrue(actual);
        }

        [TestCategory("BottomUpMergeSort")]
        public void ReturnSortedOneElementArrayByBottomUpMergeSort()
        {
            var result = Sorts.BottomUpMergeSort(oneElementArray);
            var actual = result.SequenceEqual(oneElementArray);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("MergeSort")]
        public void ReturnSortedArrayWithDoublesByMergeSort()
        {
            var result = Sorts.MergeSort(arrayWithDoubles);
            var actual = sortedArrayWithDoubles.SequenceEqual(result);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("MergeSort")]
        public void ReturnSortedDefaultElementArrayByMergeSort()
        {
            var result = Sorts.MergeSort(defaultArray);
            var actual = sortedDefaultArray.SequenceEqual(result);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("MergeSort")]
        public void ReturnSortedTwoElementArrayByMergeSort()
        {
            var result = Sorts.MergeSort(twoElementsArray);
            var actual = result.SequenceEqual(twoElementsArray);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("MergeSort")]
        public void ReturnSortedOneElementArrayByMergeSort()
        {
            var result = Sorts.MergeSort(oneElementArray);
            var actual = result.SequenceEqual(oneElementArray);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        [TestCategory("ShellSort")]
        public void ReturnSortedOneElementArrayByShellSort()
        {
            var result = Sorts.ShellSort(oneElementArray);
            var actual = result.SequenceEqual(oneElementArray);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("ShellSort")]
        public void ReturnSortedTwoElementArrayByShellSort()
        {
            var result = Sorts.ShellSort(twoElementsArray);
            var actual = sortedTwoElementsArray.SequenceEqual(result);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("ShellSort")]
        public void ReturnSortedDefaultElementArrayByShellSort()
        {
            var result = Sorts.ShellSort(defaultArray);
            var actual = sortedDefaultArray.SequenceEqual(result);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("ShellSort")]
        public void ReturnSortedArrayWithDoublesByShellSort()
        {
            var result = Sorts.ShellSort(arrayWithDoubles);
            var actual = sortedArrayWithDoubles.SequenceEqual(result);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("InsertionSort")]
        public void ReturnSortedOneElementArrayByInsertionSort()
        {
            var result = Sorts.InsertionSort(oneElementArray);
            var actual = result.SequenceEqual(oneElementArray);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("InsertionSort")]
        public void ReturnSortedTwoElementArrayByInsertionSort()
        {
            var result = Sorts.InsertionSort(twoElementsArray);
            var actual = sortedTwoElementsArray.SequenceEqual(result);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("InsertionSort")]
        public void ReturnSortedDefaultElementArrayByInsertionSort()
        {
            var result = Sorts.InsertionSort(defaultArray);
            var actual = sortedDefaultArray.SequenceEqual(result);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("InsertionSort")]
        public void ReturnSortedArrayWithDoublesByInsertionSort()
        {
            var result = Sorts.InsertionSort(arrayWithDoubles);
            var actual = sortedArrayWithDoubles.SequenceEqual(result);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("SelectionSort")]
        public void ReturnSortedOneElementArrayBySelectionSort()
        {
            var result = Sorts.SelectionSort(oneElementArray);
            var actual = result.SequenceEqual(oneElementArray);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("SelectionSort")]
        public void ReturnSortedTwoElementArrayBySelectionSort()
        {
            var result = Sorts.SelectionSort(twoElementsArray);
            var actual = sortedTwoElementsArray.SequenceEqual(result);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("SelectionSort")]
        public void ReturnSortedDefaultElementArrayBySelectionSort()
        {
            var result = Sorts.SelectionSort(defaultArray);
            var actual = sortedDefaultArray.SequenceEqual(result);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("SelectionSort")]
        public void ReturnSortedArrayWithDoublesBySelectionSort()
        {
            var result = Sorts.SelectionSort(arrayWithDoubles);
            var actual = sortedArrayWithDoubles.SequenceEqual(result);
            Assert.IsTrue(actual);
        }
    }
}
