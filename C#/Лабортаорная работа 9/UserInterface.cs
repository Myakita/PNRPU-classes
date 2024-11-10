// UserInterface.cs
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

    // Уменьшает время на одну минуту
    public static void SubtractOneMinute(Time time)
    {
        try
        {
            Console.WriteLine("Вычитание одной минуты (--):");
            time.DecrementMinute();
            Console.WriteLine($"Результат: {time}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при вычитании минуты: {ex.Message}");
        }
    }

    // Добавляет указанное количество минут к объекту Time
    public static void AddMinutes(Time time)
    {
        while (true)
        {
            try
            {
                Console.Write("Введите количество минут для добавления: ");
                int minutes = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Значение не может быть пустым."));

                time.AddMinutes(minutes);
                Console.WriteLine($"Результат добавления {minutes} минут: {time}");
                break;
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

    // Складывает два объекта Time и изменяет первый объект на месте
    public static void AddTimes(Time time1, Time time2)
    {
        try
        {
            time1.AddTime(time2);
            Console.WriteLine($"Результат сложения: {time1}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при сложении времени: {ex.Message}");
        }
    }

    // Отображает приведение типов к int и bool
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

    // Создает массив объектов Time
    public static TimeArray CreateTimeArray()
    {
        while (true)
        {
            try
            {
                Console.Write("Введите размер массива Time: ");
                int size = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Значение не может быть пустым."));

                Console.Write("Заполнить случайными значениями? (y/n): ");
                string input = Console.ReadLine()?.Trim().ToLower();
                bool randomize = input == "y";

                return randomize ? new TimeArray(size, randomize: true) : ManualFillTimeArray(size);
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

    // Ручное заполнение массива Time
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

    // Отображает элементы массива TimeArray
    public static void DisplayTimeArray(TimeArray timeArray)
    {
        Console.WriteLine("Элементы массива Time:");
        timeArray.Print();
    }

    // Находит и отображает индекс максимального элемента в массиве TimeArray
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
