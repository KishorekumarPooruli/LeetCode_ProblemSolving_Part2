using System.ComponentModel;

namespace _06_ProblemNo_2269
{
    /// <summary>
    /// https://leetcode.com/problems/find-the-k-beauty-of-a-number/description 
    //// Fixed Size Sliding Window  
    //// Time Complexity for Both Programs are O(n × k), O(n)---FAIR
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int kBeauty = solution.DivisorSubstringsAIGenerated(240, 2);
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
                //// substring gets converted to Char[] and then to string to int
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

        public int DivisorSubstringsAIGenerated(int num, int k)
        {
            int kBeauty = 0;
            string input = Convert.ToString(num);

            for (int i = 0; i <= input.Length - k; i++)
            {
                string window = input.Substring(i, k); //// i same as Skip (i). k same as Take(k)
                int divisor = int.Parse(window);

                if (divisor != 0 && num % divisor == 0)
                {
                    kBeauty++;
                }
            }

            return kBeauty;
        }

    }
}
