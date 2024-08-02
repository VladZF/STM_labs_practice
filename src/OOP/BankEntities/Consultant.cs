using OOP.Enums;
using OOP.Exceptions;

namespace OOP;

public class Consultant : Employee
{
    public override void ChangeClientProperty(DataBase db, Guid clientId, ClientProperty property, string newValue)
    {
        var client = db.Clients.FirstOrDefault(client => client.Id == clientId);
        if (client == null)
        {
            throw new ArgumentException("There is no client with this ID");
        }
        switch (property)
        {
            case ClientProperty.Name:
            case ClientProperty.Surname:
            case ClientProperty.Patronymic:
            case ClientProperty.Passport:
                throw new AccessException(nameof(Consultant), "change", property);
            case ClientProperty.Phone:
                if (string.IsNullOrWhiteSpace(newValue))
                {
                    throw new ArgumentException("Phone number is empty");
                }
                client.Phone = newValue;
                db.Save();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(property), property, null);
        }
    }

    public override string? GetClientProperty(DataBase db, Guid clientId, ClientProperty property)
    {
        var client = db.Clients.FirstOrDefault(client => client.Id == clientId);
        if (client == null)
        {
            throw new ArgumentException("There is no client with this ID");
        }

        return property switch
        {
            ClientProperty.Name => client.Name,
            ClientProperty.Surname => client.Surname,
            ClientProperty.Patronymic => client.Patronymic,
            ClientProperty.Passport => client.Passport == null ? null : "**** ******",
            ClientProperty.Phone => client.Phone,
            _ => throw new ArgumentOutOfRangeException(nameof(property), property, null)
        };
    }
}