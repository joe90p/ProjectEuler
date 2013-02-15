using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public partial class Problems
    {

        public int Problem32()
        {
            return this.GetPerms(9).ToList().Select(ProductSum).SelectMany(x => x).Distinct().Sum();
        }

        public IEnumerable<int> ProductSum(IEnumerable<int> l)
        {
            for(int i = 0; i < 9; i++)
            {
                for (int j = i + 1; j < 9; j++)
                {
                    var num1 = MathsHelper.ConvertToDecimal(l.Take(i + 1));
                    var num2 = MathsHelper.ConvertToDecimal(l.Where((x, ix) => (ix > i) && ix <= j));
                    var eq = MathsHelper.ConvertToDecimal(l.Skip(j + 1));
                    if(num1 * num2 == eq)
                    {
                        yield return eq;
                    }

                }
            }
        }

        

        public IEnumerable<IEnumerable<int>> GetPerms(int n)
        {
            return this.GetPerms(1, n);

        }

        public IEnumerable<IEnumerable<int>> GetPerms(int min, int count)
        {
            var range = Enumerable.Range(min, count).Select(x => x.ToEnumerable());
            return range.Aggregate(Enumerable.Repeat(Enumerable.Empty<int>(), 1), PermAggregate);

        }

        IEnumerable<IEnumerable<int>> PermAggregate(IEnumerable<IEnumerable<int>> list, IEnumerable<int> toConcat)
        {
            foreach(var x in list)
            {
                var f = x.ToList();
                var i = 0;
                do
                {
                    yield return f.Take(i).Concat(toConcat).Concat(f.Skip(i));
                    i++;
                } while (i <= f.Count());
            }
        }
        public int Problem39()
        {
            return MathsHelper.GetPythagTriplePerimeterCount(1000).
                OrderByDescending(x => x.Item2).
                First().Item1;
        }

        public int Problem40()
        {
            
            int x = 1000000;

            int mult = 1;
            int start = 9;
            int oldStart = start;
            while (x > start)
            {
                int thing = 9 * MathsHelper.Power(10, mult);
                mult++;
                oldStart = start;
                start = start + (thing*mult);
            }

            int num = x - oldStart - 1;
            int f = MathsHelper.Power(10, mult - 1) + (num/mult);
            int index = num%mult;

            int answer = Int32.Parse(f.ToString()[index].ToString());
            return answer;
        }

        //not mathematical
        public int Problem40Alternative()
        {
            var t = Enumerable.Range(1, 1000000).SelectMany(x => x.ToString()).ToArray();
            var indexes = Enumerable.Range(0, 7).Select(x => MathsHelper.Power(10, x));
            return indexes.Select(x => Int32.Parse(t[x - 1].ToString())).Product();
        }
    }
}
