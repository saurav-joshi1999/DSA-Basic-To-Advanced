public static class RobberMaxMoney
{
    public static void GetMaxMoneyInCircularHouse()
    {
        int[] arr = { 5, 5, 5, 5, 5, 5 };
        int fromFristHouse = MaxMoney(arr, 0, arr.Length - 2);
        int fromSecondHouse = MaxMoney(arr, 1, arr.Length - 1);
        Console.WriteLine("Max Money Robbed " +Math.Max(fromFristHouse, fromSecondHouse));
    }
    private static int MaxMoney(int[] arr, int start, int end)
    {
        if (end < start) return 0;

        int taken = arr[end] + MaxMoney(arr, start, end - 2);
        int notTaken = MaxMoney(arr, start,end - 1);
        return Math.Max(taken, notTaken);
    }
}