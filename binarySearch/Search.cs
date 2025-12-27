using System.Reflection.Metadata.Ecma335;

public static class Search
{
    public static void mainn()
    {
        Console.WriteLine(BinarySearch(new int[] { 1,3,5,6,7,8,10,11 },7, 10));
    }

    public static int BinarySearch(int[] arr, int n, int target)
    {
        if (n < 0) return -1;

        if (arr[n] == target) return n;

        if (arr[n] > target)
            return BinarySearch(arr, n - 1, target);
        else
            return BinarySearch(arr, n + 1, target);
    } 
}