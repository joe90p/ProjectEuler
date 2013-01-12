using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public partial class Problems
    {
        public int Problem39()
        {
            var perimetersOfPrimitivePythagoreanTriplets = this.GetPerimetersOfPrimitivePythagoreanTriplets().
                Select(x => GetAllMultiplesUpTo(x, 1000)).
                SelectMany(x => x).
                GroupBy(x => x);
            var result = perimetersOfPrimitivePythagoreanTriplets.
                Select(x => Tuple.Create(x.Key, x.Count())).
                OrderByDescending(x => x.Item2);
            return result.First().Item1;

        }

        private IEnumerable<int> GetAllMultiplesUpTo(int x, int upTo)
        {
            int i = 1;
            while (i * x < upTo)
            {

                yield return i * x;
                i++;
            }
        }

        private IEnumerable<int> GetPerimetersOfPrimitivePythagoreanTriplets()
        {
            //generate coprime m,n with exactly one m,n even
            int m = 2;
            int n = 1;
            int s = 1000;
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
