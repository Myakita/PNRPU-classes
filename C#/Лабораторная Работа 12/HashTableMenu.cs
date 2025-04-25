using ShipLibrary;
using System;
using ЛабораторнаяРабота12;

namespace ЛабораторнаяРабота12
{
    internal class HashTableMenu
    {
        public static void HashTableMenuOpen()
        {
            var hashTable = new ShipHashTable<string, Ship>();
            bool back = false;

            while (!back)
            {
                Console.Clear();
                Console.WriteLine("Работа с хеш-таблицей (метод цепочек)");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("1. Добавить корабль");
                Console.WriteLine("2. Рандомная генерация");
                Console.WriteLine("3. Найти корабль по ключу");
                Console.WriteLine("4. Удалить корабль по ключу");
                Console.WriteLine("5. Показать хеш-таблицу");
                Console.WriteLine("6. Очистить хеш-таблицу");
                Console.WriteLine("0. Вернуться в главное меню");

                Console.Write("\nВаш выбор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddShipToHashTable(hashTable);
                        break;
                    case "2":
                        RandomGen(hashTable);
                        break;
                    case "3":
                        FindShipByKey(hashTable);
                        break;
                    case "4":
                        RemoveShipByKey(hashTable);
                        break;
                    case "5":
                        ShowHashTable(hashTable);
                        break;
                    case "6":
                        hashTable.Clear();
                        Console.WriteLine("\nХеш-таблица очищена.");
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("\nНеверный выбор. Попробуйте снова.");
                        break;
                }
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        static void RandomGen(ShipHashTable<string, Ship> hashtable)
        {
            Console.Write("Введите количество кораблей: ");
            if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
            {
                Console.WriteLine("Ошибка! Введите корректное число.");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                hashtable.Add($"{i+1}", new Ship($"Корабль{i + 1}", i + 1));
            }
            Console.WriteLine($"\nДобавлено {count} кораблей.");
        }

        static void AddShipToHashTable(ShipHashTable<string, Ship> hashTable)
        {
            Console.Clear();
            Console.WriteLine("Добавление корабля в хеш-таблицу");
            Console.WriteLine("--------------------------------");

            Ship ship = CreateShip();
            if (ship != null)
            {
                hashTable.Add(ship.Name, ship);
                Console.WriteLine("\nКорабль успешно добавлен.");
            }
        }

        static void FindShipByKey(ShipHashTable<string, Ship> hashTable)
        {
            Console.Clear();
            Console.WriteLine("Поиск корабля по ключу");
            Console.WriteLine("----------------------");

            Console.Write("Введите ключ (имя корабля): ");
            string key = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(key))
            {
                Console.WriteLine("Ошибка! Имя не может быть пустым.");
                return;
            }

            if (hashTable.TryGetValue(key, out Ship ship))
            {
                Console.WriteLine("\nНайден корабль:");
                ship.Show();
            }
            else
            {
                Console.WriteLine($"\nКорабль с ключом '{key}' не найден.");
            }
        }

        static void RemoveShipByKey(ShipHashTable<string, Ship> hashTable)
        {
            Console.Clear();
            Console.WriteLine("Удаление корабля по ключу");
            Console.WriteLine("-------------------------");

            Console.Write("Введите ключ: ");
            string key = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(key))
            {
                Console.WriteLine("Ошибка! Имя не может быть пустым.");
                return;
            }

            if (hashTable.Remove(key))
            {
                Console.WriteLine($"\nКорабль с ключом '{key}' успешно удален.");
            }
            else
            {
                Console.WriteLine($"\nКорабль с ключом '{key}' не найден.");
            }
        }

        static void ShowHashTable(ShipHashTable<string, Ship> hashTable)
        {
            Console.Clear();
            Console.WriteLine("Содержимое хеш-таблицы:");
            Console.WriteLine("----------------------");
            hashTable.Print();
        }

        static Ship CreateShip()
        {
            Console.WriteLine("\nВыберите тип корабля:");
            Console.WriteLine("1. Обычный корабль");
            Console.WriteLine("2. Пароход");
            Console.WriteLine("3. Корвет");
            Console.WriteLine("4. Парусник");

            string choice = Console.ReadLine();
            Console.Write("Введите название корабля: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Ошибка! Имя не может быть пустым.");
                return null;
            }

            Console.Write("Введите водоизмещение корабля: ");
            if (!double.TryParse(Console.ReadLine(), out double displacement))
            {
                Console.WriteLine("Ошибка! Введите корректное число.");
                return null;
            }

            switch (choice)
            {
                case "2":
                    Console.Write("Введите мощность двигателя: ");
                    if (!int.TryParse(Console.ReadLine(), out int enginePower))
                    {
                        Console.WriteLine("Ошибка! Введите корректное число.");
                        return null;
                    }
                    return new Steamship(name, displacement, enginePower);
                case "3":
                    Console.Write("Введите размер экипажа: ");
                    if (!int.TryParse(Console.ReadLine(), out int crewSize))
                    {
                        Console.WriteLine("Ошибка! Введите корректное число.");
                        return null;
                    }
                    return new Corvette(name, displacement, crewSize);
                case "4":
                    Console.Write("Введите площадь паруса (м²): ");
                    if (!int.TryParse(Console.ReadLine(), out int sailArea))
                    {
                        Console.WriteLine("Ошибка! Введите корректное число.");
                        return null;
                    }
                    return new Sailboat(name, displacement, sailArea);
                default:
                    return new Ship(name, displacement);
            }
        }
    }
}
