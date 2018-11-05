using System;

namespace LeetcodeSolutions.DSandAlgorithms
{
    // Explanation: https://www.youtube.com/watch?v=t0Cq6tVNRBA

    public class MinHeap
    {
        //public static void Main(string[] args)
        //{
        //    MinHeap min = new MinHeap(4);

        //    min.Add(19);
        //    min.Add(8);
        //    Console.WriteLine(min.Peek());  //8
        //    min.Add(7);
        //    Console.WriteLine(min.Peek());  //7
        //    min.Add(21);
        //    Console.WriteLine(min.Peek());  //7
        //    min.Add(1);
        //    Console.WriteLine(min.Peek());  //1
        //    min.Poll();
        //    Console.WriteLine(min.Peek());  //7

        //    Console.ReadKey();
        //}

        private int[] Items { get; set; }
        private int Capacity { get; set; }
        private int Size = 0;

        public MinHeap(int capacity)
        {
            Capacity = capacity;

            Items = new int[Capacity];
        }

        // Helper Methods

        private int LeftChildIndex(int index) => index * 2 + 1;
        private int RightChildIndex(int index) => index * 2 + 2;
        private int ParentIndex(int index) => (index - 1) / 2;

        private int LeftChildValue(int index) => Items[LeftChildIndex(index)];
        private int RightChildValue(int index) => Items[RightChildIndex(index)];
        private int ParentValue(int index) => Items[ParentIndex(index)];

        private bool HasLeftChild(int index) => index * 2 + 1 < Size;
        private bool HasRightChild(int index) => index * 2 + 2 < Size;
        private bool HasParent(int index) => (index - 1) / 2 >= 0;

        // Public Methods

        // Returns the top of the heap which is the minimum in the heap.
        public int Peek()
        {
            if (Size == 0)
                throw new InvalidOperationException("Heap is Empty.");

            return Items[0];
        }

        // Removes the top of the min heap which is the minimum in the heap.
        public int Poll()
        {
            if (Size == 0)
                throw new InvalidOperationException("Heap is Empty.");

            int top = Items[0];

            Items[0] = Items[Size - 1]; // Replace the last index value at top.
            Size--;

            HeapifyDown();

            return top;
        }

        // Adds a value to the heap.
        public void Add(int value)
        {
            EnsureHasEnoughCapacity();

            Items[Size] = value;
            Size++;

            HeapifyUp();
        }

        // Private Methods

        // Doubles the heap capacity if it is met.
        private void EnsureHasEnoughCapacity()
        {
            if(Size == Capacity)
            {
                Capacity *= 2;  // double the heap capacity.

                int[] newItems = new int[Capacity];
                System.Array.Copy(Items, newItems, Size);
                Items = newItems;
            }
        }

        // Heapifies upwards starting from the last index. 
        private void HeapifyUp()
        {
            int index = Size-1;

            while(HasParent(index) && Items[index] < ParentValue(index))
            {
                Swap(index, ParentIndex(index));

                index = ParentIndex(index);
            }
        }

        // Heapifies downwards starting from the root/the first index.
        private void HeapifyDown()
        {
            int index = 0;

            while (HasLeftChild(index))
            {
                int smallerChildIndex = LeftChildIndex(index);

                // check if the value at right child index is smaller than the left.
                if (HasRightChild(index) && RightChildValue(index) < LeftChildValue(index))
                    smallerChildIndex = RightChildIndex(index);

                if (Items[index] < Items[smallerChildIndex])    // end of the heapify
                    break;
                else
                    Swap(index, smallerChildIndex);

                index = smallerChildIndex;
            }
        }

        private void Swap(int index, int swapIndex)
        {
            int temp = Items[index];
            Items[index] = Items[swapIndex];
            Items[swapIndex] = temp;
        }
    }
}
