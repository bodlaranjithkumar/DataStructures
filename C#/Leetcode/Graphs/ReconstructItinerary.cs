using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.Graphs
{
    // Leetcode 332
    public class ReconstructItinerary
    {


        // Failed for intinerary [["JFK","KUL"],["JFK","NRT"],["NRT","JFK"]]
        HashSet<int> visited = new HashSet<int>();
        IList<string> itinerary = new List<string>();

        public IList<string> FindItinerary(string[,] tickets)
        {
            FindItinerary(tickets, "JFK");

            return itinerary;
        }

        public void FindItinerary(string[,] tickets, string fromAirport)
        {
            itinerary.Add(fromAirport);

            if (visited.Count == tickets.GetLength(0))
                return;

            string toAirport = "ZZZ";

            int minIndex = -1;
            for (int i = 0; i < tickets.GetLength(0); i++)
            {
                if (tickets[i, 0] == fromAirport && !visited.Contains(i))
                {
                    if (tickets[i, 1].CompareTo(toAirport) < 0)
                    {
                        toAirport = tickets[i, 1];
                        minIndex = i;
                    }
                }
            }

            visited.Add(minIndex);

            FindItinerary(tickets, toAirport);
        }
    }
}
