namespace LeetcodeSolutions.BinaryTree
{
    public class TreeLinkNode
    {
        private readonly int Val;
        public TreeLinkNode Left, Right, Next;

        TreeLinkNode(int x)
        {
            Val = x;
        }
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
            while (root != null && root.Left != null)
            {
                TreeLinkNode CurrLevelLeftNode = root;

                while (root != null)
                {
                    root.Left.Next = root.Right;

                    if (root.Next != null)
                        root.Right.Next = root.Next.Left;

                    root = root.Next;
                }

                root = CurrLevelLeftNode.Left;
            }
        }
    }
}
