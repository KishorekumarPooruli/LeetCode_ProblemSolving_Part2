namespace _15_ProblemNo_80
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] input = new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 };
            solution.RemoveDuplicates(input);
        }
    }

    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            int rightPointer = 1;
            for (int leftPointer = 0; leftPointer < nums.Length; leftPointer++)
            {
                if(rightPointer < nums.Length)
                {
                    if (nums[leftPointer] == nums[rightPointer])
                    {
                        rightPointer++;
                    }
                    else
                    {
                        int temp = nums[leftPointer];
                        nums[leftPointer] = nums[rightPointer];
                        nums[rightPointer] = temp;
                        rightPointer++;
                    }
                }                
            }

            return nums.Length;
        }
    }
}
