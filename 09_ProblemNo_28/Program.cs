namespace _09_ProblemNo_28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int result = solution.StrStr("sadbutsad", "sad");
        }
    }

    public class Solution
    {
        public int StrStr(string haystack, string needle)
        {
            int firstPointer = 0;
            while (firstPointer < haystack.Length && haystack.Length >= needle.Length)
            {
                if (haystack[firstPointer] == needle[0] && firstPointer + needle.Length <= haystack.Length)
                {
                    string subString = haystack.Substring(firstPointer, needle.Length);
                    if (needle.Equals(subString))
                    {
                        return firstPointer;
                    }
                }

                firstPointer++;
            }


            return -1;
        }

        public int StrStrOptimal(string haystack, string needle)
        {
            int n = haystack.Length, m = needle.Length;
            if (m == 0) return 0;
            if (m > n) return -1;

            int i = 0;         // start in haystack
            int j = 0;         // index in needle

            while (i <= n - m)
            {
                // grow match while equal
                while (j < m && haystack[i + j] == needle[j]) 
                {
                    j++;
                }

                if (j == m) 
                {
                    return i;   // full match at i
                } 

                i++;    // move start forward
                j = 0;  // reset needle index
            }
            return -1;
        }

    }
}
