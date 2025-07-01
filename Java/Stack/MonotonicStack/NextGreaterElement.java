package Stack.MonotonicStack;

import java.util.Stack;

public class NextGreaterElement {

    //    Given an array of integers, find the next greater element for each element in the array.
    //    The next greater element of an element x is the first element to the right of x that is greater than x.
    //    If there is no such element, then the next greater element is -1.
    //    Example Input: [2, 1, 3, 2, 4, 3] Output: [3, 3, 4, 4, -1, -1]

    // Explanation: https://www.hellointerview.com/learn/code/stack/monotonic-stack

    public int[] nextGreaterElement(int[] input) {
        int[] result = new int[input.length];
        for(int i=0; i<result.length; i++)
            result[i] = -1;

        Stack<Integer> montonicallyDecreasingStack = new Stack<>();

        for(int i=0; i<input.length; i++) {
            int curr = input[i];
            while(!montonicallyDecreasingStack.isEmpty() && curr > input[montonicallyDecreasingStack.peek()]) {
                int index = montonicallyDecreasingStack.pop();
                result[index] = curr;
            }
            montonicallyDecreasingStack.push(i);
        }

        return result;
    }

    public int[] nextSmallestElement(int[] input) {
        int[] result = new int[input.length];
        for(int i=0; i<result.length; i++)
            result[i] = -1;

        Stack<Integer> montonicallyIncreasingStack = new Stack<>();

        for(int i=0; i<input.length; i++) {
            int curr = input[i];
            while(!montonicallyIncreasingStack.isEmpty() && curr < input[montonicallyIncreasingStack.peek()]) {
                int index = montonicallyIncreasingStack.pop();
                result[index] = curr;
            }
            montonicallyIncreasingStack.push(i);
        }

        return result;
    }
}
