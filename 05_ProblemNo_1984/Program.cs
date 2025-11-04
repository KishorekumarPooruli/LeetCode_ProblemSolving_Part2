namespace _05_ProblemNo_1984
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] input = new int[] { 87063, 61094, 44530, 21297, 95857, 93551, 9918 };
            solution.MinimumDifference(input, 6);
        }
    }

    public class Solution
    {
        public int MinimumDifference(int[] nums, int k)
        {
            Array.Sort(nums);
            int result = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                int[] subsetWindow = nums.Skip(i).Take(k).ToArray();

                if (subsetWindow.Length < k)
                {
                    break;
                }

                int maxNo = subsetWindow.Max();
                int minNo = subsetWindow.Min();
                int diff = maxNo - minNo;
                result = Math.Min(result, diff);
            }

            return result == int.MaxValue ? 0 : result;
        }
    }
}
