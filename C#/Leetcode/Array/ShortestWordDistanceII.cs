using System.Collections.Generic;

namespace LeetcodeSolutions.Array
{
    // Given a length list of names, find the minimum distance between given 2 names optimizing for find.

    // The given list has many names.
    // The names to search exist in the list.

    // Leetcode 244 - https://leetcode.com/problems/shortest-word-distance-ii
    // Question - https://www.programcreek.com/2014/07/leetcode-shortest-word-distance-ii-java/

    public class ShortestWordDistanceII
    {
        public ShortestWordDistanceII(IList<string> names)
        {
            PreProcess(names);
        }

        readonly IDictionary<string, IList<int>> nameIndexes = new Dictionary<string, IList<int>>();

        private void PreProcess(IList<string> names)
        {
            for(int i=0; i<names.Count; i++)
            {
                var name = names[i];

                if (!nameIndexes.ContainsKey(name))
                    nameIndexes[name] = new List<int>();

                nameIndexes[name].Add(i);
            }
        }

        // Tx = O(m + n) {m: Occurrences of name1, n: Occurrences of name2}
        // Sx = O(1)

        public int MinDistance(string name1, string name2)
        {
            IList<int> name1Indexes = nameIndexes[name1];
            IList<int> name2Indexes = nameIndexes[name2];

            int index1 = 0, index2 = 0, minDistance = int.MaxValue;

            while(index1 < name1Indexes.Count && index2 < name2Indexes.Count)
            {
                minDistance = System.Math.Min(minDistance, 
                                System.Math.Abs(name1Indexes[index1] - name2Indexes[index2]));

                if (index1 < index2)
                    index1++;
                else
                    index2++;
            }

            return minDistance;
        }
    }
}
