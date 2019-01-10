using System.Collections.Generic;

namespace LeetcodeSolutions.Graphs
{
    // Leetcode 332 - https://leetcode.com/problems/reconstruct-itinerary/description/
    // Submission Detail - https://leetcode.com/submissions/detail/159240719/

    public class ReconstructItinerary
    {
        // Failed for itinerary [["JFK","KUL"],["JFK","NRT"],["NRT","JFK"]]
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
