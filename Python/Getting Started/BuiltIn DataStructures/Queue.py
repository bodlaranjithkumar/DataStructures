class Queue:
    def __init__(self):
        self.queue = []

    def enqueue(self, val):
        self.queue.insert(0, val)
        print('{0} is enqueued to queue.'.format(val))

    def dequeue(self):
        if not self.is_empty():
            val = self.queue.pop()
            print('{0} is dequeued from queue.'.format(val))

    def is_empty(self):
        return self.queue == []

    def size(self):
        return len(self.queue)


if __name__ == '__main__':
    numbers_queue = Queue()
    numbers_queue.enqueue(1)
    numbers_queue.enqueue(2)
    numbers_queue.enqueue(3)

    numbers_queue.dequeue()
    numbers_queue.dequeue()
    numbers_queue.dequeue()
    numbers_queue.dequeue()  # does nothing since the queue is empty
