using System.Text.Json.Serialization;
using OOP.Enums;

namespace OOP;

public class Client
{
    private string _name;
    private string _surname;
    private string _patronymic;
    private Phone? _phone;
    private Passport? _passport;
    
    public Client(Guid id, string name, string surname, string patronymic, string? phone = null, string? passport = null)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        Phone = phone;
        Passport = passport;
    }

    [JsonIgnore]
    public DateTime ChangedAt { get; private set; }
    
    [JsonIgnore]
    public ClientProperty? LastChangedProperty { get; private set; } = null;

    public Guid Id { get; private init; }
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Empty name");
            }

            LastChangedProperty = ClientProperty.Name;
            ChangedAt = DateTime.Now;
            _name = value;
        }
    }
    
    public string Surname
    {
        get => _surname;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Empty surname");
            }

            LastChangedProperty = ClientProperty.Surname;
            ChangedAt = DateTime.Now;
            _surname = value;
        }
    }
    
    public string Patronymic
    {
        get => _patronymic;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Empty patronymic");
            }

            LastChangedProperty = ClientProperty.Patronymic;
            ChangedAt = DateTime.Now;
            _patronymic = value;
        }
    }
    
    public string? Phone
    {
        get => _phone?.Value;
        set
        {
            if (value != null)
            {
                _phone = OOP.Phone.From(value);
                LastChangedProperty = ClientProperty.Phone;
                ChangedAt = DateTime.Now;
                return;
            }
            
            LastChangedProperty = ClientProperty.Phone;
            ChangedAt = DateTime.Now;
            _phone = null;
        }
    }

    public string? Passport
    {
        get => _passport?.Value;
        set
        {
            if (value != null)
            {
                _passport = OOP.Passport.From(value);
                LastChangedProperty = ClientProperty.Passport;
                ChangedAt = DateTime.Now;
                return;
            }
            
            LastChangedProperty = ClientProperty.Passport;
            ChangedAt = DateTime.Now;
            _passport = null;
        }
    }
}