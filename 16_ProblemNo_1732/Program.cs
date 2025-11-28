namespace _16_ProblemNo_1732
{
    /// <summary>
    /// https://leetcode.com/problems/find-the-highest-altitude/description
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int result = solution.LargestAltitudeExtraSpace(new int[] { -5, 1, 5, 0, -7 });
        }
    }

    public class Solution
    {
        public int LargestAltitudeExtraSpace(int[] gain)
        {
            //// TRADITIONAL PREFIX SUM but uses extra space
            int maxSumValueTrack = 0;
            int[] resultArray = new int[gain.Length + 1];
            resultArray[gain.Length] = 0;
            for (int i = 0; i < gain.Length; i++)
            {
                maxSumValueTrack = maxSumValueTrack + gain[i];
                resultArray[i] = maxSumValueTrack;
            }

            return resultArray.Max();
        }

        public int LargestAltitudeOptimal(int[] gain)
        {
            int maxSumValueTrack = 0;
            for (int i = 0; i < gain.Length; i++)
            {
                if (i > 0)
                {
                    gain[i] = gain[i] + gain[i - 1];   // in-place prefix sum
                }

                if (gain[i] > maxSumValueTrack)
                {
                    maxSumValueTrack = gain[i];
                }
            }

            return maxSumValueTrack;
        }
    }
}
