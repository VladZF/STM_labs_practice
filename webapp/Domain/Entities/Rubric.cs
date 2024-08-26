namespace Domain.Entities;

public class Rubric
{
    private readonly HashSet<Rubric> _subRubrics = [];
    private readonly HashSet<Company> _companies = [];
    
    private Rubric()
    {
    }
    
    public Rubric(string name)
    {
        Name = name;
    }
    
    public Guid Id { get; private set; }
    public Guid? MainRubricId { get; private set; }
    public Rubric? MainRubric { get; private set; }
    public string Name { get; private set; }
    public IEnumerable<Rubric> SubRubrics => _subRubrics;
    public IEnumerable<Company> Companies => _companies;
    
    public void AddSubRubric(Rubric rubric)
    {
        _subRubrics.Add(rubric);
        rubric.MainRubricId = Id;
    }
    
    public void RemoveRubric(Rubric rubric)
    {
        _subRubrics.Remove(rubric);
    }
}