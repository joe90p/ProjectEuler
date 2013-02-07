using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public partial class Problems
    {
        public void Problem32()
        {
            var f = Enumerable.Repeat(Enumerable.Range(1, 9), 9);
            //f.Aggregate(Enumerable.Empty<IEnumerable<int>>(), (x,y) => x.SelectMany(x => y, (a,b) => a.Contai) )

        }
        public int Problem39()
        {
            return MathsHelper.GetPythagTriplePerimeterCount(1000).
                OrderByDescending(x => x.Item2).
                First().Item1;
        }

        public void GetPerms()
        {
            var x = Enumerable.Repeat(Enumerable.Empty<int>(), 1);
            for(int i = 1; i < 10; i++)
            {
                x = x.Select(r => r.SelectMany(r => Enumerable.Range(1, 9)) r.Concat(.Where(y => !r.Contains(y))));
                
            }
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
