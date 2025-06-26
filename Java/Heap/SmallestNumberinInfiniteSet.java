package Heap;

import java.util.HashSet;
import java.util.PriorityQueue;
import java.util.Set;

public class SmallestNumberinInfiniteSet {
    // Leetcode 2336: https://leetcode.com/problems/smallest-number-in-infinite-set/description/
    // Submission Detail: https://leetcode.com/problems/smallest-number-in-infinite-set/submissions/1676559190

    //    Input
    //["SmallestInfiniteSet","addBack","popSmallest","popSmallest","popSmallest","addBack","popSmallest","popSmallest","popSmallest"]
    //        [[],[2],[],[],[],[1],[],[],[]]
    //    Output
    //[null,null,1,2,3,null,1,4,5]

    //    Input
    //["SmallestInfiniteSet","popSmallest","addBack","popSmallest","addBack","popSmallest","addBack","popSmallest","popSmallest","popSmallest"]
    //        [[],[],[607],[],[781],[],[562],[],[],[]]
    //    Output
    //[null,1,null,2,null,3,null,4,5,6]

    PriorityQueue<Integer> minHeap;
    Set<Integer> set;
    int current = 1;
    public SmallestNumberinInfiniteSet() {
        minHeap = new PriorityQueue<>();
        set = new HashSet<>();
    }

    public int popSmallest() {
        if(!minHeap.isEmpty()) {
            int num = minHeap.poll();
            set.remove(num);

            return num;
        }

        return current++;
    }

    public void addBack(int num) {
        if(num < current && !set.contains(num)) {
            set.add(num);
            minHeap.add(num);
        }
    }
}
