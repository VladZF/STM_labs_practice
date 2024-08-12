using System.Collections;
using System.Data;
using ConsoleTables;
using LINQ.Entities;

namespace LINQ;

class Program
{
    public static void InitTables()
    {
        Tables.Cities =
        [
            new City(1, "Los-Angeles", 223123),
            new City(2, "Dzerzhinsk", 1212122)
        ];
        
        Tables.Customers =
        [
            new Customer(1, "Vlad", Tables.Cities.First(city => city.Id == 1)),
            new Customer(2, "Fedor", Tables.Cities.First(city => city.Id == 1)),
            new Customer(3, "Ivan", Tables.Cities.First(city => city.Id == 2)),
            new Customer(4, "Dmitriy", Tables.Cities.First(city => city.Id == 2)),
        ];

        Tables.Orders =
        [
            new Order(1, Tables.Customers.First(customer => customer.Id == 1),
                100, new DateTime(2002, 3, 16)),
            new Order(2, Tables.Customers.First(customer => customer.Id == 3),
                5000, new DateTime(2024, 9, 12)),
            new Order(3, Tables.Customers.First(customer => customer.Id == 2),
                200, new DateTime(2023, 12, 7)),
            new Order(4, Tables.Customers.First(customer => customer.Id == 3),
                1888, new DateTime(2020, 5, 1)),
            new Order(5, Tables.Customers.First(customer => customer.Id == 1),
                300, new DateTime(2023, 5, 12)),
            new Order(6, Tables.Customers.First(customer => customer.Id == 1),
                400, new DateTime(2023, 1, 1))
        ];
    }
    
    private static void IncludePersonalOrders()
    {
        foreach (var customer in Tables.Customers)
        {
            customer.AddOrders(Tables.Orders.Where(order => order.Customer.Id == customer.Id).OrderBy(order => order.Date));
        }
    }
    
    private static void ClientsInLosAngelesConsole()
    {
        var clientsInLosAngeles = Tables.Customers.Where(customer => customer.City.Name == "Los-Angeles");
        Console.WriteLine("Task 1:");
        var table = new ConsoleTable("id", "name", "cityName");
        foreach (var customer in clientsInLosAngeles)
        {
            table.AddRow(customer.Id, customer.Name, customer.City.Name);
        }
        table.Write(Format.Minimal);
    }
    
    private static void ClientsWithoutOrdersCountConsole()
    {
        var clientsWithoutOrdersCount = Tables.Customers
            .Count(customer => !customer.Orders.Any());
        Console.WriteLine("Task 2:");
        var table = new ConsoleTable("Count");
        table.AddRow(clientsWithoutOrdersCount);
        table.Write(Format.Minimal);
    }
    
    private static void ClientsInfoConsole()
    {
        Console.WriteLine("Task 3:");
        var table = new ConsoleTable("id", "customerName", "cityName", "cityCode", "ordersCount", "lastOrderDate");
        foreach (var customer in Tables.Customers)
        {
            table.AddRow(
                customer.Id,
                customer.Name,
                customer.City.Name,
                customer.City.CityCode,
                customer.Orders.Count(),
                customer.Orders.LastOrDefault()?.Date);
        }
        table.Write(Format.Minimal);
    }
    
    private static void MoreThanTwoOrdersConsole()
    {
        var moreThanTwoOrders = Tables.Customers
            .Where(customer => customer.Orders.Count() > 2)
            .OrderBy(customer => customer.Name);
        Console.WriteLine("Task 4:");
        var table = new ConsoleTable("id", "name", "cityName");
        foreach (var customer in moreThanTwoOrders)
        {
            table.AddRow(customer.Id, customer.Name, customer.City.Name);
        }
        table.Write(Format.Minimal);
    }
    
    private static void GroupedClientsConsole()
    {
        var groupedClients = Tables.Customers.GroupBy(
            customer => customer.City,
            customer => customer,
            (city, customers) => new
            {
                City = city,
                Customers = customers.Where(customer => customer.Orders.Any())
            });
        Console.WriteLine("Task 5:");
        foreach (var group in groupedClients)
        {
            var table = new ConsoleTable("name", "countOfOrders");
            Console.WriteLine(group.City.Name + ":");
            foreach (var customer in group.Customers)
            {
                table.AddRow(customer.Name, customer.Orders.Count());
            }
            table.Write(Format.Minimal);
        }
    }
    
    private static void AverageOrdersConsole()
    {
        var averageCounts = Tables.Customers
            .GroupBy(
                customer => customer.City,
                customer => customer.Orders.Count(),
                (city, counts) => new
                {
                    City = city,
                    AverageCount = counts.Average()
                }
            );
        var clientsWithLessCount = Tables.Customers
            .Where(customer => customer.Orders.Count() < averageCounts
                .First(info => info.City == customer.City)
                .AverageCount);
    
        Console.WriteLine("Task 6:");
        var table = new ConsoleTable("id", "name", "cityName");
        foreach (var customer in clientsWithLessCount)
        {
            table.AddRow(customer.Id, customer.Name, customer.City.Name);
        }
        table.Write(Format.Minimal);
    }
    
    private static void MaxSumConsole()
    {
        var maxSum = Tables.Customers.GroupBy(
            customer => customer.City,
            customer => customer,
            (currentCity, customers) => new
            {
                currentCity.Name,
                Sums = customers
                    .Sum(customer => customer.Orders.Select(order => order.Price).Sum())
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
                CityName = customer.Name,
                OrdersCount = customer.Orders.Count(),
                TotalSum = customer.Orders.Select(order => order.Price).Sum()
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
        IncludePersonalOrders();
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