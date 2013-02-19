using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class BigNumberHelper
    {
        public static List<int> GetAsListRepresentingNumber(int number)
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

        public static List<int> GetAsListRepresentingNumber(string number)
        {
            List<int> result = new List<int>();
            foreach (char c in number)
            {
                int i = Int16.Parse(c.ToString());
                result.Insert(0, i);
            }

            return result;
        }

        public static void MultiplyListRepresentingNumberVoid(List<int> listRepresentingNumber, int multiplyBy)
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

        public static List<int> MultiplyListRepresentingNumber(List<int> listRepresentingNumber, int multiplyBy, int maxLength)
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

        public static List<int> MultiplyListRepresentingNumber(List<int> listRepresentingNumber, List<int> listRepresentingNumber2)
        {
            int carryOver = 0;
            List<List<int>> listOfLists = new List<List<int>>();
            for (int i = 0; i < listRepresentingNumber.Count; i++)
            {
                List<int> mult = new List<int>(listRepresentingNumber2);

                MultiplyListRepresentingNumberVoid(mult, listRepresentingNumber[i]);
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
                result = AddListRepresentingNumbers(result, list);
            }

            return result;
        }

        public static List<int> AddListRepresentingNumbers(List<int> listRepresentingNumber, List<int> listRepresentingNumber2)
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

        public static List<int> AddListRepresentingNumbers(List<List<int>> listOfListRepresentingNumbers)
        {
            List<int> result = new List<int>();
            result.Add(0);
            foreach (List<int> listRepresentingNumber in listOfListRepresentingNumbers)
            {
                result = AddListRepresentingNumbers(result, listRepresentingNumber);
            }

            return result;
        }
    }
}
