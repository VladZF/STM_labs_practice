using LINQ.Entities;

namespace LINQ;

public class Tables
{
    public static HashSet<City> Cities { get; set; }
    public static HashSet<Order> Orders { get; set; }
    public static HashSet<Customer> Customers { get; set; }
}