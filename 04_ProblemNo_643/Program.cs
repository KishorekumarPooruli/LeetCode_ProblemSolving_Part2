using System.Globalization;

namespace _04_ProblemNo_643
{
    /// <summary>
    /// https://leetcode.com/problems/maximum-average-subarray-i/description
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 1, 12, -5, -6, 50, 3 };
            Solution solution = new Solution();
            double result = solution.FindMaxAverage(input, 1);
            //// 1,12,-5,-6,50,3
            ////  1,12,-5,-6
            //// 12,-5,-6,50
            //// -5,-6,50,3
        }
    }

    public class Solution
    {
        public double FindMaxAverage(int[] inputArray, int k)
        {
            double windowSum = default(double);
            double avg = default(double);
            int previousStartingIndex = 0;
            int startingWindowIndex = 0;
            int endingWindowIndex = k;

            for (int start = 0; start < inputArray.Length; start++)
            {
                if (start + k <= inputArray.Length) //// Checking if we have a Window
                {
                    if (start == 0)
                    {
                        //// First Iteration Calculate SUM of all the Window
                        for (int i = startingWindowIndex; i < endingWindowIndex; i++)
                        {
                            windowSum += inputArray[i];
                        }

                        previousStartingIndex = startingWindowIndex; //// Tracking Element to be Deleted in Next Iteration
                        endingWindowIndex--;  //// Assigning Last Index of the current Sliding Window
                    }
                    else
                    {
                        //// Consecutive Iteration Just Add and Subtract
                        windowSum += inputArray[endingWindowIndex + 1] - inputArray[previousStartingIndex];
                        previousStartingIndex++;
                        endingWindowIndex++;
                    }

                    var result = windowSum / (double)k;
                    avg = avg != 0 ? Math.Max(avg, result) : result;
                }
                else
                {
                    break;
                }
            }

            return avg;
        }
    }
}
