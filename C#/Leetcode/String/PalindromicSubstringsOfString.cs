using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.String
{
    public class PalindromicSubstringsOfString
    {
        //public static void Main(string[] args)
        //{
        //    PalindromicSubstringsOfString ps = new PalindromicSubstringsOfString();
        //    Helper.PrintListElements<string>(ps.PalindromicSubstrings("pop this tacocat seems nice at noon"));

        //    Console.ReadKey();
        //}

        private IList<string> palindromicSubstrings = new List<string>();

        public IList<string> PalindromicSubstrings(string s)
        {
            if (s != null)
            {
                for (int i = 0; i < s.Length-1; i++)
                {
                    PalindromicSubstrings(s, i, i + 1);
                }
            }

            return palindromicSubstrings;
        }

        private void PalindromicSubstrings(string s, int left, int right)
        {
            while(left >= 0 && right < s.Length && s[left] == s[right])
            {
                string str = s.Substring(left, right-left+1);

                if (!palindromicSubstrings.Contains(str))
                    palindromicSubstrings.Add(str);

                left--;
                right++;
            }
        }
    }
}
