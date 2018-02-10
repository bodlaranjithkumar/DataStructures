using System;
using System.Text;

namespace LeetcodeSolutions.Math
{
    //Leetcdoe 67
    public class AddBinary
    {
        //public static void Main(string[] args)
        //{
        //    AddBinary bin = new AddBinary();
        //    Console.WriteLine(bin.AddBinaryStrings("11", "1")); //100
        //    Console.WriteLine(bin.AddBinaryStrings("11", "11"));//110
        //    Console.WriteLine(bin.AddBinaryStrings("00", "00"));//00
        //    Console.WriteLine(bin.AddBinaryStrings("110", "1110"));//10100
        //    Console.WriteLine(bin.AddBinaryStrings("1", "1"));//10
        //    Console.WriteLine(bin.AddBinaryStrings("1", "1011"));//1100
        //    Console.WriteLine(bin.AddBinaryStrings("", "1011"));//1011
        //    Console.WriteLine(bin.AddBinaryStrings("1011", ""));//1011
        //    Console.WriteLine(bin.AddBinaryStrings("", ""));//

        //    Console.ReadKey();
        //}
        
        public string AddBinaryStrings(string a, string b)
        {
            if (a == null || b == null)
                return null;

            StringBuilder result = new StringBuilder(System.Math.Max(a.Length, b.Length) + 1);
            int i = a.Length - 1, j = b.Length - 1, carry = 0;

            while (i >= 0 || j >= 0 || carry == 1)
            {
                carry += i >= 0 ? a[i--] - '0' : 0;
                carry += j >= 0 ? b[j--] - '0' : 0;
                result.Insert(0, carry % 2);
                carry /= 2;
            }

            return result.ToString();
        }

        
        //public string AddBinaryStrings(string a, string b)
        //{
        //    if (a == null || b == null)
        //        return null;

        //    StringBuilder result = new StringBuilder();
        //    int i = a.Length-1, j = b.Length-1;
        //    char carry = '0';

        //    while(i >= 0 || j >= 0)
        //    {
        //        char c1 = i >= 0 ? a[i] : '0';
        //        char c2 = j >= 0 ? b[j] : '0';

        //        carry = Helper(c1, c2, carry, result);

        //        i--;
        //        j--;
        //    }

        //    if (carry == '1')
        //        result.Insert(0, carry);

        //    return result.ToString();
        //}

        //private static char Helper(char c1, char c2, char carry, StringBuilder result)
        //{
        //    if (c1 == '0' && c2 == '0')
        //    {
        //        result.Insert(0, carry == '1' ? '1' : '0');
        //        return '0';
        //    }
        //    else if ((c1 == '0' && c2 == '1') || (c1 == '1' && c2 == '0'))
        //    {
        //        if(carry == '1')
        //        {
        //            result.Insert(0, '0');
        //            return '1';
        //        }
        //        else
        //        {
        //            result.Insert(0, '1');
        //            return '0';
        //        }
        //    }
        //    else
        //    {
        //        result.Insert(0, carry);
        //        return '1';
        //    }
        //}
    }
}
