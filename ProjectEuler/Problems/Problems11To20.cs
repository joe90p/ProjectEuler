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

        public void Problem11()
        {
            //Not sure what has happened to the solution to this??
        }

        public int Problem12()
        {
            int numberOfFactors = 0;
            int n = 0;
            int triangle = 0;

            while (numberOfFactors < 500)
            {
                n++;
                triangle += n;
                numberOfFactors = MathsHelper.NumberOfFactors(triangle);
            }

            return triangle;
        }

        public IEnumerable<int> Problem13()
        {
            var list = new List<List<int>>();
            var fileLines = File.ReadAllLines("C:\\Phil\\PE\\ProjectEuler\\ProjectEuler\\Problems\\BigNumbers.txt").ToList();
            var nums = fileLines.Select(BigNumberHelper.GetAsListRepresentingNumber).ToList();
            return BigNumberHelper.AddListRepresentingNumbers(nums).ToArray().Reverse().Take(10);
        }

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
            return x == 1000 ? "onethousand" : string.Empty;
        }
    }
}
