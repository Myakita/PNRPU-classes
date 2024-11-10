namespace Лабораторная_Работа_3
{
    internal class Program
    {
        static double SN(double x, int n)
        {
            double sum = 0;
            double denumerator = 0.0;
            double recurpart;

            for (int i = 1; i <= n; i++)
            {
                recurpart = Math.Cos(i*x);
                denumerator += 2*i - 1;

                if (i % 2 == 0)
                {
                    sum += recurpart / denumerator;
                }
                else
                {
                    sum -= recurpart / denumerator;
                }
            }

            return sum;
        }

        static double SE(double x, double e)
        {
            double sum = 0;
            double denumerator = 0.0;
            double recurpart;
            recurpart = Math.Cos(x);


            int i = 1;
            while (Math.Abs(recurpart / denumerator) > e)
            {
                recurpart = Math.Cos(i * x);
                denumerator += 2 * i - 1;

                if (i % 2 == 0)
                {
                    sum += recurpart / denumerator;
                }
                else
                {
                    sum -= recurpart / denumerator;
                }

                i++;
            }

            return sum;
        }

        static void Main()
        {
            double x1 = Math.PI / 5;
            double x2 = Math.PI;
            double PiSquare = Math.PI * Math.PI;
            int k = 10;
            int n = 20;
            double e = 0.001;
            double step = (x2 - x1) / k;

            Console.WriteLine("Вычисление функции");
            Console.WriteLine("X\tSN\t\tSE\t\tY");

            for (int i = 0; i <= k; i++)
            {
                double x = x1 + i * step;
                double SN = Program.SN(x, n);
                double SE = Program.SE(x, e);
                double Y = (x * x - (PiSquare / 3))/4;

                Console.WriteLine($"{x:F1}\t{SN:F4}\t\t{SE:F4}\t\t{Y:F4}");
            }
        }
    }
}
