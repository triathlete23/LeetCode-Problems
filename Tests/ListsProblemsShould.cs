using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemsLibrary.Problems.Helpers;
using ProblemsLibrary.Problems;

namespace Tests
{
    [TestClass]
    public class ListsProblemsShould
    {
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
    }
}
