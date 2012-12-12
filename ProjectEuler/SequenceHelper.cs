using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public class SequenceHelper
    {
        public static bool IsPalindrome(int pal)
        {
            int factor = 0;
            int maxPower = 7;
            bool palindromeSet = false;
            int[] palindrome = new int[1];
            int j = 0;

            for (int i = maxPower; i >= 0; i--)
            {
                factor = (pal / MathsHelper.Power(10, i));
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
                pal = pal - (factor * MathsHelper.Power(10, i));
            }
            return IsPalindrome(palindrome);
        }

        public static bool IsPalindrome(int[] pal)
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

        public static IEnumerable<int> GetRange(int min, int count)
        {
            for (int i = min; i <= min + count - 1; i++)
            {
                yield return i;
            }
        }

        
    }
}
