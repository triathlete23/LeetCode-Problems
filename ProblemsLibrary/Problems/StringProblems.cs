using System.Collections.Generic;

namespace ProblemsLibrary.Problems
{
   public static class StringProblems
    {
        public static IList<string> FindAndReplacePattern(string[] words, string pattern)
        {
            var resList = new List<string>();
            foreach (var word in words)
            {
                var isPattern = CheckWordToPattern(word, pattern);
                var isWord = CheckWordToPattern(pattern, word);
                if (isPattern && isWord)
                {
                    resList.Add(word);
                }
            }

            return resList;
        }

        private static bool CheckWordToPattern(string word, string pattern)
        {
            if (word.Length != pattern.Length) return false;

            var dict = new Dictionary<char, char>();

            for (var i = 0; i < word.Length; i++)
            {
                if (dict.ContainsKey(pattern[i]))
                {
                    if (dict[pattern[i]] != word[i])
                    {
                        return false;
                    }
                    continue;
                }

                dict[pattern[i]] = word[i];
            }

            return true;
        }

        public static int UniqueMorseRepresentations(string[] words)
        {
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToCharArray();
            string[] codes = new[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };

            var dict = new Dictionary<char, string>();
            for (var i = 0; i < codes.Length; i++)
            {
                dict.Add(alphabet[i], codes[i]);
            }

            var transformations = new List<string>();

            foreach (var word in words)
            {
                string transformation = string.Empty;
                foreach (var caracter in word)
                {
                    transformation += dict[caracter];
                }
                if (!transformations.Contains(transformation))
                {
                    transformations.Add(transformation);
                }
            }

            return transformations.Count;
        }

        public static int HammingDistance(int x, int y)
        {
            var counter = 0;
            var xored = x ^ y;
            var i = 31;
            while (i-- > 0)
            {
                counter += xored & 1;
                xored >>= 1;
            }

            return counter;
        }
    }
}
