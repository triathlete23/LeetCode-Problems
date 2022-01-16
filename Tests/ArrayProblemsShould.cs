using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemsLibrary.Problems;

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
    }
}
