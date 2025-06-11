package BinarySearch;

public class KokoEatingBananas {
  // Leetcode 875: https://leetcode.com/problems/koko-eating-bananas/description/
  // Submission Detail: https://leetcode.com/problems/koko-eating-bananas/submissions/1638917516

  //Input: piles = [3,6,7,11], h = 8
  //Output: 4

  //Input: piles = [30,11,23,4,20], h = 5
  //Output: 30

  //Input: piles = [30,11,23,4,20], h = 6
  //Output: 23

  //Input: apples = [3, 6, 7], h = 8
  //Output: 3

  // Tx = O(nlogk)
  // Sx = O(1)
  public int minEatingSpeed(int[] piles, int h) {
    // Step 1: Calculate the maximum of the piles. This is our search range.
    int max = 0;
    for(int pile : piles)
      max = Math.max(max, pile);

    // Step 2: Use binary search on max piles till we reach the min
    int start = 1, end = max, minSpeed = max;

    while(start <= end) {
      int mid = start + (end - start) / 2;
      int harvestHours = this.maxHarvestHours(piles, mid);

      if(harvestHours <= h) {
        minSpeed = Math.min(mid, minSpeed);
        end = mid-1;
      } else {
        start = mid+1;
      }
    }

    return minSpeed;
  }

  private int maxHarvestHours(int[] piles, int harvestRate) {
    int sum = 0;

    for(int pile : piles)
      sum += Math.ceil((double)pile / harvestRate);

    return sum;
  }
}
