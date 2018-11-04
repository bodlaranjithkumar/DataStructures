using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.String
{
    // Leetcode 288
    // Explanation : http://www.cnblogs.com/grandyang/p/5220589.html
    // Hashset
    public class UniqueWordAbbreviation
    {
        //public static void Main(string[] args)
        //{
        //    UniqueWordAbbreviation w1 = new UniqueWordAbbreviation(new string[] { "deer", "door", "cake", "card" });

        //    Console.WriteLine(w1.IsUnique("dear")); //false
        //    Console.WriteLine(w1.IsUnique("cart")); //true
        //    Console.WriteLine(w1.IsUnique("cane")); //false
        //    Console.WriteLine(w1.IsUnique("make")); //true

        //    UniqueWordAbbreviation w2 = new UniqueWordAbbreviation(new string[] {});

        //    Console.WriteLine(w2.IsUnique("dear")); //true


        //    Console.ReadKey();
        //}

        HashSet<string> abbreviations;

        // Tx = O(n)
        // Sx = O(n)
        public UniqueWordAbbreviation(string[] words)
        {
            abbreviations = new HashSet<string>();

            foreach (var word in words)
            {
                string abbreviation = AbbreviationHelper(word);
                if (!abbreviations.Contains(abbreviation))
                    abbreviations.Add(abbreviation);
            }
        }

        // Tx = O(1)
        bool IsUnique(string word)
        {
            // True when there abbreviations is empty or there is current abbreviation in the abbreviations list.
            return abbreviations.Count == 0 || !abbreviations.Contains(AbbreviationHelper(word));
        }

        private string AbbreviationHelper(string word)
        {
            int? length = word?.Length;
            string abbreviation = (length == null || length <= 2)
                    ? word
                    : word[0] + Convert.ToString(length - 2) + word[length.GetValueOrDefault() - 1];

            return abbreviation;
        }
    }
}
