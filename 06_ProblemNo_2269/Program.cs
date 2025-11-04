using System.ComponentModel;

namespace _06_ProblemNo_2269
{
    /// <summary>
    /// https://leetcode.com/problems/find-the-k-beauty-of-a-number/description 
    //// Fixed Size Sliding Window  
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int kBeauty = solution.DivisorSubstrings(430043, 2);
        }
    }

    public class Solution
    {
        public int DivisorSubstrings(int num, int k)
        {
            int kBeauty = 0;
            string input = Convert.ToString(num);

            for (int i = 0; i < input.Length; i++) 
            {
                char[] window = input.Skip(i).Take(k).ToArray();
                if (window.Length == k)
                {
                    int divisor = int.Parse(new string(window));
                    int remainder = divisor != 0 ? num % divisor : 1; 
                    if (remainder == 0)
                    {
                        kBeauty++;
                    }
                }
                else
                {
                    break;
                }
            }
            
            return kBeauty;
        }
    }
}
