package BinarySearch;

public class BinarySearch {
  // nums = [-1,0,3,5,9,12], target = 9   =>   4
  // nums = [-1,0,3,5,9,12], target = 2   =>  -1

  // Tx = O(logn)
  // Sx = O(1)
  public int binarySearch(int[] arr, int key) {
    int start = 0, end = arr.length-1;

    while(start <= end) {
      int mid = start + (end-start)/2;
      if(arr[mid] == key) {
        return mid;
      } else if (arr[mid] < key) {
        start = mid+1;
      } else {
        end = mid-1;
      }
    }

    return -1;
  }
}
