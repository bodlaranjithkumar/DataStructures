public class Solution {

    // Leetcode 611 - Valid Triangle Number
    // Submission Detail - https://leetcode.com/problems/valid-triangle-number/submissions/1530637555

    // In order for a triplet to be valid lengths of a triangle, the sum of any two sides must be greater than the third side. 
    // By sorting the array, we can leverage the two-pointer technique to count all valid triplets in O(n2) time and O(1) space.
    // The key to this question is realizing that if we have 3 numbers, such as 4, 8, 9, arranged from smallest to largest, 
    // and the sum of the two smallest numbers is greater than the largest number, then we have a valid triplet ( 4 + 8 > 9).
    // But not only that, triplets where the smallest number is between 4 and 8 are also valid triplets.

    public int TriangleNumber(int[] numbers) {
        System.Array.Sort(numbers);
        int count = 0;

        for(int i=numbers.Length-1; i > 1; i--) {
            int left = 0;
            int right = i-1;

            while(left < right) {
                if(numbers[left] + numbers[right] > numbers[i]) {
                    count += right - left;
                    right--;
                } else {
                    left++;
                }
            }
        }

        return count;
    }
}