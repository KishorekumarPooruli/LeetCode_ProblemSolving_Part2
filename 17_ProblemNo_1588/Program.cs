namespace _17_ProblemNo_1588
{
    /// <summary>
    /// https://leetcode.com/problems/sum-of-all-odd-length-subarrays
    /// TIME COMPLEX:  O(n²) , SPACE COMPLEX: O(n)
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
           Solution solution = new Solution();
            int result = solution.SumOddLengthSubarrays(new int[] { 10, 11, 12 });
        }
    }

    public class Solution
    {
        public int SumOddLengthSubarrays(int[] arr)
        {
            int totalSum = 0;
            int[] prefixSum = this.BuildPrefixArray(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                for(int j = i; j < arr.Length; j += 2)
                {
                    if (i - 1 < 0)
                    {
                        totalSum += prefixSum[j];
                    }
                    else
                    {
                        //// CHECKING USING PREFIX SUM LOGIC
                        totalSum += prefixSum[j] - prefixSum[i - 1];
                    }
                }
            }

            return totalSum;
        }

        private int[] BuildPrefixArray(int[] arr)
        {
            int[] prefixSum = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                if(i - 1 >= 0)
                {
                    prefixSum[i] = prefixSum[i - 1] + arr[i];
                }
                else
                {
                    prefixSum[i] = arr[i];
                }
            }

            return prefixSum;
        }
    }
}
