using System;

namespace _07_ProblemNo_2379
{
    /// <summary>
    /// https://leetcode.com/problems/minimum-recolors-to-get-k-consecutive-black-blocks
    ////  O(n) for MinimumRecolorsGPT and  O(n * k) for MinimumRecolors
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int result = solution.MinimumRecolorsGPT("WBBWWBBWBW", 7);
        }
    }

    public class Solution
    {
        public int MinimumRecolors(string blocks, int k)
        {
            int result = 0;
            if(!this.IsConsecutiveOptimal(blocks, k))
            {
                //// Fixed Size Sliding Window Technique
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

        private bool IsConsecutiveOptimal(string blocks, int k)
        {
            //// Variable Size Sliding Window 
            int upperPointer = 0;
            int lowerPointer = 0;
            int consectuiveCount = 0;
            for (int i = 0; i < blocks.Length; i++)
            {
                if (consectuiveCount == k)
                {
                    //// If the consectuiveCount matches k then return
                    return true;
                }

                if (blocks[i] == 'B')
                {
                    //// If Block B is Found Moves Lower Pointer Forward and Validate is Next Pointer also B
                    lowerPointer++;
                    consectuiveCount++;
                }
                else
                {
                    //// If Next Pointer is not B then Reset
                    upperPointer = i + 1;
                    lowerPointer = i + 1;
                    consectuiveCount = 0;
                }
            }

            return false;
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

        public int MinimumRecolorsGPT(string blocks, int k)
        {
            //// Classic Sliding Window
            int n = blocks.Length;
            int minOps = n; // Max possible recolors is n
            int countW = 0;

            // Initial window
            for (int i = 0; i < k; i++)
            {
                //// FIRST WINDOW COUNT THE W
                if (blocks[i] == 'W')
                    countW++;
            }
            minOps = countW;

            // Slide the window
            for (int i = k; i < n; i++)
            {
                if (blocks[i - k] == 'W')
                {
                    //// STARTING WINDOW --
                    countW--;
                }
                
                if (blocks[i] == 'W')
                {
                    //// ENDING WINDOW ++
                    countW++;
                }
                    
                minOps = Math.Min(minOps, countW);
            }
            return minOps;
        }
    }
}
