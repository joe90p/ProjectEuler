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

        public void Problem43()
        {
            var list = this.GetPerms(0,10).Select(x => new { Orig = x, Split = this.Split(x, 3) });
            var hmm = list.
                Select(x => new
                {
                    x.Orig,
                    Split = x.Split.Item2.
                            Aggregate(x.Split.Item1.ToEnumerable(), (y, i) => y.Concat(y.Last().Skip(1).Concat(i))).Skip(1)

                }
                            );
            var ooo = hmm.Select(x => new {x.Orig, Nums = x.Split.Select(MathsHelper.ConvertToDecimal)});
            var primes = MathsHelper.GetPrimesUpTo(17).ToList();
            var interesting = ooo.Where(x => x.Nums.Zip(primes, (a, b) => a % b).All(y => y == 0)).ToList();
            var thingy = interesting.Select(x => x.Orig.Reverse().ToList()).ToList();

            var pe = new ProjectEuler();
            var hello = pe.AddListRepresentingNumbers(thingy);


        }

        public Tuple<IEnumerable<T>, IEnumerable<T>>  Split<T>(IEnumerable<T> num, int splitPoint)
        {
            return Tuple.Create(num.Take(splitPoint), num.Skip(splitPoint));
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
