namespace ReflectionSerializer.TestClasses;

public class Person
{
    private int _age;
    
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age
    {
        get => _age;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            
            _age = value;
        }
    }
    
    public Person(string name, string surname, HashSet<string> languages, Dictionary<string, int> addressIndices, int age = 18)
    {
        Name = name;
        Surname = surname;
        Age = age;
        Languages = languages;
        AddressIndices = addressIndices;
    }
    
    public HashSet<string> Languages { get; set; }
    
    public Dictionary<string, int> AddressIndices { get; set; }
}