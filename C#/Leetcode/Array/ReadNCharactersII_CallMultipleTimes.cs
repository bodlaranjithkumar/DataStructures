namespace LeetcodeSolutions.Array
{
    // Leetcode 158 - https://leetcode.com/problems/read-n-characters-given-read4-ii-call-multiple-times/
    // Submission Detail - https://leetcode.com/submissions/detail/182602133/

    public class ReadNCharactersII_CallMultipleTimes
    {
        /* The Read4 API is defined in the parent class Reader4.
      int Read4(char[] buf); */


        /**
         * @param buf Destination buffer
         * @param n   Maximum number of characters to read
         * @return    The number of characters read
         */

        readonly int lastIndexRead = 0, totalCharsFromRead4 = 0;
        readonly char[] temp = new char[4];

        //public int Read(char[] buf, int totalCharsToRead)
        //{
        //    int totalCharsRead = 0;

        //    while (totalCharsRead < totalCharsToRead)
        //    {
        //        if (lastIndexRead >= totalCharsFromRead4)
        //        {
        //            totalCharsFromRead4 = Read4(temp);
        //            lastIndexRead = 0;      // Reset to 0 so that the value stays <= 4.
        //        }
                  
        //        if (totalCharsFromRead4 == 0)        // no more characters left in the file to read by the api
        //          break;
                  
        //         buf[totalCharsRead++] = temp[lastIndexRead++];
        //    }

        //    return totalCharsRead;
        //}
    }
}
