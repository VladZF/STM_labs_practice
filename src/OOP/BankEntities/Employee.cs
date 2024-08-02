using OOP.Enums;

namespace OOP;

public abstract class Employee
{
    public abstract void ChangeClientProperty(DataBase db, Guid clientId, ClientProperty property, string newValue);
    public abstract string? GetClientProperty(DataBase db, Guid clientId, ClientProperty property);
}