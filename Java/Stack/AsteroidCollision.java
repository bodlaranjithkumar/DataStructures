package Stack;

import java.util.Stack;

public class AsteroidCollision {
    // Leetcode 735: https://leetcode.com/problems/asteroid-collision/description/
    // Submission Detail: https://leetcode.com/problems/asteroid-collision/submissions/1672912846

    //Input: asteroids = [5,10,-5]
    //Output: [5,10]
    //Explanation: The 10 and -5 collide resulting in 10. The 5 and 10 never collide.

    //Input: asteroids = [8,-8]
    //Output: []
    //Explanation: The 8 and -8 collide exploding each other.

    //Input: asteroids = [10,2,-5]
    //Output: [10]
    //Explanation: The 2 and -5 collide resulting in -5. The 10 and -5 collide resulting in 10.

    public int[] asteroidCollision(int[] asteroids) {
        Stack<Integer> nums = new Stack<>();

        for(int asteroid:asteroids) {
            if(asteroid >= 0) {
                nums.push(asteroid);
            } else {
                int absAsteroid = Math.abs(asteroid);

                while(!nums.isEmpty() && nums.peek() > 0 && absAsteroid > nums.peek()) {
                    nums.pop();
                }

                if(nums.isEmpty()  || nums.peek() < 0) {
                    nums.push(asteroid);
                }

                if(!nums.isEmpty() && absAsteroid == nums.peek()) {
                    nums.pop();
                }
            }
        }

        int[] result = new int[nums.size()];

        for(int index=result.length-1; index>=0; index--) {
            result[index] = nums.pop();
        }

        return result;
    }
}
