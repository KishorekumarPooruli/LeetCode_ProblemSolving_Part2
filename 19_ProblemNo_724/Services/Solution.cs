using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_ProblemNo_724.Services
{
    /// <summary>
    /// https://leetcode.com/problems/find-pivot-index/description
    /// Time and Space Complexitiy : O(N)
    /// </summary>
    public sealed class Solution : ISolution
    {
        public int PivotIndex(int[] nums)
        {
            int[] prefixSumArray = this.BuildPrefixSum(nums);
            int i = 0;
            int result = -1;
            while (i < nums.Length)
            {
                int leftSum = i - 1 >=0 ? prefixSumArray[i - 1] : 0;
                int rightSum = prefixSumArray[nums.Length - 1] - prefixSumArray[i];
                if (leftSum == rightSum)
                {
                    result = i;
                    break;
                }
                else
                {
                    i++;
                }
            }

            return result;
        }

        private int[] BuildPrefixSum(int[] nums)
        {
            int[] prefixSumArray = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++) 
            {
                if (i - 1 >= 0)
                {
                    prefixSumArray[i] = nums[i] + prefixSumArray[i - 1];
                }
                else
                {
                    prefixSumArray[i] = nums[i];
                }
            }

            return prefixSumArray;
        }
    }
}
