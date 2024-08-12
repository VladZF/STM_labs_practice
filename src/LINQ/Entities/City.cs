namespace LINQ.Entities;

public class City(int id, string name, int cityCode)
{
    public int Id { get; init; } = id;
    public string Name { get; set; } = name;
    public int CityCode { get; set; } = cityCode;

    public override string ToString() => $"{Id}. Name: {Name}, CityCode: {CityCode}";
}