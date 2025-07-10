package DFS.Tree;

import DataStructures.TreeNode;

public class ConvertSortedArrayToBinarySearchTree {
    // Leetcode 108: https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/description/
    // Submission Detail: https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/submissions/1692811585

    //Input: nums = [-10,-3,0,5,9]
    //Output: [0,-3,9,-10,null,5]
    //Explanation: [0,-10,5,null,-3,null,9] is also accepted

    //Input: nums = [1,3]
    //Output: [3,1]
    //Explanation: [1,null,3] and [3,1] are both height-balanced BSTs.

    public TreeNode sortedArrayToBST(int[] nums) {
        return sortedArrayToBST(nums, 0, nums.length-1);
    }

    private TreeNode sortedArrayToBST(int[] nums, int startIndex, int endIndex) {
        if(startIndex > endIndex)
            return null;

        int mid = startIndex + (endIndex-startIndex)/2;

        int val = nums[mid];
        TreeNode left = sortedArrayToBST(nums, startIndex, mid-1);
        TreeNode right = sortedArrayToBST(nums, mid+1, endIndex);

        TreeNode node = new TreeNode(val, left, right);

        return node;
    }
}
