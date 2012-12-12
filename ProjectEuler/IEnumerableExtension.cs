using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> list, T tackOn)
        {
            return list.Concat(tackOn.ToEnumerable());
        }

        public static IEnumerable<T> ToEnumerable<T>(this T thing)
        {
            return new T[] { thing};
        }

        public static int Product(this IEnumerable<int> list)
        {
            return list.Aggregate(1, (x, y) => x*y);
        }
    }
}
