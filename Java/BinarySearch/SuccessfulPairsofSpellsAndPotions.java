package BinarySearch;

import java.util.Arrays;

public class SuccessfulPairsofSpellsAndPotions {
    // Leetcode 2300: https://leetcode.com/problems/successful-pairs-of-spells-and-potions/description/
    // Submission Detail: https://leetcode.com/problems/successful-pairs-of-spells-and-potions/submissions/1680589049

    //Input: spells = [5,1,3], potions = [1,2,3,4,5], success = 7
    //Output: [4,0,3]
    //Explanation:
    //        - 0th spell: 5 * [1,2,3,4,5] = [5,10,15,20,25]. 4 pairs are successful.
    //- 1st spell: 1 * [1,2,3,4,5] = [1,2,3,4,5]. 0 pairs are successful.
    //- 2nd spell: 3 * [1,2,3,4,5] = [3,6,9,12,15]. 3 pairs are successful.
    //        Thus, [4,0,3] is returned.

    //Input: spells = [3,1,2], potions = [8,5,8], success = 16
    //Output: [2,0,2]
    //Explanation:
    //        - 0th spell: 3 * [8,5,8] = [24,15,24]. 2 pairs are successful.
    //- 1st spell: 1 * [8,5,8] = [8,5,8]. 0 pairs are successful.
    //- 2nd spell: 2 * [8,5,8] = [16,10,16]. 2 pairs are successful.
    //        Thus, [2,0,2] is returned.

    public int[] successfulPairs(int[] spells, int[] potions, long success) {
        Arrays.sort(potions);
        int[] result = new int[spells.length];

        for(int index = 0; index<spells.length; index++) {
            int low = 0, high = potions.length-1;
            while(low <= high) {
                int mid = low + (high-low)/2;
                long productStrength = (long)spells[index] * potions[mid];

                if(productStrength >= success)
                    high = mid-1;
                else
                    low = mid+1;
            }
            result[index] = potions.length - (high+1);
        }

        return result;
    }
}
