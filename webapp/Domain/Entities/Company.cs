namespace Domain.Entities;

public class Company
{
    private readonly HashSet<string> _phones = [];
    private HashSet<Rubric> _rubrics = [];
    
    private Company()
    {
    }
    
    public Company(string name, Building building)
    {
        Name = name;
        Building = building;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Guid BuildingId { get; private set; }
    public Building Building { get; private set; }
    public IEnumerable<string> Phones => _phones;
    public IEnumerable<Rubric> Rubrics => _rubrics;
}