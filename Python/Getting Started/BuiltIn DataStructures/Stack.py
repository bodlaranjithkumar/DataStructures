class Stack:
    def __init__(self):
        self.stack = []

    # property
    def is_empty(self):
        return len(self.stack) == 0

    def push(self, val):
        self.stack.append(val)
        print('{0} is pushed to stack.'.format(val))

    def pop(self):
        if not self.is_empty():
            val = self.stack.pop()
            print('{0} is popped from the stack:'.format(val))
            return val

    def size(self):
        return len(self.stack)


if __name__ == '__main__':
    numbers_stack = Stack()
    numbers_stack.push(1)
    numbers_stack.push(2)
    numbers_stack.push(3)

    numbers_stack.pop()
    numbers_stack.pop()
    numbers_stack.pop()
    numbers_stack.pop() #does nothing since the stack is empty.
