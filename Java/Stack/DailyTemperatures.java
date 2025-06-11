package Stack;

import java.util.Stack;

public class DailyTemperatures {
    // Leetcode 739: https://leetcode.com/problems/daily-temperatures/description/
    // Submission Details: https://leetcode.com/problems/daily-temperatures/submissions/1660198096

    //Input: temperatures = [73,74,75,71,69,72,76,73]
    //Output: [1,1,4,2,1,1,0,0]

    //Input: temperatures = [30,40,50,60]
    //Output: [1,1,1,0]

    //Input: temperatures = [30,60,90]
    //Output: [1,1,0]

    // Tx = O(n)
    // Sx = O(n)
    public int[] dailyTemperatures(int[] temperatures) {
        int[] result = new int[temperatures.length];

        Stack<Integer> monotonicallyDecreasingTemperaturesIndices = new Stack<>();

        for(int currentIndex = 0; currentIndex < temperatures.length; currentIndex++) {
            int currentTemperature = temperatures[currentIndex];

            while(!monotonicallyDecreasingTemperaturesIndices.isEmpty() && currentTemperature > temperatures[monotonicallyDecreasingTemperaturesIndices.peek()]) {
                int top = monotonicallyDecreasingTemperaturesIndices.pop();
                result[top] = currentIndex-top;
            }
            monotonicallyDecreasingTemperaturesIndices.push(currentIndex);
        }

        return result;
    }
}
