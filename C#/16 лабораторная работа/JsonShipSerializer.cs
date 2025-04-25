using ЛабораторнаяРабота12;
using System.Text.Json;
using System.IO;

public class JsonShipSerializer : IShipSerializer
{
    public void Serialize(string filePath, ShipHashTable<string, ShipLibrary.Ship> table)
    {
        var options = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true };
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            JsonSerializer.Serialize(fs, table, options);
        }
    }

    public ShipHashTable<string, ShipLibrary.Ship> Deserialize(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            return JsonSerializer.Deserialize<ShipHashTable<string, ShipLibrary.Ship>>(fs);
        }
    }
}
