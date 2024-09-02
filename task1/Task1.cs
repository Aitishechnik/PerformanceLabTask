using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceLabTask
{
    public class Task1
    {
        private const int CLOSING_VALUE = 1;

        public static void GetCirculArarrayPath(int n, int m)
        {
            Console.WriteLine(GetCurcularValue(n));
        }

        private static List<int> GetCurcularArrays(int initialValue, int subarrayLength)
        {
            List<int> ints = new List<int>();
            int currentValue = initialValue;

            do
            {
                ints.Add(currentValue);


            } while (currentValue % 10 != CLOSING_VALUE);
        }


        private static int ShiftDigits(int firstDigit, int initialValue)
        {
            int result = initialValue;

            while (GetFirstDigit(result) != firstDigit)
            {

            }
        }

        private static int GetFirstDigit(int value)
        {
            while (value / 10 > 0) value /= 10;
            return value;
        }

        private static int GetCurcularValue(int initalValue)
        {
            int result = 0;

            for(int i = 0; i <= initalValue; i++)
            {
                result *= 10;
                result += i;
            }

            return result;
        }
    }
}
