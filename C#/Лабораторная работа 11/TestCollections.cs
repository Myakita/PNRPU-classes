using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ShipLibrary;

namespace Лабораторная_работа_11
{
    public class TestCollections
    {
        private Queue<Steamship> steamships;
        private Queue<string> steamshipStrings;
        private SortedDictionary<Ship, Steamship> shipSteamshipDictionary;
        private SortedDictionary<string, Steamship> stringSteamshipDictionary;
        private static int collision;

        public int Count => steamships.Count;

        public TestCollections(int count)
        {
            steamships = new Queue<Steamship>();
            steamshipStrings = new Queue<string>();
            shipSteamshipDictionary = new SortedDictionary<Ship, Steamship>();
            stringSteamshipDictionary = new SortedDictionary<string, Steamship>();

            for (int i = 0; i < count; i++)
            {
                Steamship steamship;
                string steamshipString;

                do
                {
                    steamship = new Steamship();
                    steamship.RandomInit();
                    steamshipString = steamship.ToString();
                    collision++;
                }
                while (shipSteamshipDictionary.ContainsKey(steamship.BaseShip) || stringSteamshipDictionary.ContainsKey(steamshipString));

                steamships.Enqueue(steamship);
                steamshipStrings.Enqueue(steamshipString);
                shipSteamshipDictionary.Add(steamship.BaseShip, steamship);
                stringSteamshipDictionary.Add(steamshipString, steamship);
            }
        }

        public void AddElement(Steamship steamship)
        {
            if (steamship == null)
            {
                throw new ArgumentNullException(nameof(steamship), "Добавляемый элемент не может быть null");
            }

            if (steamships.Contains(steamship))
            {
                throw new ArgumentException($"Пароход с именем '{steamship.Name}' и водоизмещением {steamship.Displacement} уже существует в Queue<Steamship>");
            }

            string steamshipString = steamship.ToString();
            if (steamshipStrings.Contains(steamshipString))
            {
                throw new ArgumentException($"Строковое представление '{steamshipString}' уже существует в Queue<string>");
            }

            if (shipSteamshipDictionary.ContainsKey(steamship.BaseShip))
            {
                throw new ArgumentException($"Корабль с именем '{steamship.Name}' и водоизмещением {steamship.Displacement} уже существует как ключ в SortedDictionary<Ship, Steamship>");
            }

            if (stringSteamshipDictionary.ContainsKey(steamshipString))
            {
                throw new ArgumentException($"Строковое представление '{steamshipString}' уже существует как ключ в SortedDictionary<string, Steamship>");
            }

            Console.WriteLine("\nВремя добавления элементов:");
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            steamships.Enqueue(steamship);
            stopwatch.Stop();
            Console.WriteLine($"Queue<Steamship>: {stopwatch.ElapsedTicks} тиков");

            stopwatch.Restart();
            steamshipStrings.Enqueue(steamshipString);
            stopwatch.Stop();
            Console.WriteLine($"Queue<string>: {stopwatch.ElapsedTicks} тиков");

            stopwatch.Restart();
            shipSteamshipDictionary.Add(steamship.BaseShip, steamship);
            stopwatch.Stop();
            Console.WriteLine($"SortedDictionary<Ship, Steamship>: {stopwatch.ElapsedTicks} тиков");

            stopwatch.Restart();
            stringSteamshipDictionary.Add(steamshipString, steamship);
            stopwatch.Stop();
            Console.WriteLine($"SortedDictionary<string, Steamship>: {stopwatch.ElapsedTicks} тиков");

            collision++;
        }

        public void RemoveElement(Steamship steamship)
        {
            if (!steamships.Contains(steamship))
            {
                throw new KeyNotFoundException($"Элемент {steamship} отсутствует");
            }

            Console.WriteLine("\nВремя удаления элементов:");
            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            var tempQueue = new Queue<Steamship>();
            while (steamships.Count > 0)
            {
                var current = steamships.Dequeue();
                if (!current.Equals(steamship))
                {
                    tempQueue.Enqueue(current);
                }
            }
            steamships = tempQueue;
            stopwatch.Stop();
            Console.WriteLine($"Queue<Steamship>: {stopwatch.ElapsedTicks} тиков");

            stopwatch.Restart();
            var tempStringQueue = new Queue<string>();
            while (steamshipStrings.Count > 0)
            {
                var current = steamshipStrings.Dequeue();
                if (current != steamship.ToString())
                {
                    tempStringQueue.Enqueue(current);
                }
            }
            steamshipStrings = tempStringQueue;
            stopwatch.Stop();
            Console.WriteLine($"Queue<string>: {stopwatch.ElapsedTicks} тиков");

            stopwatch.Restart();
            shipSteamshipDictionary.Remove(new Ship(steamship.Name, steamship.Displacement));
            stopwatch.Stop();
            Console.WriteLine($"SortedDictionary<Ship, Steamship>: {stopwatch.ElapsedTicks} тиков");

            stopwatch.Restart();
            stringSteamshipDictionary.Remove(steamship.ToString());
            stopwatch.Stop();
            Console.WriteLine($"SortedDictionary<string, Steamship>: {stopwatch.ElapsedTicks} тиков");

            collision--;
        }

