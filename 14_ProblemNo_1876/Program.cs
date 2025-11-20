using System;

namespace _14_ProblemNo_1876
{
    /// <summary>
    /// https://leetcode.com/problems/substrings-of-size-three-with-distinct-characters
    /// CountGoodSubstrings() TimeComplexity : O(n), Space Complexity: O(n)
    /// CountGoodSubstringsOptimal()  TimeComplexity : O(n), Space Complexity: O(1)
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = Solution.Instance.CountGoodSubstringsOptimal("aababcabc");
        }
    }

    public sealed class Solution
    {
        private static readonly Lazy<Solution> lazy = new Lazy<Solution>(() => new Solution());
        public static Solution Instance => lazy.Value;
        public int CountGoodSubstrings(string s)
        {
            //// Uses Extra Spaces
            List<Tuple<string, bool>> tuple = new List<Tuple<string, bool>>();  
            int windowSize = 3;
            int index = 0;
            while (index + windowSize <= s.Length) 
            {
                string subStringWindow = s.Substring(index, windowSize);
                HashSet<char> chars = new HashSet<char>();
                bool isUniqueTuple = true;
                for (int i = 0; i < subStringWindow.Length; i++)
                {
                    if (chars.Contains(subStringWindow[i])) 
                    {
                        isUniqueTuple = false;
                        break;
                    }
                    else
                    {
                        chars.Add(subStringWindow[i]);
                    }
                    
                }

                tuple.Add(Tuple.Create(subStringWindow, isUniqueTuple));
                index++;
            }

            return tuple.Count(y => y.Item2);
        }

        public int CountGoodSubstringsOptimal(string s)
        {
            int windowSize = 3;
            int count = 0;
            int index = 0;
            while (index + windowSize <= s.Length)
            {
                string subStringWindow = s.Substring(index, windowSize);
                if (subStringWindow[0] != subStringWindow[1] &&
                    subStringWindow[0] != subStringWindow[2] &&
                    subStringWindow[1] != subStringWindow[2])
                {
                    //// Instead of Additional DataType just tradtional IF CONDITION
                    count++;
                }

                index++;
            }

            return count;
        }
    }
}
