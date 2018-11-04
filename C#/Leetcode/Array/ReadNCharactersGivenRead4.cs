using System;

namespace LeetcodeSolutions.Array
{
    // Leetcode 157 - https://leetcode.com/problems/read-n-characters-given-read4/
    // Submission Detail - https://leetcode.com/submissions/detail/182491830/

    public class ReadNCharactersGivenRead4
    {
        public class Solution //: Reader4
        {
            /**
             * @param buf Destination buffer
             * @param totalCharsToRead   Maximum number of characters to read
             * @return    The number of characters read
             */
            // Two Cases: 1. totalCharsToRead > total chars Read4 can read. Ex: totalCharsToRead = 20, total chars in the file = 10. Covered by the reachedEndOfFile bool flag.
            //            2. totalCharsToRead < total chars Read4 can read. Ex: totalCharsToRead = 10, total chars in the file = 20. Covered by the 2nd condition in the while loop.

            //public int Read(char[] buf, int totalCharsToRead)
            //{
            //    int totalCharsRead = 0;
            //    bool reachedEndOfFile = false;
            //    char[] tempBuf = new char[4]; // used to read 4 characters from the API at a time.

            //    while (!reachedEndOfFile && totalCharsRead < totalCharsToRead)
            //    {
            //        int count = Read4(tempBuf);

            //        reachedEndOfFile = count < tempBuf.Length;

            //        count = System.Math.Min(count, totalCharsToRead - totalCharsRead);

            //        for (int i = 0; i < count; i++)
            //        {
            //            buf[totalCharsRead++] = tempBuf[i];
            //        }
            //    }

            //    return totalCharsRead;
            //}
        }
    }
}
