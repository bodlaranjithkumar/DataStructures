namespace LeetcodeSolutions.BinaryTree
{
    public class TreeLinkNode
    {
        int val;
        public TreeLinkNode left, right, next;
        TreeLinkNode(int x) { val = x; }
    }

    // Leetcode 116 - https://leetcode.com/problems/populating-next-right-pointers-in-each-node
    // Submission Detail - https://leetcode.com/submissions/detail/151040301/

    public class PopulatingNextRightPointersInEachNode
    {
        // Tx = O(n)
        // Sx = O(1)
        // Breadth-First Traversal
        public void Connect(TreeLinkNode root)
        {
            while (root != null && root.left != null)
            {
                TreeLinkNode CurrLevelLeftNode = root;
                while (root != null)
                {
                    root.left.next = root.right;
                    if (root.next != null) root.right.next = root.next.left;
                    root = root.next;
                }

                root = CurrLevelLeftNode.left;
            }
        }
    }
}
