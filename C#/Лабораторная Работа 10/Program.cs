using System;
using ShipLibrary;

namespace Лабораторная_Работа_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Ship[] ships = new Ship[]
            {
            new Steamship { Name = "Titanic", Displacement = 46000, EnginePower = 5000 },
            new Steamship { Name = "Matilda", Displacement = 90000, EnginePower = 7500 },
            new Steamship { Name = "Isolda", Displacement = 25000, EnginePower = 10000 },
            new Sailboat { Name = "Black Pearl", Displacement = 2000, SailArea = 150 },
            new Sailboat { Name = "White Power", Displacement = 3500, SailArea = 100 },
            new Sailboat { Name = "Hen Tai", Displacement = 1500, SailArea = 50 },
            new Sailboat { Name = "Bo Sinn", Displacement = 9000, SailArea = 250 },
            new Corvette { Name = "Victory", Displacement = 3000, CrewSize = 5 },
            new Ship { Name = "Enterprise", Displacement = 8000 }
            };
            Console.WriteLine("\n=== Демонстрация метода Display ===");
            foreach (var ship in ships)
            {
                ship.Display();
            }
            Console.WriteLine("=== До сортировки ===");
            foreach (var ship in ships)
            {
                ship.Show();
            }

            Array.Sort(ships);

            Console.WriteLine("=== После сортировки ===");
            foreach (var ship in ships)
            {
                ship.Show();
            }

            

            Console.Write("\nВведите минимальное водоизмещение для подсчета: ");
            double minDisplacement;
            while (!double.TryParse(Console.ReadLine(), out minDisplacement))
            {
                Console.WriteLine("Пожалуйста, введите корректное число.");
            }
            int count = 0;
            foreach (var ship in ships)
            {
                if (ship.Displacement > minDisplacement)
                {
                    count++;
                }
            }
            Console.WriteLine($"Количество судов с водоизмещением больше {minDisplacement}: {count}");

            Console.WriteLine("\nНазвания всех пароходов:");
            foreach (var ship in ships)
            {
                if (ship is Steamship steamship)
                {
                    Console.WriteLine(steamship.Name);
                }
            }

            double totalDisplacement = 0;
            int sailboatCount = 0;
            foreach (var ship in ships)
            {
                if (ship is Sailboat sailboat)
                {
                    totalDisplacement += sailboat.Displacement;
                    sailboatCount++;
                }
            }
            if (sailboatCount > 0)
            {
                double averageDisplacement = totalDisplacement / sailboatCount;
                Console.WriteLine($"\nСреднее водоизмещение всех парусников: {averageDisplacement:F2}");
            }
            else
            {
                Console.WriteLine("\nПарусников в списке нет.");
            }


            Console.WriteLine("\n=== Демонстрация клонирования ===");
            Student student1 = new Student();
            student1.Name = "Иванов";
            student1.Grades = new int[] { 5, 4, 5, 4, 5 };

            Console.WriteLine("Исходный студент:");
            student1.Show();

            Student shallowCopy = student1.ShallowCopy();
            Console.WriteLine("\nПоверхностная копия:");
            shallowCopy.Show();

            Student deepCopy = student1.DeepCopy();
            Console.WriteLine("\nГлубокая копия:");
            deepCopy.Show();

            Console.WriteLine("\nИзменяем оценки в исходном объекте...");
            student1.Grades[0] = 2;
            student1.Name = "Измененный Иванов";

            Console.WriteLine("\nПосле изменения исходного объекта:");
            Console.WriteLine("Исходный объект:");
            student1.Show();
            Console.WriteLine("Поверхностная копия:");
            shallowCopy.Show();
            Console.WriteLine("Глубокая копия:");
            deepCopy.Show();
        }
    }
}
