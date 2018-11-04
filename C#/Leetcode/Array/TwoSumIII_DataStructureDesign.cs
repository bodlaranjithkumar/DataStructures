using System.Collections.Generic;

namespace LeetcodeSolutions.Array
{
    // Leetcode 170 - https://leetcode.com/problems/two-sum-iii-data-structure-design/
    // Submission Detail - https://leetcode.com/submissions/detail/182406463/

    public class TwoSumIII_DataStructureDesign
    {
        // Solution 1: Optimizing for add

        IDictionary<int, int> numberFrequency;

        /** Initialize your data structure here. */
        public TwoSumIII_DataStructureDesign()
        {
            numberFrequency = new Dictionary<int, int>();
        }

        // Tx = O(1)
        // Sx = O(n)
        public void Add(int number)
        {
            if (!numberFrequency.ContainsKey(number))
                numberFrequency.Add(number, 1);
            else
                numberFrequency[number] = 2;    // Since the problem is two sum. Doesn't matter if there are > 2 duplicates.
        }

        // Tx = O(n)
        public bool Find(int value)
        {
            foreach (int number in numberFrequency.Keys)
            {
                int diff = value - number;

                if (numberFrequency.ContainsKey(diff))
                    if (number != diff || numberFrequency[diff] == 2)
                        return true;
            }

            return false;
        }



        // Solution 2: Optimizing for Find.
        // Time Limit exceeded for huge inputs.

        HashSet<int> numberSet;
        HashSet<int> sumSet;

        /** Initialize your data structure here. */
        //public TwoSumIII_DataStructureDesign()
        //{
        //    numberSet = new HashSet<int>();
        //    sumSet = new HashSet<int>();
        //}

        // Tx = O(n)
        // Sx = O(n)
        public void Add1(int number)
        {
            if (!numberSet.Contains(number))
                numberSet.Add(number);
            else
                sumSet.Add(number * 2); // If duplicate number, add twice the number.

            if (numberSet.Count > 1)
                foreach (int num in numberSet)
                    if (num != number)
                        sumSet.Add(num + number);
        }

        // Tx = O(1)
        public bool Find1(int value)
        {
            return sumSet.Contains(value);
        }
    }
}
