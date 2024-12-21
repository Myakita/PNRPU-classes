using System;

public static class UserInterface
{
    public static Time CreateTime()
    {
        while (true)
        {
            try
            {
                Console.Write("Введите количество часов: ");
                int hours = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Значение не может быть пустым."));

                Console.Write("Введите количество минут: ");
                int minutes = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Значение не может быть пустым."));

                return new Time(hours, minutes);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка ввода: {ex.Message}. Попробуйте снова.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Введите корректное числовое значение.");
            }
        }
    }
    public static void ShowTime(Time time) 
    {
        time.Show();
    }

    public static void PerformUnaryOperation(Time time)
    {
        Console.WriteLine("Применение унарной операции (--):");
        time = --time;
        Console.WriteLine($"Результат: {time}");
    }

    public static void PerformAdditionWithMinutes(Time time)
    {
        Console.Write("Введите количество минут для добавления: ");
        if (int.TryParse(Console.ReadLine(), out int minutes))
        {
            time += minutes;
            
            Console.WriteLine($"Результат: {time}");
        }
        else
        {
            Console.WriteLine("Ошибка: Введите корректное значение минут.");
        }
    }

    public static void PerformAdditionWithTime(Time time1, Time time2)
    {
        Console.WriteLine("Сложение двух временных интервалов:");
        time1 = time1 + time2;
        Console.WriteLine($"Результат: {time1}");
    }


    public static void DisplayConversions(Time time)
    {
        try
        {
            Console.WriteLine($"Явное приведение к int (часы): {(int)time}");
            Console.WriteLine($"Неявное приведение к bool (проверка ненулевого времени): {(time ? "True" : "False")}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при выполнении приведения: {ex.Message}");
        }
    }

    public static TimeArray CreateTimeArray()
    {
        while (true)
        {
            try
            {
                Console.Write("Введите размер массива Time: ");
                string sizeInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(sizeInput))
                    throw new ArgumentException("Значение не может быть пустым.");

                int size = int.Parse(sizeInput);

                string input = "";
                while (input != "y" && input != "n")
                {
                    Console.Write("Заполнить случайными значениями? (y/n): ");
                    input = Console.ReadLine().Trim().ToLower();

                    if (input != "y" && input != "n")
                        Console.WriteLine("Ошибка: Введите 'y' для да или 'n' для нет.");
                }

                bool randomize = input == "y";

                if (randomize)
                {
                    return new TimeArray(size, randomize: true);
                }
                else
                {
                    return ManualFillTimeArray(size);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка ввода: {ex.Message}. Попробуйте снова.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Введите корректное числовое значение.");
            }
        }
    }

    private static TimeArray ManualFillTimeArray(int size)
    {
        TimeArray timeArray = new TimeArray(size);
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Ввод значения для элемента {i + 1}:");
            timeArray[i] = CreateTime();
        }
        return timeArray;
    }

    public static void DisplayTimeArray(TimeArray timeArray)
    {
        Console.WriteLine("Элементы массива Time:");
        timeArray.Print();
    }

    public static void DisplayMaxIndex(TimeArray timeArray)
    {
        try
        {
            int maxIndex = timeArray.MaxIndex();
            Console.WriteLine($"Индекс элемента с максимальным временем: {maxIndex}");
            Console.WriteLine($"Максимальный элемент: {timeArray[maxIndex]}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при поиске максимального элемента: {ex.Message}");
        }
    }
}
