
namespace _10_ProblemNo_125
{
    /// <summary>
    /// https://leetcode.com/problems/valid-palindrome  
    /// Two Pointer -Approach 2 
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            bool result = solution.IsPalindromeOptimal(" ");
        }
    }
    public class Solution
    {
        //// O(n) time, O(n) space - allocates new string and intermediate collections.
        public bool IsPalindrome(string s)
        {
            char[] input = s.ToArray(); //// STRING TO CHAR ARRAY
            string text = string.Concat(input.Where(char.IsLetterOrDigit)).ToLower(); //// EXTRA SPACE.
            int downPointer = text.Length - 1;
            bool isPalindrome = true;
            for (int topPointer = 0; topPointer < text.Length; topPointer++)
            {
                if (text[topPointer] == text[downPointer])
                {
                    downPointer--;
                    isPalindrome = true;
                    continue;
                }
                else
                {
                    isPalindrome = false;
                    break;
                }
            }

            return isPalindrome;
        }

        //// O(n) time, O(1) space
        public bool IsPalindromeOptimal(string s)
        {
            int downPointer = s.Length - 1;
            int topPointer = 0;
            bool isPalindrome = true;
            while (topPointer < downPointer)
            {
                char topPointerValue = s[topPointer];
                char downPointerValue = s[downPointer];
                if (!char.IsLetterOrDigit(topPointerValue))
                {
                    topPointer++;
                }
                else if (!char.IsLetterOrDigit(downPointerValue))
                {
                    downPointer--;
                }
                else
                {
                    if (char.ToLower(topPointerValue) == char.ToLower(downPointerValue))
                    {
                        downPointer--;
                        topPointer++;
                        isPalindrome = true;
                    }
                    else
                    {
                        return isPalindrome = false;                        
                    }
                }
            }

            return isPalindrome;
        }
    }
}