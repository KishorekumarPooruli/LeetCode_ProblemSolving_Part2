namespace _11_ProblemNo_344
{
    /// <summary>
    /// https://leetcode.com/problems/reverse-string
    /// Two Pointer Concept, Time and Space Complexity is O(1)
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            solution.ReverseString(new char[] { 'H', 'a','n', 'n', 'a', 'h' });
        }
    }

    public class Solution
    {
        public void ReverseString(char[] s)
        {
            int rightPointer = s.Length - 1;
            for (int leftPointer = 0; leftPointer < s.Length/2; leftPointer++) 
            {
                char temp = s[leftPointer];
                s[leftPointer] = s[rightPointer];
                s[rightPointer] = temp;
                rightPointer--;
            }
        }

        public void ReverseStringGPT(char[] s)
        {
            //// Still internally it uses two pointer approach so both method has o(n)
            Array.Reverse(s);
        }
    }
}
