using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler

{
    public partial class Problems
    {
        public int Problem41()
        {
            var primes = MathsHelper.GetPrimesUpTo(987654321);
            return primes.Last(this.IsPandigital);

        }

        public bool IsPandigital(int n)
        {
            var x = this.SplitNumber(n).OrderBy(y => y).ToList();
            return x.SequenceEqual(Enumerable.Range(1, x.Count));
        }

        public IEnumerable<int> SplitNumber(int n)
        {
            while (n > 0)
            {
                yield return n % 10;
                n /= 10;
            }
        }
    }
}
