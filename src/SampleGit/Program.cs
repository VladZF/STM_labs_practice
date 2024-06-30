using src;

Console.WriteLine("Insert array: ");
int[] array;
try
{
    var arrayString = Console.ReadLine();
    if (string.IsNullOrEmpty(arrayString))
    {
        Console.WriteLine("Error: Input is empty");
        return;
    }
    array = arrayString.Split().Select(int.Parse).ToArray();
}
catch (FormatException e)
{
    Console.WriteLine("Error: wrong format of array input");
    return;
}
catch (OverflowException e)
{
    Console.WriteLine("Error: detected number(s) greater than int32");
    return;
}
catch (Exception e)
{
    Console.WriteLine($"Error: {e.Message}");
    return;
}

Console.WriteLine("Sorted array: ");
Functions.BubbleSort(ref array);
foreach (var item in array)
    Console.Write(item + " ");
Console.WriteLine("\nInsert target for search in sorted array: ");
int target;
try
{
    target = int.Parse(Console.ReadLine()!);
}
catch (FormatException e)
{
    Console.WriteLine("Error: wrong format of target input");
    return;
}
catch (OverflowException e)
{
    Console.WriteLine("Error: target is greater than int32");
    return;
}
catch (Exception e)
{
    Console.WriteLine($"Error: {e.Message}");
    return;
}

var index = Functions.MyBinarySearch(array, target);
Console.WriteLine(index == -1 ? "There is no element in array" : $"index of the element is {index}");

