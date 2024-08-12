using System.Text.Json;

namespace OOP;

public class DataBase
{
    private readonly string _clientsTablePath;
    private readonly string _changesTablePath;
    private readonly HashSet<Client> _clients;
    private readonly HashSet<ChangeInfo> _changes;

    public IEnumerable<Client> Clients => _clients;
    public IEnumerable<ChangeInfo> Changes => _changes;
    
    public DataBase(string clientsTablePath, string changesTablePath)
    {
        var jsonClients = File.ReadAllText(clientsTablePath);
        var jsonChanges = File.ReadAllText(changesTablePath);
        _clients = JsonSerializer.Deserialize<HashSet<Client>>(jsonClients)!;
        _changes = JsonSerializer.Deserialize<HashSet<ChangeInfo>>(jsonChanges)!;
        _clientsTablePath = clientsTablePath;
        _changesTablePath = changesTablePath;
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
    
    public void AddChange(ChangeInfo change)
    {
        _changes.Add(change);
    }

    public void Save()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        using var clientsStream = new StreamWriter(_clientsTablePath);
        using var changesStream = new StreamWriter(_changesTablePath);
        var jsonClients = JsonSerializer.Serialize(Clients, options);
        var jsonChanges = JsonSerializer.Serialize(Changes, options);
        clientsStream.Write(jsonClients);
        changesStream.Write(jsonChanges);
    }
}