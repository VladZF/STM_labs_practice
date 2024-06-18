var array = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
BubbleSort(ref array);
foreach (var item in array)
{
    Console.Write(item + " ");
}
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
