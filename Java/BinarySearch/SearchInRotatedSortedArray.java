package BinarySearch;

public class SearchInRotatedSortedArray {
  // Leetcode 33: https://leetcode.com/problems/search-in-rotated-sorted-array/description/
  // Submission Detail: https://leetcode.com/problems/search-in-rotated-sorted-array/submissions/1640927745
  // Explanation: https://www.hellointerview.com/learn/code/binary-search/search-in-rotated-sorted-array

  //  Input: nums = [4,5,6,7,0,1,2], target = 0
  //  Output: 4
  //
  //  Input: nums = [4,5,6,7,0,1,2], target = 3
  //  Output: -1
  //
  //  Input: nums = [1], target = 0
  //  Output: -1

  //  Input:nums = [8,9,10,12,16,17,1,2,3], target = 3
  //  Output: 8

  // Tx = O(n)
  // Sx = O(1)
  public int search(int[] nums, int target) {
    int left = 0, right = nums.length-1;

    while(left <= right) {
      int mid = left + (right - left)/2;
      if(nums[mid] == target)
        return mid;

      if(nums[left] <= nums[mid]) {
        if(nums[left] <= target && target < nums[mid])
          right = mid-1;
        else
          left = mid+1;
      } else {
        if(nums[mid] < target && target <= nums[right])
          left = mid+1;
        else
          right = mid-1;
      }
    }

    return -1;
  }
}
