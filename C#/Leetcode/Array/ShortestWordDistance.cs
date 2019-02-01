using System.Collections.Generic;

namespace LeetcodeSolutions.Array
{
    // If names exist - return the shortest path
    // If either of the names doesn't exist - return -1
    // If both the names are equal - return 0
    // The list of names is initialized and non-empty.
    // Case-sensitive 

    // Input List: A, B, C, A, D, T, F, G, H, T, A
    // A, T => 1
    // A, A => 0
    // A, Z => -1

    // Leetcode 243 - https://leetcode.com/problems/shortest-word-distance
    // Question - https://www.programcreek.com/2014/08/leetcode-shortest-word-distance-java/

    public class ShortestWordDistance
    {
        // Tx = O(n) {n: Count of names list}
        // Sx = O(1)
        public int MinDistance(IList<string> names, string name1, string name2)
        {
            int length = names.Count;
            int name1LatestIndex = length, name2LatestIndex = length, minDistance = length;

            for(int i=0; i<length; i++)
            {
                string current = names[0];

                if (current.CompareTo(name1) == 0)
                    name1LatestIndex = i;

                // Not using else if covers the case where both the names are the same.
                if (current.CompareTo(name2) == 0)
                    name2LatestIndex = i;

                if (name1LatestIndex != length && name2LatestIndex != length)
                    minDistance = System.Math.Min(minDistance, System.Math.Abs(name1LatestIndex - name2LatestIndex));
            }

            if (name1LatestIndex == length || name2LatestIndex == length)
                return -1;

            return minDistance;
        }
    }
}
