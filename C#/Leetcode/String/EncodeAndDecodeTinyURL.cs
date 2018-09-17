using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.String
{
    // Leetcode 535 - https://leetcode.com/problems/encode-and-decode-tinyurl/
    // Submission Detail - https://leetcode.com/submissions/detail/170097495/

    public class EncodeAndDecodeTinyURL
    {
        private string EncodeString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const string BaseUrl = "http://tinyurl.com/";
        private IDictionary<string, string> url2Tiny = new Dictionary<string, string>();
        private IDictionary<string, string> tiny2Url = new Dictionary<string, string>();
        Random rand = new Random();

        // Encodes a URL to a shortened URL
        public string Encode(string longUrl)
        {
            if (url2Tiny.ContainsKey(longUrl))
                return url2Tiny[longUrl];

            string shortenedUrl;
            do
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < 6; i++)
                {
                    int randomIndex = rand.Next(0, EncodeString.Length);
                    sb.Append(EncodeString[randomIndex]);
                }

                shortenedUrl = sb.ToString();
            } while (tiny2Url.ContainsKey(shortenedUrl));

            url2Tiny.Add(longUrl, shortenedUrl);
            tiny2Url.Add(shortenedUrl, longUrl);

            return shortenedUrl;
        }

        // Decodes a shortened URL to its original URL.
        public string Decode(string shortUrl)
        {
            return tiny2Url[shortUrl.Replace(BaseUrl, "")];
        }
    }
}
