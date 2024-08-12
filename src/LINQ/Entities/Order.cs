namespace LINQ.Entities;

public class Order(int id, Customer customer, decimal price, DateTime date)
{
    public int Id { get; init; } = id;
    public Customer Customer { get; init; } = customer;
    public decimal Price { get; set; } = price;
    public DateTime Date { get; init; } = date;

    public override string ToString() => $"{Id}. Customer: {Customer}, Price: {Price}, Date: {Date}";
}