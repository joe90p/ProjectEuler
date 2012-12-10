using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public class MathsHelper
    {
        public static bool IsPrime(long numberToTest)
        {
            if (numberToTest == 1)
            {
                return false;
            }
            if (numberToTest == 2)
            {
                return true;
            }
            if (numberToTest % 2 == 0)
            {
                return false;
            }
            for (int j = 3; j <= Math.Pow(numberToTest, 0.5); j = j + 2)
            {
                if (numberToTest % j == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static int Power(int exponent, int index)
        {
            int result = 1;
            for (int i = 0; i < index; i++)
            {
                result = result * exponent;
            }
            return result;
        }
    }
}
