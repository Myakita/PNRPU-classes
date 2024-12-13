using System;
using ShipLibrary;

namespace Лабораторная_работа_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Тестирование производительности коллекций");
            int collectionSize = GetValidInt("Введите количество элементов для создания коллекции: ", 1);

            Console.WriteLine("Инициализация тестовых коллекций...");
            TestCollections testCollections = new TestCollections(collectionSize);
            Console.WriteLine("Коллекции успешно созданы!");

            testCollections.MeasureSearchTime();

            var collections = new TestCollections(1000);
            var newShip = new Steamship("Новый корабль", 5000, 1500);
            collections.AddElement(newShip);
            collections.RemoveElement(newShip);

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();

            
        }

        private static int GetValidInt(string prompt, int minValue)
        {
            int value;
            bool isValid;
            do
            {
                Console.Write(prompt);
                isValid = int.TryParse(Console.ReadLine(), out value) && value >= minValue;
                if (!isValid)
                {
                    Console.WriteLine($"Пожалуйста, введите целое число больше или равное {minValue}.");
                }
            } while (!isValid);
            return value;
        }
    }
}
