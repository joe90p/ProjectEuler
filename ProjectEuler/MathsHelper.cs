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

        public static IEnumerable<int> GetPrimesUpTo(int limit)
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

        public static int gcd(int a, int b)
        {
            bool agreaterThanb = a > b;
            int y = agreaterThanb ? b : a;
            int x = agreaterThanb ? a : b;

            while (x % y != 0)
            {
                int temp = x;
                x = y;
                y = temp % x;
            }
            return y;
        }

        public static IEnumerable<int> GetFactors(int n)
        {
            yield return 1;
            int count = 0;
            bool squareFlag = false;
            int upperLimit = (int)Math.Ceiling(Math.Sqrt((double)n));
            for (int x = 2; x <= upperLimit; x++)
            {
                if (n % x == 0)
                {
                    yield return x;
                    yield return n/x;
                }
            }
        }


        public static IEnumerable<Tuple<int, int>> GetPythagTriplePerimeterCount(int upToPerimeter)
        {
            var perimetersOfPrimitivePythagoreanTriplets = GetPerimetersOfPrimitivePythagoreanTriplets(upToPerimeter).
                Select(x => GetAllMultiplesUpTo(x, upToPerimeter)).
                SelectMany(x => x).
                GroupBy(x => x);
            return perimetersOfPrimitivePythagoreanTriplets.Select(x => Tuple.Create(x.Key, x.Count()));
        }

        private static IEnumerable<int> GetAllMultiplesUpTo(int x, int upTo)
        {
            int i = 1;
            while (i * x < upTo)
            {

                yield return i * x;
                i++;
            }
        }

        private static IEnumerable<int> GetPerimetersOfPrimitivePythagoreanTriplets(int s)
        {
            //generate coprime m,n with exactly one m,n even
            int m = 2;
            int n = 1;
            int mlimit = (int)Math.Sqrt(s / 2);

            while (m <= mlimit)
            {
                n = m % 2 == 0 ? 1 : 2;
                while (n < m)
                {
                    if (MathsHelper.gcd(m, n) == 1)
                    {
                        yield return (2 * m * (m + n));
                    }
                    n += 2;
                }
                m++;
            }
        }
    }
}
