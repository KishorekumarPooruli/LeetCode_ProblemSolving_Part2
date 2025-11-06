using System;

namespace _07_ProblemNo_2379
{
    /// <summary>
    /// https://leetcode.com/problems/minimum-recolors-to-get-k-consecutive-black-blocks
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int result = solution.MinimumRecolors("WBBWWBBWBW", 7);
        }
    }

    public class Solution
    {
        public int MinimumRecolors(string blocks, int k)
        {
            ////char[] input = blocks.ToCharArray();
            int result = 0;
            if(!IsConsecutive(blocks, k))
            {
                List<int> minmumsOperations = new List<int>();
                for (int i = 0; i < blocks.Length; i++)
                {
                    char[] windowSubString = blocks.Skip(i).Take(k).ToArray();
                    if (windowSubString.Length == k)
                    {
                        int countNoOfB = windowSubString.Count(y => y == 'B');
                        int missingB = k - countNoOfB;
                        minmumsOperations.Add(missingB);
                        result = minmumsOperations.Min();
                    }
                    else
                    {
                        break;
                    }
                } 
            }
            return result;
        }

        private bool IsConsecutive(string blocks, int k)
        {
            List<int> indexsofB = new List<int>();
            for (int i = 0; i < blocks.Length; i++)
            {
                if (blocks[i] == 'B')
                {
                    indexsofB.Add(i);
                }
            }

            foreach (var index in indexsofB)
            {
                char[] windowSubString = blocks.Skip(index).Take(k).ToArray();
                ///// windowSubString = blocks.Substring(index, k).ToCharArray(); 
                ///// This can be used but we need to check if they are inside bounds index + k < blocks.Length
                bool isConcecutive = windowSubString.All(y => y == windowSubString[0]);
                if (isConcecutive && windowSubString.Length == k)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
