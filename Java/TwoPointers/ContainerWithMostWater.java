package TwoPointers;

public class ContainerWithMostWater {
    // Leetcode 11: https://leetcode.com/problems/container-with-most-water/description/
    // Submission Detail: https://leetcode.com/problems/container-with-most-water/submissions/1622463007

    //Input: height = [1,8,6,2,5,4,8,3,7]
    //Output: 49

    // Tx = O(n)
    // Sx = O(1)
    public int maxArea(int[] height) {
        int maxArea = 0, currentArea, left = 0, right = height.length-1;

        while(left < right) {
            int leftHeight = height[left];
            int rightHeight = height[right];
            currentArea = Math.min(leftHeight, rightHeight) * (right - left);
            maxArea = Math.max(currentArea, maxArea);

            if(leftHeight < rightHeight) {
                left++;
            } else {
                right--;
            }
        }

        return maxArea;
    }
}