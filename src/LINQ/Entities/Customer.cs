namespace LINQ.Entities;

public class Customer(int id, string name, City city)
{
    public int Id { get; init; } = id;
    public string Name { get; set; } = name;
    public City City { get; set; } = city;

    private readonly HashSet<Order> _orders = [];

    public IEnumerable<Order> Orders => _orders;
    
    public void AddOrder(Order order)
    {
        _orders.Add(order);
    }
    
    public void AddOrders(IEnumerable<Order> orders)
    {
        foreach (var currentOrder in orders)
        {
            _orders.Add(currentOrder);
        }
    }

    public override string ToString() => $"{Id}. Name: {Name}, City: {City}";
}