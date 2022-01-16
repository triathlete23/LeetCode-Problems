using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemsLibrary;

namespace Tests
{
    [TestClass]
    public class InterviwProblemsShould
    {
        [TestMethod]
        public void TestCase1()
        {
            var list = new List<int> {1, 2, 1};
            Assert.AreEqual(1, InterviewProblems.Count(list));
        }

        [TestMethod]
        public void TestCase2()
        {
            var list = new List<int> { 1, 1, 5 };
            Assert.AreEqual(2, InterviewProblems.Count(list));
        }

        [TestMethod]
        public void TestCase3()
        {
            var list = new List<int> { 1, 1, 3, 2, 3, 2 };
            Assert.AreEqual(3, InterviewProblems.Count(list));
        }

        [TestMethod]
        public void TestCase4()
        {
            var list = new List<int> { 1, 1, 2, 2, 1, 1 };
            Assert.AreEqual(1, InterviewProblems.Count(list));
        }
    }
}
