using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ЛабораторнаяРабота12;
using ShipLibrary;

public class Form1Logic
{
    public ShipHashTable<string, Ship> Table { get; private set; } = new ShipHashTable<string, Ship>();
    public readonly LogJournal LogJournal = new LogJournal();

    public void GenerateShips(string countText)
    {
        if (int.TryParse(countText, out int count) && count > 0)
        {
            Table = new ShipHashTable<string, Ship>();
            var rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                string name = $"корабль{i + 1}";
                Ship ship;
                int type = rnd.Next(3);
                switch (type)
                {
                    case 0: ship = new Corvette(); break;
                    case 1: ship = new Steamship(); break;
                    default: ship = new Sailboat(); break;
                }
                ship.Name = name;
                ship.RandomInit();
                ship.Name = name;
                Table.Add(name, ship);
            }
        }
    }

    public IEnumerable<KeyValuePair<string, Ship>> SortedByShipNumber()
    {
        return Table.OrderBy(pair =>
        {
            var key = pair.Key;
            int num = 0;
            if (key != null)
            {
                for (int i = key.Length - 1; i >= 0; i--)
                {
                    if (!char.IsDigit(key[i]))
                    {
                        int.TryParse(key.Substring(i + 1), out num);
                        break;
                    }
                }
            }
            return num;
        });
    }

    public IShipSerializer GetSerializer(string format)
    {
        switch (format)
        {
            case "XML": return new XmlShipSerializer();
            case "Binary": return new BinaryShipSerializer();
            default: return new JsonShipSerializer();
        }
    }

    public string GetExtension(string format)
    {
        switch (format)
        {
            case "XML": return ".xml";
            case "Binary": return ".bin";
            default: return ".json";
        }
    }

    public void SaveToFile(string filePath, string format)
    {
        var serializer = GetSerializer(format);
        serializer.Serialize(filePath, Table);
        LogJournal.Add($"Коллекция сохранена в файл: {filePath}");
    }

    public void LoadFromFile(string filePath, string format)
    {
        var serializer = GetSerializer(format);
        Table = serializer.Deserialize(filePath);
        LogJournal.Add($"Коллекция загружена из файла: {filePath}");
    }

    public (long syncSave, long syncLoad, long asyncSave, long asyncLoad) MeasureSerialization(string filePath, string format)
    {
        var serializer = GetSerializer(format);
        var sw = Stopwatch.StartNew();
        serializer.Serialize(filePath, Table);
        sw.Stop();
        var syncSave = sw.ElapsedTicks;

        sw.Restart();
        var t = serializer.Deserialize(filePath);
        sw.Stop();
        var syncLoad = sw.ElapsedTicks;

        long asyncSave = 0, asyncLoad = 0;
        asyncSave = System.Threading.Tasks.Task.Run(() =>
        {
            var swAsync = Stopwatch.StartNew();
            serializer.Serialize(filePath, Table);
            swAsync.Stop();
            return swAsync.ElapsedTicks;
        }).Result;
        asyncLoad = System.Threading.Tasks.Task.Run(() =>
        {
            var swAsync = Stopwatch.StartNew();
            var t2 = serializer.Deserialize(filePath);
            swAsync.Stop();
            return swAsync.ElapsedTicks;
        }).Result;

        LogJournal.Add($"Выполнен замер времени сериализации/десериализации для формата {format}");
        return (syncSave, syncLoad, asyncSave, asyncLoad);
    }

    public IEnumerable<KeyValuePair<string, Ship>> LinqDisplacement()
    {
        return Table.Where(pair => pair.Value.Displacement > 7500);
    }

    public IEnumerable<KeyValuePair<string, Ship>> LinqEnginePower()
    {
        return Table.Where(pair =>
        {
            var prop = pair.Value.GetType().GetProperty("EnginePower");
            if (prop != null)
            {
                var value = prop.GetValue(pair.Value);
                if (value is int power && power > 1500)
                    return true;
            }
            return false;
        });
    }

    public IEnumerable<KeyValuePair<string, Ship>> LinqCrewSize()
    {
        return Table.Where(pair =>
        {
            var prop = pair.Value.GetType().GetProperty("CrewSize");
            if (prop != null)
            {
                var value = prop.GetValue(pair.Value);
                if (value is int crew && crew > 250)
                    return true;
            }
            return false;
        });
    }

    public bool RemoveShip(string key)
    {
        bool removed = Table.Remove(key);
        if (removed)
            LogJournal.Add($"Удалён корабль: {key}");
        return removed;
    }

    public Ship SearchShip(string key)
    {
        Table.TryGetValue(key, out Ship ship);
        return ship;
    }

    public IEnumerable<string> GetTableLines()
    {
        foreach (var pair in SortedByShipNumber())
            yield return $"{pair.Key}: {pair.Value}\n";
    }

    public IEnumerable<string> GetLogLines()
    {
        foreach (var log in LogJournal.GetAll())
            yield return log + Environment.NewLine;
    }

    public IEnumerable<string> GetLinqDisplacementLines()
    {
        foreach (var pair in LinqDisplacement())
            yield return $"{pair.Key}: {pair.Value}\n";
        LogJournal.Add("LINQ: Корабли с водоизмещением > 7500");
    }

    public IEnumerable<string> GetLinqEnginePowerLines()
    {
        foreach (var pair in LinqEnginePower())
            yield return $"{pair.Key}: {pair.Value}\n";
        LogJournal.Add("LINQ: Корабли с мощностью двигателя > 1500 л.с.");
    }

    public IEnumerable<string> GetLinqCrewSizeLines()
    {
        foreach (var pair in LinqCrewSize())
            yield return $"{pair.Key}: {pair.Value}\n";
        LogJournal.Add("LINQ: Корабли с экипажем > 250 человек");
    }

    public IEnumerable<string> RemoveShipAndGetLines(string key)
    {
        if (RemoveShip(key))
            yield return $"Корабль \"{key}\" удалён из коллекции.\n";
        else
            yield return $"Корабль \"{key}\" не найден в коллекции.\n";
    }

    public IEnumerable<string> SearchShipLines(string key)
    {
        var ship = SearchShip(key);
        if (ship != null)
            yield return $"Найден корабль \"{key}\": {ship}\n";
        else
            yield return $"Корабль \"{key}\" не найден.\n";
    }

    public int TableCount => Table.Count;

    public async System.Threading.Tasks.Task<IEnumerable<string>> MeasureSerializationAsync(string filePath, string format)
    {
        return await System.Threading.Tasks.Task.Run(() =>
        {
            var (syncSave, syncLoad, asyncSave, asyncLoad) = MeasureSerialization(filePath, format);
            return new[]
            {
                $"\n[{format}]\n",
                $"Синхронное сохранение: {syncSave} тиков\n",
                $"Синхронная загрузка: {syncLoad} тиков\n",
                $"Асинхронное сохранение: {asyncSave} тиков\n",
                $"Асинхронная загрузка: {asyncLoad} тиков\n"
            };
        });
    }
}
