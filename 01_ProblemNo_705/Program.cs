namespace _01_ProblemNo_705
{
    /// <summary>
    /// https://leetcode.com/problems/design-hashset/description/
    /// </summary>
    internal class Solution
    {
        static void Main(string[] args)
        {
            MyHashSet  myHashSet = new MyHashSet();
            myHashSet.Add(1000000);
            myHashSet.Add(2);
            bool param_3 = myHashSet.Contains(1000000);
            myHashSet.Remove(2);
            param_3 = myHashSet.Contains(2);
        }
    }

    public class MyHashSet
    {
        bool[] hashMapDataSet = new bool[1000000 + 1]; //// ARRAY contains{0 - 1000000}

        public void Add(int key)
        {
            //// Since index is used to assign the value checking if the index is inside the bounds
            if (key < hashMapDataSet.Length) 
            {
                hashMapDataSet[key] = true;
            }
        }

        public void Remove(int key)
        {
            if (key < hashMapDataSet.Length)
            {
                hashMapDataSet[key] = false;
            }
        }

        public bool Contains(int key)
        {
            //// here first or firstorDefault or contains
            //// is not used since it is a loop that iterates and find the element. Instead of that directly used via index
            if (key < hashMapDataSet.Length)
            {
                return hashMapDataSet[key];
            }

            return false;
        }
    }
}
