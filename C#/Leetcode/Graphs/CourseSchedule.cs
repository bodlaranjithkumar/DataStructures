using System.Collections.Generic;

namespace LeetcodeSolutions.Graphs
{
    // Leetcode 207
    // Submission Detail: https://leetcode.com/submissions/detail/159417103/

    public class CourseSchedule
    {
        // 4 [[1,2],[2,3],[0,1],[3,1]] -> false
        // 4 [[1,2],[0,1],[2,3]] -> true
        // 3 [[1,0],[2,0],[0,2]] -> false

        // Reference: https://leetcode.com/problems/course-schedule/discuss/58568/C-Solution

        // Idea: DFS - Preprocess the given order pairs and create a graph using dictionary<int, list<int>>.
        //       Use boolean array to set the visited status of a node. Set to true if visited for the first time. If previously seen, return false.
        IDictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        public bool CanFinish(int numCourses, int[,] prerequisites)
        {
            PreProcess(prerequisites);

            bool[] visited = new bool[numCourses];

            foreach (var key in graph.Keys)
                if (!visited[key] && !DFS(graph, visited, key))
                    return false;

            return true;
        }

        private bool DFS(IDictionary<int, List<int>> graph, bool[] visited, int course)
        {
            if (visited[course])
                return false;

            visited[course] = true;

            for (int i = 0; graph.ContainsKey(course) && i < graph[course].Count; i++)
                if (!DFS(graph, visited, graph[course][i]))
                    return false;

            visited[course] = false;

            return true;
        }

        private void PreProcess(int[,] prerequisites)
        {
            for (int i = 0; i < prerequisites.GetLength(0); i++)
            {
                if (!graph.ContainsKey(prerequisites[i, 0]))
                    graph.Add(prerequisites[i, 0], new List<int>() { prerequisites[i, 1] });
                else
                    graph[prerequisites[i, 0]].Add(prerequisites[i, 1]);
            }
        }
    }
}
