using System.Text.Json.Serialization;

namespace ReflectionSerializer.TestClasses;

public class Person
{ 
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    
    
    public Car? Car { get; set; }
    
    public Person(string name, string surname, List<string> languages, Dictionary<string, int> addressIndices, int age = 18, Car? car = null)
    {
        Name = name;
        Surname = surname;
        Age = age;
        Languages = languages;
        AddressIndices = addressIndices;
        Car = car;
    }
    
    public Person()
    {
        Name = "";
        Surname = "";
        Age = 0;
        Languages = [];
        AddressIndices = new Dictionary<string, int>();
        Car = null;
    }
    
    [JsonPropertyName("Knowledge of languages")]
    public List<string> Languages { get; set; }
    
    [JsonIgnore]
    public Dictionary<string, int> AddressIndices { get; set; }
}