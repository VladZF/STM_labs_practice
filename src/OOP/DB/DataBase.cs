using System.Text.Json;

namespace OOP;

public class DataBase
{
    private readonly string _filepath;
    private readonly HashSet<Client> _clients;

    public IEnumerable<Client> Clients => _clients;
    
    public DataBase(string filepath)
    {
        var json = File.ReadAllText(filepath);
        _clients = JsonSerializer.Deserialize<HashSet<Client>>(json)!;
        _filepath = filepath;
    }
    
    public void AddClient(string name, string surname, string patronymic, string? phone = null, string? passport = null)
    {
        var client = new Client(Guid.NewGuid(), name, surname, patronymic, phone, passport);
        _clients.Add(client);
        Save();
    }
    
    public void RemoveClient(Guid clientId)
    {
        var client = Clients.FirstOrDefault(client => client.Id == clientId);
        if (client == null)
        {
            throw new ArgumentException("There is no client with this ID");
        }
        _clients.Remove(client);
        Save();
    }

    public void Save()
    {
        using var stream = new StreamWriter(_filepath);
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(Clients, options);
        stream.Write(json);
    }
}