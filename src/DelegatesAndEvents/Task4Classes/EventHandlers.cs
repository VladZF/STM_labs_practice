namespace DelegatesAndEvents.Task4Classes;

public class EventHandlers
{ 
    public void WhenAdded(string name, string title) => Console.WriteLine($"{name}: added new post '{title}'");

    public void WhenDeleted(string name, string title) => Console.WriteLine($"{name}: deleted post '{title}'");
}