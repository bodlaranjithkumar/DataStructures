using System.Collections.Generic;

namespace LeetcodeSolutions.Array
{
    public class AccountsMerge
    {
        // Leetcode 721 - https://leetcode.com/problems/accounts-merge/description/
        // Submission Detail - https://leetcode.com/submissions/detail/205609480/

        public List<List<string>> MergeAccounts(List<List<string>> accounts)
        {
            List<List<string>> result = new List<List<string>>();
            IDictionary<string, List<int>> emailIndices = new Dictionary<string, List<int>>();
            int count = accounts.Count;
            bool[] visited = new bool[count];

            for (int i = 0; i < count; i++)
            {
                List<string> curr = accounts[i];
                for (int j = 1; j < curr.Count; j++)
                {
                    string email = curr[j];

                    if (!emailIndices.ContainsKey(email))
                        emailIndices.Add(email, new List<int>());
                    
                    List<int> list = emailIndices[email];
                    list.Add(i);
                }
            }

            for (int i = 0; i < count; i++)
            {
                if (visited[i])
                    continue;

                string name = accounts[i][0];
                HashSet<string> mergedList = new HashSet<string>();
                Stack<int> st = new Stack<int>();
                st.Push(i);

                while (st.Count > 0)
                {
                    int index = st.Pop();
                    if (visited[index])
                        continue;

                    visited[index] = true;
                    List<string> curr = accounts[index];

                    for (int j = 1; j < curr.Count; j++)
                    {
                        string email = curr[j];
                        List<int> list = emailIndices[email];
                        mergedList.Add(email);

                        foreach(int k in list)
                        {
                            if (!visited[k])
                            {
                                st.Push(k);
                            }
                        }
                    }
                }

                List<string> newList = new List<string>(mergedList);
                newList.Sort(string.CompareOrdinal);
                newList.Insert(0, name);
                result.Add(newList);
            }

            return result;
        }
    }
}
