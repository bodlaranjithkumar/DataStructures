package DFS.Tree;

import DataStructures.TreeNode;

public class LeafSimilarTrees {
    // Leetcode 872: https://leetcode.com/problems/leaf-similar-trees/description/
    // Submission Detail: https://leetcode.com/problems/leaf-similar-trees/submissions/1673116495

    //Input: root1 = [3,5,1,6,2,9,8,null,null,7,4], root2 = [3,5,1,6,7,4,2,null,null,null,null,null,null,9,8]
    //Output: true

    //Input: root1 = [1,2,3], root2 = [1,3,2]
    //Output: false

    public boolean leafSimilar(TreeNode root1, TreeNode root2) {
        StringBuilder sb1 = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();

        dfs(root1, sb1);
        dfs(root2, sb2);

        return sb1.toString().equals(sb2.toString());
    }

    private void dfs(TreeNode node, StringBuilder sb) {
        // Base case: Empty node
        if(node == null)
            return;

        // Base Case: Leaf Node
        if(node.left == null && node.right == null) {
            sb.append(node.val).append(" ");
            return;
        }

        dfs(node.left, sb);
        dfs(node.right, sb);
    }
}
