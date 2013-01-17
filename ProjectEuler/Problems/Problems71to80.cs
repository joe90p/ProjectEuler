using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public partial class Problems
    {
        public int Problem75()
        {
            return MathsHelper.GetPythagTriplePerimeterCount(1500000).
                Count(x => x.Item2 == 1);
        }
    }
}
