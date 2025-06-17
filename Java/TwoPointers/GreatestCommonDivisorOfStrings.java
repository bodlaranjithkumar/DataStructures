package TwoPointers;

public class GreatestCommonDivisorOfStrings {
    // Leetcode 1071: https://leetcode.com/problems/greatest-common-divisor-of-strings/description/
    // Submission Detail: https://leetcode.com/problems/greatest-common-divisor-of-strings/submissions/1667665183

    //Input: str1 = "ABCABC", str2 = "ABC"
    //Output: "ABC"

    //Input: str1 = "ABABAB", str2 = "ABAB"
    //Output: "AB"

    //Input: str1 = "LEET", str2 = "CODE"
    //Output: ""

    public String gcdOfStrings(String str1, String str2) {
        // If 2 strings when combined in difference sequences are not equal, they do not have a GCD
        if(!(str1+str2).equals(str2+str1))
            return "";

        // If there is a GCD, it the characters of either string with end index of length.
        int length = GCDofNums(str1.length(), str2.length());
        return str1.substring(0, length);
    }

    // Euclidean Algorithm to find the GCD of two numbers
    //Start with a = 48 and b = 18.
    //Compute a % b:
    //48 % 18 = 12.
    //Update a = 18 and b = 12.

    //Compute a % b:
    //18 % 12 = 6.
    //Update a = 12 and b = 6.

    //Compute a % b:
    //12 % 6 = 0.
    //Update a = 6 and b = 0.
    //Since b = 0, the GCD is a = 6.

    private int GCDofNums(int num1, int num2) {
        while(num2 != 0) {
            int temp = num2;
            num2 = num1 % num2;
            num1 = temp;
        }

        return num1;
    }
}
