namespace LeetcodeSolutions.Math
{
    // Leetcode 278 - https://leetcode.com/problems/first-bad-version/description/
    // Submission Detail - https://leetcode.com/submissions/detail/140342535/
    // Modified binary search

    public class FirstBadVersion //: VersionControl
    {
        //Tx = O(lgn)
        //public int FindFirstBadVersion(int n)
        //{
        //    int low = 1, high = n;

        //    while (low < high)
        //    {
        //        int mid = low + (high - low) / 2;

        //        // IsBadVersion below is implemented by OJ.
        //        //if (IsBadVersion(mid)) high = mid;
        //        //else low = mid + 1;
        //    }

        //    return low;
        //}

        //// Tx = O(n)
        //public int FindFirstBadVersionBruteForce(int n)
        //{
        //    for (int i = 1; i < n; i++)
        //       // if (IsBadVersion(i))
        //            return i;

        //    return n;
        //}
    }
}
