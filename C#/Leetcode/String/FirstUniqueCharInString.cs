using System;

namespace LeetcodeSolutions.String
{
    // Leetcode 387
    class FirstUniqueCharInString
    {
        static void Main(string[] args)
        {
            FirstUniqueCharInString uniqChar = new FirstUniqueCharInString();
            Console.WriteLine($"expected:0\tactual:{uniqChar.FirstUniqChar("leetcode")}");
            Console.WriteLine($"expected:2\tactual:{uniqChar.FirstUniqChar("eetcode")}");
            Console.WriteLine($"expected:2\tactual:{uniqChar.FirstUniqChar("loveleetcode")}");
            Console.WriteLine($"expected:-1\tactual:{uniqChar.FirstUniqChar("baba")}");
            Console.WriteLine($"expected:-1\tactual:{uniqChar.FirstUniqChar("")}");
            Console.WriteLine($"expected:0\tactual:{uniqChar.FirstUniqChar("c")}");
            Console.WriteLine($"expected:8\tactual:{uniqChar.FirstUniqChar("dddccdbba")}");

            Console.ReadKey();
        }

        // Runtime : 135 ms
        // Tx = O(n) { n : length of the string }
        // Sx = O(1) { Actually O(128) }
        public int FirstUniqChar(string s)
        {
            int[] uniqueCharIndices = new int[128];
            int length = s.Length;

            if (length == 1)
                return 0;
            else if (length == 0)
                return -1;

            for (int index = 0; index < length; index++)
            {
                int currentCharValue = s[index];
                int currentUniqueCharIndexValue = uniqueCharIndices[currentCharValue];

                if (currentUniqueCharIndexValue == 0)
                {
                    uniqueCharIndices[currentCharValue] = length - index;
                }
                else if (currentUniqueCharIndexValue <= length)
                {
                    uniqueCharIndices[currentCharValue] = length + 1;
                }
            }

            int minIndex = 0;
            for (int index = 0; index < uniqueCharIndices.Length; index++)
            {
                if (uniqueCharIndices[index] <= length && uniqueCharIndices[index] > minIndex)
                {
                    minIndex = uniqueCharIndices[index];
                }
            }
            
            return minIndex != 0 ? length - minIndex : -1;
        }
    }
}
