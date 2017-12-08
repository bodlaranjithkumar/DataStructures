using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.Interview
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WordFrequency frequency = new WordFrequency(new List<string>
            {
                "java",
                "python",
                "C#",
                "java",
                "python",
                "go",
                "java",
            });

            frequency.FindnthFrequentWord(0).ForEach(w => Console.Write($"{w}\t"));
            Console.WriteLine();
            frequency.FindnthFrequentWord(1).ForEach(w => Console.Write($"{w}\t"));
            Console.WriteLine();
            frequency.FindnthFrequentWord(2).ForEach(w => Console.Write($"{w}\t"));
            Console.WriteLine();
            frequency.FindnthFrequentWord(3).ForEach(w => Console.Write($"{w}\t"));
            Console.ReadKey();
        }
    }

    public class WordFrequency
    {
        private readonly List<string> words;

        public WordFrequency(List<string> Words)
        {
            words = Words;
        }

        // Tx = O(n)
        // Sx = O(n) 
        // TODO: Return the list of words with the same casing as input.
        public List<string> FindnthFrequentWord(int n)
        {
            Dictionary<string, int> frequencies = new Dictionary<string, int>();

            foreach(string word in words)
            {
                string key = word.ToLower();
                if (frequencies.ContainsKey(key))
                    frequencies[key]++;
                else
                    frequencies[key] = 1;
            }

            Dictionary<int, List<string>> wordsWithSameFrequencies = new Dictionary<int, List<string>>();

            foreach(string word in frequencies.Keys)
            {
                int frequency = frequencies[word];

                if (wordsWithSameFrequencies.ContainsKey(frequency))
                    wordsWithSameFrequencies[frequency].Add(word);
                else
                    wordsWithSameFrequencies[frequency] = new List<string> { word };
            }

            List<int> sortedFrequencies = new List<int>(wordsWithSameFrequencies.Keys);
            sortedFrequencies.Sort();

            int nthFrequency = n < sortedFrequencies.Count ? sortedFrequencies[n] : -1;

            return wordsWithSameFrequencies.ContainsKey(nthFrequency)
                        ? wordsWithSameFrequencies[nthFrequency]
                        : new List<string>();

        }
    }
}
