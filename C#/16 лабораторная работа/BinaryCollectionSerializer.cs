using System.IO;
using System.Threading.Tasks;
using ЛабораторнаяРабота12;
using ShipLibrary;

public class BinaryCollectionSerializer<T> : ICollectionSerializer<T>
    where T : class
{
    public void Serialize(string filePath, T collection)
    {
        if (collection is ShipHashTable<string, Ship> ships)
        {
            using (var fs = new FileStream(filePath, FileMode.Create))
            using (var writer = new BinaryWriter(fs))
            {
                writer.Write(ships.Count);
                foreach (var pair in ships)
                {
                    writer.Write(pair.Key ?? "");
                    var ship = pair.Value as Ship;
                    writer.Write(ship.GetType().Name);
                    ship.Write(writer);
                }
            }
        }
        else
        {
            throw new NotSupportedException("Binary serialization not implemented for this type.");
        }
    }

    public T Deserialize(string filePath)
    {
        if (typeof(T) == typeof(ShipHashTable<string, Ship>))
        {
            var table = new ShipHashTable<string, Ship>();
            using (var fs = new FileStream(filePath, FileMode.Open))
            using (var reader = new BinaryReader(fs))
            {
                int count = reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    string key = reader.ReadString();
                    string typeName = reader.ReadString();

                    Ship ship;
                    switch (typeName)
                    {
                        case nameof(Corvette):
                            ship = new Corvette();
                            break;
                        case nameof(Steamship):
                            ship = new Steamship();
                            break;
                        case nameof(Sailboat):
                            ship = new Sailboat();
                            break;
                        default:
                            ship = new Ship();
                            break;
                    }
                    ship.Read(reader);
                    table.Add(key, ship);
                }
            }
            return (T)(object)table;
        }
        throw new NotSupportedException("Binary deserialization not implemented for this type.");
    }

    public async Task SerializeAsync(string filePath, T collection)
    {
        await Task.Run(() => Serialize(filePath, collection));
    }

    public async Task<T> DeserializeAsync(string filePath)
    {
        return await Task.Run(() => Deserialize(filePath));
    }
}
