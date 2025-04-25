using ЛабораторнаяРабота12;

public interface IShipSerializer
{
    void Serialize(string filePath, ShipHashTable<string, ShipLibrary.Ship> table);
    ShipHashTable<string, ShipLibrary.Ship> Deserialize(string filePath);
}
