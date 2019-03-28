using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.Interview
{
    /*
        We have some clickstream data that we gathered on our client's website. Using cookies, we collected snippets of users' anonymized URL histories while they browsed the site. The histories are in chronological order and no URL was visited more than once per person.

        Write a function that takes two users' browsing histories as input and returns the longest contiguous sequence of URLs that appears in both.

        Sample input:

        user0 = ["/start.html", "/pink.php", "/register.asp", "/orange.html", "/red.html"]
        user1 = ["/start.html", "/green.html", "/blue.html", "/pink.php", "/register.asp", "/orange.html"]
        user2 = ["/red.html", "/green.html", "/blue.html", "/pink.php", "/register.asp"]
        user3 = ["/blue.html", "/logout.php"]

        Sample output:

        findContiguousHistory(user0, user1)
           /pink.php
           /register.asp
           /orange.html

        findContiguousHistory(user1, user2)
           /green.html
           /blue.html
           /pink.php
           /register.asp

        findContiguousHistory(user0, user3)
           (empty)

        findContiguousHistory(user2, user3)
           /blue.html

        findContiguousHistory(user3, user3)
           /blue.html
           /logout.php
    */


    public class ContiguousHistory
    {
        static void Main(string[] args)
        {
            string[] user0 = { "/start.html", "/pink.php", "/register.asp", "/orange.html", "/red.html" };
            string[] user1 = { "/start.html", "/green.html", "/blue.html", "/pink.php", "/register.asp", "/orange.html" };
            string[] user2 = { "/red.html", "/green.html", "/blue.html", "/pink.php", "/register.asp" };
            string[] user3 = { "/blue.html", "/logout.php" };


            var result1 = findContiguousHistory(user0, user1);

            foreach (var str in result1)
            {
                Console.WriteLine(str);
            }
        }

        public static IList<string> findContiguousHistory(string[] a, string[] b)
        {
            int i = 0, j = 0, start = 0, end = 0, length = 0;

            while (i < a.Length && j < b.Length)
            {
                if (a[i].Equals(b[j]))
                {
                    i++;
                    j++;

                    if (i == a.Length - 1 || j == b.Length - 1 || length < end - start)
                        end = i;
                }
                else
                {

                    start = i;

                    j++;
                }
            }

            IList<string> result = new List<string>();

            for (int k = start; k < end; k++)
            {
                result.Add(a[k]);
            }

            return result;
        }
    }
}
