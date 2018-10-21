using System;

namespace LeetcodeSolutions.String
{
    // Leetcdoe 165 - https://leetcode.com/problems/compare-version-numbers/description/
    // Submission Detail - https://leetcode.com/submissions/detail/184165156/

    public class CompareVersionNumbers
    {
        public static void Main(string[] args)
        {
            CompareVersionNumbers comp = new CompareVersionNumbers();
            Console.WriteLine(comp.CompareVersion("1.0.1", "1"));   // 1
            Console.WriteLine(comp.CompareVersion("01", "1"));      // -1

            Console.ReadKey();
        }

        public int CompareVersion(string version1, string version2)
        {
            string[] v1 = version1.Split('.');
            string[] v2 = version2.Split('.');

            int length = System.Math.Max(v1.Length, v2.Length);

            for (int index = 0; index < length; index++)
            {
                int num1 = index < v1.Length ? Convert.ToInt32(v1[index]) : 0;
                int num2 = index < v2.Length ? Convert.ToInt32(v2[index]) : 0;

                if (num1.CompareTo(num2) != 0)
                    return num1.CompareTo(num2);
            }

            return 0;
        }

        public int CompareVersion1(string version1, string version2)
        {
            int index = 0;

            int length1 = version1.Length, length2 = version2.Length;

            while (true)
            {
                if (index < length1 && (index >= length2 || version1[index] > version2[index]))
                    return 1;
                else if (index < length2 && (index >= length1 || version1[index] < version2[index]))
                    return -1;
                else
                    return 0;

                index += 2;
            }
        }
    }
}
