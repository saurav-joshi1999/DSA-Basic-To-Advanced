public static class ShiftArray
{
    public static void mainn()
    {
        // int[] arr = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        // ShiftByN(arr, 5);
        // Console.WriteLine(string.Join(" ", arr));
        MoveZeroToEnd();
    }
    private static void ShiftByN(int[] arr, int n)
    {
        n = n % arr.Length;
        int[] carr = new int[n];
        for (int i = 0; i < n; i++)
        {
            carr[i] = arr[i];
        }

        for (int i = 0; i < arr.Length - n; i++)
        {
            arr[i] = arr[i + n];
        }

        for (int i = 0; i < n; i++)
        {
            arr[i + arr.Length - n] = carr[i];
        }
    }

    public static void MoveZeroToEnd()
    {
        int[] arr = { 1, 1, 0, 9, 0, 7, 0, 6, 8, 0 };
        int curr = 0; int j = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != 0)
            {
                arr[curr] = arr[i];
                curr++;
            }
            else
            {
                j++;
            }
        }

        for (int i = arr.Length - j; i < arr.Length; i++)
        {
            arr[i] = 0;
        }

        Console.WriteLine(string.Join(" ", arr));
    }
}