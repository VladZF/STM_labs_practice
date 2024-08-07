using System.Collections;
using System.Data;
using ConsoleTables;

namespace LINQ;

class Program
{
    public static void InitTables()
    {
        Tables.Customers =
        [
            new Customer(1, "Kirill", 2),
            new Customer(2, "Darya", 2),
            new Customer(3, "Meow", 1),
            new Customer(4, "Vlad", 1),
        ];

        Tables.Orders =
        [
            new Order(1, 1, 2500, new DateTime(2002, 3, 23)),
            new Order(2, 3, 5678, new DateTime(2024, 9, 5)),
            new Order(3, 3, 10000, new DateTime(2023, 12, 1)),
            new Order(4, 3, 1234, new DateTime(2020, 5, 2))
        ];

        Tables.Cities =
        [
            new City(1, "Balahna", 606403),
            new City(2, "Los-Angeles", 555555)
        ];
    }
    
    private static void ClientsInLosAngelesConsole()
    {
        var clientsInLosAngeles = Tables.Customers
            .Where(customer => customer.CityId == Tables.Cities
                .First(city => city.Name == "Los-Angeles").Id);
        Console.WriteLine("Task 1:");
        var table = new ConsoleTable("id", "name", "cityId");
        foreach (var customer in clientsInLosAngeles)
        {
            table.AddRow(customer.Id, customer.Name, customer.CityId);
        }
        table.Write(Format.Minimal);
    }
    
    private static void ClientsWithoutOrdersCountConsole()
    {
        var clientsWithoutOrdersCount = Tables.Customers
            .Select(customer => customer.Id)
            .Count(id => !Tables.Orders
                .Select(order => order.CustomerId)
                .Contains(id));
        Console.WriteLine("Task 2:");
        var table = new ConsoleTable("Count");
        table.AddRow(clientsWithoutOrdersCount);
        table.Write(Format.Minimal);
    }
    
    private static void ClientsInfoConsole()
    {
        var clientsInfo = Tables.Customers
            .Join(Tables.Cities,
                customer => customer.CityId,
                city => city.Id,
                (customer, city) => new
                {
                    customer.Id,
                    customer.Name,
                    CityName = city.Name,
                    city.CityCode,
                    OrdersCount = Tables.Orders.Count(order => order.CustomerId == customer.Id),
                    LastOrder = Tables.Orders.OrderBy(order => order.Date).LastOrDefault(order => order.CustomerId == customer.Id)
                });
        Console.WriteLine("Task 3:");
        var table = new ConsoleTable("id", "customerName", "cityName", "cityCode", "ordersCount", "lastOrderDate");
        foreach (var row in clientsInfo)
        {
            table.AddRow(row.Id, row.Name, row.CityName, row.CityCode, row.OrdersCount, row.LastOrder?.Date);
        }
        table.Write(Format.Minimal);
    }
    
    private static void MoreThanTwoOrdersConsole()
    {
        var moreThanTwoOrders = Tables.Customers
            .Where(customer => Tables.Orders
                .Count(order => order.CustomerId == customer.Id) > 2)
            .OrderBy(customer => customer.Name);
        Console.WriteLine("Task 4:");
        var table = new ConsoleTable("id", "name", "CityId");
        foreach (var customer in moreThanTwoOrders)
        {
            table.AddRow(customer.Id, customer.Name, customer.CityId);
        }
        table.Write(Format.Minimal);
    }
    
    private static void GroupedClientsConsole()
    {
        var groupedClients = Tables.Customers.GroupBy(
            customer => customer.CityId,
            customer => customer,
            (cityId, customers) => new
            {
                CityName = Tables.Cities.First(city => city.Id == cityId).Name,
                CountsOfOrders = (IEnumerable<(string name, int count)>)customers.Select(customer => 
                    (customer.Name, Tables.Orders.Count(order => order.CustomerId == customer.Id)))
            });
        Console.WriteLine("Task 5:");
        foreach (var cityInfo in groupedClients)
        {
            var table = new ConsoleTable("name", "countOfOrders");
            Console.WriteLine(cityInfo.CityName + ":");
            foreach (var customerInfo in cityInfo.CountsOfOrders)
            {
                table.AddRow(customerInfo.name, customerInfo.count);
            }
            table.Write(Format.Minimal);
        }
    }
    
    private static void AverageOrdersConsole()
    {
        var averageCounts = Tables.Customers
            .GroupBy(
                customer => customer.CityId,
                customer => customer,
                (cityId, customers) => new
                {
                    CityId = cityId,
                    Count = customers
                        .Average(customer => Tables.Orders
                            .Count(order => order.CustomerId == customer.Id))
                }
            );
        var clientsWithLessCount = Tables.Customers
            .Where(customer => Tables.Orders
                .Count(order => order.CustomerId == customer.Id) < averageCounts
                .First(info => info.CityId == customer.CityId).Count);

        Console.WriteLine("Task 6:");
        var table = new ConsoleTable("id", "name", "cityId");
        foreach (var customer in clientsWithLessCount)
        {
            table.AddRow(customer.Id, customer.Name, customer.CityId);
        }
        table.Write(Format.Minimal);
    }
    
    private static void MaxSumConsole()
    {
        var maxSum = Tables.Customers.GroupBy(
            customer => customer.CityId,
            customer => customer,
            (cityId, customers) => new
            {
                Tables.Cities.First(city => city.Id == cityId).Name,
                Sums = customers
                    .Sum(customer => Tables.Orders
                        .Where(order => order.CustomerId == customer.Id)
                        .Sum(order => order.Price))
            } 
        ).MaxBy(x => x.Sums)
        ?.Name;
        Console.WriteLine("Task 7:");
        var table = new ConsoleTable("maxSum");
        table.AddRow(maxSum);
        table.Write(Format.Minimal);
    }
    
    private static void MinimalOrdersConsole()
    {
        var minimalOrders = Tables.Customers
            .Select(customer => new
            {
                customer.Name,
                CityName = Tables.Cities.First(city => city.Id == customer.CityId).Name,
                OrdersCount = Tables.Orders.Count(order => order.CustomerId == customer.Id),
                TotalSum = Tables.Orders.Where(order => order.CustomerId == customer.Id).Sum(order => order.Price)
            })
            .OrderBy(x => x.TotalSum)
            .Take(3);
        Console.WriteLine("Task 8:");
        var table = new ConsoleTable("name", "cityName", "ordersCount", "totalSum");
        foreach (var row in minimalOrders)
        {
            table.AddRow(row.Name, row.CityName, row.OrdersCount, row.TotalSum);
        }
        table.Write(Format.Minimal);
    }
    
    private static void Main(string[] args)
    {
        InitTables();
        ClientsInLosAngelesConsole();
        ClientsWithoutOrdersCountConsole();
        ClientsInfoConsole();
        MoreThanTwoOrdersConsole();
        GroupedClientsConsole();
        AverageOrdersConsole();
        MaxSumConsole();
        MinimalOrdersConsole();
    }
}