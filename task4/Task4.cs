using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceLabTask
{
    public class Task4
    {
        public void SolveTask4(string path)
        {
            var numbers = ReadData(path);
            Array.Sort(numbers);
            var median = CalculateMedian(numbers);
            CalculateSteps(numbers, median);
        }

        private int[] ReadData(string path)
        {
            string text;
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }

            var textArray = text.Split('\n');
            int[] ints = new int[textArray.Length];
            for (int i = 0; i < textArray.Length; i++)
            {
                if (!int.TryParse(textArray[i], out ints[i]))
                    throw new Exception($"Ошибка в данных файла {path}\nномер строки: {i+1}");
            }
            return ints;
        }

        private void CalculateSteps(int[] sortedNumbers, double median)
        {
            median = Math.Round(median);
            int steps = 0;
            foreach (int number in sortedNumbers)
            {
                steps += (int)Math.Abs(number - median);
            }

            Console.WriteLine("Минимальное количество шагов: " + steps);
        }

        double CalculateMedian(int[] numbers)
        {
            int size = numbers.Length;
            if (size % 2 == 0)
            {
                return (numbers[size / 2 - 1] + numbers[size / 2]) / 2.0;
            }
            else
            {
                return numbers[size / 2];
            }
        }
    }
}
