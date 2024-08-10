using OOP.Enums;

namespace OOP.Exceptions;

public class AccessException(string employeeName, string action, ClientProperty? property = null)
    : Exception($"{employeeName} has no access for {action} {property.ToString()?.ToLower()}");