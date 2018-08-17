using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Array
{
    // Leetcode 380
    // Submission Detail: https://leetcode.com/submissions/detail/169974164/

    public class InsertDeleteGetRandom
    {
        public class RandomizedSet
        {
            // Idea: if getrandom() function is not needed, a straigh forward solution is to use HashSet to 
            //       implement insert and remove in O(1) time. Since getrandom() func needs to return a value 
            //       and hashset doesn't return a value at a random index, we need to store the value ina a list 
            //       and value, list's index in a dictionary.
            //  The tricky part is Remove function implementation. If the value to remove is not at last index in 
            //  the list, we can simply remove it but if getrandom function returns this removed index, there won't
            //  be any value at that index and throws index out of range exception. So swap this value with the 
            //  value in last index and remove the value at last index and update the value at the last index in 
            //  dictionary with the new location.

            IDictionary<int, int> valuesLocation;
            IList<int> values;
            Random rand;

            /** Initialize your data structure here. */
            public RandomizedSet()
            {
                valuesLocation = new Dictionary<int, int>();
                values = new List<int>();
                rand = new Random();
            }

            /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
            public bool Insert(int val)
            {
                if (valuesLocation.ContainsKey(val))
                    return false;

                valuesLocation.Add(val, values.Count);
                values.Add(val);

                return true;
            }

            /** Removes a value from the set. Returns true if the set contained the specified element. */
            public bool Remove(int val)
            {
                if (!valuesLocation.ContainsKey(val))
                    return false;

                int valLocation = valuesLocation[val];
                int lastIndex = values.Count - 1;

                if (valLocation != lastIndex)
                {
                    int valAtLastIndex = values[lastIndex];

                    values[valLocation] = valAtLastIndex;
                    valuesLocation[valAtLastIndex] = valLocation;
                    //values[lastIndex] = val;          // THis is not needed since it is going to be removed in the next step anyways.
                }

                values.RemoveAt(values.Count - 1);
                valuesLocation.Remove(val);

                return true;
            }

            /** Get a random element from the set. */
            public int GetRandom()
            {
                // https://docs.microsoft.com/en-us/dotnet/api/system.random.next?redirectedfrom=MSDN&view=netframework-4.7.2#System_Random_Next_System_Int32_System_Int32_
                int randValuesIndex = rand.Next(0, values.Count);

                return values[randValuesIndex];
            }
        }
    }
}
