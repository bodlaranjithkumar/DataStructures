using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.Interview
{
    /*
        You are in charge of a display advertising program. Your ads are displayed on websites all over the internet. You have some CSV input data that counts how many times you showed an ad on each individual domain. Every line consists of a count and a domain name. It looks like this:

        counts = [ "900,google.com",
             "60,mail.yahoo.com",
             "10,mobile.sports.yahoo.com",
             "40,sports.yahoo.com",
             "300,yahoo.com",
             "10,stackoverflow.com",
             "2,en.wikipedia.org",
             "1,es.wikipedia.org",
             "1,mobile.sports" ]

        Write a function that takes this input as a parameter and returns a data structure containing the number of hits that were recorded on each domain AND each domain under it. For example, an impression on "mail.yahoo.com" counts for "mail.yahoo.com", "yahoo.com", and "com". (Subdomains are added to the left of their parent domain. So "mail" and "mail.yahoo" are not valid domains. Note that "mobile.sports" appears as a separate domain as the last item of the input.)

        Sample output (in any order/format):

        getTotalsByDomain(counts)
        1320    com
         900    google.com
         410    yahoo.com
          60    mail.yahoo.com
          10    mobile.sports.yahoo.com
          50    sports.yahoo.com
          10    stackoverflow.com
           3    org
           3    wikipedia.org
           2    en.wikipedia.org
           1    es.wikipedia.org
           1    mobile.sports
           1    sports

    */

    public class TotalsByDomain
    {
        static void Main(string[] args)
        {
            string[] counts = {
            "900,google.com",
            "60,mail.yahoo.com",
            "10,mobile.sports.yahoo.com",
            "40,sports.yahoo.com",
            "300,yahoo.com",
            "10,stackoverflow.com",
            "2,en.wikipedia.org",
            "1,es.wikipedia.org",
            "1,mobile.sports"
        };

            //string test = "mobile.sports.yahoo.com";
            //var result = Helper(test);

            var result = getTotalsByDomain(counts);

            foreach (var key in result.Keys)
            {
                Console.WriteLine("{0}, \t {1}", result[key], key);
            }
        }

        public static IDictionary<string, int> getTotalsByDomain(string[] counts)
        {
            IDictionary<string, int> domainHits = new Dictionary<string, int>();

            foreach (string count in counts)
            {
                string[] split = count.Split(new char[] { ',' });

                IList<string> domains = Helper(split[1]);

                foreach (string domain in domains)
                {
                    if (!domainHits.ContainsKey(domain))
                        domainHits.Add(domain, 0);

                    domainHits[domain] += Int32.Parse(split[0]);
                }
            }

            return domainHits;
        }

        private static IList<string> Helper(string fullDomain)
        {
            IList<string> domainSplits = new List<string>() { fullDomain };

            for (int i = 0; i < fullDomain.Length; i++)
            {
                if (fullDomain[i] == '.')
                {
                    string str = fullDomain.Substring(i + 1, fullDomain.Length - (i + 1));
                    domainSplits.Add(str);
                    //Console.WriteLine(str);
                }
            }

            return domainSplits;
        }
    }
}
