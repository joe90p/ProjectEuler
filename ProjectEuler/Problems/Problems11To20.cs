using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public partial class Problems
    {
        /*If the numbers 1 to 5 are written out in words: one, two, three, four, five, 
         * then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters 
         * would be used?

NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters 
         * and 115 (one hundred and fifteen) contains 20 letters. The use of "and" when writing out numbers 
         * is in compliance with British usage.*/

        public void Problem17()
        {
            var numbers = new Dictionary<int, string>
                              {
                                  {0, string.Empty},
                                  {1, "one"},
                                  {2, "two"},
                                  {3, "three"},
                                  {4, "four"},
                                  {5, "five"},
                                  {6, "six"},
                                  {7, "seven"},
                                  {8, "eight"},
                                  {9, "nine"},
                                  {10, "ten"},
                                  {11, "eleven"},
                                  {12, "twelve"},
                                  {13, "thirteen"},
                                  {14, "fourteen"},
                                  {15, "fifteen"},
                                  {16, "sixteen"},
                                  {17, "seventeen"},
                                  {18, "eighteen"},
                                  {19, "nineteen"},
                                  {20, "twenty"},
                                  {30, "thirty"},
                                  {40, "forty"},
                                  {50, "fifty"},
                                  {60, "sixty"},
                                  {70, "seventy"},
                                  {80, "eighty"},
                                  {90, "ninety"},
                                  {100, "hundred"},
                                  {1000, "thousand"}
                              };

            Func<int, string> getnumberLetterCount = x => GetNumberLetterCount(x, numbers);

            var hello = Enumerable.Range(1, 1000).Select(getnumberLetterCount).ToList();
            var answer = hello.Select(x => x.Count()).Sum();
        }

        public string GetNumberLetterCount(int x, Dictionary<int, string> numbers)
        {
            if (x <= 20)
            {
                return numbers[x];
            }
            if (x > 20 && x < 100)
            {
                return numbers[x / 10 * 10] + numbers[x % 10];
            }
            if (x >= 100 && x < 1000)
            {
                string toReturn = numbers[x / 100] + "hundred";
                if (x % 100 !=0)
                {
                    toReturn += "and" + GetNumberLetterCount(x - ((x / 100) * 100), numbers);
                }
                return toReturn;
            }
            if (x == 1000)
            {
                return "onethousand";
            }
            return string.Empty;
        }
    }
}
