﻿using OOP.Enums;

namespace OOP;

public class Manager : Employee
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
                client.Name = newValue;
                break;
            case ClientProperty.Surname:
                client.Surname = newValue;
                break;
            case ClientProperty.Patronymic:
                client.Patronymic = newValue;
                break;
            case ClientProperty.Passport:
                client.Passport = newValue;
                break;
            case ClientProperty.Phone:
                client.Phone = newValue;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(property), property, null);
        }
        db.Save();
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
            ClientProperty.Passport => client.Passport,
            ClientProperty.Phone => client.Phone,
            _ => throw new ArgumentOutOfRangeException(nameof(property), property, null)
        };
    }

    public override void AddClient
        (DataBase db, string name, string surname, string patronymic, string? phone = null, string? passport = null) =>
        db.AddClient(name, surname, patronymic, phone, passport);

    public override void RemoveClient(DataBase db, Guid id) => db.RemoveClient(id);
}