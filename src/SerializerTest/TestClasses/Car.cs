namespace ReflectionSerializer.TestClasses;

public class Car( string manufacturer, string model, string number, EcologyLevel ecologyLevel)
{
    public Car() : this(string.Empty, string.Empty, string.Empty, EcologyLevel.Low)
    {
    }
    
    public string Manufacturer { get; set; } = manufacturer;
    public string Model { get; set; } = model;
    public string Number { get; set; } = number;

    public EcologyLevel EcologyLevel { get; set; } = ecologyLevel;
}