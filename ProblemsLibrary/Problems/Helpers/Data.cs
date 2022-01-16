using System;

namespace ProblemsLibrary.Problems.Helpers
{
    public static class Data
    {
        public static readonly string Alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";

        public static int[] GenerateRandomArray(int length)
        {
            var ar = new int[length];
            var rand = new Random();
            for (var i = 0; i < length; i++)
            {
                ar[i] = rand.Next(0, length);
            }
            return ar;
        }
    }
}
