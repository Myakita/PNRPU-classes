using ЛабораторнаяРабота12;
using System.IO;

public class BinaryShipSerializer : IShipSerializer
{
    public void Serialize(string filePath, ShipHashTable<string, ShipLibrary.Ship> table)
    {
        using (var fs = new FileStream(filePath, FileMode.Create))
        using (var writer = new System.IO.BinaryWriter(fs))
        {
            writer.Write(table.Count);
            foreach (var pair in table)
            {
                writer.Write(pair.Key ?? "");
                var ship = pair.Value as ShipLibrary.Ship;
                writer.Write(ship.GetType().Name);
                ship.Write(writer);
            }
        }
    }

    public ShipHashTable<string, ShipLibrary.Ship> Deserialize(string filePath)
    {
        var table = new ShipHashTable<string, ShipLibrary.Ship>();
        using (var fs = new FileStream(filePath, FileMode.Open))
        using (var reader = new System.IO.BinaryReader(fs))
        {
            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                string key = reader.ReadString();
                string typeName = reader.ReadString();

                ShipLibrary.Ship ship;
                switch (typeName)
                {
                    case nameof(ShipLibrary.Corvette):
                        ship = new ShipLibrary.Corvette();
                        break;
                    case nameof(ShipLibrary.Steamship):
                        ship = new ShipLibrary.Steamship();
                        break;
                    case nameof(ShipLibrary.Sailboat):
                        ship = new ShipLibrary.Sailboat();
                        break;
                    default:
                        ship = new ShipLibrary.Ship();
                        break;
                }
                ship.Read(reader);
                table.Add(key, ship);
            }
        }
        return table;
    }
}