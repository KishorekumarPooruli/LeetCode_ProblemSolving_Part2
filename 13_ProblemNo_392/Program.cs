using System;

namespace _13_ProblemNo_392
{
    /// <summary>
    /// https://leetcode.com/problems/is-subsequence
    /// Time: O(n), where n = t.Length
    /// Space: O(1)
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            bool result = Solution.Instance.IsSubsequence("axc", "ahbgdc");
        }
    }

    public sealed class Solution
    {
        private static readonly Lazy<Solution> lazy = new Lazy<Solution>(() => new Solution());

        //// public static Solution Instance => lazy.Value;
        public static Solution Instance { get { return lazy.Value; } } //// SINGLETON PATTERN IMPLEMENTATION

        public bool IsSubsequence(string s, string t)
        {
            bool result = t.Length > 1 || s.Length == t.Length; //// CORNER CASE FIXES: 
            //// s ="" t ="ahbgdc" O/P= TRUE
            //// s = "" t = "" O / P = TRUE
            //// s = "abc" t = "" O / P = false
            int upperPointer = 0;
            int lowerPointer = 0;
            while (upperPointer < s.Length && lowerPointer < t.Length) 
            {
                result = false;
                if (s[upperPointer] == t[lowerPointer])
                { 
                    upperPointer++;
                    lowerPointer++;

                    if (upperPointer == s.Length)
                    {
                        result = true;
                        return result;
                    }
                }
                else
                {
                    lowerPointer++;
                }                
            }            
            return result;
        }
    }
}