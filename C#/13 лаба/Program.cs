using ЛабораторнаяРабота12;
using ShipLibrary;

namespace Лабораторная_работа_13
{
    internal class Program : ShipCollectionNew<string, Ship>
    {
        static void Main(string[] args)
        {
            ShipCollectionNew<string, Ship> FTable = new ShipCollectionNew<string, Ship>() { Name = "FTable" };
            ShipCollectionNew<string, Ship> STable = new ShipCollectionNew<string, Ship>() { Name = "STable" };


            Journal FJournal = new Journal();
            Journal SJournal = new Journal();

            FTable.CollectionCountChanged += FJournal.CollectionCountChanged;
            FTable.CollectionReferenceChanged += FJournal.CollectionRefChanged;

            STable.CollectionReferenceChanged += SJournal.CollectionRefChanged;
            STable.CollectionCountChanged += SJournal.CollectionCountChanged;

            FTable.Add("Корабль1", new Ship("Корабль1", 2));
            FTable.Add("Корабль2", new Corvette("Корабль2", 2, 3));
            FTable.Add("Корабль3", new Steamship("Корабль3", 2, 4));

            STable.Add("Корабль4", new Ship("Корабль4", 2));
            STable.Add("Корабль5", new Steamship("Корабль5", 2, 4));
            STable.Add("Корабль6", new Sailboat("Корабль6", 2, 52));

            FTable.Remove("Корабль1");
            FTable.Remove("Корабль3");

            STable.Remove("Корабль4");
            STable.Remove("Корабль6");

            FTable["Корабль2"] = new Corvette("КорабльТесея", 2, 42);
            STable["Корабль5"] = new Steamship("ЕщеКорабльТесея", 3, 55);

            Console.WriteLine("Первый журнал:");
            FJournal.PrintLog();
            Console.WriteLine("Второй журнал:");
            SJournal.PrintLog();
        }
    }
}
