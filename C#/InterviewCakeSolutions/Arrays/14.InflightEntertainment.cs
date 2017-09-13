using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCakeSolutions.Arrays
{
    class InFlightEntertainment
    {
        //public static void Main(string[] args)
        //{
        //    int[] movieLengths = { 250,250,10, 150, 70, 300, 120, 200, 500, 490 };
        //    Console.WriteLine(moviesExists(50, movieLengths));
        //    Console.Read();
        //}

        public static bool moviesExists(int flightLength, int[] movieLengths)
        {
            if (movieLengths.Length < 2)
                throw new ArgumentException("Minimum 2 movie lenghts required in the array.", nameof(movieLengths));

            if (flightLength < 0)
                throw new ArgumentException("flightLength cannot be less than 0", nameof(flightLength));

            HashSet<int> FirstMovieLengths = new HashSet<int>();

            foreach(int movieLength in movieLengths)
            {
                int remainingMovieLength = flightLength - movieLength;

                // "AND" condition to check if 2 movies are not of same length. The consideration here is 2 items with same movie length are treated same movies.
                if (remainingMovieLength > 0 && !FirstMovieLengths.Contains(movieLength))   
                {
                    if (FirstMovieLengths.Contains(remainingMovieLength))
                    {
                        return true; 
                    }

                    FirstMovieLengths.Add(movieLength);
                }
            }

            return false;
        }
    }
}