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

        public long Problem14()
        {
            long largestChainCount = 0;
            long numberWithLargestChainCount = 0;
            Dictionary<long, long> numberChainLength = new Dictionary<long, long>();
            Func<long, long> generator = n => n % 2 == 0 ? (n / 2) : (3 * n) + 1;
            for (long i = 1000000; i > 1; i--)
            {
                long chainCount = 1;
                long j = i;
                while (j > 1)
                {
                    j = generator(j);
                    if (numberChainLength.ContainsKey(j))
                    {
                        chainCount = chainCount + numberChainLength[j];
                        break;
                    }
                    else
                    {
                        chainCount++;
                    }
                }
                numberChainLength[i] = chainCount;
                if (chainCount > largestChainCount)
                {
                    largestChainCount = chainCount;
                    numberWithLargestChainCount = i;
                }
            }

            return numberWithLargestChainCount;
        }

        public void Problem15()
        {
            throw new NotImplementedException();
        }

        public int Problem16()
        {
            List<int> listRepresentingNumber = new List<int>();
            listRepresentingNumber.Add(1);

            for (int index = 1; index <= 1000; index++)
            {
                BigNumberHelper.MultiplyListRepresentingNumberVoid(listRepresentingNumber, 2);
            }

            int answer = listRepresentingNumber.Sum();
            return answer;
        }

        public int Problem17()
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
            return answer;
        }

        public long Problem18()
        {
            var ts = new TriangleSummer("C:\\Users\\Phil\\Documents\\GitHub\\ProjectEuler\\ProjectEuler\\Problems\\P18.txt");
            var answer = ts.FindMaxSumInTriangle();
            return answer;

        }

        public int Problem19()
        {
            const int sunday = 6;
            const int startYear = 1901;
            int nextStartingDay = 0;
            int sundaysOnFirstDayOfMonth = 0;

            Func<int,bool> isLeapYear = y => y % 4 == 0 && (y % 100 != 0 || y % 400 == 0);

            for (int i = 0; i < 99; i++)
            {
                int[] numberofDaysInMonthForYear = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                numberofDaysInMonthForYear[1] = isLeapYear(startYear + i) ? 29 : 28;
                foreach (int daysInMonth in numberofDaysInMonthForYear)
                {
                    nextStartingDay = nextStartingDay + daysInMonth % 7;
                    nextStartingDay = nextStartingDay >= 7 ? nextStartingDay - 7 : nextStartingDay;
                    if (nextStartingDay == sunday)
                    {
                        sundaysOnFirstDayOfMonth++;
                    }
                }
            }


            return sundaysOnFirstDayOfMonth;

        }

        public int Problem20()
        {
            int i = 100;
            List<int> num = BigNumberHelper.GetAsListRepresentingNumber(i);


            while (i > 1)
            {
                List<int> num2 = BigNumberHelper.GetAsListRepresentingNumber(i - 1);
                num = BigNumberHelper.MultiplyListRepresentingNumber(num, num2);
                i--;
            }

            int answer = num.Sum();
            return answer;
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
