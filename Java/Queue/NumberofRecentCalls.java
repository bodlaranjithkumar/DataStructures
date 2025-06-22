package Queue;

import java.util.LinkedList;
import java.util.Queue;

public class NumberofRecentCalls {
    // Leetcode 933: https://leetcode.com/problems/number-of-recent-calls/description/
    // Submission Detail: https://leetcode.com/problems/number-of-recent-calls/submissions/1672979043

    //Input
    //["RecentCounter", "ping", "ping", "ping", "ping"]
    //    [[], [1], [100], [3001], [3002]]

    //Output
    //[null, 1, 2, 3, 3]
    //
    //Explanation
    //RecentCounter recentCounter = new RecentCounter();
    //recentCounter.ping(1);     // requests = [1], range is [-2999,1], return 1
    //recentCounter.ping(100);   // requests = [1, 100], range is [-2900,100], return 2
    //recentCounter.ping(3001);  // requests = [1, 100, 3001], range is [1,3001], return 3
    //recentCounter.ping(3002);  // requests = [1, 100, 3001, 3002], range is [2,3002], return 3

    class RecentCounter {
        Queue<Integer> pings;
        public RecentCounter() {
            pings = new LinkedList<>();
        }

        public int ping(int t) {
            while(!pings.isEmpty() && t > pings.peek()+3000) {
                pings.poll();
            }
            pings.offer(t);

            return pings.size();
        }
    }
}
