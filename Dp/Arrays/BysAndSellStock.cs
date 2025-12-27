public static class BysAndSellStock
{
    public static void Mainn()
    {
        int[] arr = { 3,3,5,0,0,3,1,3 };
        Console.WriteLine("Max Profit : " + MaxProfit(arr, 1, 0, 2));
        Console.WriteLine("Max Profit Tab : " + MaxProfitTab(arr, 1));
        Console.WriteLine("Max Profit with 2 Tranx : " + MaxProfitWith2Transaction(arr, 1, 0, 0));
    }

    public static int BuySellOnces(int[] arr)
    {
        int mini = arr[0]; int profit = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            int diff = arr[i] - mini;
            profit = Math.Max(profit, diff);
            mini = Math.Min(mini, arr[i]);
        }

        return profit;
    }

    public static int profit = 0;
    public static int MaxProfit(int[] arr, int canbBuy, int n, int fees)
    {
        if (n >= arr.Length)
            return 0;

        //int profit = 0;
        if (canbBuy == 1)
        {
            profit = Math.Max(-arr[n] + MaxProfit(arr, 0, n + 1, fees), MaxProfit(arr, 1, n + 1, fees));
        }
        else
        {
            profit = Math.Max(arr[n] -fees + MaxProfit(arr, 1, n + 2, fees), MaxProfit(arr, 0, n + 1, fees)); // n+2 for colldown
        }

        return profit;
    }

    public static int MaxProfitTab(int[] arr, int canbBuy)
    {
        int n = arr.Length;
        //int[,] dp = new int[n + 1, 2];
        //dp[n, 0] = dp[n, 1] = 0;
        int pre1 = 0; int pre2 = 0;
        int cur1 = 0; int cur2 = 0;

        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = 0; j <= 1; j++)
            {
                if (j == 1)
                    cur2 = Math.Max(-arr[i] + pre1, pre2);
                else
                    cur1 = Math.Max(arr[i] + pre2, pre1);

                pre1 = cur1; pre2 = cur2;
            }
        }
        return pre2;
    }

     public static int towTranProfit = 0;    
    public static int MaxProfitWith2Transaction(int[] arr, int canbBuy, int n, int transaction)
    {
        if (transaction == 2)
            return 0;

        if (n == arr.Length)
            return 0;

        //int profit = 0;
        if (canbBuy == 1)
        {
            towTranProfit = Math.Max(-arr[n] + MaxProfitWith2Transaction(arr, 0, n + 1, transaction),
                                        MaxProfitWith2Transaction(arr, 1, n + 1, transaction));
        }
        else
        {
            towTranProfit = Math.Max(arr[n] + MaxProfitWith2Transaction(arr, 1, n + 1, transaction + 1),
                                        MaxProfitWith2Transaction(arr, 0, n + 1, transaction));
        }

        return towTranProfit;
    }
}