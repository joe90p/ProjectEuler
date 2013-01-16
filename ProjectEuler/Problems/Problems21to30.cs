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
        public void Problem22()
        {
            string[] fileLines = File.ReadAllLines("C:\\Phil\\PE\\ProjectEuler\\ProjectEuler\\Problems\\names.txt");
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

            var answer =
                lines.First().
                OrderBy(x => x).
                Select((x, i) => x.Select(l => letterValues[l]).Sum()*(i + 1)).
                Sum();
        }

        public void Problem23()
        {
            var range = Enumerable.Range(1, 28123);
            var tuples = range.
                            Select(x => Tuple.Create(x, MathsHelper.GetFactors(x).Distinct().Sum())).
                            ToList();
            var abundents = tuples.Where(x => x.Item2 > x.Item1).Select(x => x.Item1).Where(x => x <= 28123).Skip(1).ToList();
            var abundentSums = abundents.SelectMany(x => abundents, (x, y) => x + y).Distinct().Where(x => x <= 28123).OrderBy(x=> x).ToList();
            int tot = (28123*28124/2);
            int answer = tot - abundentSums.Sum();
        }
    }
}
