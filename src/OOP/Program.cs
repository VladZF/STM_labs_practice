using OOP.Enums;

namespace OOP;

class Program
{
    static void Main(string[] args)
    {
        var path = args[0];
        var db = new DataBase(path);
        var consultant = new Consultant();
        var id = db.Clients.First(client => client.Name == "Alexey").Id;
        Console.WriteLine(consultant.GetClientProperty(db, id, ClientProperty.Name));
        Console.WriteLine(consultant.GetClientProperty(db, id, ClientProperty.Surname));
        Console.WriteLine(consultant.GetClientProperty(db, id, ClientProperty.Patronymic));
        Console.WriteLine(consultant.GetClientProperty(db, id, ClientProperty.Passport));
        Console.WriteLine(consultant.GetClientProperty(db, id, ClientProperty.Phone));
        try 
        {
            consultant.ChangeClientProperty(db, id, ClientProperty.Phone, "+79822315521");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}