using System.Threading.Tasks;

public interface ICollectionSerializer<T>
{
    void Serialize(string filePath, T collection);
    T Deserialize(string filePath);

    Task SerializeAsync(string filePath, T collection);
    Task<T> DeserializeAsync(string filePath);
}
