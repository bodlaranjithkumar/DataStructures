using System;
using System.Text;

namespace LeetcodeSolutions.String
{
    // Leetcode 273 - https://leetcode.com/problems/integer-to-english-words/
    // Submission Detail - https://leetcode.com/submissions/detail/161037769/
    // Reference: https://leetcode.com/problems/integer-to-english-words/discuss/70627/Short-clean-Java-solution
    // Use ranges - 0-10,10-20,20-100 and call recursively for bigger numbers.

    public class IntegerToEnglishWords
    {
        //public static void Main(string[] args)
        //{
        //    IntegerToEnglishWords ie = new IntegerToEnglishWords();
        //    Console.WriteLine($"123 \t {ie.NumberToWords(123)}");
        //    Console.WriteLine($"12345 \t {ie.NumberToWords(12345)}");
        //    Console.WriteLine($"1234567 \t {ie.NumberToWords(1234567)}");
        //    Console.WriteLine($"0 \t {ie.NumberToWords(0)}");
        //    Console.WriteLine($"100 \t {ie.NumberToWords(100)}");
        //    Console.WriteLine($"101 \t {ie.NumberToWords(101)}");
        //    Console.WriteLine($"21 \t {ie.NumberToWords(21)}");
        //    Console.WriteLine($"500 \t {ie.NumberToWords(500)}");
        //    Console.WriteLine($"13500 \t {ie.NumberToWords(13500)}");
        //    Console.WriteLine($"900000000 \t {ie.NumberToWords(900000000)}");
        //    Console.WriteLine($"1000000000 \t {ie.NumberToWords(1000000000)}");
        //    Console.WriteLine($"1987654938 \t {ie.NumberToWords(1987654938)}");
        //    Console.ReadKey();
        //}

        #region clean code solution 
        private static string[] belowTen = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        private static string[] belowTwenty = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private static string[] belowHundred = { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        public string NumberToWords(int num)
        {
            if (num == 0)
                return "Zero";
            else
                return Helper(num);
        }

        private string Helper(int num)
        {
            StringBuilder sb = new StringBuilder();
            if (num < 10) sb.Append(belowTen[num]);
            else if (num < 20) sb.Append(belowTwenty[num - 10]);
            else if (num < 100) sb.Append(belowHundred[num / 10]).Append(" ").Append(Helper(num % 10));
            else if (num < 1000) sb.Append(Helper(num / 100)).Append(" Hundred ").Append(Helper(num % 100));
            else if (num < 1000000) sb.Append(Helper(num / 1000)).Append(" Thousand ").Append(Helper(num % 1000));
            else if (num < 1000000000) sb.Append(Helper(num / 1000000)).Append(" Million ").Append(Helper(num % 1000000));
            else sb.Append(Helper(num / 1000000000)).Append(" Billion ").Append(Helper(num % 1000000000));
            return sb.ToString().Trim();
        }
        #endregion

        #region solution 1
        //private StringBuilder result;
        ////private static string[] numbers_lt_20 = {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", 
        ////    "twelve","thirteen", "forteen","fifteen","sixteen","seventeen","eighteen","nineteen","twenty","thirty","forty",
        ////    "fifty","sixty","seventy","eighty","ninty"};
        //private static Dictionary<int, string> numbers_lt_100 = new Dictionary<int, string>()
        //{
        //    {1, "One"},
        //    {2, "Two" },
        //    {3, "Three" },
        //    {4, "Four" },
        //    {5, "Five" },
        //    {6, "Six" },
        //    {7, "Seven"},
        //    {8, "Eight" },
        //    {9, "Nine" },
        //    {10, "Ten" },
        //    {11, "Eleven" },
        //    {12, "Twelve" },
        //    {13, "Thirteen" },
        //    {14, "Fourteen" },
        //    {15, "Fifteen" },
        //    {16, "Sixteen" },
        //    {17, "Seventeen" },
        //    {18, "Eighteen" },
        //    {19, "Nineteen" },
        //    {20, "Twenty" },
        //    {30, "Thirty" },
        //    {40, "Forty" },
        //    {50, "Fifty" },
        //    {60, "Sixty" },
        //    {70, "Seventy" },
        //    {80, "Eighty" },
        //    {90, "Ninety" }
        //};
        //static int thousand = 1000;
        //private static string[] multiples_thousand = { "Thousand", "Million", "Billion" };

        //// TODO: Code can be cleaned up
        //// Tx = O(1)
        //// Sx = O(1)
        //public string NumberToWords(int num)
        //{
        //    result = new StringBuilder();

        //    if (num == 0)
        //    {
        //        return "Zero";
        //    }
        //    else if (num < 1000)
        //    {
        //        return HundredHelper(num);
        //    }
        //    else
        //    {
        //        int i = -1;
        //        while (num > 0)
        //        {
        //            int rem = num % thousand;
        //            num /= thousand;
        //            if (i >= 0 && rem > 0)
        //                result.Insert(0, HundredHelper(rem) + " " + multiples_thousand[i] + " ");
        //            else
        //                result.Append(HundredHelper(rem));

        //            i++;
        //        }
        //    }

        //    return result.ToString().Trim();
        //}

        //private string HundredHelper(int num)
        //{
        //    if (numbers_lt_100.ContainsKey(num))
        //        return numbers_lt_100[num];
        //    else
        //    {
        //        if (num >= 100)
        //            return numbers_lt_100[num / 100] + " Hundred" + (num % 100 == 0 ? "" : " ") + TenHelper(num % 100);
        //        else
        //            return TenHelper(num);
        //    }
        //}

        //private string TenHelper(int num)
        //{
        //    if (num > 0)
        //        if (numbers_lt_100.ContainsKey(num))
        //            return numbers_lt_100[num];
        //        else
        //            return numbers_lt_100[num - num % 10] + " " + numbers_lt_100[num % 10];
        //    else
        //        return string.Empty;
        //}
        #endregion
    }
}
