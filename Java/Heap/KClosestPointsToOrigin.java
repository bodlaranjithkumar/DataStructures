package Heap;

import java.util.PriorityQueue;

public class KClosestPointsToOrigin {
  // Leetcode 973: https://leetcode.com/problems/k-closest-points-to-origin/
  // Submission Detail: https://leetcode.com/problems/k-closest-points-to-origin/submissions/1647678423

  // Tx = O(n logk)
  // Sx = O(k)
  public int[][] kClosestSimplified(int[][] points, int k) {
    PriorityQueue<int[]> maxHeap = new PriorityQueue<>((a,b) -> getDistance(b) - getDistance(a));

    for(int[] point : points) {
      if(maxHeap.size() < k) {
        maxHeap.offer(point);
      } else if (getDistance(point) < getDistance(maxHeap.peek())) {
        maxHeap.poll();
        maxHeap.offer(point);
      }
    }

    // Copies the contents of the maxheap into a new array.The order of the elements
    // in the array isn't sorted by distance. To do that, iterate by polling and add.
    return maxHeap.toArray(new int[maxHeap.size()][]);
  }

  private int getDistance(int[] point) {
    return point[0]*point[0] + point[1]*point[1];
  }


  // Submission Detail: https://leetcode.com/problems/k-closest-points-to-origin/submissions/1647670870
  public int[][] kClosest(int[][] points, int k) {
    PriorityQueue<OriginDistance> maxHeap = new PriorityQueue<>((a, b) -> Double.compare(b.distance, a.distance));
    // Step 1: Iterate through the points and calculate the Euclidean distance to the origin (0,0). Store that in the maxHeap along with index to the point.
    for (int index = 0; index < points.length; index++) {
      int[] point = points[index];
      double distance = Math.sqrt(point[0]*point[0] + point[1]*point[1]);
      OriginDistance originDistance = new OriginDistance(index, distance);

      if(maxHeap.size() < k) {
        maxHeap.add(originDistance);
      } else if(distance < maxHeap.peek().distance) {
        maxHeap.poll();
        maxHeap.add(originDistance);
      }
    }

    // Step 2: Iterate through the maxHeap and get the points correspoding to the indexes.
    int[][] result = new int[maxHeap.size()][2];
    for(int index = 0; index < result.length; index++) {
      OriginDistance originDistance = maxHeap.poll();
      result[index][0] = points[originDistance.index][0];
      result[index][1] = points[originDistance.index][1];
    }

    return result;
  }

  public class OriginDistance {
    // declare a public readonly variable of type integer
    public final int index;
    public final double distance;

    public OriginDistance(int index, double distance) {
      this.index = index;
      this.distance = distance;
    }
  }
}
