using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.String
{
    // Leetcode 246
    public class StrobogrammaticNumber
    {
        public static void Main(string[] args)
        {
            StrobogrammaticNumber s = new StrobogrammaticNumber();
            Console.WriteLine($"{s.IsStrobogrammatic("88")}");  // true
            Console.WriteLine($"{s.IsStrobogrammatic("69")}");  // true
            Console.WriteLine($"{s.IsStrobogrammatic("818")}");  // true
            Console.WriteLine($"{s.IsStrobogrammatic("878")}");  // false
            Console.WriteLine($"{s.IsStrobogrammatic("797")}");  // false

            Console.ReadKey();
        }

        private static Dictionary<int, int> StrobogrammaticNumbers =
            new Dictionary<int, int>()
            {
                { 0,0 },
                { 1,1 },
                { 6,9 },
                { 8,8 },
                { 9,9 }
            };


        // Tx = O(n)
        // Sx = O(1)
        public bool IsStrobogrammatic(string s)
        {
            int low = 0, high = s.Length - 1;

            while(low <= high)
            {
                if (!char.IsNumber(s[low]) 
                        || !char.IsNumber(s[high]) 
                        || !StrobogrammaticNumbers.ContainsKey(s[low] - '0') 
                        || !StrobogrammaticNumbers.ContainsKey(s[high] - '0')
                        || StrobogrammaticNumbers[s[low] - '0'] != StrobogrammaticNumbers[s[high] - '0'])
                    return false;

                low++;
                high--;               
            }
            
            return true;
        }
    }
}
