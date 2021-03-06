﻿using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;

namespace LeetcodeSolutions
{
    public class Helper
    {
        public static void PrintArray(int[] result)
        {
            foreach (var val in result)
            {
                Console.Write($"{val}\t");
            }
        }

        public static void Print<T>(T val)
        {
            Console.WriteLine($"{val}");
        }

        public static void PrintListNodes(ListNode head)
        {
            while (head != null)
            {
                Console.WriteLine($"{head.Val} \t");
                head = head.Next;
            }
        }

        public static void PrintListElements<T>(IList<T> list)
        {
            Console.Write("[");
            foreach(var t in list)
            {
                Console.Write($"{t},");
            }
            Console.Write("]\n");
        }

        public static ListNode CreateListNode(int[] values)
        {
            ListNode head = new ListNode(0);
            ListNode node = head;

            foreach (var val in values)
            {
                node.Next = new ListNode(val);
                node = node.Next;
            }

            return head.Next;
        }

        public static void Swap(int[] A, int index1, int index2)
        {
            int temp = A[index1];
            A[index1] = A[index2];
            A[index2] = temp;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for(int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }
        }
    }
}
