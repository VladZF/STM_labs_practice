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
                return;
            }
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
                return;
            }
            _passport = null;
        }
    }
}