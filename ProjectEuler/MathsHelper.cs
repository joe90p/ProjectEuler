using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

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

        public static bool IsPrime(int numberToTest)
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

        public static IEnumerable<int> GetFibonacciSequenceUpTo(int limit)
        {
            int current = 1;
            int previous = 0;
            while (current <= limit)
            {
                int sum = current + previous;
                previous = current;
                current = sum;
                yield return sum;
            }
        }

        public static IEnumerable<int> GetPrimes(int limit)
        {
            int start = 2;
            BitArray compositeArray = new BitArray(limit - start + 1, true);
            for (int i = start; i <= limit; i++)
            {
                if (compositeArray[i - start])
                {
                    int x = i;
                    while (x <= limit)
                    {
                        compositeArray[x - start] = false;
                        x += i;
                    }
                    yield return i;
                }
            }
        }
    }
}
