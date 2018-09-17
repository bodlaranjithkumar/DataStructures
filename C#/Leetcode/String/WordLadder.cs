using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.String
{
    // Leetcode 127 - https://leetcode.com/problems/word-ladder/description/

    public class WordLadder
    {
        // Time Limit Exceeded for input = "qa","sq",["si","go","se","cm","so","ph","mt","db","mb","sb","kr","ln","tm","le","av","sm","ar","ci","ca","br","ti","ba","to","ra","fa","yo","ow","sn","ya","cr","po","fe","ho","ma","re","or","rn","au","ur","rh","sr","tc","lt","lo","as","fr","nb","yb","if","pb","ge","th","pm","rb","sh","co","ga","li","ha","hz","no","bi","di","hi","qa","pi","os","uh","wm","an","me","mo","na","la","st","er","sc","ne","mn","mi","am","ex","pt","io","be","fm","ta","tb","ni","mr","pa","he","lr","sq","ye"]
        //"leet", "code", ["lest","leet","lose","code","lode","robe","lost"]
        //public static void Main(string[] args)
        //{
        //    WordLadder ladder = new WordLadder();

        //    IList<string> dictionary1 = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };
        //    //Console.WriteLine(ladder.LadderLength("hit", "cog", dictionary1));  //5

        //    IList<string> dictionary2 = new List<string> { "lest", "leet", "lose", "code", "lode", "robe", "lost" };
        //    Console.WriteLine(ladder.LadderLength("leet", "code", dictionary2));  //6

        //    Console.ReadKey();
        //}

        int minTransformationLength;
        HashSet<string> visited;
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            minTransformationLength = wordList.Count + 1;

            // Add beginword which handles the case when this word exists in the wordList.
            visited = new HashSet<string>(wordList.Count) { beginWord };    

            LadderLength(beginWord, endWord, wordList, 1);

            return minTransformationLength == wordList.Count + 1 ? 0 : minTransformationLength;
        }

        private void LadderLength(string beginWord, string endWord, IList<string> wordList, int length)
        {
            // base case
            if (beginWord == endWord)
            {
                minTransformationLength = System.Math.Min(minTransformationLength, length);
                return;
            }

            for (int i = 0; i < wordList.Count; i++)
            {
                string current = wordList[i];

                if (!visited.Contains(current) && beginWord != current && IsOneCharDifferent(beginWord, current))
                {
                    visited.Add(current);

                    LadderLength(current, endWord, wordList, length+1); // beginword becoms current

                    visited.Remove(current);
                }
            }
        }

        // ToDo: Optimize

        private bool IsOneCharDifferent(string word1, string word2)
        {
            int count = 0;
            for (int i = 0; i < word1.Length; i++)
            {
                if (word1[i] != word2[i])
                    count++;

                if (count > 1)
                    return false;
            }

            return true;
        }

        //int[] word1CharCount = new int[26];
        //int[] word2CharCount = new int[26];
        //private bool IsOneCharDifferent(string word1, string word2)
        //{
        //    for (int i = 0; i < word1.Length; i++)
        //    {
        //        word1CharCount[word1[i] - 'a']++;
        //        word2CharCount[word2[i] - 'a']++;
        //    }

        //    int count = 0;
        //    for (int i = 0; i < word1CharCount.Length; i++)
        //    {
        //        if (word1CharCount[i] != word2CharCount[i])
        //            count++;
        //    }

        //    for (int i = 0; i < word1CharCount.Length; i++)
        //    {
        //        word1CharCount[i] = 0;
        //        word2CharCount[i] = 0;
        //    }

        //    return count == 2;
        //}
    }
}
