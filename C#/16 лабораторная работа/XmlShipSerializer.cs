using ЛабораторнаяРабота12;
using System.Xml.Serialization;
using System.IO;

public class XmlShipSerializer : IShipSerializer
{
    public void Serialize(string filePath, ShipHashTable<string, ShipLibrary.Ship> table)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ShipHashTable<string, ShipLibrary.Ship>));
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            serializer.Serialize(fs, table);
        }
    }

    public ShipHashTable<string, ShipLibrary.Ship> Deserialize(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ShipHashTable<string, ShipLibrary.Ship>));
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            return (ShipHashTable<string, ShipLibrary.Ship>)serializer.Deserialize(fs);
        }
    }
}
