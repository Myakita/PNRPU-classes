using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

public class XmlCollectionSerializer<T> : ICollectionSerializer<T>
{
    public void Serialize(string filePath, T collection)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            serializer.Serialize(fs, collection);
        }
    }

    public T Deserialize(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            return (T)serializer.Deserialize(fs);
        }
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
