package Arrays;

public class CanPlaceFlowers {
    // Leetcode 605: https://leetcode.com/problems/can-place-flowers/
    // Submission Detail: https://leetcode.com/problems/can-place-flowers/submissions/1667683264

    //Input: flowerbed = [1,0,0,0,1], n = 1
    //Output: true

    //Input: flowerbed = [1,0,0,0,1], n = 2
    //Output: false

    //Input: flowerbed = [1], n = 1
    //Output: false

    //Input: flowerbed = [0], n = 1
    //Output: true

    //Input: flowerbed = [1,0], n = 1
    //Output: false

    //Input: flowerbed = [0, 0], n = 1
    //Output: true

    //Input: flowerbed = [1,0,1], n = 1
    //Output: false

    //Input: flowerbed = [0, 0, 1], n = 1
    //Output: true

    //Input: flowerbed = [0, 0, 1], n = 1
    //Output: false

    //Input: flowerbed = [1,0,0,0,1,0,0], n = 2
    //Output: true

    //Input: flowerbed = [0,0,1,0,0], n = 1
    //Output: true

    public boolean canPlaceFlowers(int[] flowerbed, int n) {
        int length = flowerbed.length;
        if(n == 0)
            return true;

        if(length == 1 && n == 1) {
            return flowerbed[0] == 0;
        }

        for(int index=0; index<length; index++) {
            if (flowerbed[index] == 0) {
                if((index == 0 || flowerbed[index-1] == 0)
                    && (index == length-1 || flowerbed[index + 1] == 0)) {
                    flowerbed[index] = 1;
                    n--;
                    index++;

                    if(n==0)
                        return true;
                }
            }
        }

        return false;
    }
}
