using System.Collections.Generic;

namespace LeetcodeSolutions.Graphs
{
    // Leetcode 841 - https://leetcode.com/problems/keys-and-rooms/
    // Submission Detail: BFS - https://leetcode.com/submissions/detail/159170601/
    //                    DFS - https://leetcode.com/submissions/detail/159173594/
    public class KeysAndRooms
    {
        // Idea: Graph DFS
        //      Check if all the rooms are visited.
        HashSet<int> visited = new HashSet<int>();
        public bool CanVisitAllRoomsDFS(IList<IList<int>> rooms)
        {
            CanVisitAllRooms(rooms, 0);

            return visited.Count == rooms.Count;
        }

        public void CanVisitAllRooms(IList<IList<int>> rooms, int room)
        {
            visited.Add(room);
            IList<int> keys = rooms[room];

            foreach (int key in keys)
                if (!visited.Contains(key))
                    CanVisitAllRooms(rooms, key);
        }

        // Idea: Graph BFS
        //       1. Add the total number of the unique room keys found in the rooms to the keys list.
        //       2. After visiting all the possible rooms starting from room 0, check if all the available rooms are visited.
        public bool CanVisitAllRoomsBFS(IList<IList<int>> rooms)
        {
            if (rooms == null || rooms.Count == 0) return true;

            HashSet<int> visited = new HashSet<int>();
            List<int> keys = new List<int>();

            keys.Add(0);

            while (keys.Count > 0)
            {
                int currentRoom = keys[0];
                keys.RemoveAt(0);

                while (rooms[currentRoom].Count > 0)
                {
                    int key = rooms[currentRoom][0];
                    rooms[currentRoom].RemoveAt(0);

                    if (!visited.Contains(key) && !keys.Contains(key) && key != currentRoom)
                        keys.Add(key);
                }

                visited.Add(currentRoom);
            }

            return visited.Count == rooms.Count;
        }
    }
}
