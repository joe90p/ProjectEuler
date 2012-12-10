using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public partial class Problems
    {
        public int Problem1()
        {
            return Enumerable.Range(1, 999).Where(x => x % 3 == 0 || x % 5 == 0).Sum();
        }

        public int Problem2()
        {
            return MathsHelper.GetFibonacciSequenceUpTo(4000000).Where(x => x % 2 == 0).Sum();
        }

        public long Problem3()
        {
            long number = 600851475143;
            List<long> primes = new List<long>();

            for (long i = 2; i <= Math.Pow(number, 0.5); i++)
            {
                if (number % i == 0)
                {
                    long otherDivisor = number / i;
                    if (MathsHelper.IsPrime(i))
                    {
                        primes.Add(i);
                    }
                    else
                    {
                        if (MathsHelper.IsPrime(otherDivisor))
                        {
                            return otherDivisor;
                        }
                    }
                }
            }

            primes.Reverse();

            return primes[0];
        }

        public int Problem4()
        {
            List<int> palindromes = new List<int>();
            int num = 999;
            for (int i = num; i >= 100; i--)
            {
                for (int j = i; j >= 100; j--)
                {
                    if (SequenceHelper.IsPalindrome(j * i))
                    {
                        palindromes.Add(j * i);
                    }
                }
            }
            palindromes.Sort();
            palindromes.Reverse();
            return palindromes[0];
        }

        public int Problem6()
        {
            int result = 0;
            int number = 100;
            for (int i = 1; i <= number; i++)
            {
                for (int j = i + 1; j <= number; j++)
                {
                    result = result + (i * j);
                }
            }
            return (2 * result);
        }

        public int Problem7()
        {
            return this.TheNthPrimeIs(10001);
        }

        public int Problem8()
        {
            int biggestProduct = 0;

            string number = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
            for (int i = 0; i <= number.Length - 5; i++)
            {
                int currentProduct = 1;
                for (int j = 0; j < 5; j++)
                {
                    currentProduct = currentProduct * Int32.Parse(number[i + j].ToString());
                }
                if (currentProduct > biggestProduct)
                {
                    biggestProduct = currentProduct;
                }
            }

            return biggestProduct;
        }

        public int Problem9()
        {
            for (int c = 0; c < 500; c++)
            {
                int aPlusB = 1000 - c;
                if (aPlusB <= 500)
                {
                    break;
                }
                else
                {
                    int product;
                    if (IsPythagoreanTriplet(aPlusB, c, out product))
                    {
                        return product;
                    }
                }
            }
            return 0;
        }

        private bool IsPythagoreanTriplet(int aPlusB, int c, out int product)
        {
            product = 0;
            for (int a = 1; aPlusB - a >= a; a++)
            {
                int b = aPlusB - a;
                if (b - a <= 500)
                {
                    if ((a * a) + (b * b) == (c * c))
                    {
                        product = a * b * c;
                        return true;
                    }
                }
            }
            return false;
        }

        public long Problem10()
        {
            Func<long,int,long> func = (l,i) => l+i;
            return MathsHelper.GetPrimes(2000000).Aggregate(0, func); 
        }

        public int TheNthPrimeIs(int whichNumerPrime)
        {
            int i = 1;
            int numberToTest = 3;
            while (i < whichNumerPrime)
            {
                if (MathsHelper.IsPrime(numberToTest))
                {
                    i++;
                }
                numberToTest++;
            }
            return numberToTest - 1;
        }
    }
}
