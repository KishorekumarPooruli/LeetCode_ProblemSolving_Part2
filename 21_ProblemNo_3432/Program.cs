namespace _21_ProblemNo_3432
{
    /// <summary>
    /// https://leetcode.com/problems/count-partitions-with-even-sum-difference
    /// TIME AND SPACE COMPLEXITY: O(n)
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            solution.CountPartitions(new int[] { 2, 4, 6, 8 });
        }
    }

    public class Solution
    {
        public int CountPartitions(int[] nums)
        {
            int resultEvenSum = 0;
            int[] prefixArray = this.BuildPrefixSum(nums);
            for (int i = 0; i < nums.Length - 1; i++) 
            {
                int currentIndexPrefix = prefixArray[i]; //// CONTAINS PREFIX OF LEFT ELEMENTS
                int remaningPrefixRightSide = prefixArray[nums.Length - 1] - currentIndexPrefix;
                int difference = currentIndexPrefix - remaningPrefixRightSide;
                if (difference % 2 == 0) 
                {
                    resultEvenSum++;
                }
            }

            return resultEvenSum;
        }

        private int[] BuildPrefixSum(int[] nums)
        {
            int[] intPrefixArray = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (i - 1 >= 0)
                {
                    intPrefixArray[i] = nums[i] + intPrefixArray[i - 1];
                }
                else
                {
                    intPrefixArray[i] = nums[i];
                }
            }

            return intPrefixArray;
        }
    }
}
