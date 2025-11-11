namespace _08_ProblemNo_3
{
    /// <summary>
    /// https://leetcode.com/problems/longest-substring-without-repeating-characters
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int result = solution.LengthOfLongestSubstringOptimal("abcabcbb");
        }
    }

    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            //// Brute Force Approach
            int lengthofLongestSubstring = 0;
            for (int upperPointer = 0; upperPointer < s.Length; upperPointer++) 
            {
                string subString = s[upperPointer].ToString();
                for (int lowerPointer = upperPointer + 1; lowerPointer < s.Length; lowerPointer++)
                {
                    if(!subString.Contains(s[lowerPointer]))
                    {
                        subString = string.Concat(subString, s[lowerPointer]);
                    }
                    else
                    {
                       break;
                    }
                }

                lengthofLongestSubstring = Math.Max(subString.Length, lengthofLongestSubstring);
            }

            return lengthofLongestSubstring;
        }

        public int LengthOfLongestSubstringOptimal(string s)
        {
            //// Sliding Window
            Dictionary<char, int> charIndexMap = new Dictionary<char, int>();
            int maxLength = 0;
            int left = 0;

            for (int right = 0; right < s.Length; right++)
            {
                char currentChar = s[right];

                // If the character is already in the window, move the left pointer
                if (charIndexMap.ContainsKey(currentChar) && charIndexMap[currentChar] >= left)
                {
                    left = charIndexMap[currentChar] + 1;
                }

                // Update or add the index of the current character
                charIndexMap[currentChar] = right;

                // Calculate the maximum length of current valid window
                maxLength = Math.Max(maxLength, right - left + 1);
            }

            return maxLength;
        }
    }
}
