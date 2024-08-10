using OOP.Enums;

namespace OOP;

public class ChangeInfo(
    Guid clientId,
    DateTime changedAt,
    string workerName,
    string? propertyName,
    string? oldValue = null,
    string? newValue = null
)
{
    public Guid ClientId { get; init; } = clientId;
    public DateTime ChangedAt { get; init; } = changedAt;
    public string? PropertyName { get; init; } = propertyName;
    public string WorkerName { get; init; } = workerName;
    public string? OldValue { get; init; } = oldValue;
    public string? NewValue { get; init; } = newValue;
}