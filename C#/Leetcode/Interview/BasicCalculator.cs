using System;

namespace LeetcodeSolutions.Interview
{
    public class BasicCalculator
    {
        //string expression1 = "6+9-12"; // = 3
        //string expression2 = "1+2-3+4-5+6-7"; // = -2
        //string expression3 = "1000-1000"; // = 0
        //string expression4 = "255"; // = 255

        // Tx = O(n)
        // Sx = O(1)

        public static int Calculate(string expression)
        {
            int op1 = 0, op2 = 0;
            char plusOrMinus = ' ';

            for (int i = 0; i < expression.Length;)
            {
                char c = expression[i];

                if (c == '+' || c == '-')
                {
                    plusOrMinus = c;
                    i++;
                }
                else if (char.IsDigit(c))
                {
                    while (i < expression.Length && char.IsDigit(expression[i]))
                    {
                        c = expression[i];

                        if (plusOrMinus == ' ')
                        {
                            op1 = (op1 * 10) + (c - '0');
                        }
                        else
                        {
                            op2 = (op2 * 10) + (c - '0');
                        }

                        i++;
                    }
                }

                if ((op1 != 0 || (op1 == 0 && plusOrMinus != ' ')) && op2 != 0)
                {
                    if (plusOrMinus == '+')
                        op1 = op1 + op2;
                    else if (plusOrMinus == '-')
                        op1 = op1 - op2;

                    plusOrMinus = ' ';
                    op2 = 0;
                }
            }

            return op1;
        }
    }
}
