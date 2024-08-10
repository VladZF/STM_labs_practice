using OOP.Enums;

namespace OOP;

public abstract class Employee
{
    public abstract void ChangeClientProperty(DataBase db, Guid clientId, ClientProperty property, string newValue);
    public abstract string? GetClientProperty(DataBase db, Guid clientId, ClientProperty property);
    public abstract void AddClient(DataBase db, string name, string surname, string patronymic, string? phone = null, string? passport = null);
    public abstract void RemoveClient(DataBase db, Guid id);
}