        public int GetCollision()
        {
            return collision - steamships.Count;
        }

        public void Show()
        {
            foreach (var ship in steamships)
            {
                ship.Show();
            }
        }

        public void MeasureSearchTime()
        {
            if (steamships.Count == 0)
            {
                Console.WriteLine("Коллекции пусты.");
                return;
            }

            Steamship first = (Steamship)steamships.Peek().Clone();
            Steamship middle = (Steamship)GetMiddleElement().Clone();
            Steamship last = (Steamship)GetLastElement().Clone();
            Steamship notFound = new Steamship("Несуществующий пароход", 999999, 1000);

            Console.WriteLine("\nQueue<Steamship>");
            MeasureContains(steamships, first, "Первый элемент");
            MeasureContains(steamships, middle, "Центральный элемент");
            MeasureContains(steamships, last, "Последний элемент");
            MeasureContains(steamships, notFound, "Несуществующий элемент");

            Console.WriteLine("\nQueue<string>");
            MeasureContains(steamshipStrings, first.ToString(), "Строковое представление первого элемента");
            MeasureContains(steamshipStrings, middle.ToString(), "Строковое представление центрального элемента");
            MeasureContains(steamshipStrings, last.ToString(), "Строковое представление последнего элемента");
            MeasureContains(steamshipStrings, notFound.ToString(), "Строковое представление несуществующего элемента");

            Console.WriteLine("\nSortedDictionary<Ship, Steamship>");
            MeasureContainsKey(shipSteamshipDictionary, new Ship(first.Name, first.Displacement), "Ключ первого элемента");
            MeasureContainsKey(shipSteamshipDictionary, new Ship(middle.Name, middle.Displacement), "Ключ центрального элемента");
            MeasureContainsKey(shipSteamshipDictionary, new Ship(last.Name, last.Displacement), "Ключ последнего элемента");
            MeasureContainsKey(shipSteamshipDictionary, new Ship(notFound.Name, notFound.Displacement), "Ключ несуществующего элемента");

            Console.WriteLine("\nSortedDictionary<string, Steamship> по ключу");
            MeasureContainsKey(stringSteamshipDictionary, first.ToString(), "Ключ-строка первого элемента");
            MeasureContainsKey(stringSteamshipDictionary, middle.ToString(), "Ключ-строка центрального элемента");
            MeasureContainsKey(stringSteamshipDictionary, last.ToString(), "Ключ-строка последнего элемента");
            MeasureContainsKey(stringSteamshipDictionary, notFound.ToString(), "Ключ-строка несуществующего элемента");

            Console.WriteLine("\nSortedDictionary<Ship, Steamship> по значению");
            MeasureContainsValue(shipSteamshipDictionary, first, "Значение первого элемента");
            MeasureContainsValue(shipSteamshipDictionary, middle, "Значение центрального элемента");
            MeasureContainsValue(shipSteamshipDictionary, last, "Значение последнего элемента");
            MeasureContainsValue(shipSteamshipDictionary, notFound, "Значение несуществующего элемента");
        }

        private Steamship GetMiddleElement()
        {
            var count = steamships.Count;
            var middleIndex = count / 2;
            var tempQueue = new Queue<Steamship>();
            for (int i = 0; i < middleIndex; i++)
            {
                tempQueue.Enqueue(steamships.Dequeue());
            }
            var middleElement = steamships.Peek();
            while (tempQueue.Count > 0)
            {
                steamships.Enqueue(tempQueue.Dequeue());
            }
            return middleElement;
        }

        private Steamship GetLastElement()
        {
            var count = steamships.Count;
            var tempQueue = new Queue<Steamship>();
            for (int i = 0; i < count - 1; i++)
            {
                tempQueue.Enqueue(steamships.Dequeue());
            }
            var lastElement = steamships.Peek();
            while (tempQueue.Count > 0)
            {
                steamships.Enqueue(tempQueue.Dequeue());
            }
            return lastElement;
        }

        private void MeasureContains<T>(Queue<T> queue, T element, string description)
        {
            var stopwatch = Stopwatch.StartNew();
            var found = queue.Contains(element);
            stopwatch.Stop();
            Console.WriteLine($"Поиск {description} в Queue<T>: {stopwatch.ElapsedTicks} тиков, найден: {found}");
        }

        private void MeasureContainsKey<TKey>(SortedDictionary<TKey, Steamship> dictionary, TKey key, string description)
        {
            var stopwatch = Stopwatch.StartNew();
            var found = dictionary.ContainsKey(key);
            stopwatch.Stop();
            Console.WriteLine($"Поиск {description} в SortedDictionary<TKey, Steamship>: {stopwatch.ElapsedTicks} тиков, найден: {found}");
        }

        private void MeasureContainsValue(SortedDictionary<Ship, Steamship> dictionary, Steamship value, string description)
        {
            var stopwatch = Stopwatch.StartNew();
            var found = dictionary.ContainsValue(value);
            stopwatch.Stop();
            Console.WriteLine($"Поиск {description} в SortedDictionary<Ship, Steamship>: {stopwatch.ElapsedTicks} тиков, найден: {found}");
        }
    }
}
