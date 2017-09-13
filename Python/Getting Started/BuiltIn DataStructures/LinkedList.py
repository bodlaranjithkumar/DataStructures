class Node:
    def __init__(self, data):
        self.data = data
        self.next = None


class LinkedList:
    def __init__(self):
        self.head = None

    def print_list(self):
        node = self.head
        while node:
            print(node.data)
            node = node.next


# What is this for?
# Ans: https://stackoverflow.com/questions/419163/what-does-if-name-main-do
if __name__ == '__main__':
    list = LinkedList()

    list.head = Node(1)
    second = Node(2)
    third = Node(3)

    list.head.next = second
    second.next = third

    list.print_list()