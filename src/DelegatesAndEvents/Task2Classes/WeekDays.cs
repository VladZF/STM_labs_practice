namespace DelegatesAndEvents.Task2Classes;

public class WeekDays
{ 
    public static Func<string> GiveWeekDays()
    {
        var day = new DateOnly(2023, 12, 31);
        return WeekDay;

        string WeekDay()
        {
            day = day.AddDays(1);
            return day.DayOfWeek.ToString();
        }
    }
}