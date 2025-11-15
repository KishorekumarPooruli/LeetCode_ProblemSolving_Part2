namespace _12_ProblemNo_345
{
    /// <summary>
    /// https://leetcode.com/problems/reverse-vowels-of-a-string
    /// Time/Space: O(n) 
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string result = solution.ReverseVowels("leetcode");
        }
    }

    public class Solution
    {
        public string ReverseVowels(string s)
        {
            //// Since string is immutable we can't swap the char in there index. So we use STRINGBUILDER or char[] Array
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(s);
            int leftPointer = 0;
            int rightPointer = s.Length - 1;
            HashSet<char> vowels = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            while (leftPointer < rightPointer) 
            {
                bool isleftPointerVowel = vowels.Contains(stringBuilder[leftPointer]);
                bool isRightPointerVowel = vowels.Contains(stringBuilder[rightPointer]);
                //// BELOW PERFORMS a LINEAR SEARCH/ SEQUENCE SEARCH compares each element. If you use HASH SET directly that element hash alone is compared. 
                //// bool isleftPointerVowel = vowels.Any(y => y == stringBuilder[leftPointer]);
                //// bool isRightPointerVowel = vowels.Any(y => y == stringBuilder[rightPointer]);
                //// char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
                //// bool isleftPointerVowel = vowels.Contains(stringBuilder[leftPointer]);
                //// bool isRightPointerVowel = vowels.Contains(stringBuilder[rightPointer]);
                if (!isRightPointerVowel)
                {
                    rightPointer--;
                }
                else if (!isleftPointerVowel)
                {
                    leftPointer++;
                }
                else
                {
                    char tempValue = stringBuilder[leftPointer];
                    stringBuilder[leftPointer] = stringBuilder[rightPointer];
                    stringBuilder[rightPointer] = tempValue;
                    leftPointer++;
                    rightPointer--;
                }                
            }

            return stringBuilder.ToString(); ///// Or Instead of String Builder you can use char[] value = s.ToArray();
        }
    }
}
