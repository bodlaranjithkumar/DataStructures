using System;
using System.Collections.Generic;

namespace InterviewCakeSolutions.Queue
{
    class QueueWith2Stacks
    {
        Stack<int> s1;
        Stack<int> s2;

        QueueWith2Stacks()
        {
            s1 = new Stack<int>();
            s2 = new Stack<int>();
        }

        //public static void Main(string[] args)
        //{
        //    QueueWith2Stacks myQueue = new QueueWith2Stacks();

        //    try
        //    {
        //        myQueue.Enqueue(1);
        //        myQueue.Enqueue(2);
        //        myQueue.Enqueue(3);

        //        Console.WriteLine($"Peek Operation returned : {myQueue.Peek()}");           //1
        //        Console.WriteLine($"Dequeue Operation returned : {myQueue.Dequeue()}");     //1
        //        Console.WriteLine($"Peek Operation returned : {myQueue.Peek()}");           //2
        //        Console.WriteLine($"Dequeue Operation returned : {myQueue.Dequeue()}");     //2
        //        Console.WriteLine($"Peek Operation returned : {myQueue.Peek()}");           //3
        //        Console.WriteLine($"Dequeue Operation returned : {myQueue.Dequeue()}");     //3
        //        Console.WriteLine($"Peek Operation returned : {myQueue.Peek()}");           //Exception

        //        myQueue.Enqueue(4);
        //        myQueue.Enqueue(5);
        //        myQueue.Enqueue(6);
        //        Console.WriteLine($"Peek Operation returned : {myQueue.Peek()}");           //4
        //        Console.WriteLine($"Dequeue Operation returned : {myQueue.Dequeue()}");     //4
        //        Console.WriteLine($"Peek Operation returned : {myQueue.Peek()}");           //5                
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    Console.ReadKey();
        //}

        public void Enqueue(int number)
        {
            s1.Push(number);
        }

        private void PushToStack2()
        {
            if (s2.Count == 0)
            {
                if (s1.Count == 0)
                {
                    throw new InvalidOperationException("Queue is emtpy");
                }

                while (s1.Count != 0)
                {
                    s2.Push(s1.Pop());
                }
            }            
        }

        public int Peek()
        {
            PushToStack2();
            return s2.Peek();
        }

        public int Dequeue()
        {
            PushToStack2();
            return s2.Pop();
        }
    }
}
