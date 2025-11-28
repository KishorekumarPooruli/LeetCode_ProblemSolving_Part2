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
            solution.LargestAltitudeOptimal(new int[] { -4, -3, -2, -1, 4, 3, 2 });
        }
    }

    public class Solution
    {
        public int LargestAltitude(int[] gain)
        {
            //// TRADITIONAL PREFIX SUM but uses extra space
            int maxSumValueTrack = 0;
            int[] resultArray = new int[gain.Length + 1];
            resultArray[gain.Length] = 0;
            for (int i = 0; i < gain.Length; i++)
            {
                maxSumValueTrack = maxSumValueTrack + gain[i];
                resultArray[i] = maxSumValueTrack + gain[i];
                if (resultArray[i] > maxSumValueTrack)
                {
                    maxSumValueTrack = resultArray[i];
                }
            }

            return maxSumValueTrack;
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
