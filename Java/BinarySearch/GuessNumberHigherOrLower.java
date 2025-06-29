package BinarySearch;

public class GuessNumberHigherOrLower {
    // Leetcode 374: https://leetcode.com/problems/guess-number-higher-or-lower/description/
    // Submission Detail: https://leetcode.com/problems/guess-number-higher-or-lower/submissions/1679825803

    //Input: n = 10, pick = 6
    //Output: 6
    //Example 2:

    //Input: n = 1, pick = 1
    //Output: 1
    //Example 3:

    //Input: n = 2, pick = 1
    //Output: 1

    public int guessNumber(int n) {
        int low=0, high=n;

        while(low <= high) {
            int mid = low + (high-low)/2;
            int guessResult = guess(mid);   // guess is an inbuilt API

            if(guessResult == -1) {
                high = mid-1;
            } else if(guessResult == 1) {
                low = mid+1;
            } else if(guessResult == 0) {
                return mid;
            }
        }

        return -1;
    }
}
