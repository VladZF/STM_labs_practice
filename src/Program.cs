var array = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
BubbleSort(ref array);
foreach (var item in array)
    Console.Write(item + " ");
Console.WriteLine("\nInsert target for search in array");
var target = int.Parse(Console.ReadLine()!);
var index = MyBinarySearch(array, target);
Console.WriteLine(index == -1 ? "There is no element in array" : $"index of the element is {index}");
return;

void BubbleSort(ref int[] arr)
{
    for (var i = arr.Length - 1; i >= 0; --i)
    {
        var flag = false;
        for (var j = 0; j < i; ++j)
        {
            if (arr[j] > arr[j + 1])
            {
                flag = true;
                (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
            }

            if (!flag)
                return;
        }
    }
}

int MyBinarySearch(int[] arr, int target)
{
    var left = 0;
    var right = arr.Length;
    while (left <= right)
    {
        var mid = (left + right) / 2;
        if (target < arr[mid])
            right = mid - 1;
        else if (target > arr[mid])
            left = mid + 1;
        else
        {
            while (mid >= 0 && arr[mid] == target)
                mid--;
            return mid + 1;
        }
    }

    return -1;
}