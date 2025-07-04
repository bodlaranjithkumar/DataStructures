package Arrays;

import java.util.ArrayList;
import java.util.List;

public class KidsWithGreatestNumberofCandies {
    // Leetcode 1431: https://leetcode.com/problems/kids-with-the-greatest-number-of-candies/?envType=study-plan-v2&envId=leetcode-75
    // Submission Detail: https://leetcode.com/problems/kids-with-the-greatest-number-of-candies/submissions/1667669780

    //Input: candies = [2,3,5,1,3], extraCandies = 3
    //Output: [true,true,true,false,true]
    //Explanation: If you give all extraCandies to:
    //        - Kid 1, they will have 2 + 3 = 5 candies, which is the greatest among the kids.
    //- Kid 2, they will have 3 + 3 = 6 candies, which is the greatest among the kids.
    //- Kid 3, they will have 5 + 3 = 8 candies, which is the greatest among the kids.
    //- Kid 4, they will have 1 + 3 = 4 candies, which is not the greatest among the kids.
    //        - Kid 5, they will have 3 + 3 = 6 candies, which is the greatest among the kids.

    //Input: candies = [4,2,1,1,2], extraCandies = 1
    //Output: [true,false,false,false,false]
    //Explanation: There is only 1 extra candy.
    //Kid 1 will always have the greatest number of candies, even if a different kid is given the extra candy.

    //Input: candies = [12,1,12], extraCandies = 10
    //Output: [true,false,true]

    public List<Boolean> kidsWithCandies(int[] candies, int extraCandies) {
        List<Boolean> kidsCandies = new ArrayList<>(candies.length);
        int maxCandyCountWithAKid = 0;

        // Step 1: Find Max Candy
        for(int candy: candies) {
            maxCandyCountWithAKid = Math.max(maxCandyCountWithAKid, candy);
        }

        // Step2: Check if after giving extraCandies to the current kid, they have the highest.
        for(int index=0; index<candies.length; index++) {
            int candy = candies[index];
            boolean haveHighest = (candy+extraCandies) >= maxCandyCountWithAKid ? true : false;
            kidsCandies.add(index, haveHighest);
        }

        return kidsCandies;
    }
}
