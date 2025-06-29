package BinarySearch;

public class FindPeakElement {
    // Leetcode 162: https://leetcode.com/problems/find-peak-element/description/
    // Submission Detail: https://leetcode.com/problems/find-peak-element/submissions/1680681522

    //Input: nums = [1,2,3,1]
    //Output: 2
    //Explanation: 3 is a peak element and your function should return the index number 2.

    //Input: nums = [1,2,1,3,5,6,4]
    //Output: 5
    //Explanation: Your function can return either index number 1 where the peak element is 2, or index number 5 where the peak element is 6.

    // Tx = O(log n)
    // Sx = O(1)
    // The question is to find any peak and not necessarily the global peak.
    public int findPeakElement(int[] nums) {
        int low = 0, high = nums.length-1;

        while(low < high) {
            int mid = low + (high-low)/2;

            if(nums[mid] < nums[mid+1])
                low = mid+1;
            else
                high = mid;
        }

        return low;
    }
}
