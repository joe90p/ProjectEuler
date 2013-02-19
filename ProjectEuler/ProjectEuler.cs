using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace ProjectEuler
{
    public class ProjectEuler
    {
        public long Problem14()
        {
            long largestChainCount = 0;
            long numberWithLargestChainCount = 0;
            Dictionary<long, long> numberChainLength = new Dictionary<long, long>();
            for (long i = 1000000; i > 1; i--)
            {
                long chainCount = 1;
                long j = i;
                while (j > 1)
                {
                    j = this.GeneratorProblem14(j);
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

        private long GeneratorProblem14(long n)
        {
            return n % 2 == 0 ? (n / 2) : (3 * n) + 1;
        }

        public void ProblemSixteen()
        {
            List<int> listRepresentingNumber = new List<int>();
            listRepresentingNumber.Add(1);

            for (int index = 1; index <= 1000; index++)
            {
                BigNumberHelper.MultiplyListRepresentingNumberVoid(listRepresentingNumber, 2);
            }

            int answer = listRepresentingNumber.Sum();
        }

        public void ProblemSeventeen()
        {
            Dictionary<int, int> intsAsString = new Dictionary<int, int>();
            intsAsString.Add(1, 3);
            intsAsString.Add(2, 3);
            intsAsString.Add(3, 5);
            intsAsString.Add(4, 4);
            intsAsString.Add(5, 4);
            intsAsString.Add(6, 3);
            intsAsString.Add(7, 5);
            intsAsString.Add(8, 5);
            intsAsString.Add(9, 4);
            intsAsString.Add(10, 3);
            intsAsString.Add(11, 6);
            intsAsString.Add(12, 6);
            intsAsString.Add(13, 8);
            intsAsString.Add(14, 8);
            intsAsString.Add(15, 7);
            intsAsString.Add(16, 7);
            intsAsString.Add(17, 9);
            intsAsString.Add(18, 8);
            intsAsString.Add(19, 8);

            //tens
            Dictionary<int, int> tensAsString = new Dictionary<int, int>();
            tensAsString.Add(2, 6);
            tensAsString.Add(3, 6);
            tensAsString.Add(4, 5);
            tensAsString.Add(5, 5);
            tensAsString.Add(6, 5);
            tensAsString.Add(7, 7);
            tensAsString.Add(8, 6);
            tensAsString.Add(9, 6);

            int test = 1234;
            int runningTotal = 0;
            List<int> number = BigNumberHelper.GetAsListRepresentingNumber(test);

            if (number.Count == 4)
            {
                runningTotal += 11;
            }

            if (number.Count == 3)
            {
                runningTotal += (intsAsString[number[2]] + 7);
                if (number[1] == 0 && number[0] == 0)
                {

                }
            }

            if (number.Count == 2)
            {
                int asInt = number[1] * 10 + number[0];
                if (asInt <= 19)
                {
                    runningTotal += intsAsString[asInt];
                }
                else
                {
                    if (number[0] == 0)
                    {
                        runningTotal += tensAsString[number[1]];
                    }
                    else
                    {
                        runningTotal += tensAsString[number[1]] + intsAsString[number[0]];
                    }
                }

            }

            if (number.Count == 1)
            {
                runningTotal += intsAsString[number[0]];
            }


        }

        public long Problem18()
        {
            return this.FindMaxSumInTriangle("C:\\Euler18.txt");
        }

        public int Problem19()
        {
            int monthStartingDay = 0; //Monday = 0, Tuesday = 1 etc
            int sunday = 6;
            int startYear = 1901;
            int year = 0;
            int nextStartingDay = 0;
            int sundaysOnFirstDayOfMonth = 0;



            for (int i = 0; i < 99; i++)
            {
                int[] numberofDaysInMonthForYear = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                numberofDaysInMonthForYear[1] = this.IsLeapYear(startYear + i) ? 29 : 28;
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

        public void ProblemTwenty()
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
        }

        public List<int> Problem24()
        {
            return this.GetLexicographicPermutation(10, 1000000);
        }

        public int Problem25()
        {
            List<int> result = new List<int>();
            List<int> prevprev = BigNumberHelper.GetAsListRepresentingNumber(1);
            List<int> prev = BigNumberHelper.GetAsListRepresentingNumber(1);
            int n = 2;
            while (result.Count() < 1000)
            {
                result = BigNumberHelper.AddListRepresentingNumbers(prevprev, prev);
                prevprev = prev;
                prev = result;
                n++;
            }
            return n;
        }

        public long Problem28()
        {
            int n = 1;
            long value = 1;
            long count = 1;

            while (n < 2001)
            {
                value = value + (2 * ((n + 3) / 4));
                count += value;
                n++;
            }

            return count;

        }

        public long Problem67()
        {
            return this.FindMaxSumInTriangle("C:\\Euler67.txt");
        }

        public bool IsLeapYear(int year)
        {
            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }

        private List<int> GetLexicographicPermutation(int totalPermutationLength, int permutationIndex)
        {
            List<int> numberList = new List<int>();
            List<int> result = new List<int>();

            for (int i = 0; i < totalPermutationLength; i++)
            {
                numberList.Add(i);
            }

            while (totalPermutationLength > 0)
            {
                int x = this.Factorial(totalPermutationLength - 1);
                int q = (permutationIndex - 1) / x;
                q = q < 0 ? 0 : q;
                result.Add(numberList[q]);
                numberList.RemoveAt(q);
                permutationIndex = permutationIndex - (q * x);
                totalPermutationLength--;
            }

            return result;
        }

        private long FindMaxSumInTriangle(string filePath)
        {
            List<List<long>> triangle = new List<List<long>>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    List<long> numbers = new List<long>();
                    string[] triangleLine = line.Split(' ');
                    foreach (string numString in triangleLine)
                    {
                        string trimmedNumString = numString.TrimStart('0');
                        long num = Int64.Parse(trimmedNumString);
                        numbers.Add(num);
                    }
                    triangle.Add(numbers);
                }
            }

            for (int i = triangle.Count - 2; i >= 0; i--)
            {
                for (int j = 0; j < triangle[i].Count; j++)
                {
                    long multiplier = Math.Max(triangle[i + 1][j], triangle[i + 1][j + 1]);
                    triangle[i][j] += multiplier;
                }
            }

            return triangle[0][0];
        }

        

        

        private int Factorial(int n)
        {
            return n <= 1 ? 1 : n * this.Factorial(n - 1);
        }

        public void Problem27()
        {
            Dictionary<long, bool> isPrimeDict = new Dictionary<long, bool>();
            long maxConsecutive = 0;
            Tuple<long, long> coeffs;

            for (long a = -500; a < 500; a++)
            {
                long aValue = (2 * a) + 1;
                for (long b = -500; b < 500; b++)
                {
                    long bValue = (2 * b) + 1;
                    //bool resultPrime = true;
                    while (true)
                    {
                        long quadValue = this.GetQuadraticValue(aValue, bValue, 0);
                        if (!isPrimeDict.ContainsKey(quadValue))
                        {
                            bool isPrime = MathsHelper.IsPrime(quadValue);
                            isPrimeDict.Add(quadValue, isPrime);
                        }
                        if (isPrimeDict[quadValue])
                        {
                            maxConsecutive++;
                            coeffs = Tuple.Create(aValue, bValue);
                        }
                        else
                        {
                            break;
                        }
                    }

                }
            }
        }

        public int Problem36()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var binomialExpansionDictionary = GetBinomialExpansionLevelDictionary(10);
            Func<int, bool> valid = i => i < 1000000 && IsPalindrome(i.ToString());
            int rollingTotal = 1;
            foreach (var kvp in binomialExpansionDictionary)
            {
                Func<int, int, IEnumerable<int>> g = ExpandPalindromicIndexEven;
                Func<int, int, IEnumerable<int>> h = ExpandPalindromicIndexOdd;
                var p = ApplyPartial(g, kvp.Key);
                var q = ApplyPartial(h, kvp.Key);
                foreach (var r in kvp.Value)
                {
                    IEnumerable<int> th = new int[] { Increase(r, p), Increase(r, q), Increase(r, q) + MathsHelper.Power(2, kvp.Key + 1) };
                    foreach (var x in th)
                    {
                        if (valid(x))
                        {
                            rollingTotal += x;
                        }
                    }
                }
            }
            sw.Stop();
            return rollingTotal;
        }

        public int Problem36Alternative()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var answer = GetEnumerable(1000000).Sum(x => IsPalindrome(x.ToString()) && IsPalindrome(Convert.ToString(x, 2)) ? x : 0);
            sw.Stop();
            return answer;
        }


        public int Increase(IEnumerable<int> list, Func<int, IEnumerable<int>> func)
        {
            return list.Select(func).Select(PowerUp).Sum();
        }

        public int PowerUp(IEnumerable<int> t)
        {
            int result = 0;
            foreach (int i in t)
            {
                result += MathsHelper.Power(2, i);
            }
            return result;
        }

        public IEnumerable<int> ExpandPalindromicIndexEven(int level, int n)
        {
            return new int[] { level + n + 1, level - n };
        }

        public IEnumerable<int> ExpandPalindromicIndexOdd(int level, int n)
        {
            return new int[] { level + n + 2, level - n };
        }

        public Dictionary<int, IEnumerable<IEnumerable<int>>> GetBinomialExpansionLevelDictionary(int expansionLevel)
        {
            IEnumerable<IEnumerable<int>> x = new IEnumerable<int>[] { GetEnumerable(0) };
            var toExpand = x;
            int counter = 0;
            Dictionary<int, IEnumerable<IEnumerable<int>>> treeLevelDictionary = new Dictionary<int, IEnumerable<IEnumerable<int>>>();
            treeLevelDictionary.Add(0, x);
            while (counter < expansionLevel)
            {
                counter++;
                toExpand = Expand(toExpand);
                treeLevelDictionary.Add(counter, toExpand);
            }
            return treeLevelDictionary;
        }

        public IEnumerable<IEnumerable<int>> Expand(IEnumerable<IEnumerable<int>> input)
        {
            return input.SelectMany(x => Expand(x));
        }

        public IEnumerable<IEnumerable<int>> Expand(IEnumerable<int> input)
        {
            int inputLength = input.Count();
            var last = new int[] { input.Last() + 1 };
            var x = input.TakeWhile((e, i) => i < inputLength - 1).Concat(last);
            var y = input.Concat(last);
            return new IEnumerable<int>[] { x, y };
        }

        public IEnumerable<int> GetEnumerable(int m)
        {
            for (int i = 0; i <= m; i++)
            {
                yield return i;
            }
        }

        private long GetQuadraticValue(long a, long b, long n)
        {
            return (n * (a + n)) + b;
        }

        private static Func<T2, TResult> ApplyPartial<T1, T2, TResult>(Func<T1, T2, TResult> function, T1 arg1)
        {
            return x => function(arg1, x);
        }

        public bool IsPalindrome(string x)
        {
            return x.SequenceEqual(x.Reverse());
        }

        public int Problem29()
        {
            int min = 2;
            int max = 100;
            Func<int, int> func = x => Enumerable.Range(1, x).Select(y => GetMultipleSequence(y, min, max)).SelectMany(y => y).GroupBy(y => y).Count();
            var higherPowers = GetHighPowers(max);
            var mult = (max - min + 1);
            var answer = (mult * (mult - higherPowers.Sum())) + higherPowers.Select(func).Sum();
            return answer;
        }

        public int Problem37()
        {
            var truncatable = new Dictionary<int, IEnumerable<IEnumerable<int>>>();
            IEnumerable<IEnumerable<int>> choices = new int[][] { new int[] { 1 }, new int[] { 3 }, new int[] { 7 }, new int[] { 9 } };
            var tailElements = new HashSet<int>(new int[] { 3, 7 });
            //var primes = new HashSet<int>(GetPrimesUpTo(1000000000));

            //primes.

            Func<IEnumerable<int>, int> getNumber = list => list.Reverse().Select((i, j) => i * MathsHelper.Power(10, j)).Sum();
            Func<IEnumerable<int>, IEnumerable<IEnumerable<int>>> getRLSubsets = list => list.Select((i, j) => list.Skip(j));

            truncatable.Add(1, new int[][] { new int[] { 2 }, new int[] { 3 }, new int[] { 5 }, new int[] { 7 } });


            for (int q = 2; q < 20; q++)
            {
                truncatable[q] = truncatable[q - 1].SelectMany(p => choices, (r, t) => r.Concat(t));
                truncatable[q] = truncatable[q].Where(x => MathsHelper.IsPrime((long)getNumber(x))).ToList();
                truncatable[q - 1] = truncatable[q - 1].Where(x => getRLSubsets(x).Select(getNumber).All(y => MathsHelper.IsPrime((long)y)));
                if (truncatable[q - 1].Count() == 0)
                {
                    truncatable[q] = new List<IEnumerable<int>>();
                    break;
                }
            }

            var tyy = truncatable.Where(x => x.Key >= 2).Select(x => x.Value).Select(x => x.Select(getNumber)).SelectMany(x => x).Sum();


            IEnumerable<int> test = Enumerable.Range(1, 4);
            var hg = test.Select((i, j) => test.Skip(j));



            return 0;
        }

        public IEnumerable<int> GetHighPowers(int n)
        {
            int start = 2;
            BitArray array = new BitArray(n - start + 1, true);
            for (int i = start; i <= n; i++)
            {
                if (array[i - start])
                {
                    int counter = 1;
                    int x = i * i;
                    while (x <= n)
                    {
                        array[x - start] = false;
                        counter++;
                        x *= i;
                    }
                    if (counter == 1)
                    {
                        break;
                    }
                    yield return counter;
                }
            }
        }

        

        private IEnumerable<int> GetMultipleSequence(int n, int minPower, int maxPower)
        {
            for (int i = minPower * n; i <= n * maxPower; i += n)
            {
                yield return i;
            }
        }


        /// <summary>
        /// To get the upper limit we note that a number with n digits cannot have a digit factorial sum greater n * factorial(9).
        /// We can propose an upper limit of 10^7 (this is an n-digit number greater than n * factorial(9)).
        /// 
        /// We can then show by induction that for all k > 10^7 that k > digitfacorialsum(k)
        /// 
        /// Result is true for k = 10^7
        /// 
        /// Assume true up to some k > 10^7
        /// 
        /// we know digitfactorialsum(k+1) is less than n * factorial(9)
        /// 
        /// Therefore k +1 > k > n * factorial(9) > digitfactorialsum(k+1)
        /// Therefore k+1 >  digitfactorialsum(k+1). QED.
        /// </summary>
        public void Problem34()
        {
            var answer = DigitSumEqual(MathsHelper.Power(10, 7), this.Factorial);
        }

        /// <summary>
        /// To get the upper limit see the comments for problem 34.
        /// </summary>
        public void Problem30()
        {
            var answer = DigitSumEqual(MathsHelper.Power(10, 6), x => MathsHelper.Power(x, 5));
        }

        public int DigitSumEqual(int upperLimit, Func<int, int> digitMap)
        {
            var digitMapLookup = new KeyValueMap<int, int>(digitMap);
            Func<IEnumerable<int>, int> digitSum = xs => xs.Select(digitMapLookup.GetValue).Sum();
            return Enumerable.Range(10, upperLimit)
                                .Select(x => new { Num = x, ListNum = BigNumberHelper.GetAsListRepresentingNumber(x) })
                                .Where(x => x.Num == digitSum(x.ListNum))
                                .Sum(x => x.Num);
        }

        public void Coins()
        {
            int number = 0;
            Action adder = () => number++;
            int[] coins = { 1, 2 };
            var node = new Node(coins, null, () => { }, adder, 0);

        }

        /*public void Coins2()
        {
            int targetAmount = 200;
            int answer = 0;
            IEnumerable<IEnumerable<int>> coins = new int[][] { 
                                                                new int[] { 1 }, 
                                                                new int[] { 2 },
                                                                new int[] { 5 },
                                                                new int[] { 10 },
                                                                new int[] {20},
                                                                new int[] {50},
                                                                new int[] {100},
                                                                new int[] {200}};
            var toFold = Enumerable.Repeat(coins, targetAmount);


            Func<IEnumerable<IEnumerable<int>>, IEnumerable<IEnumerable<int>>, IEnumerable<IEnumerable<int>>> hmmm = (l1, l2) => Accumulator(l1, l2, targetAmount, i => answer += i);
            var xhg = toFold.Aggregate(hmmm);

        }

        private IEnumerable<IEnumerable<int>> Accumulator(IEnumerable<IEnumerable<int>> l1, IEnumerable<IEnumerable<int>> l2, int totalToFind, Action<int> adder)
        {
            var toReturn = l1.SelectMany(x => l2.Where(y => y.First() >= x.Last()).Select(y => x.Concat(y)));
            adder(toReturn.Count(x => x.Sum() == totalToFind));
            return toReturn.Where(x=> x.Sum() < totalToFind).ToList();

        }*/

        public void Coins2()
        {
            int targetAmount = 200;
            int answer = 0;
            IEnumerable<Tuple<int, int>> coins = (new int[] { 1, 2, 5, 10, 20, 50, 100, 200 }).Select(x => Tuple.Create(x, x));
            var toFold = Enumerable.Repeat(coins, targetAmount);


            Func<IEnumerable<Tuple<int, int>>, IEnumerable<Tuple<int, int>>, IEnumerable<Tuple<int, int>>> hmmm = (l1, l2) => Accumulator(l1, l2, targetAmount, i => answer += i);
            var xhg = toFold.Aggregate(hmmm);

        }

        private IEnumerable<Tuple<int, int>> Accumulator(IEnumerable<Tuple<int, int>> l1, IEnumerable<Tuple<int, int>> l2, int totalToFind, Action<int> adder)
        {
            counter++;
            var toReturn = l1.SelectMany(x => l2.Where(y => y.Item1 >= x.Item1).Select(y => Tuple.Create(y.Item1, x.Item2 + y.Item1)));
            adder(toReturn.Count(x => x.Item2 == totalToFind));
            Func<int, int, int, bool> test = (s, t, u) => s < u || ((s >= u) && ((totalToFind - t) % u) == 0);
            return toReturn.Where(x => x.Item2 < totalToFind).Where(x => test(x.Item1, x.Item2, 5)).Where(x => test(x.Item1, x.Item2, 10)).ToList();

        }

        static int counter = 0;

        public void Problem97()
        {
            var q = Enumerable.Repeat(2, 7830457);
            var rt = q.Aggregate(Enumerable.Repeat<int>(1, 1).ToList(), (x, y) => BigNumberHelper.MultiplyListRepresentingNumber(x, y, 10));

            //MultiplyListRepresentingNumberVoid(rt, 28433);
            var d = BigNumberHelper.GetAsListRepresentingNumber(28433);

            var s = BigNumberHelper.MultiplyListRepresentingNumber(rt, d);


        }

        public void Problem99()
        {
            var lines = File.ReadAllLines("C:\\Phil\\prob99.txt");
            var linesSplit = lines.Select(x => x.Split(','));
            double valMax = 0.0;
            //Tuple<double, double> blahhh;
            int i = 0;
            int maxLine = 0;
            foreach (var splitLine in linesSplit)
            {
                double b = Double.Parse(splitLine[0]);
                double index = Double.Parse(splitLine[1]);

                double valTemp = index * Math.Log(b);
                if (valTemp > valMax)
                {
                    valMax = valTemp;
                    maxLine = i;
                }
                i++;
            }
        }

        public IEnumerable<Tuple<T, T>> GetDiagonal<T>(IEnumerable<T> list)
        {
            var reversed = list.Reverse();
            return list.Zip(reversed, Tuple.Create);
        }

        /*public void ConcealedSquare()
        {
            var numbers = Enumerable.Repeat(Enumerable.Range(0, 10), 10);
            IEnumerable<IEnumerable<int>> seed = new IEnumerable<int>[] { Enumerable.Empty<int>() };
            var test = Enumerable.Range(1, 10).Reverse().Select(w=> SpecialMod(w,10));
            var hmm = test.Aggregate(Enumerable.Empty<int>(), (d, f) => d.Concat(ToEnumerable(0).Concat(ToEnumerable(f)))).Skip(1);
            Func<int, bool>[] bry = hmm.Select((x, i) => SpecialMod(i, 2) == 0 ? (Func<int, bool>)(s => s == x) : h => true).ToArray();
            int index = 0;
            var t = numbers.Aggregate(seed, (x, i) => Agg(x, i, () => index++, bry[index]));
            t.ToList();
        }

        private IEnumerable<IEnumerable<int>> Agg(IEnumerable<IEnumerable<int>> x, IEnumerable<int> i, Action adder, Func<int, bool> func)
        {
            var toReturn = x.SelectMany(y => i, (a, b) => a.Concat(ToEnumerable(b))).Where(q => func(SpecialMod(DiagSum2(q), 10))).ToList(); 
            adder(); 
            return toReturn; 
        }*/

        public void Problem206()
        {

            var numbers = Enumerable.Repeat(Enumerable.Range(0, 10), 10);
            IEnumerable<IEnumerable<int>> seed = new IEnumerable<int>[] { Enumerable.Empty<int>() };
            var seed2 = seed.Select(h => Tuple.Create(h, 0));
            var test = Enumerable.Range(1, 10).Reverse().Select(w => SpecialMod(w, 10));
            var hmm = test.Aggregate(Enumerable.Empty<int>(), (d, f) => d.Concat(ToEnumerable(0).Concat(ToEnumerable(f)))).Skip(1);
            Func<int, bool>[] bry = hmm.Select((x, i) => SpecialMod(i, 2) == 0 ? (Func<int, bool>)(s => s == x) : h => true).ToArray();
            int index = 0;
            var t = numbers.Aggregate(seed2, (x, i) => Agg(x, i, () => index++, bry[index])).ToList();
            /*while (index < 19)
            {
                var temp = t.Select(j => Tuple.Create(j.Item1, SpecialMod(DiagSum(j.Item1.Skip(index - 9)) + j.Item2, 10)));
                t = temp.Where(z => bry[index](z.Item2)).Select(k => Tuple.Create(k.Item1, k.Item2 / 10)).ToList();
                index++;
            }*/

            var multi = t.Select(q => Tuple.Create(BigNumberHelper.MultiplyListRepresentingNumber(q.Item1.ToList(), q.Item1.ToList()), q.Item1)).ToList();
            //multi.Where(d=> d.All(
            multi = multi.Where(df => df.Item1.Count == 19 || (df.Item1.Count == 20 && df.Item1[19] == 0)).Select(sw => Tuple.Create(sw.Item1.Take(19).ToList(), sw.Item2)).ToList();
            int counter = 0;
            int maxCounter = 0;
            foreach (var numero in multi)
            {
                counter = 0;
                foreach (var numeroElement in numero.Item1)
                {
                    if (counter > maxCounter)
                    {
                        maxCounter = counter;
                    }
                    if (!bry[counter](numeroElement))
                    {
                        break;
                    }
                    counter++;
                }
                if (counter == 19)
                {

                }

            }




            Console.WriteLine(t.Count);
        }


        private IEnumerable<Tuple<IEnumerable<int>, int>> Agg(IEnumerable<Tuple<IEnumerable<int>, int>> x, IEnumerable<int> i, Action adder, Func<int, bool> func)
        {
            var temp =
                x.SelectMany(y => i, (a, b) => Tuple.Create(a.Item1.Concat(ToEnumerable(b)), a.Item2))
                 .Select(e => Tuple.Create(e.Item1, DiagSum(e.Item1) + e.Item2));
            var toReturn = temp.Where(v => func(SpecialMod(v.Item2, 10))).Select(r => Tuple.Create(r.Item1, r.Item2 / 10));
            //.Select(v => Tuple.Create(v, DiagSum(v))).Where(q => func(SpecialMod(q.Item2 + , 10))).ToList();
            adder();
            return toReturn;
        }

        public int DiagSum2(IEnumerable<int> line)
        {
            var subLine = line.Reverse().Skip(1);
            return (DiagSum(subLine) / 10) + DiagSum(line);

        }

        public int DiagSum(IEnumerable<int> line)
        {
            return GetDiagonal(line).Select(y => y.Item1 * y.Item2).Sum();
        }


        private int SpecialMod(int number, int mod)
        {
            return number < mod ? number : number % mod;
        }


        private IEnumerable<T> ToEnumerable<T>(T arg)
        {
            yield return arg;
        }

        public int GetTriangleSection(int topLength, int depth)
        {
            int bigDoubleTriangle = (topLength + depth - 1) * (topLength + depth);
            int smallDoubleTriangle = (topLength - 1) * topLength;
            return (bigDoubleTriangle - smallDoubleTriangle) / 2;
        }

        public long NChooseK(int n, int k)
        {
            Func<long, long, long> mult = (x, y) => x * y;
            long num = 1;
            for (int i = n; i > n - k; i--)
            {
                num *= i;
            }
            long d = Convert.ToInt64(Factorial(k));
            return num / d;
        }

        public int Problem53()
        {
            int counter = 4;
            int total = 4;
            int n = 24;
            int k = 9;
            while (n <= 100 && k > 0)
            {
                long val = NChooseK(n, k);
                if (val > 1000000)
                {
                    k--;
                    counter += 3;
                }
                else
                {
                    counter++;

                }
                total = total + counter;
                n++;

            }
            return total;
        }

        public int Problem81()
        {
            int squareLength = 80;
            /*var line1 = new List<int>() { 1, 1, 1, 1 };
            var line2 = new List<int>() { 2, 3, 4, 1 };
            var line3 = new List<int>() { 1, 2, 5, 1 };
            var line4 = new List<int>() { 6, 9, 3, 1 };

            var lines = new List<List<int>>() { line1, line2, line3, line4 };*/

            /*var line1 = new List<int>() {131,	673,	234,	103,	18,};
            var line2 = new List<int>() { 201,	96,	342,	965,	150};
            var line3 = new List<int>() { 630,	803,	746,	422,	111};
            var line4 = new List<int>() {537,	699,	497,	121,	956 };
            var line5 = new List<int>() {805,	732,	524,	37,	331};


            var lines = new List<List<int>>() { line1, line2, line3, line4,line5 };*/

            string[] fileLines = File.ReadAllLines("C:\\Phil\\Problem81.txt");
            var lines = fileLines.Select(l => l.Split(',').Select(x => Convert.ToInt32(x)).ToList()).ToList();





            var triangle1 = new List<List<int>>();

            for (int i = 0; i < squareLength; i++)
            {
                var triangleLine = new List<int>();
                for (int j = 0; j < i + 1; j++)
                {
                    triangleLine.Add(lines[i - j][j]);
                }
                triangle1.Add(triangleLine);
            }

            for (int p = 1; p < squareLength; p++)
            {
                var triangleLine = new List<int>();
                for (int q = 0; q < squareLength - p; q++)
                {
                    triangleLine.Add(lines[squareLength - 1 - q][p + q]);
                }
                triangle1.Add(triangleLine);
            }

            for (int i = triangle1.Count - 2; i >= 0; i--)
            {
                for (int j = 0; j < triangle1[i].Count; j++)
                {
                    if (triangle1[i + 1].Count > triangle1[i].Count)
                    {
                        int adder = Math.Min(triangle1[i + 1][j], triangle1[i + 1][j + 1]);
                        triangle1[i][j] += adder;
                    }
                    else
                    {
                        int adder = 0;
                        if (j > triangle1[i + 1].Count - 1)
                        {
                            adder = triangle1[i + 1][j - 1];
                        }
                        else if (j - 1 < 0)
                        {
                            adder = triangle1[i + 1][j];
                        }
                        else
                        {
                            adder = Math.Min(triangle1[i + 1][j], triangle1[i + 1][j - 1]); ;
                        }


                        triangle1[i][j] += adder;
                    }

                }
            }
            return triangle1[0][0];

        }

        public void Problem44()
        {
            int n = 0;
            Dictionary<int, int> pentagDictionary = new Dictionary<int, int>();
            List<Tuple<int, int>> numbersToCheck = new List<Tuple<int, int>>();
            int minDifference = 0;
            bool foundOne = false;
            while (true)
            {
                int pent = (n * ((3 * n) - 1)) / 2;
                pentagDictionary.Add(n, pent);



                var maybe = numbersToCheck.Where(x => pentagDictionary[x.Item1] + pentagDictionary[x.Item2] == pent);
                if (maybe.Count() > 0)
                {
                    minDifference = maybe.Min(x => pentagDictionary[x.Item1] - pentagDictionary[x.Item2]);
                    foundOne = true;

                }
                numbersToCheck = numbersToCheck.Where(x => pentagDictionary[x.Item1] + pentagDictionary[x.Item2] > pent).ToList();


                if (foundOne && (pent - pentagDictionary[n - 1] > minDifference))
                {
                    break;
                }
                for (int i = n - 1; i >= 1; i--)
                {

                    int diff = pent - pentagDictionary[i];
                    if (pentagDictionary.ContainsValue(diff))
                    {
                        numbersToCheck.Add(Tuple.Create(n, i));
                    }
                    /*bool breakMe = false;
                    for (int j = n - 2; j >= 0; j--)
                    {
                        int sum = pentagDictionary[i] + pentagDictionary[j];
                        if (sum >= pent)
                        {
                            numbersToCheck.Add(Tuple.Create(i, j));
                        }
                        else
                        {
                            breakMe = true;
                            break;
                        }
                    }
                    if (breakMe)
                    {
                        break;
                    }*/

                }

                n++;
            }
        }

        public void Pentagonal2()
        {

            int m = 2;
            while (true)
            {
                int x = 2;
                while (x < m)
                {
                    int numerator = (6 * m * m) - (2 * m) - (3 * x * x) - x;
                    int denominator = (6 * x);

                    if (numerator % denominator == 0)
                    {
                        break;
                    }
                    x++;
                }
                m++;
            }
        }

        public void Pentagonal3()
        {
            int x = 1;
            int n = 1;
            int m = 1;


            int numerator = (3 * x * x) + (6 * m * x) - x + m - (3 * m * m);
            int denominator = n;
            int denominator2 = (3 * n) - 1;

            while (true)
            {
                m = 1;
                while (m < x)
                {
                    n = 1;
                    while (n < x)
                    {
                        if ((numerator % denominator == 0) && (numerator % denominator2 == 0))
                        {
                            break;
                        }
                        n++;
                    }
                    m++;
                }
                x++;
            }

        }


    }

    public class Node
    {
        Node Parent { get; set; }
        int currentChild;
        int PathCost { get; set; }
        private List<Node> childNodes = new List<Node>();
        private List<int> childNumbers;
        private Action adder;

        public void AddNextChild()
        {
            if (currentChild == this.childNumbers.Count())
            {
                if (this.Parent != null)
                {
                    this.Parent.AddNextChild();
                }
                else
                {
                }
            }
            else
            {
                //int parentPathCost = this.Parent == null ? 0 : this.Parent.PathCost;
                var newPathCost = this.PathCost + childNumbers[currentChild];
                this.childNodes.Add(new Node(childNumbers.Skip(currentChild), this, () => currentChild++, adder, newPathCost));
            }

        }


        public Node(IEnumerable<int> children, Node parent, Action advance, Action adder, int pathCost)
        {
            advance();
            this.Parent = parent;
            this.PathCost = pathCost;
            this.childNumbers = new List<int>(children);
            this.adder = adder;
            if (PathCost > 50)
            {
                if (this.Parent != null)
                {
                    this.Parent.AddNextChild();
                }

            }
            else if (PathCost == 50)
            {

                if (this.Parent != null)
                {
                    this.Parent.AddNextChild();
                }
                adder();
            }
            else
            {
                this.AddNextChild();
            }
        }
    }

    public class KeyValueMap<S, T>
    {
        private Func<S, T> getValue;
        private Dictionary<S, T> dictionary = new Dictionary<S, T>();

        public KeyValueMap(Func<S, T> getValue)
        {
            this.getValue = getValue;
        }
        public T GetValue(S arg)
        {
            if (!dictionary.ContainsKey(arg))
            {
                this.dictionary.Add(arg, getValue(arg));
            }
            return dictionary[arg];
        }
    }
}
