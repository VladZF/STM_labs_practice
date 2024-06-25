using src;

Console.WriteLine("Insert array: ");
var array = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
Console.WriteLine("Sorted array: ");
Functions.BubbleSort(ref array);
foreach (var item in array)
    Console.Write(item + " ");
Console.WriteLine("\nInsert target for search in sorted array: ");
var target = int.Parse(Console.ReadLine()!);
var index = Functions.MyBinarySearch(array, target);
Console.WriteLine(index == -1 ? "There is no element in array" : $"index of the element is {index}");

