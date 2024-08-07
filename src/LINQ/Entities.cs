namespace LINQ;

public record City(int Id, string Name, int CityCode);

public record Customer(int Id, string Name, int CityId);

public record Order(int Id, int CustomerId, decimal Price, DateTime Date);