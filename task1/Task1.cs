
namespace PerformanceLabTask
{
    public class Task1
    {
        private const int CLOSING_VALUE = 1;

        public void SolveTask1()
        {
            int n = 0;
            int m = 0;

            while(n <= 0)
            {
                Console.WriteLine("Задайте целочисленное значение больше 0");
                if(int.TryParse(Console.ReadLine(), out int input) && input > 0)
                    n = input;
                else
                    Console.Clear();
            }
            Console.Clear();
            
            while(m <= 0 || m > n)
            {
                Console.WriteLine("Задайте целочисленное значение в диапазоне от 1 до n\nТекущее значение n = " + n);
                if (int.TryParse(Console.ReadLine(), out int input) && input > 0 && input <= n)
                    m = input;
                else
                    Console.Clear();
            }
            Console.Clear();
            Console.Write("Полученный путь: ");
            var result = GetCircularArrayValues(n,m);
            for (int i = 0; i < result.Count; i++) 
                Console.Write(result[i] + (i == result.Count-1? "." : ", "));
        }

        private List<int> GetCircularArrayValues(int n, int m)
        {
            List<int> ints = new List<int>() {CLOSING_VALUE};
            var initialArray = GetInitialArray(n);
            var arrayPartition = CutArray(initialArray, m);

            do
            {
                arrayPartition = CutArray(ShiftValues(initialArray, arrayPartition[^1]), m);
                ints.Add(arrayPartition[0]);
            }
            while (arrayPartition[^1] != CLOSING_VALUE);
            return ints;
        }

        private int[] ShiftValues(int[] initialArray, int index)
        {
            int[] result = new int[initialArray.Length];

            for (int i = 0; i < initialArray.Length; i++)
            {
                int newIndex = (i + index - 1) % initialArray.Length;
                result[i] = initialArray[newIndex];
            }
            return result;
        }

        private int[] GetInitialArray(int n)
        {
            int[] ints = new int[n];
            for(int i = 0; i < n; i++) ints[i] = i+1;
            return ints;
        }

        private int[] CutArray(int[] array, int newLength)
        {
            if(array.Length < newLength)
                throw new Exception("Array length is not suitable");
            int[] result = new int[newLength];
            for(int i = 0; i < result.Length; i++)
                result[i] = array[i];
            return result;
        }
    }
}