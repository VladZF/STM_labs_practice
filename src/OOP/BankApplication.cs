using OOP.Enums;

namespace OOP;

public class BankApplication(DataBase db)
{
   private Employee? _worker;

   public void Start()
   {
      var choose = -1;
      while (choose != 3)
      {
         try
         {
            PrintAuthChooses();
            Console.Write("Choose option: ");
            choose = int.Parse(Console.ReadLine()!);
            switch (choose)
            {
               case 1:
                  _worker = new Consultant();
                  Console.WriteLine("You authorized as consultant");
                  InteractWithClients();
                  break;
               case 2:
                  _worker = new Manager();
                  Console.WriteLine("You authorized as manager");
                  InteractWithClients();
                  break;
               case 3:
                  continue;
               default:
                  Console.WriteLine("Incorrect choose");
                  break;
            }
         }
         catch (Exception e)
         {
            Console.WriteLine($"Error: {e.Message}");
         }
      }

      Console.WriteLine("Shutting down application...");
   }
   
   private void InteractWithClients()
   {
      var command = -1;
      while (command != 5)
      {
         PrintCommands();
         Console.Write("Choose command: ");
         try
         {
            command = int.Parse(Console.ReadLine()!);
            switch (command)
            {
               case 1:
                  GetClientPropertyConsole();
                  break;
               case 2:
                  ChangeClientPropertyConsole();
                  break;
               case 3:
                  AddClientToDbConsole();
                  break;
               case 4:
                  RemoveClientFromDbConsole();
                  break;
               case 5:
                  continue;
               default:
                  Console.WriteLine("Incorrect command");
                  break;
            }
         }
         catch (Exception e)
         {
            Console.WriteLine($"Error: {e.Message}");
         }
      }
   }
   
   private void AddClientToDbConsole()
   { 
      Console.Write("Name: ");
      var name = Console.ReadLine()!;
      Console.Write("Surname: ");
      var surname = Console.ReadLine()!;
      Console.Write("Patronymic: ");
      var patronymic = Console.ReadLine()!;
      Console.Write("Phone ('-' if no info): ");
      var phone = Console.ReadLine()!;
      Console.Write("Passport ('-' if no info): ");
      var passport = Console.ReadLine()!;
      _worker?.AddClient(
         db,
         name,
         surname,
         patronymic,
         phone.Trim() != "-" ? phone : null,
         passport.Trim() != "-" ? passport : null
      );
   }
   
   private void RemoveClientFromDbConsole()
   {
      Console.Write("ID: ");
      var id = Guid.Parse(Console.ReadLine()!);
      _worker?.RemoveClient(db, id);
   }
   
   private void GetClientPropertyConsole()
   {
      try
      {
         PrintProperties();
         Console.Write("Select property: ");
         var property = (ClientProperty)int.Parse(Console.ReadLine()!);
         Console.Write("Insert client ID: ");
         var id = Guid.Parse(Console.ReadLine()!);
         var result = _worker?.GetClientProperty(db, id, property);
         Console.WriteLine(result ?? "No info");
      }
      catch (Exception e)
      {
         Console.WriteLine($"Error: {e.Message}");
      }
   }
   
   private void ChangeClientPropertyConsole()
   {
      try
      {
         PrintProperties();
         Console.Write("Select property: ");
         var property = (ClientProperty)int.Parse(Console.ReadLine()!);
         Console.Write("Insert client ID: ");
         var id = Guid.Parse(Console.ReadLine()!);
         Console.Write("Insert new value of property: ");
         var value = Console.ReadLine()!;
         _worker?.ChangeClientProperty(db, id, property, value);
      }
      catch (Exception e)
      {
         Console.WriteLine($"Error: {e.Message}");
      }
   }
   
   private static void PrintProperties()
   {
      Console.WriteLine("1. Name");
      Console.WriteLine("2. Surname");
      Console.WriteLine("3. Patronymic");
      Console.WriteLine("4. Passport");
      Console.WriteLine("5. Phone number");
   }
   
   private static void PrintCommands()
   {
      Console.WriteLine("1. Get client property by ID");
      Console.WriteLine("2. Change client property by ID");
      Console.WriteLine("3. Add new client to database");
      Console.WriteLine("4. Remove client from database");
      Console.WriteLine("5. Logout from account");
   }
   
   private static void PrintAuthChooses()
   {
      Console.WriteLine("1. Authorize as consultant");
      Console.WriteLine("2. Authorize as manager");
      Console.WriteLine("3. Exit from application");
   }
}