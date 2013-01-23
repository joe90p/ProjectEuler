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
            return MathsHelper.GetPythagTriplePerimeterCount(1000).
                OrderByDescending(x => x.Item2).
                First().Item1;
        }

        public int Problem40()
        {
            /*
            int x = 100;

            int mult = 1;
            int start = 9;
            int oldStart = start;
            while (x > start)
            {
                int thing = start * MathsHelper.Power(10, mult);
                mult++;
                oldStart = start;
                start = start + (thing*mult);
            }

            int num = x - oldStart - 1;
            int f = MathsHelper.Power(10, mult - 1) + (num/mult);
            int index = num%mult;

            int answer = Int32.Parse(f.ToString()[index].ToString());
            */

            //not mathematical
            var t = Enumerable.Range(1, 1000000).SelectMany(x => x.ToString()).ToArray();
            var indexes = Enumerable.Range(0, 7).Select(x => MathsHelper.Power(10, x));
            return indexes.Select(x => Int32.Parse(t[x - 1].ToString())).Product();

        }
    }
}
