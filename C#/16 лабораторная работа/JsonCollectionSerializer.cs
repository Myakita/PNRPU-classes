using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class JsonCollectionSerializer<T> : ICollectionSerializer<T>
{
    public void Serialize(string filePath, T collection)
    {
        var options = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true };
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            JsonSerializer.Serialize(fs, collection, options);
        }
    }

    public T Deserialize(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            return JsonSerializer.Deserialize<T>(fs);
        }
    }

    public async Task SerializeAsync(string filePath, T collection)
    {
        var options = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true };
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            await JsonSerializer.SerializeAsync(fs, collection, options);
        }
    }

    public async Task<T> DeserializeAsync(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            return await JsonSerializer.DeserializeAsync<T>(fs);
        }
    }
}
