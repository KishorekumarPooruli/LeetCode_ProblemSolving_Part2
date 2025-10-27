using System;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;

namespace _03_ProblemNo_5
{
    /// <summary>
    /// https://leetcode.com/problems/longest-palindromic-substring
    /// </summary>
    internal class RunnerModule
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string result = solution.LongestPalindrome("ccc");
        }
    }

    public class Solution
    {
        public string? LongestPalindrome(string s)
        {
            int leftPointerIndex = 0;
            int rightPointerIndex = 0;
            int centrePointerIndex = 0;
            List<string> outputs = new List<string>();

            for(int i = centrePointerIndex; i < s.Length; i++)
            {
                char centerValue = s[i];
                leftPointerIndex = i;
                rightPointerIndex = i;
                while (leftPointerIndex < s.Length || rightPointerIndex < s.Length)
                {
                    char leftValue = leftPointerIndex >= 0 && leftPointerIndex < s.Length ? s[leftPointerIndex] :  ' ';
                    char rightValue = rightPointerIndex >= 0 && rightPointerIndex < s.Length ? s[rightPointerIndex] : ' ';

                    if (leftValue.Equals(' ') && rightValue.Equals(' '))
                    {
                        break;
                    }

                    if (centerValue.Equals(leftValue) && centerValue.Equals(rightValue))
                    {
                        outputs.Add(centerValue.ToString()); 
                    }
                    else if (centerValue.Equals(leftValue))
                    {
                        outputs.Add($"{centerValue}{leftValue}");
                    }
                    else if (centerValue.Equals(rightValue))
                    {
                        outputs.Add($"{centerValue}{rightValue}");
                    }
                    else if (leftValue.Equals(rightValue))
                    {
                        outputs.Add($"{leftValue}{centerValue}{rightValue}");
                    }
                    else
                    {
                        break;
                    }


                    leftPointerIndex = leftPointerIndex - 1;
                    rightPointerIndex = rightPointerIndex + 1;
                }

            }

            return outputs.OrderByDescending(s => s.Length).FirstOrDefault();
        }
    }


}
