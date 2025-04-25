using ShipLibrary;
using ЛабораторнаяРабота12;

namespace Лабораторная_работа_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sea sea = new Sea();

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

            sea.AddSea("Черное море");
            sea.AddSea("Красное море");
            sea.AddSea("Балтийское море");
            sea.AddShip("Красное море", ships[2]);
            sea.AddShip("Красное море", ships[3]);
            sea.AddShip("Красное море", ships[4]);
            sea.AddShip("Черное море", ships[1]);
            sea.AddShip("Черное море", ships[0]);
            sea.AddShip("Балтийское море", ships[7]);
            sea.AddShip("Балтийское море", ships[2]);
            sea.AddShip("Балтийское море", ships[8]);
            sea.AddShip("Балтийское море", ships[6]);
            sea.AddShip("Балтийское море", ships[5]);
            Console.WriteLine("---Часть 1---");
            sea.PrintSeas();

            sea.GetShipsInSeaLinq("Красное море");
            sea.GetShipCountInSeaMethod("Черное море");
            sea.GetCommonShipsMethod("Красное море", "Балтийское море");
            sea.GetMaxDisplacementLinq("Черное море");
            sea.GroupShipsByTypeMethod("Балтийское море");

            Console.WriteLine("---Часть 2---");

            ShipHashTable<string, Ship> seaShips = new ShipHashTable<string, Ship>();

            seaShips.Add("Черное море", new Steamship { Name = "Titanic", Displacement = 46000, EnginePower = 5000 });
            seaShips.Add("Черное море", new Steamship { Name = "Matilda", Displacement = 90000, EnginePower = 7500 });
            seaShips.Add("Красное море", new Sailboat { Name = "Black Pearl", Displacement = 2000, SailArea = 150 });
            seaShips.Add("Красное море", new Sailboat { Name = "White Power", Displacement = 3500, SailArea = 100 });

            seaShips.PrintToConsole();

            var largeShips = seaShips.SelectByCondition(s => s.Value.Displacement > 5000);
            Console.WriteLine("Корабли с водоизмещением > 5000:");
            foreach (var ship in largeShips)
                Console.WriteLine(ship.Value.Name);

            double avgDisplacement = seaShips.AggregateData(s => s.Value.Displacement, values => values.Average());
            Console.WriteLine($"Среднее водоизмещение: {avgDisplacement}");

            var sortedShips = seaShips.Sort(s => s.Value.Displacement, ascending: false);
            Console.WriteLine("Корабли, отсортированные по водоизмещению:");
            foreach (var ship in sortedShips)
                Console.WriteLine($"{ship.Value.Name} ({ship.Value.Displacement})");

            var groupedShips = seaShips.GroupByProperty(s => s.Key);
            Console.WriteLine("Группировка кораблей по морю:");
            foreach (var group in groupedShips)
            {
                Console.WriteLine($"Море: {group.Key}");
                foreach (var ship in group.Value)
                    Console.WriteLine($"  - {ship.Value.Name}");
            }

            Console.WriteLine("---Делаем замеры---");
            static void PrintResult(IEnumerable<KeyValuePair<string, Ship>> result)
            {
                foreach (var ship in result)
                {
                    Console.WriteLine($"{ship.Key} - {ship.Value.Displacement}");
                }
            }

            ShipHashTable<string, Ship> seaShipsForTimeMeasure = new ShipHashTable<string, Ship>();
            seaShips.Add("Titanic", new Steamship { Name = "Titanic", Displacement = 46000, EnginePower = 5000 });
            seaShips.Add("Black Pearl", new Sailboat { Name = "Black Pearl", Displacement = 2000, SailArea = 150 });
            seaShips.Add("Victory", new Corvette { Name = "Victory", Displacement = 3000, CrewSize = 5 });

            Func<KeyValuePair<string, Ship>, bool> condition = kvp => kvp.Value.Displacement > 3000;

            Console.WriteLine("\n=== LINQ ===");
            var linqResult = seaShipsForTimeMeasure.SelectByCondition_LINQ(condition);

            Console.WriteLine("\n=== Метод расширения ===");
            var extensionResult = seaShipsForTimeMeasure.SelectByCondition_Extension(condition);

            Console.WriteLine("\n=== Foreach ===");
            var foreachResult = seaShipsForTimeMeasure.SelectByCondition_Foreach(condition);
        }

    }
}

