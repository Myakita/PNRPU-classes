using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipLibrary;
using ЛабораторнаяРабота12;

namespace Лабораторная_работа_14
{
    public class Sea
    {
        private SortedDictionary<string,List<Ship>> seas = new();

        public void AddSea(string seaName)
        {
            if (!seas.ContainsKey(seaName))
            {
                seas[seaName] = new List<Ship>();
            }
        }

        public void AddShip(string seaName, Ship ship)
        {
            if (!seas.ContainsKey(seaName))
            {
                AddSea(seaName);
            }
            seas[seaName].Add(ship);
        }

        public void PrintSeas()
        {
            foreach (var sea in seas)
            {
                Console.WriteLine($"Море: {sea.Key}");
                foreach (var ship in sea.Value)
                {
                    Console.WriteLine($"  - {ship}");
                }
            }
        }

        public void GetShipsInSeaLinq(string seaName)
        {
            var ships = (from sea in seas
                         where sea.Key == seaName
                         from ship in sea.Value
                         select ship).ToList();

            Console.WriteLine($"Корабли в {seaName} (LINQ):");
            foreach (var ship in ships)
            {
                Console.WriteLine($"- {ship.Name} (Водоизмещение: {ship.Displacement})");
            }
        }

        public void GetShipCountInSeaLinq(string seaName)
        {
            int count = (from sea in seas
                         where sea.Key == seaName
                         select sea.Value.Count).FirstOrDefault();

            Console.WriteLine($"Количество кораблей в {seaName} (LINQ): {count}");
        }

        public void GetCommonShipsLinq(string sea1, string sea2)
        {
            var commonShips = seas[sea1].Intersect(seas[sea2]).ToList();

            Console.WriteLine($"Общие корабли в {sea1} и {sea2}:");
            foreach (var ship in commonShips)
            {
                Console.WriteLine($"- {ship.Name}");
            }
        }

        public void GetMaxDisplacementLinq(string seaName)
        {
            double maxDisplacement = (from ship in seas[seaName]
                                   select ship.Displacement).Max();

            Console.WriteLine($"Максимальное водоизмещение корабля в {seaName} (LINQ): {maxDisplacement}");
        }

        public void GroupShipsByTypeLinq(string seaName)
        {
            var groupedShips = (from ship in seas[seaName]
                                group ship by ship.GetType() into shipGroup
                                select new { Type = shipGroup.Key, Ships = shipGroup.ToList() })
                        .ToDictionary(g => g.Type, g => g.Ships);

            Console.WriteLine($"Группировка кораблей в {seaName} (LINQ):");
            foreach (var group in groupedShips)
            {
                Console.WriteLine($"Тип: {group.Key.Name}");
                foreach (var ship in group.Value)
                {
                    Console.WriteLine($"  - {ship.Name}");
                }
            }
        }

        public void GroupShipsByTypeMethod(string seaName)
        {
            var groupedShips = seas[seaName]
        .GroupBy(ship => ship.GetType())
        .ToDictionary(g => g.Key, g => g.ToList());

            Console.WriteLine($"Группировка кораблей в {seaName} (Методы расширения):");
            foreach (var group in groupedShips)
            {
                Console.WriteLine($"Тип: {group.Key.Name}");
                foreach (var ship in group.Value)
                {
                    Console.WriteLine($"  - {ship.Name}");
                }
            }
        }

        public void GetMaxDisplacementMethod(string seaName)
        {
            double maxDisplacement = seas[seaName].Max(ship => ship.Displacement);

            Console.WriteLine($"Максимальное водоизмещение корабля в {seaName} (Методы расширения): {maxDisplacement}");
        }

        public void GetCommonShipsMethod(string sea1, string sea2)
        {
            var commonShips = seas[sea1].Intersect(seas[sea2]).ToList();

            Console.WriteLine($"Общие корабли в {sea1} и {sea2}:");
            foreach (var ship in commonShips)
            {
                Console.WriteLine($"- {ship.Name}");
            }
        }

        public void GetUnionShipsMethod(string sea1, string sea2)
        {
            var allShips = seas[sea1].Union(seas[sea2]).ToList();

            Console.WriteLine($"Все корабли из {sea1} и {sea2}:");
            foreach (var ship in allShips)
            {
                Console.WriteLine($"- {ship.Name}");
            }
        }

        public void GetDifferenceShipsMethod(string sea1, string sea2)
        {
            var diffShips = seas[sea1].Except(seas[sea2]).ToList();

            Console.WriteLine($"Корабли, которые есть в {sea1}, но нет в {sea2}:");
            foreach (var ship in diffShips)
            {
                Console.WriteLine($"- {ship.Name}");
            }
        }
        public void GetShipCountInSeaMethod(string seaName)
        {
            int count = seas.Where(sea => sea.Key == seaName)
                    .Select(sea => sea.Value.Count)
                    .FirstOrDefault();

            Console.WriteLine($"Количество кораблей в {seaName} (Методы расширения): {count}");
        }
        public void GetShipsInSeaMethod(string seaName)
        {
            var ships = seas.Where(sea => sea.Key == seaName)
                    .SelectMany(sea => sea.Value)
                    .ToList();

            Console.WriteLine($"Корабли в {seaName} (Методы расширения):");
            foreach (var ship in ships)
            {
                Console.WriteLine($"- {ship.Name} (Водоизмещение: {ship.Displacement})");
            }
        }

    }
}
