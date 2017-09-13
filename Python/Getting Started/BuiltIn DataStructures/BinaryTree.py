class Node:
    def __init__(self, val):
        self.val = val
        self.left = None
        self.right = None


class BinaryTree:
    def __init__(self):
        self.root = None

    def print_nodes(self, node):
        if not node:
            return None

        print(node.val)
        self.print_nodes(node.left)
        self.print_nodes(node.right)


if __name__ == '__main__':
    tree = BinaryTree()
    tree.root = Node(10)
    tree.root.left = Node(5)
    tree.root.left.left = Node(1)
    tree.root.right = Node(15)

    tree.print_nodes(tree.root)
