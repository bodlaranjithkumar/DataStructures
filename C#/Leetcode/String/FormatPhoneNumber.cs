using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.String
{
    public class FormatPhoneNumber
    {
        // 12 -> 12
        // 123 -> 123
        // 1234 -> 12-34
        // 00-44  48 555 8361 -> 004-448-555-583-61
        // 0 - 22 1985-324 -> 022-198-53-24
        // 555372654 -> 555-372-654

        public string Format(string s)
        {
            if (s == null) return s;

            StringBuilder str = new StringBuilder(s);
            str.Replace(" ", "").Replace("-", "");

            for (int i = 0; i < str.Length;)
            {
                int remainingLength = str.Length - i;

                if (remainingLength == 4)
                    i += 2;
                else
                    i += 3;

                if (i < str.Length)
                    str.Insert(i, '-');
            }

            return str.ToString();
        }
    }
}
