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
        public int Problem1()
        {
            int result = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    result = result + i;
                }
            }
            return result;
        }

        public int Problem2()
        {
            int result = 0;
            int num1 = 1;
            int num2 = 0;
            int buffer = 0;
            while (num1 <= 4000000)
            {
                if (num1 % 2 == 0)
                {
                    result = result + num1;
                }
                buffer = num1;
                num1 = num1 + num2;
                num2 = buffer;

            }
            return result;
        }

        public long Problem3()
        {
            long number = 600851475143;
            List<long> primes = new List<long>();
            for (long i = 2; i <= Math.Pow(number, 0.5); i++)
            {
                if (number % i == 0)
                {
                    long otherDivisor = number / i;
                    if (this.IsPrime(i))
                    {
                        primes.Add(i);
                    }
                    else
                    {
                        if (this.IsPrime(otherDivisor))
                        {
                            return otherDivisor;
                        }
                    }
                }
            }

            primes.Reverse();

            return primes[0];
        }

        public int Problem4()
        {
            List<int> palindromes = new List<int>();
            int num = 999;
            for (int i = num; i >= 100; i--)
            {
                for (int j = i; j >= 100; j--)
                {
                    if (IsPalindrome(j * i))
                    {
                        palindromes.Add(j * i);
                    }
                }
            }
            palindromes.Sort();
            palindromes.Reverse();
            return palindromes[0];
        }

        public int Problem6()
        {
            int result = 0;
            int number = 100;
            for (int i = 1; i <= number; i++)
            {
                for (int j = i + 1; j <= number; j++)
                {
                    result = result + (i * j);
                }
            }
            return (2 * result);
        }

        public int Problem7()
        {
            return this.TheNthPrimeIs(10001);
        }

        public int Problem8()
        {
            int biggestProduct = 0;

            string number = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
            for (int i = 0; i <= number.Length - 5; i++)
            {
                int currentProduct = 1;
                for (int j = 0; j < 5; j++)
                {
                    currentProduct = currentProduct * Int32.Parse(number[i + j].ToString());
                }
                if (currentProduct > biggestProduct)
                {
                    biggestProduct = currentProduct;
                }
            }

            return biggestProduct;
        }

        public int Problem9()
        {
            for (int c = 0; c < 500; c++)
            {
                int aPlusB = 1000 - c;
                if (aPlusB <= 500)
                {
                    break;
                }
                else
                {
                    int product;
                    if (IsPythagoreanTriplet(aPlusB, c, out product))
                    {
                        return product;
                    }
                }
            }
            return 0;
        }

        private bool IsPythagoreanTriplet(int aPlusB, int c, out int product)
        {
            product = 0;
            for (int a = 1; aPlusB - a >= a; a++)
            {
                int b = aPlusB - a;
                if (b - a <= 500)
                {
                    if ((a * a) + (b * b) == (c * c))
                    {
                        product = a * b * c;
                        return true;
                    }
                }
            }
            return false;
        }

        public long Problem10()
        {
            long primeSum = 0;
            for (long i = 3; i < 2000000; i = i + 2)
            {
                if (IsPrime(i))
                {
                    primeSum = primeSum + i;
                }
            }
            return primeSum + 2;
        }

        public void ProblemEleven()
        {
            double x = Math.Pow(2, 40);
        }

        public void ProblemTwelve()
        {
            int numberOfFactors = 0;
            int n = 0;

            while (numberOfFactors < 5)
            {
                n++;
                numberOfFactors = this.NumberOfFactors(n);
            }
        }

        public void Problem13()
        {
            List<List<int>> list = new List<List<int>>();
            /*List<int> n = GetAsListRepresentingNumber("30786");
            List<int> m = GetAsListRepresentingNumber("34534");
            List<int> p = GetAsListRepresentingNumber("7");
            list.Add(m);
            list.Add(n);
            list.Add(p);*/
            list.Add(GetAsListRepresentingNumber("37107287533902102798797998220837590246510135740250"));
            list.Add(GetAsListRepresentingNumber("46376937677490009712648124896970078050417018260538"));
            list.Add(GetAsListRepresentingNumber("74324986199524741059474233309513058123726617309629"));
            list.Add(GetAsListRepresentingNumber("91942213363574161572522430563301811072406154908250"));
            list.Add(GetAsListRepresentingNumber("23067588207539346171171980310421047513778063246676"));
            list.Add(GetAsListRepresentingNumber("89261670696623633820136378418383684178734361726757"));
            list.Add(GetAsListRepresentingNumber("28112879812849979408065481931592621691275889832738"));
            list.Add(GetAsListRepresentingNumber("44274228917432520321923589422876796487670272189318"));
            list.Add(GetAsListRepresentingNumber("47451445736001306439091167216856844588711603153276"));
            list.Add(GetAsListRepresentingNumber("70386486105843025439939619828917593665686757934951"));
            list.Add(GetAsListRepresentingNumber("62176457141856560629502157223196586755079324193331"));
            list.Add(GetAsListRepresentingNumber("64906352462741904929101432445813822663347944758178"));
            list.Add(GetAsListRepresentingNumber("92575867718337217661963751590579239728245598838407"));
            list.Add(GetAsListRepresentingNumber("58203565325359399008402633568948830189458628227828"));
            list.Add(GetAsListRepresentingNumber("80181199384826282014278194139940567587151170094390"));
            list.Add(GetAsListRepresentingNumber("35398664372827112653829987240784473053190104293586"));
            list.Add(GetAsListRepresentingNumber("86515506006295864861532075273371959191420517255829"));
            list.Add(GetAsListRepresentingNumber("71693888707715466499115593487603532921714970056938"));
            list.Add(GetAsListRepresentingNumber("54370070576826684624621495650076471787294438377604"));
            list.Add(GetAsListRepresentingNumber("53282654108756828443191190634694037855217779295145"));
            list.Add(GetAsListRepresentingNumber("36123272525000296071075082563815656710885258350721"));
            list.Add(GetAsListRepresentingNumber("45876576172410976447339110607218265236877223636045"));
            list.Add(GetAsListRepresentingNumber("17423706905851860660448207621209813287860733969412"));
            list.Add(GetAsListRepresentingNumber("81142660418086830619328460811191061556940512689692"));
            list.Add(GetAsListRepresentingNumber("51934325451728388641918047049293215058642563049483"));
            list.Add(GetAsListRepresentingNumber("62467221648435076201727918039944693004732956340691"));
            list.Add(GetAsListRepresentingNumber("15732444386908125794514089057706229429197107928209"));
            list.Add(GetAsListRepresentingNumber("55037687525678773091862540744969844508330393682126"));
            list.Add(GetAsListRepresentingNumber("18336384825330154686196124348767681297534375946515"));
            list.Add(GetAsListRepresentingNumber("80386287592878490201521685554828717201219257766954"));
            list.Add(GetAsListRepresentingNumber("78182833757993103614740356856449095527097864797581"));
            list.Add(GetAsListRepresentingNumber("16726320100436897842553539920931837441497806860984"));
            list.Add(GetAsListRepresentingNumber("48403098129077791799088218795327364475675590848030"));
            list.Add(GetAsListRepresentingNumber("87086987551392711854517078544161852424320693150332"));
            list.Add(GetAsListRepresentingNumber("59959406895756536782107074926966537676326235447210"));
            list.Add(GetAsListRepresentingNumber("69793950679652694742597709739166693763042633987085"));
            list.Add(GetAsListRepresentingNumber("41052684708299085211399427365734116182760315001271"));
            list.Add(GetAsListRepresentingNumber("65378607361501080857009149939512557028198746004375"));
            list.Add(GetAsListRepresentingNumber("35829035317434717326932123578154982629742552737307"));
            list.Add(GetAsListRepresentingNumber("94953759765105305946966067683156574377167401875275"));
            list.Add(GetAsListRepresentingNumber("88902802571733229619176668713819931811048770190271"));
            list.Add(GetAsListRepresentingNumber("25267680276078003013678680992525463401061632866526"));
            list.Add(GetAsListRepresentingNumber("36270218540497705585629946580636237993140746255962"));
            list.Add(GetAsListRepresentingNumber("24074486908231174977792365466257246923322810917141"));
            list.Add(GetAsListRepresentingNumber("91430288197103288597806669760892938638285025333403"));
            list.Add(GetAsListRepresentingNumber("34413065578016127815921815005561868836468420090470"));
            list.Add(GetAsListRepresentingNumber("23053081172816430487623791969842487255036638784583"));
            list.Add(GetAsListRepresentingNumber("11487696932154902810424020138335124462181441773470"));
            list.Add(GetAsListRepresentingNumber("63783299490636259666498587618221225225512486764533"));
            list.Add(GetAsListRepresentingNumber("67720186971698544312419572409913959008952310058822"));
            list.Add(GetAsListRepresentingNumber("95548255300263520781532296796249481641953868218774"));
            list.Add(GetAsListRepresentingNumber("76085327132285723110424803456124867697064507995236"));
            list.Add(GetAsListRepresentingNumber("37774242535411291684276865538926205024910326572967"));
            list.Add(GetAsListRepresentingNumber("23701913275725675285653248258265463092207058596522"));
            list.Add(GetAsListRepresentingNumber("29798860272258331913126375147341994889534765745501"));
            list.Add(GetAsListRepresentingNumber("18495701454879288984856827726077713721403798879715"));
            list.Add(GetAsListRepresentingNumber("38298203783031473527721580348144513491373226651381"));
            list.Add(GetAsListRepresentingNumber("34829543829199918180278916522431027392251122869539"));
            list.Add(GetAsListRepresentingNumber("40957953066405232632538044100059654939159879593635"));
            list.Add(GetAsListRepresentingNumber("29746152185502371307642255121183693803580388584903"));
            list.Add(GetAsListRepresentingNumber("41698116222072977186158236678424689157993532961922"));
            list.Add(GetAsListRepresentingNumber("62467957194401269043877107275048102390895523597457"));
            list.Add(GetAsListRepresentingNumber("23189706772547915061505504953922979530901129967519"));
            list.Add(GetAsListRepresentingNumber("86188088225875314529584099251203829009407770775672"));
            list.Add(GetAsListRepresentingNumber("11306739708304724483816533873502340845647058077308"));
            list.Add(GetAsListRepresentingNumber("82959174767140363198008187129011875491310547126581"));
            list.Add(GetAsListRepresentingNumber("97623331044818386269515456334926366572897563400500"));
            list.Add(GetAsListRepresentingNumber("42846280183517070527831839425882145521227251250327"));
            list.Add(GetAsListRepresentingNumber("55121603546981200581762165212827652751691296897789"));
            list.Add(GetAsListRepresentingNumber("32238195734329339946437501907836945765883352399886"));
            list.Add(GetAsListRepresentingNumber("75506164965184775180738168837861091527357929701337"));
            list.Add(GetAsListRepresentingNumber("62177842752192623401942399639168044983993173312731"));
            list.Add(GetAsListRepresentingNumber("32924185707147349566916674687634660915035914677504"));
            list.Add(GetAsListRepresentingNumber("99518671430235219628894890102423325116913619626622"));
            list.Add(GetAsListRepresentingNumber("73267460800591547471830798392868535206946944540724"));
            list.Add(GetAsListRepresentingNumber("76841822524674417161514036427982273348055556214818"));
            list.Add(GetAsListRepresentingNumber("97142617910342598647204516893989422179826088076852"));
            list.Add(GetAsListRepresentingNumber("87783646182799346313767754307809363333018982642090"));
            list.Add(GetAsListRepresentingNumber("10848802521674670883215120185883543223812876952786"));
            list.Add(GetAsListRepresentingNumber("71329612474782464538636993009049310363619763878039"));
            list.Add(GetAsListRepresentingNumber("62184073572399794223406235393808339651327408011116"));
            list.Add(GetAsListRepresentingNumber("66627891981488087797941876876144230030984490851411"));
            list.Add(GetAsListRepresentingNumber("60661826293682836764744779239180335110989069790714"));
            list.Add(GetAsListRepresentingNumber("85786944089552990653640447425576083659976645795096"));
            list.Add(GetAsListRepresentingNumber("66024396409905389607120198219976047599490197230297"));
            list.Add(GetAsListRepresentingNumber("64913982680032973156037120041377903785566085089252"));
            list.Add(GetAsListRepresentingNumber("16730939319872750275468906903707539413042652315011"));
            list.Add(GetAsListRepresentingNumber("94809377245048795150954100921645863754710598436791"));
            list.Add(GetAsListRepresentingNumber("78639167021187492431995700641917969777599028300699"));
            list.Add(GetAsListRepresentingNumber("15368713711936614952811305876380278410754449733078"));
            list.Add(GetAsListRepresentingNumber("40789923115535562561142322423255033685442488917353"));
            list.Add(GetAsListRepresentingNumber("44889911501440648020369068063960672322193204149535"));
            list.Add(GetAsListRepresentingNumber("41503128880339536053299340368006977710650566631954"));
            list.Add(GetAsListRepresentingNumber("81234880673210146739058568557934581403627822703280"));
            list.Add(GetAsListRepresentingNumber("82616570773948327592232845941706525094512325230608"));
            list.Add(GetAsListRepresentingNumber("22918802058777319719839450180888072429661980811197"));
            list.Add(GetAsListRepresentingNumber("77158542502016545090413245809786882778948721859617"));
            list.Add(GetAsListRepresentingNumber("72107838435069186155435662884062257473692284509516"));
            list.Add(GetAsListRepresentingNumber("20849603980134001723930671666823555245252804609722"));
            list.Add(GetAsListRepresentingNumber("53503534226472524250874054075591789781264330331690"));
            List<int> result = this.AddListRepresentingNumbers(list);
        }

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
                this.MultiplyListRepresentingNumberVoid(listRepresentingNumber, 2);
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
            List<int> number = this.GetAsListRepresentingNumber(test);

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
            List<int> num = this.GetAsListRepresentingNumber(i);


            while (i > 1)
            {
                List<int> num2 = this.GetAsListRepresentingNumber(i - 1);
                num = this.MultiplyListRepresentingNumber(num, num2);
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
            List<int> prevprev = GetAsListRepresentingNumber(1);
            List<int> prev = GetAsListRepresentingNumber(1);
            int n = 2;
            while (result.Count() < 1000)
            {
                result = AddListRepresentingNumbers(prevprev, prev);
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

        private int NumberOfFactors(int n)
        {
            int count = 0;
            bool squareFlag = false;
            int upperLimit = (int)Math.Ceiling(Math.Sqrt((double)n));
            for (int x = 2; x <= upperLimit; x++)
            {
                if (n % x == 0)
                {

                    if (x != upperLimit)
                    {
                        count++;
                    }
                    else
                    {
                        squareFlag = (n / x == x);
                    }

                }

            }
            int result = (count * 2) + 2;
            return squareFlag ? result - 1 : result;

        }

        private bool IsPalindrome(int pal)
        {
            int factor = 0;
            int maxPower = 7;
            bool palindromeSet = false;
            int[] palindrome = new int[1];
            int j = 0;

            for (int i = maxPower; i >= 0; i--)
            {
                factor = (pal / Power(10, i));
                if (!palindromeSet && factor > 0)
                {
                    palindromeSet = true;
                    palindrome = new int[i + 1];
                }
                if (palindromeSet)
                {
                    palindrome[j] = factor;
                    j++;
                }
                pal = pal - (factor * Power(10, i));
            }
            return IsPalindrome(palindrome);
        }

        private bool IsPalindrome(int[] pal)
        {
            int i = 0;
            for (i = 0; i < pal.Length / 2; i++)
            {
                if (pal[i] != pal[pal.Length - 1 - i])
                {
                    break;
                }
            }
            if (i >= pal.Length / 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Power(int exponent, int index)
        {
            int result = 1;
            for (int i = 0; i < index; i++)
            {
                result = result * exponent;
            }
            return result;
        }

        private bool IsPrime(long numberToTest)
        {
            if (numberToTest == 1)
            {
                return false;
            }
            if (numberToTest == 2)
            {
                return true;
            }
            if (numberToTest % 2 == 0)
            {
                return false;
            }
            for (int j = 3; j <= Math.Pow(numberToTest, 0.5); j = j + 2)
            {
                if (numberToTest % j == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void MultiplyListRepresentingNumberVoid(List<int> listRepresentingNumber, int multiplyBy)
        {
            int carryOver = 0;
            for (int listPosition = 0; listPosition < listRepresentingNumber.Count; listPosition++)
            {
                int multiplied = (listRepresentingNumber[listPosition] * multiplyBy) + carryOver;
                if (multiplied >= 10)
                {
                    int factorOf10 = multiplied / 10;
                    int remainder = multiplied % 10;
                    listRepresentingNumber[listPosition] = remainder;
                    carryOver = factorOf10;
                }
                else
                {
                    listRepresentingNumber[listPosition] = multiplied;
                    carryOver = 0;
                }
            }

            if (carryOver > 0)
            {
                listRepresentingNumber.Add(carryOver);
            }
        }

        private List<int> MultiplyListRepresentingNumber(List<int> listRepresentingNumber, int multiplyBy, int maxLength)
        {
            listRepresentingNumber = new List<int>(listRepresentingNumber);
            int carryOver = 0;
            for (int listPosition = 0; listPosition < Math.Min(listRepresentingNumber.Count, maxLength); listPosition++)
            {
                int multiplied = (listRepresentingNumber[listPosition] * multiplyBy) + carryOver;
                if (multiplied >= 10)
                {
                    int factorOf10 = multiplied / 10;
                    int remainder = multiplied % 10;
                    listRepresentingNumber[listPosition] = remainder;
                    carryOver = factorOf10;
                }
                else
                {
                    listRepresentingNumber[listPosition] = multiplied;
                    carryOver = 0;
                }
            }

            if (carryOver > 0)
            {
                listRepresentingNumber.Add(carryOver);
            }
            return listRepresentingNumber.Take(maxLength).ToList();
        }

        private List<int> GetAsListRepresentingNumber(int number)
        {
            List<int> result = new List<int>();
            double maxPowerOf10 = Math.Log((double)number) / Math.Log(10.0);
            int maxPowerOf10AsInt = (int)(Math.Floor(maxPowerOf10));
            for (int i = maxPowerOf10AsInt; i >= 0; i--)
            {
                int powerOf10 = (int)(Math.Pow(10.0, (double)i));
                int powerOf10PlusOne = (int)(Math.Pow(10.0, (double)i + 1));

                int div1 = (number / powerOf10);
                int div2 = (number / powerOf10PlusOne);
                int ds = div1 - (10 * div2);
                result.Insert(0, ds);
            }

            return result;

        }

        private List<int> GetAsListRepresentingNumber(string number)
        {
            List<int> result = new List<int>();
            foreach (char c in number)
            {
                int i = Int16.Parse(c.ToString());
                result.Insert(0, i);
            }

            return result;
        }

        public List<int> MultiplyListRepresentingNumber(List<int> listRepresentingNumber, List<int> listRepresentingNumber2)
        {
            int carryOver = 0;
            List<List<int>> listOfLists = new List<List<int>>();
            for (int i = 0; i < listRepresentingNumber.Count; i++)
            {
                List<int> mult = new List<int>(listRepresentingNumber2);

                this.MultiplyListRepresentingNumberVoid(mult, listRepresentingNumber[i]);
                for (int j = 0; j < i; j++)
                {
                    mult.Insert(0, 0);
                }
                listOfLists.Add(mult);
            }

            List<int> result = new List<int>();
            result.Add(0);


            foreach (List<int> list in listOfLists)
            {
                result = this.AddListRepresentingNumbers(result, list);
            }

            return result;
        }

        public List<int> AddListRepresentingNumbers(List<int> listRepresentingNumber, List<int> listRepresentingNumber2)
        {
            List<int> addedNumber = new List<int>();
            int carryOver = 0;
            int maxCount = Math.Max(listRepresentingNumber.Count, listRepresentingNumber2.Count);
            for (int i = 0; i < maxCount; i++)
            {
                int a = 0;
                int b = 0;
                if (i < listRepresentingNumber.Count)
                {
                    a = listRepresentingNumber[i];
                }
                if (i < listRepresentingNumber2.Count)
                {
                    b = listRepresentingNumber2[i];
                }
                int added = a + b + carryOver;
                if (added >= 10)
                {
                    int factorOf10 = added / 10;
                    int remainder = added % 10;
                    addedNumber.Add(remainder);
                    carryOver = factorOf10;
                }
                else
                {
                    addedNumber.Add(added);
                    carryOver = 0;
                }
            }
            if (carryOver > 0)
            {
                addedNumber.Add(carryOver);
            }
            return addedNumber;
        }

        public List<int> AddListRepresentingNumbers(List<List<int>> listOfListRepresentingNumbers)
        {
            List<int> result = new List<int>();
            result.Add(0);
            foreach (List<int> listRepresentingNumber in listOfListRepresentingNumbers)
            {
                result = AddListRepresentingNumbers(result, listRepresentingNumber);
            }

            return result;
        }

        public int TheNthPrimeIs(int whichNumerPrime)
        {
            int i = 1;
            int numberToTest = 3;
            while (i < whichNumerPrime)
            {
                if (this.IsPrime(numberToTest))
                {
                    i++;
                }
                numberToTest++;
            }
            return numberToTest - 1;
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
                            bool isPrime = this.IsPrime(quadValue);
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
                    IEnumerable<int> th = new int[] { Increase(r, p), Increase(r, q), Increase(r, q) + Power(2, kvp.Key + 1) };
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
                result += Power(2, i);
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
            //var primes = new HashSet<int>(GetPrimes(1000000000));

            //primes.

            Func<IEnumerable<int>, int> getNumber = list => list.Reverse().Select((i, j) => i * Power(10, j)).Sum();
            Func<IEnumerable<int>, IEnumerable<IEnumerable<int>>> getRLSubsets = list => list.Select((i, j) => list.Skip(j));

            truncatable.Add(1, new int[][] { new int[] { 2 }, new int[] { 3 }, new int[] { 5 }, new int[] { 7 } });


            for (int q = 2; q < 20; q++)
            {
                truncatable[q] = truncatable[q - 1].SelectMany(p => choices, (r, t) => r.Concat(t));
                truncatable[q] = truncatable[q].Where(x => IsPrime((long)getNumber(x))).ToList();
                truncatable[q - 1] = truncatable[q - 1].Where(x => getRLSubsets(x).Select(getNumber).All(y => IsPrime((long)y)));
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

        public IEnumerable<int> GetPrimes(int n)
        {
            int start = 2;
            BitArray compositeArray = new BitArray(n - start + 1, true);
            for (int i = start; i <= n; i++)
            {
                if (compositeArray[i - start])
                {
                    int x = i;
                    while (x <= n)
                    {
                        compositeArray[x - start] = false;
                        x += i;
                    }
                    yield return i;
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
            var answer = DigitSumEqual(Power(10, 7), this.Factorial);
        }

        /// <summary>
        /// To get the upper limit see the comments for problem 34.
        /// </summary>
        public void Problem30()
        {
            var answer = DigitSumEqual(Power(10, 6), x => Power(x, 5));
        }

        public int DigitSumEqual(int upperLimit, Func<int, int> digitMap)
        {
            var digitMapLookup = new KeyValueMap<int, int>(digitMap);
            Func<IEnumerable<int>, int> digitSum = xs => xs.Select(digitMapLookup.GetValue).Sum();
            return Enumerable.Range(10, upperLimit)
                                .Select(x => new { Num = x, ListNum = GetAsListRepresentingNumber(x) })
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
            var rt = q.Aggregate(Enumerable.Repeat<int>(1, 1).ToList(), (x, y) => MultiplyListRepresentingNumber(x, y, 10));

            //MultiplyListRepresentingNumberVoid(rt, 28433);
            var d = GetAsListRepresentingNumber(28433);

            var s = MultiplyListRepresentingNumber(rt, d);


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

            var multi = t.Select(q => Tuple.Create(MultiplyListRepresentingNumber(q.Item1.ToList(), q.Item1.ToList()), q.Item1)).ToList();
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
