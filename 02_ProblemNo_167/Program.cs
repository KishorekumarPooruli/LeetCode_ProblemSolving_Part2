namespace _02_ProblemNo_167
{
    /// <summary>
    /// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/description/
    /// TIMECOMPLEX: O(N)
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            Solution twoSum = new Solution();
            int[] input = new int[] { 2, 7, 11, 15 };
            int[] result = twoSum.TwoSumProblem(input, 9);
        }
    }

    public class Solution
    {
        public int[] TwoSumProblem(int[] inputArray, int target)
        {
            int[] result = new int[] {};
            int leftPointer = 0;
            int rightPointer = inputArray.Length - 1;
            while (leftPointer < rightPointer)
            {
                int total = inputArray[leftPointer] + inputArray[rightPointer];
                if (total == target)
                {
                    result =  new int[] { leftPointer + 1, rightPointer + 1};
                    break;
                }
                else if (total > target)
                {
                    //// if the Total is Greater than TARGET move the RIGHT pointer forward
                    rightPointer--;
                }
                else
                {
                    //// if the Total is Lesser than TARGET move the LEFT pointer forward
                    leftPointer++;
                }
            }

            return result;
        }
    }
}