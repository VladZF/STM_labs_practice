using ReflectionSerializer.TestClasses;

namespace ReflectionSerializer;

class Program
{
    static void Main(string[] args)
    {
        var person = new Person(
            "Adam",
            "Wilson",
            ["Russian", "English"],
            new Dictionary<string, int> { {"Green Street", 233232}, {"Time Square", 1337228}});
        Console.WriteLine(Serializer.Serialize(person));
    }
}