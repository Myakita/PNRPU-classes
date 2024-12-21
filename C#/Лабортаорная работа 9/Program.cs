using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Создание объекта Time:");
        Time time1 = UserInterface.CreateTime();

        TimeArray timeArray = null;
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nДоступные операции:");
            Console.WriteLine("1. Вывод объекта времени");
            Console.WriteLine("2. Вычитание одной минуты (--)");
            Console.WriteLine("3. Добавление минут к времени (+ с целым числом)");
            Console.WriteLine("4. Сложение двух объектов Time (+ между Time)");
            Console.WriteLine("5. Приведение типов (int и bool)");
            Console.WriteLine("6. Создание массива Time");
            Console.WriteLine("7. Просмотр элементов массива Time");
            Console.WriteLine("8. Поиск максимального элемента массива");
            Console.WriteLine("0. Выход");

            Console.Write("\nВыберите операцию (0-7): ");
            int choice;

            try
            {
                choice = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Значение не может быть пустым."));
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Введите корректное числовое значение.");
                continue;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка ввода: {ex.Message}");
                continue;
            }

            switch (choice)
            {
                case 1:
                    UserInterface.ShowTime(time1);
                    break;
                case 2:
                    UserInterface.PerformUnaryOperation(time1);
                    break;
                case 3:
                    UserInterface.PerformAdditionWithMinutes(time1);
                    break;
                case 4:
                    Console.WriteLine("Создание второго объекта Time для сложения:");
                    Time time2 = UserInterface.CreateTime();
                   
                    UserInterface.PerformAdditionWithTime(time1, time2);
                    break;
                case 5:
                    UserInterface.DisplayConversions(time1);
                    break;
                case 6:
                    timeArray = UserInterface.CreateTimeArray();
                    Console.WriteLine("Массив Time создан.");
                    break;
                case 7:
                    if (timeArray != null)
                    {
                        UserInterface.DisplayTimeArray(timeArray);
                    }
                    else
                    {
                        Console.WriteLine("Массив еще не создан. Пожалуйста, выберите пункт 5 для создания массива.");
                    }
                    break;
                case 8:
                    if (timeArray != null)
                    {
                        UserInterface.DisplayMaxIndex(timeArray);
                    }
                    else
                    {
                        Console.WriteLine("Массив еще не создан. Пожалуйста, выберите пункт 5 для создания массива.");
                    }
                    break;
                case 0:
                    exit = true;
                    Console.WriteLine("Выход из программы...");
                    break;
                default:
                    Console.WriteLine("Некорректный выбор операции. Попробуйте снова.");
                    break;
            }
        }

        Console.WriteLine($"\nОбщее количество созданных объектов Time: {Time.ObjectCount}");
    }
}
