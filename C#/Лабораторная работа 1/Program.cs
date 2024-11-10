using System;

internal class Program
{
    static void Main(string[] args)
    {
        int  n = 0, m = 0;
        double x = 0;
        bool isValid;

        isValid = false;
        while (!isValid)
        {
            Console.WriteLine("Введите n:");
            if (int.TryParse(Console.ReadLine(), out n))
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("Ошибка: введите корректное целое число.");
            }
        }

        isValid = false;
        while (!isValid)
        {
            Console.WriteLine("Введите m:");
            if (int.TryParse(Console.ReadLine(), out m))
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("Ошибка: введите корректное целое число.");
            }
        }


        do
        {
            Console.WriteLine("Введите x:");
            if (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Ошибка: введите корректное целое число.");
                continue;
            }

            if (x == 0)
                Console.WriteLine("Недопустимое значение x, попробуйте снова");
        } while (x == 0);

        Console.WriteLine("Результат первой задачи:");
        Console.WriteLine("Переменные до изменений:");
        Console.WriteLine("m=" + m);
        Console.WriteLine("n=" + n);
        int r1 = (n++) * (--m);
        Console.WriteLine("1) n++ * --m=" + r1);
        Console.WriteLine("Переменные после изменений:");
        Console.WriteLine("m=" + m);
        Console.WriteLine("n=" + n);

        bool r2, r3;
        Console.WriteLine("Переменные до изменений:");
        Console.WriteLine("m=" + m);
        Console.WriteLine("n=" + n);
        r2 = (n--) < (m++);
        Console.WriteLine("2) n-- < m++=" + r2);
        Console.WriteLine("Переменные после изменений:");
        Console.WriteLine("m=" + m);
        Console.WriteLine("n=" + n);
        Console.WriteLine("Переменные до изменений:");
        Console.WriteLine("m=" + m);
        Console.WriteLine("n=" + n);
        r3 = (--n) > (--m);
        Console.WriteLine("3) --n > --m=" + r3);
        Console.WriteLine("Переменные после изменений:");
        Console.WriteLine("m=" + m);
        Console.WriteLine("n=" + n);

        double r4 = Math.Pow(Math.Abs(x + 1), 0.25) + (1 / Math.Pow(x, 2));
        Console.WriteLine("Math.Pow(Math.Abs(x + 1), 0.25) + (1 / Math.Pow(x, 2)) = " + r4);
        Console.WriteLine("x=" + x);

        double x1 = 0, y1 = 0;
        isValid = false;
        while (!isValid)
        {
            Console.WriteLine("Введите x1 и y1:");
            if (double.TryParse(Console.ReadLine(), out x1) && double.TryParse(Console.ReadLine(), out y1))
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("Ошибка: введите корректные числа типа double.");
            }
        }

        Console.WriteLine("Результат второй задачи:");
        if (((x1 * x1 + y1 * y1 <= 1) && (x1 <= 0 && y1 >= 0)) ||
            ((x1 * x1 + y1 * y1 <= 1) && (x1 >= 0 && y1 <= 0)) ||
            ((y1 == -x1 + 1) && (x1 >= 0 && y1 >= 0)) ||
            ((y1 == -x1 - 1) && (x1 <= 0 && y1 <= 0)))
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }

        double a1 = 0, b1 = 0;
        isValid = false;
        while (!isValid)
        {
            Console.WriteLine("Введите a и b типа double:");
            if (double.TryParse(Console.ReadLine(), out a1) && double.TryParse(Console.ReadLine(), out b1))
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("Ошибка: введите корректные числа типа double.");
            }
        }

        float a2 = 0, b2 = 0;
        isValid = false;
        while (!isValid)
        {
            Console.WriteLine("Введите a и b типа float:");
            if (float.TryParse(Console.ReadLine(), out a2) && float.TryParse(Console.ReadLine(), out b2))
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("Ошибка: введите корректные числа типа float.");
            }
        }

        double c1 = Math.Pow(a1 + b1, 4);
        double d1 = Math.Pow(a1, 4) + 6 * a1 * a1 * b1 * b1 + Math.Pow(b1, 4);
        double e1 = (4 * a1 * b1 * b1 * b1) + (4 * a1 * a1 * a1 * b1);
        float c2 = (float)Math.Pow(a2 + b2, 4);
        float d2 = (float)(Math.Pow(a2, 4) + 6 * a2 * a2 * b2 * b2 + Math.Pow(b2, 4));
        float e2 = (float)((4 * a2 * b2 * b2 * b2) + (4 * a2 * a2 * a2 * b2));

        double r5 = (c1 - d1) / e1;
        float r6 = (c2 - d2) / e2;

        Console.WriteLine("Результат третьей задачи:");
        Console.WriteLine("c1=" + c1);
        Console.WriteLine("d1=" + d1);
        Console.WriteLine("e1=" + e1);
        Console.WriteLine("c2=" + c2);
        Console.WriteLine("d2=" + d2);
        Console.WriteLine("e2=" + e2);
        Console.WriteLine("r5=" + r5);
        Console.WriteLine("r6=" + r6);
    }
}
