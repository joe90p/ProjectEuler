using System;
using System.Collections.Generic;
using System.IO;
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

        public int Problem42()
        {
            string[] fileLines = File.ReadAllLines("C:\\Phil\\PE\\ProjectEuler\\ProjectEuler\\Problems\\words.txt");
            var lines = fileLines.Select(l => l.Split(',').Select(x => x.Replace("\"", string.Empty)));
            var letterValues = new Dictionary<char, int>
                                   {
                                       {'A', 1},
                                       {'B', 2},
                                       {'C', 3},
                                       {'D', 4},
                                       {'E', 5},
                                       {'F', 6},
                                       {'G', 7},
                                       {'H', 8},
                                       {'I', 9},
                                       {'J', 10},
                                       {'K', 11},
                                       {'L', 12},
                                       {'M', 13},
                                       {'N', 14},
                                       {'O', 15},
                                       {'P', 16},
                                       {'Q', 17},
                                       {'R', 18},
                                       {'S', 19},
                                       {'T', 20},
                                       {'U', 21},
                                       {'V', 22},
                                       {'W', 23},
                                       {'X', 24},
                                       {'Y', 25},
                                       {'Z', 26}
                                   };

            var isTriangle = this.IsTriangle();

            var answer =
                lines.First().
                OrderBy(x => x).
                Select((x, i) => x.Select(l => letterValues[l]).Sum()).
                Count(isTriangle);

            return answer;
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


            var hello = BigNumberHelper.AddListRepresentingNumbers(thingy);


        }

        public Func<int, bool> IsTriangle()
        {
            var t = Tuple.Create(1, 1);
            var triangles = new HashSet<int> { 1};
            return x =>
                                        {
                                            while (x > t.Item2)
                                            {
                                                var newCount = t.Item2 + 1;
                                                var newT = t.Item1 + newCount;
                                                triangles.Add(newT);
                                                t = Tuple.Create(newT, newCount);
                                            }
                                            return triangles.Contains(x);
                                        };

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
