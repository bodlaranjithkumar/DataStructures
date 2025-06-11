public class Solution {
    // Leetcode 11 - https://leetcode.com/problems/container-with-most-water/
    // Submission Detail - https://leetcode.com/problems/container-with-most-water/submissions/1522939402

    // Uses two pointer approach to find the maximum area. The area is calculated by finding the minimum height between the two pointers
    // and then multiplying it with the width between the two pointers. The width is calculated by subtracting the right pointer from the left pointer.
    // The maximum area is then calculated by taking the maximum of the current area and the previous maximum area.
    // The left pointer is moved to the right if the height at the left pointer is less than the height at the right pointer, else the right pointer is moved to the left.
    

    // Time Complexity: O(n)
    // Space Complexity: O(1)
    public int MaxArea(int[] heights) {
        int maxArea = 0;
        int left = 0;
        int right = heights.Length-1;

        while(left < right) {
            int width = right - left;
            int height = System.Math.Min(heights[left], heights[right]);
            int area = width * height;
            maxArea = System.Math.Max(area, maxArea);

            if(heights[left] < heights[right])
                left++;
            else
                right--;
        }

        return maxArea;
    }
}