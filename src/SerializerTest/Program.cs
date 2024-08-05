using ReflectionSerializer.TestClasses;

namespace SerializerTest;
using Serialization;

class Program
{
    static void Main(string[] args)
    {
        var car = new Car(
            "Tesla",
            "Model X",
            "AX231A 152",
            EcologyLevel.High
        );
        var person = new Person(
            "Adam",
            "Wilson",
            ["Russian", "English"],
            new Dictionary<string, int>
            {
                {"Wall street", 233232},
                {"Green avenue", 232323}
            }, 
            23,
            car);
        var jsonString = Serializer.Serialize(person);
        Console.WriteLine(jsonString);
        var same = Deserializer.Deserialize<Person>(jsonString!);
        Console.WriteLine();
    }
}