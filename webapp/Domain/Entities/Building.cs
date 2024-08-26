namespace Domain.Entities;

public class Building
{
    
    private Building()
    {
    }
    
    public Building(string address, double xPosition, double yPosition)
    {
        Address = address;
        XPosition = xPosition;
        YPosition = yPosition;
    }
    
    private readonly HashSet<Company> _companies = [];
    public Guid Id { get; private init; }
    public string Address { get; private set; }
    public double XPosition { get; private set; }
    public double YPosition { get; private set; }
    
    public IEnumerable<Company> Companies => _companies;
}