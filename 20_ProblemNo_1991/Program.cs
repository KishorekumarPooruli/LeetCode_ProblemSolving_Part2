namespace _20_ProblemNo_1991
{
    /// <summary>
    /// TIME AND SPACE: O(N)
    /// https://leetcode.com/problems/find-the-middle-index-in-array
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int result = solution.FindMiddleIndex(new int[] { 2, 5 });
        }
    }

    public class Solution
    {
        public int FindMiddleIndex(int[] nums)
        {
            int[] prefixArray = this.BuildPrefixSum(nums);
            int totalSum = prefixArray[nums.Length - 1];

            for (int i = 0; i < nums.Length; i++) 
            {
                int leftSum = 0;
                if (i - 1 >= 0)
                {
                    leftSum = prefixArray[i - 1];
                }
                int rightSum = totalSum - leftSum - nums[i];

                if (leftSum == rightSum)
                {
                    return i;
                }
            }

            return -1;
        }

        private int[] BuildPrefixSum(int[] nums)
        {
            int[] intPrefixArray = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++) 
            {
                if (i - 1 >= 0)
                {
                    intPrefixArray[i] = nums[i] + intPrefixArray[i -1];
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
