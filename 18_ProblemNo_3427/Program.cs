namespace _18_ProblemNo_3427
{
    /// <summary>
    /// https://leetcode.com/problems/sum-of-variable-length-subarrays/submissions/1851896392/?envType=problem-list-v2&envId=prefix-sum
    /// TIME, SPACE : O(n)
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            ISolution solution = new Solution();
            Solution solution1 = new Solution();
            List<ISolution> solutions = new List<ISolution>();
            solution.SubarraySum(new int[] { 3, 1, 1, 2 });
            ///// DEPENDENCY INJECTIOn and pass as aruguments

        }
    }

    public class Solution : ISolution
    {
        public int SubarraySum(int[] nums)
        {
            int totalResult = 0;
            int[] preFixArray = this.BuildPrefixSumArray(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                int start = Math.Max(0, i - nums[i]);

                if (start - 1 >= 0)
                {
                    ////totalResult += preFixArray[i] - preFixArray[i - 2];
                    totalResult += preFixArray[i] - preFixArray[start - 1];
                }
                else
                {
                    totalResult += preFixArray[i];
                }
            }

            return totalResult;
        }

        private int[] BuildPrefixSumArray(int[] nums)
        {
            int[] prefixArrayResult = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++) 
            {
                if(i - 1 >= 0)
                {
                    prefixArrayResult[i] = nums[i] + prefixArrayResult[i - 1];
                }
                else
                {
                    prefixArrayResult[i] = nums[i];
                }
                 
            }

            return prefixArrayResult;
        }
    }
}
