using System;
using System.Collections.Generic;
using System.Text;

namespace GainloSolutions.Facebook
{
    class MinimumDeletionsOfAString
    {
        //public static void Main(string[] args)
        //{
        //    HashSet<string> dictionary = new HashSet<string>() {
        //        "Cat",
        //        "Cats",
        //        "Ca",
        //        "Chats",
        //        "Chatts"
        //    };

        //    MinimumDeletionsOfAString minimumDeletion = new MinimumDeletionsOfAString();
        //    Console.WriteLine(minimumDeletion.FindMinimumDeletionsFromAString(dictionary, "chats"));
        //    Console.ReadKey();
        //}

        public int FindMinimumDeletionsFromAString(HashSet<string> dictionary, string str)
        {
            // Edge Case
            if (str.Length > 0 && dictionary.Count == 0)
                throw new ArgumentException("No words found in the dictionary", nameof(dictionary));
            else if (str.Length == 0 || (dictionary.Count > 0 && dictionary.Contains(str)))
                return 0;

            string longest = str.ToLower();
            int minimumDeletions = str.Length;

            foreach (string word in dictionary)
            {
                string shortest = word.ToLower();

                // Only iterate through dictionary word if it's length is <= length of input string.
                if (shortest.Length <= longest.Length)
                {
                    int longestStringIndex = 0;     // Index of input string.
                    int shortestStringIndex = 0;    // Index of dictionary word.

                    while(shortestStringIndex < word.Length)
                    {
                        if (shortest[shortestStringIndex] == longest[longestStringIndex])
                        {
                            shortestStringIndex++;
                            longestStringIndex++;
                        }
                        else if(shortest[shortestStringIndex] != longest[longestStringIndex])
                        {
                            longestStringIndex++;
                        }

                        // If the dictionary word index reached the end, calculate the characters in the original string to be deleted.
                        if (shortestStringIndex == shortest.Length - 1)
                        {
                            minimumDeletions = Math.Min(minimumDeletions, (longest.Length - shortest.Length));
                        }
                    }
                }
            }
            return minimumDeletions;
        }
    }
}
