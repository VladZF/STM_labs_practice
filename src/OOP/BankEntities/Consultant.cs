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

                var oldValue = client.Phone;
                client.Phone = newValue;
                db.AddChange(
                    new ChangeInfo(
                        client.Id,
                        DateTime.Now,
                        nameof(Consultant),
                        client.LastChangedProperty.ToString(),
                        oldValue,
                        client.Phone
                    )
                );
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

    public override void AddClient(DataBase db, string name, string surname, string patronymic, string? phone = null, string? passport = null)
    {
        throw new AccessException(nameof(Consultant), "add to DB");
    }

    public override void RemoveClient(DataBase db, Guid id)
    {
        throw new AccessException(nameof(Consultant), "remove to DB");
    }
}