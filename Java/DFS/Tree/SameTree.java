package DFS.Tree;

import DataStructures.TreeNode;

public class SameTree {
    // Leetcode 100: https://leetcode.com/problems/same-tree/description/
    // Submission Detail: https://leetcode.com/problems/same-tree/submissions/1692740644

    //Input: p = [1,2,3], q = [1,2,3]
    //Output: true

    //Input: p = [1,2,1], q = [1,1,2]
    //Output: false

    //Input: p = [1,2], q = [1,null,2]
    //Output: false

    public boolean isSameTree(TreeNode p, TreeNode q) {
        if(p == null && q == null) {
            return true;
        } else if(q == null || p == null || p.val != q.val) {
            return false;
        }

        return isSameTree(p.left, q.left) && isSameTree(p.right, q.right);
    }
}
