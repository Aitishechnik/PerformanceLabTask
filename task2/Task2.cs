namespace PerformanceLabTask
{
    public class Task2
    {
        private const int ON_THE_CIRLCE = 0;
        private const int INSIDE_THE_CIRLCE = 1;
        private const int OUTSIDE_THE_CIRLCE = 2;
        private double h = 0;
        private double k = 0;
        private double r = 0;

        public void Solition(string circleParamsPath, string dotsPath)
        {
            SetCircle(circleParamsPath);
            DefinePoints(SetPoints(dotsPath));
        }

        private void SetCircle(string circleParamsPath)
        {
            string rawText;
            using (StreamReader sr = new StreamReader(circleParamsPath))
            {
                rawText = sr.ReadToEnd();
            }
            rawText = rawText.Replace('.',',');
            var text = rawText.Split('\n');

            if (!double.TryParse(text[0].Split(" ")[0], out h) ||
            !double.TryParse(text[0].Split(" ")[1], out k) ||
            !double.TryParse(text[1], out r)) 
                throw new Exception("Ошибка данных в файле " + circleParamsPath);
            if (r <= 0) throw new Exception("Значение радиуса окружности не может быть <= 0");
        }

        private double[,] SetPoints(string dotsPath)
        {
            string rawText;
            using (StreamReader sr = new StreamReader(dotsPath))
            {
                rawText = sr.ReadToEnd();
            }
            rawText = rawText.Replace('.', ',');
            var text = rawText.Split('\n');
            double[,] points = new double[text.Length, 2];
            for(int i = 0; i < points.GetLength(0); i++)
            {
                if (!double.TryParse(text[i].Split(" ")[0], out double x) ||
                !double.TryParse(text[i].Split(" ")[1], out double y))
                    throw new Exception("Ошибка в файле " + dotsPath + " номер строки: " + (i+1));
                points[i,0] = x;
                points[i,1] = y;
            }
            return points;
        }

        private void DefinePoints(double[,] points)
        {
            var rSquared = Math.Pow(r, 2);

            for(int i = 0; i < points.GetLength(0); i++)
            {
                double d = Math.Pow(points[i,0] - h, 2) + Math.Pow(points[i,1] - k, 2);

                if (d < rSquared)
                    Console.WriteLine(INSIDE_THE_CIRLCE);
                else if (d == rSquared)
                    Console.WriteLine(ON_THE_CIRLCE);
                else
                    Console.WriteLine(OUTSIDE_THE_CIRLCE);
            }
        }
    }
}
