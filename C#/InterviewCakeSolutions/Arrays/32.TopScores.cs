using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCakeSolutions.Arrays
{
    class TopScores
    {
        //public static void Main(string[] args)
        //{
        //    int[] unsortedScores = new[] { 37, 89, 41, 53, 65, 91, 53 };
        //    const int highestPossibleScore = 100;

        //    TopScores topScores = new TopScores();

        //    // sortedScores: [91, 89, 65, 53, 41, 37]
        //    int[] sortedScores = topScores.SortScores(unsortedScores, highestPossibleScore);

        //    foreach (int score in sortedScores)
        //        Console.WriteLine($"{score},");

        //    Console.ReadKey();
        //}

        /// <summary>
        /// Sorts the scores in descending order.
        /// </summary>
        /// <param name="unsortedScores">Unsorted scores array</param>
        /// <param name="highestPossibleScore">The highest possible score. This is a constant</param>
        /// <returns></returns>
        public int[] SortScores(int[] unsortedScores, int highestPossibleScore)
        {
            // Edge Cases
            if (unsortedScores.Length == 0 || unsortedScores.Length == 1)
                return unsortedScores;
            else if (highestPossibleScore < 0)
                throw new ArgumentException(nameof(highestPossibleScore), "Highest Possible Score cannot be a negative number");

            int[] sortedScores = new int[unsortedScores.Length];

            int[] scoresOccurrence = new int[highestPossibleScore];

            // Update scoresOccurrence. 
            foreach (int score in unsortedScores)
            {
                if (score < 0)
                    throw new ArgumentException("Score cannot be negative number.");
                else if (score > highestPossibleScore)
                    throw new ArgumentException("Highest Possible Score is less than a score.");

                scoresOccurrence[score]++;
            }

            int sortedScoresIndex = 0;

            // Insert the scores in decreasing order.
            for(int score = highestPossibleScore - 1; score >= 0; score--)
            {
                while(scoresOccurrence[score] > 0)
                {
                    sortedScores[sortedScoresIndex] = score;
                    sortedScoresIndex++;
                    scoresOccurrence[score]--;
                }
            }

            return sortedScores;
        }
    }
}
