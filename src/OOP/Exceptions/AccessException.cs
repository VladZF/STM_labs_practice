using OOP.Enums;

namespace OOP.Exceptions;

public class AccessException(string employeeName, string action, ClientProperty property)
    : Exception($"{employeeName} has no access for {property.ToString().ToLower()} {action}");