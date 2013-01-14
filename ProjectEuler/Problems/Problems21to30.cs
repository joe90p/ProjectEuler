using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public partial class Problems
    {
        public void Problem23()
        {
            var range = Enumerable.Range(1, 28123);
            var tuples = range.Select(x => Tuple.Create(x, MathsHelper.GetFactors(x).Distinct().Sum())).ToList();
            var abundents = tuples.Where(x => x.Item2 > x.Item1).Select(x => x.Item1).Where(x => x <= 28123).Skip(1).ToList();
            var abundentSums = abundents.SelectMany(x => abundents, (x, y) => x + y).Distinct().Where(x => x <= 28123).OrderBy(x=> x).ToList();
            int tot = (28123*28124/2);
            int answer = tot - abundentSums.Sum();
        }
    }
}
