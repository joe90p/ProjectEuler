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
    }
}
