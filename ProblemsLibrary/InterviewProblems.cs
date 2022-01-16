using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemsLibrary
{
    public static class InterviewProblems
    {
        public static int Count(List<int> stones)
        {
            stones.Sort();
            var nextLevel = stones.CreateNextLevel();
            while (nextLevel.Distinct().Count() != nextLevel.Count)
            {
                nextLevel = nextLevel.CreateNextLevel();
            }

            return nextLevel.Count;
        }

        private static ICollection<int> CreateNextLevel(this ICollection<int> stones)
        {
            var nextLevel = new List<int>();
            while (stones.Count >= 1)
            {
                var i = stones.FirstOrDefault();
                stones.Remove(i);
                if (stones.Contains(i))
                {
                    nextLevel.Add(i * 2);
                    stones.Remove(i);
                }
                else
                {
                    nextLevel.Add(i);
                }
            }

            return nextLevel;
        }
    }
}
